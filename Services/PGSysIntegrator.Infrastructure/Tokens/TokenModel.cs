
using System;
using PGSysIntegrator.Application.Contracts.Infrastructure;

namespace PGSysIntegrator.Infrastructure.Tokens
{
    public class TokenModel 
    {
        public ITokenParams tokenParams { get; set; }
        public ITokenTimer tokenTimer { get; set; }
        public ITokenResponse tokenResponse{ get; set; }


        public TokenModel()
        {
            tokenParams = new TokenParams();
            tokenTimer = new TokenTimer();
            tokenResponse = new TokenResponse();
        }
   
        public TokenModel GetAndSetToken(string client_id, string client_secret, string  grant_type)
        {
          
            this.tokenParams.client_id = client_id;
            this.tokenParams.client_secret = client_secret;
            this.tokenParams.grant_type = grant_type;

            
            this.tokenTimer.Expired = true;
            this.tokenTimer.StartUse = DateTime.Now;
            this.tokenTimer.EndUse = DateTime.Now;
            return this;
        }


        public DateTime CheckAndSetToken()
        {
            if (this.tokenTimer.Expired)
            {
                //TODo: call to set token
                this.tokenTimer.Expired = false;
                this.tokenTimer.StartUse = DateTime.Now;
                this.tokenTimer.EndUse = DateTime.Now;
                // change return to actual return value tokenExpire
                
            }
            return this.tokenTimer.EndUse;
        }

    }
}
