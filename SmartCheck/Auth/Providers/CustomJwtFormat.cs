using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace SmartChef.Auth.Providers
{
    /// <summary>
    /// CustomJwtFormat class
    /// Generates the Token by validating
    /// the username and password
    /// </summary>
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        /// <summary>
        /// The _issuer field
        /// </summary>
        private readonly string _issuer;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="issuer"></param>
        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }
        /// <summary>
        /// Issues the token by validating
        /// the user and password and validating
        /// the role assigned to the user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];

            var symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;

            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime,
                expires.Value.UtcDateTime, signingKey);

            // var stringName = token.Payload.Where(i => i.Key == "nameid").Select(i => i.Value).FirstOrDefault();


            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            // Write the Jwt Token 
            return jwt;
        }
        /// <summary>
        /// Unprotects the token
        /// </summary>
        /// <param name="protectedText"></param>
        /// <returns></returns>
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}