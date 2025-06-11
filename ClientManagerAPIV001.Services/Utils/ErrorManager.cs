using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services.Utils
{
    public static class ErrorManager
    {
        public static CustomErrorRes GetObj(string? code, string? message )
        {
            code ??= "GE00001";
            message ??= "General Error Occured";
            return new CustomErrorRes()
            {
                IsError = true,
                ErrorCode = code,
                Message = message
            };
        }
        public static AppRes<T> Error<T>(string? code, string? msg)
        {
            return new AppRes<T>()
            {
                Error = GetObj(code, msg)
            };
        }

        public static AppRes<T> Error<T>( string? msg)
        {
            return new AppRes<T>()
            {
                Error = GetObj(null, msg)
            };
        }
    }
}
