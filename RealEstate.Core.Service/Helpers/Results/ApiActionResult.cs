using RealEstate.Core.Services.Helpers.Results;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Core.Services.Helpers.Results
{
    /// <summary>
    /// ReflectionHelpers Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiActionResult<T> where T : class
    {
        /// <summary>
        /// Result property
        /// </summary>
        protected ApiResult<T> Result { get; set; }
        /// <summary>
        /// ApiActionResult
        /// </summary>
        /// <param name="result"></param>
        public ApiActionResult(ApiResult<T> result)
        {
            Result = result;
        }
        /// <summary>
        /// ApiActionResult
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiActionResult<T> WithResult(ApiResult<T> result)
        {
            return new ApiActionResult<T>(result);
        }
        /// <summary>
        /// ActionResult
        /// </summary>
        /// <returns></returns>
        public ActionResult Return()
        {
            return Result?.Result;
        }
    }
    /// <summary>
    /// ApiActionResult class
    /// </summary>
    public class ApiActionResult
    {
        /// <summary>
        /// Result property
        /// </summary>
        protected ApiResult Result { get; set; }
        /// <summary>
        /// ApiActionResult method
        /// </summary>
        /// <param name="result"></param>
        public ApiActionResult(ApiResult result)
        {
            Result = result;
        }
        /// <summary>
        /// ApiActionResult method
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ApiActionResult WithResult(ApiResult result)
        {
            return new ApiActionResult(result);
        }
        /// <summary>
        /// ActionResult method
        /// </summary>
        /// <returns></returns>
        public ActionResult Return()
        {
            return Result?.Result;
        }
    }
}