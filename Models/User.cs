using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFE_Khalifa_Sami_2021.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    #nullable enable
        public string? Surname { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? NationalRegister { get; set; }    
        public DateTime? DateOfBirth { get; set; }
        public List<Property>? PropertiesList { get; set; }
    }
}