using System;

namespace TFE_Khalifa_Sami_2021.REST.DTO
{
    public class ContractDto
    {
        public int IdContract { get; set; }
        public int IdProperty { get; set; }
        public int IdUser { get; set; }

        public PropertyDto? Property { get; set; }
        public UserDto? User { get; set; }
        
        public float GuaranteeAmount { get; set; }
        public DateTime? BeginContract { get; set; }
        public DateTime? EndContract { get; set; }
    }
}