using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplaintsEntry.Models
{
    public class ComplaintsMetadata
    {
        [Display(Name = "Reference")]
        public string coReference { get; set; }

        [Display(Name = "Retailer")]
        public string coRetailer { get; set; }

        [Display(Name = "Date Entered")]
        public DateTime coDateEntered { get; set; }

        [Display(Name = "Element")]
        public string coElement { get; set; }

        [Display(Name = "SubElement")]
        public string coSubElement { get; set; }

        [Display(Name = "CSN Code")]
        public string coPremierCSNCode { get; set; }

        [Display(Name = "Site")]
        public string coManufacturingLocation { get; set; }

        [Display(Name = "Dough Code")]
        public string coDoughCode { get; set; }
    }
}