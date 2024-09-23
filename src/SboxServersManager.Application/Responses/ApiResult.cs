﻿namespace SboxServersManager.Application.Responses
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
