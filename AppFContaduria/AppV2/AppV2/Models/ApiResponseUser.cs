using System;
using System.Collections.Generic;
using System.Text;

namespace AppV2.Models
{
    public class ApiResponseUser
    {
        internal string errorMessage;

        public string Token { get; set; }
        public string Role { get; set; }
        public string code_User { get; set; }
    }
}
