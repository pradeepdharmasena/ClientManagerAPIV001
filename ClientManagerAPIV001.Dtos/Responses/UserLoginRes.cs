﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class UserLoginRes
    {
        public  string AccessToken { get; set; } = string.Empty;
        public  string RefreshToken { get; set; } = string.Empty;
    }
}
