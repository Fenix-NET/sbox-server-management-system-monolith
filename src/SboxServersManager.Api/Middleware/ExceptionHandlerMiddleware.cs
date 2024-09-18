using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Exceptions;
using SboxServersManager.Domain.ErrorModel;
using System.Net;
using System.Text.Json;

namespace SboxServersManager.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, $"Произошла ошибка! Подробности: {ex.Message}");

            var errorDetails = new ErrorDetails();
            (string details, int code) result;

            switch (ex)
            {
                case BadRequestException badReqEx:
                    result = HandleBadRequestException(badReqEx, errorDetails);
                    break;
                case NotFoundException notFoundException:
                    result = HandleNotFoundException(notFoundException, errorDetails);
                    break;
                case ValidationException validationException: 
                    result = HandleValidationException(validationException, errorDetails);
                    break;
                default:
                    result = (JsonSerializer.Serialize(errorDetails), 500); 
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.code;

            await context.Response.WriteAsync(result.details);
        }
        private (string, int) HandleBadRequestException(BadRequestException ex, ErrorDetails errorDetails)
        {
            return (JsonSerializer.Serialize(errorDetails), errorDetails.StatusCode);
        }
        private (string, int) HandleNotFoundException(NotFoundException ex, ErrorDetails errorDetails)
        {
            return (JsonSerializer.Serialize(errorDetails), errorDetails.StatusCode);
        }
        private (string, int) HandleValidationException(ValidationException ex, ErrorDetails errorDetails)
        {
            return (JsonSerializer.Serialize(errorDetails), errorDetails.StatusCode);
        }
    }
}
