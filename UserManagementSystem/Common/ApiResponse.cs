using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementSystem.Common
{
    public class ApiResponse<T> where T: class
    {
        public T Result { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public static ApiResponse<T> Ok(T result) => new ApiResponse<T>
        {
            Result = result,
            StatusCode = HttpStatusCode.OK
        };

        public static ApiResponse<T> Ok() => new ApiResponse<T>
        {
            Result = null,
            StatusCode = HttpStatusCode.OK
        };

        public static ApiResponse<T> BadRequest() => new ApiResponse<T>
        {
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };

        public static ApiResponse<T> NotFound() => new ApiResponse<T>
        {
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };

        public static ApiResponse<T> InternalServerError() => new ApiResponse<T>
        {
            Result = null,
            StatusCode = HttpStatusCode.InternalServerError
        };
    }
}
