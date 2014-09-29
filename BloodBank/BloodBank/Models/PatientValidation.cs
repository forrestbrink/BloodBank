using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBank
{
    [MetadataType(typeof(DonorValidation))]

    public partial class Donor
    {
    }

    public class DonorValidation
    {
        [Required]
        public string DonorName { get; set; }

        [Required]
        public string DonorBloodGroup { get; set; }

        [Required]
        public string DonorMedicalreport { get; set; }

        [Required]
        public string DonorAddress { get; set; }

        [Required]
        [Phone]
        public string DonorContactNumber { get; set; }
    }
}