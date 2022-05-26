using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatudeCode(StatusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

         private string GetDefaultMessageForStatudeCode(int statusCode)
        { 
            return statusCode switch{
                400 => "A Bad Request You have made",
                401 => "Authorized, you are not",
                404 => "Recource found , it was not",
                500 => "Errors are the path to the darkside. Error leads to anger, anger leads to hate",
                _ => null 
            };
        }
    }
}