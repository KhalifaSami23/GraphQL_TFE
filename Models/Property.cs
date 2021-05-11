using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFE_Khalifa_Sami_2021.Models
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        
        public string Description { get; set; }
        public string Address { get; set; }

    #nullable enable
        public float? RentCost { get; set; }
        public float? FixedChargesCost { get; set; }
    }
}