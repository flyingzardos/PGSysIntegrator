using PGSysIntegrator.Domain.Common;

namespace PGSysIntegrator.Domain.Entities
{
    public class e5PlantItemDeleteModel : e5EntityBase // derives from abstract class which provides additional properties
    {
        public string[] objectReferences { get; set; }

    }
}
