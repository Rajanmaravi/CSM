﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class TokenResponse
    {

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? UserRole { get; set; }

    }
}
