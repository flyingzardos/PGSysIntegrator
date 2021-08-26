using PGSysIntegrator.Application.Contracts.Infrastructure;
using System;


namespace PGSysIntegrator.Infrastructure.Tokens
{
    public class TokenTimer : ITokenTimer
    {
        public DateTime StartUse{ get; set; }
        public DateTime EndUse{ get; set; }
        public bool Expired { get; set; }
    }
}
