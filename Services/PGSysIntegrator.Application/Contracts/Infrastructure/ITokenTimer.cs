using System;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface ITokenTimer 
    {
        DateTime StartUse{ get; set; }
        DateTime EndUse{ get; set; }
        bool Expired { get; set; }
    }
}
