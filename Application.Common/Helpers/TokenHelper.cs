namespace App.Common.Helpers
{
    using System;

    public class TokenHelper
    {
        public static AuthenticationToken CreateNewAuthenticationToken()
        {
            return new AuthenticationToken(Guid.NewGuid(), DateTimeHelper.GetAuthenticationTokenExpiredUtcDateTime());
        }
    }
}