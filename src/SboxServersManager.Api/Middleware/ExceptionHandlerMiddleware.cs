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

            (string details, int code) result;

            switch (ex)
            {
                case BadRequestException badReqEx:
                    result = HandleBadRequestException((BadRequestException)ex);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NotFoundException notFoundException:
                    result = HandleNotFoundException((NotFoundException)ex);
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ValidationException validationException: 
                    result = HandleValidationException((ValidationException)ex);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    result = ("Произошла неизвестная ошибка", 500);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = result.code,
                Message = result.details,
            }.ToString());
        }
        private (string, int) HandleBadRequestException(BadRequestException ex)
        {
            return (ex.Message, 400);
        }
        private (string, int) HandleNotFoundException(NotFoundException ex)
        {
            return (ex.Message, 404);
        }
        private (string, int) HandleValidationException(ValidationException ex)
        {
            return (ex.Message, 400);
        }
    }
}
