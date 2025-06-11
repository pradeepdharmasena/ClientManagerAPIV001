using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services.Utils
{
    public static class ResWrapper
    {
        public static AppRes<T> Res<T>(T result)
        {
            return new AppRes<T>()
            {
                Results = result,
            };
        }
    }
}
