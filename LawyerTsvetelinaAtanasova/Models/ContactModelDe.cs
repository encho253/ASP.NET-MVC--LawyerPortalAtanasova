using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyerTsvetelinaAtanasova.Models
{
    public class ContactModelDe
    {
        [Required(ErrorMessage = "Name Erforderlich")]
        public string NameDe { get; set; }

        [Required(ErrorMessage = "E-Mail ist obligatorisch")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-Mail muss gültig sein")]
        public string EmailDe { get; set; }

        [Required(ErrorMessage = "Das Mobiltelefon ist obligatorisch")]
        public int MobileDe { get; set; }


        [Required(ErrorMessage = "Kommunikation erforderlich ist")]
        public string MessageDe { get; set; }
    }
}