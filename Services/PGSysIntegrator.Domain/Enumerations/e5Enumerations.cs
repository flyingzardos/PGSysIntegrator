using System.ComponentModel;

namespace PGSysIntegrator.Domain.Enumerations
{
    public class e5Enumerations
    {
        // private  DescriptionAttribute code = EnumExtensions.GetEnumDescriptionAttribute(actionCode.Create);

        public enum actionCode
        {
            [field:Description("")]
            NoAction = 1,
            [field:Description("F")]
            Fetch = 2,
            [field:Description("C")]
            Create = 3,
            [field:Description("U")]
            Update = 4,
            [field:Description("D")]
            Delete = 5
        } 

        public enum severityCode
        {

            [field:Description("S")]
            Success = 1,
            [field:Description("I")]
            Info = 2,
            [field:Description("W")]
            Warning = 3,
            [field:Description("C")]
            Critical = 4,
           
        } 

    }
}
