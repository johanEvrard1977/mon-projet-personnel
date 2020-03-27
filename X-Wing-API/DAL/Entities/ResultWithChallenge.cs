using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_Demo_01.Models
{
    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly IHttpActionResult next;
        private readonly string realm;

        public ResultWithChallenge(IHttpActionResult next, string realm)
        {
            this.next = next;
            this.realm = realm;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(
                                    CancellationToken cancellationToken)
        {

            //Permet de renvoyer un header 401 avec les infos concernant l'authentification et le domaine
            var res = await next.ExecuteAsync(cancellationToken);
            if (res.StatusCode == HttpStatusCode.Unauthorized)
            {
                res.Headers.WwwAuthenticate.Add(
                   new AuthenticationHeaderValue("Basic", this.realm));
            }

            return res;
        }
    }
}