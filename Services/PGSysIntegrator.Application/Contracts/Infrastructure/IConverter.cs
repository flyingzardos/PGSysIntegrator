using System.Threading.Tasks;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IConverter<TSource, TDestination>
    {
        Task<TDestination> Convert(TSource source);
    }
}
