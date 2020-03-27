using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using WebApi_Demo_01.Models;
using WebApi_Demo_01.Services;

namespace WebApi_Demo_01.Helper
{
    public class BasicAuthenticator : Attribute, IAuthenticationFilter
    {
        private IUserRepository _userService = new UserService();

        private readonly string realm;
        public bool AllowMultiple { get { return false; } }

        public BasicAuthenticator(string realm)
        {
            this.realm = "realm=" + realm;
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            return this.AuthenticateAsyncV2(context, cancellationToken);

            /*HttpRequestMessage req = context.Request;
            if (req.Headers.Authorization != null && req.Headers.Authorization.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string credentials = encoding.GetString( Convert.FromBase64String(req.Headers.Authorization.Parameter));
                string[] parts = credentials.Split(':');
                string userId = parts[0].Trim();
                string password = parts[1].Trim();
 
                if (userId !="" && !_userService.Check(userId,password)) // Just a dumb check
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userId)
                    };
                    var id = new ClaimsIdentity(claims, "Basic");
                    var principal = new ClaimsPrincipal(new[] { id });
                    context.Principal = principal;
                }
            } 
            else
            {
                context.ErrorResult = new UnauthorizedResult(
                     new AuthenticationHeaderValue[0],
                                          context.Request);
            }
            return Task.FromResult(0);*/
        }

        public Task AuthenticateAsyncV2(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            HttpRequestMessage req = context.Request;
            try
            {
                if (req.Headers.Authorization == null || !req.Headers.Authorization.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)) throw new UnauthorizedAccessException();

                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string credentials = encoding.GetString(Convert.FromBase64String(req.Headers.Authorization.Parameter));
                string[] parts = credentials.Split(':');
                string userId = parts[0].Trim();
                string password = parts[1].Trim();

                if (userId == "" || !_userService.Check(userId, password)) throw new UnauthorizedAccessException();

                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userId)
                    };
                var id = new ClaimsIdentity(claims, "Basic");
                var principal = new ClaimsPrincipal(new[] { id });
                context.Principal = principal;
            }
            catch (UnauthorizedAccessException)
            {
                context.ErrorResult = new UnauthorizedResult(
                     new AuthenticationHeaderValue[0],
                                          context.Request);
            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            //Méthode appellée lors de la tentative d'accès
            context.Result = new ResultWithChallenge(context.Result, realm);
            return Task.FromResult(0);
        }


    }
}