using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PGSysIntegrator.Application.Contracts.Infrastructure;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PGSysIntegrator.Infrastructure.Helpers
{
    public class ConverterFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ConverterFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task<object> Convert(Type inType, Type outType, object inObject)
        {
            var converterType = typeof(IConverter<,>).MakeGenericType(inType, outType);

            var converter = _serviceProvider.GetService(converterType);

            var task = (Task)converterType.InvokeMember("Convert", BindingFlags.InvokeMethod, null, converter, new object[] { inObject });
            await task;
            var resultProperty = task.GetType().GetProperty("Result");
            var result = resultProperty.GetValue(task);

            return result;
        }

        
    }
   
}
