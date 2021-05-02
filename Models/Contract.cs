using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFE_Khalifa_Sami_2021.Models
{
    public class Contract
    {
        [Key]
        public int IdContract { get; set; }
        public int IdProperty { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("IdProperty")]
        public Property Property { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }

        public float GuaranteeAmount { get; set; }


    #nullable enable

        public DateTime? BeginContract { get; set; }
        public DateTime? EndContract { get; set; }
        public DateTime? SignatureDate { get; set; }
    }
}