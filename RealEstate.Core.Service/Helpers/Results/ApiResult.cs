using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RealEstate.Core.Services.Helpers.Results
{
    /// <summary>
    /// ApiResult Class
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Result property
        /// </summary>
        public ActionResult Result { get; set; }
        /// <summary>
        /// StatusCode property
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// ApiResult Method
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        protected ApiResult(int? statusCode, string message)
        {
            StatusCode = statusCode;
            if(statusCode == 204)
            {
                Result = new NoContentResult();
            }
            else
            {
                Result = new JsonResult(message)
                {
                    StatusCode = statusCode
                };
            }
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        protected ApiResult(HttpStatusCode statusCode, string message) : this((int?)statusCode, message)
        {
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult WithSuccess(string message = "")
        {
            return new ApiResult(HttpStatusCode.OK, message);
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <returns></returns>
        public static ApiResult WithNoContent()
        {
            return new ApiResult(HttpStatusCode.NoContent, null);
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult WithCode(HttpStatusCode code, string message = "")
        {
            return new ApiResult(code, message);
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult WithBadRequest(string message = "")
        {
            return new ApiResult(HttpStatusCode.BadRequest, message);
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult WithNotFound(string message = "")
        {
            return new ApiResult(HttpStatusCode.NotFound, message);
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult WithException(string message = "")
        {
            return new ApiResult(450, message);
        }
    }
    /// <summary>
    /// ApiResult class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> where T : class
    {
        /// <summary>
        /// Result property
        /// </summary>
        public JsonResult Result { get; set; }
        /// <summary>
        /// StatusCode property
        /// </summary>
        public int? StatusCode { get; set; }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        protected ApiResult(int? statusCode, string message = "")
        {
            StatusCode = statusCode;
            Result = new JsonResult(message)
            {
                StatusCode = statusCode
            };
        }
        /// <summary>
        /// ApiResult constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="result"></param>
        protected ApiResult(int? statusCode, T result)
        {
            Result = new JsonResult(result)
            {
                StatusCode = statusCode
            };
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected ApiResult(HttpStatusCode statusCode, string message = "") : this((int?)statusCode, message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected ApiResult(HttpStatusCode statusCode, T result) : this((int?)statusCode, result)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithSuccess(T result)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(HttpStatusCode.OK, result);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithCode(HttpStatusCode code, string message = "")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(code, message);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithCode(HttpStatusCode code, T result)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(code, result);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithBadRequest(string message = "")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(HttpStatusCode.BadRequest, message);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithBadRequest(T result)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(HttpStatusCode.BadRequest, result);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithNotFound(string message = "")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(HttpStatusCode.NotFound, message);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static ApiResult<T> WithException(string message = "")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return new ApiResult<T>(450, message);
        }
    }
}