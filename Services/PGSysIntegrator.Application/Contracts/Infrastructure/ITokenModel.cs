using System;


namespace  PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface ITokenModel 
    {
        ITokenParams TokenParams { get; set; }
        ITokenTimer TokenTimer { get; set; }
     
    }
}
