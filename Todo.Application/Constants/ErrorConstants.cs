using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Constants
{
    public class ErrorConstants
    {
        public const string InvalidEmail = "The provided email address doesn't exist in database";
        public const string InvalidRefreshToken = "The provided refresh token is invalid.";
        public const string RevokedRefreshToken = "The provided refresh token has been revoked.";
        public const string InvalidPassword = "Invalid Password";
        public const string ExpiredRefreshToken = "The provided refresh token has expired.";

    }
}
