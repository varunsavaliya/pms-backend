using System.Runtime.Serialization;

namespace PMS.Model.Common.Enums
{
    public class PlanEnums
    {
        /// <summary>
        /// Duration in months
        /// </summary>
        public enum Duration
        {
            [EnumMember(Value = "1 Month")]
            OneMonth = 1,

            [EnumMember(Value = "3 Months")]
            ThreeMonths = 3,

            [EnumMember(Value = "6 Months")]
            SixMonths = 6,

            [EnumMember(Value = "1 Year")]
            OneYear = 12,
        }
    }
}
