using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyerTsvetelinaAtanasova.Models
{
    public class ContactModelEn
    {
        [Required(ErrorMessage = "Name is required")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email should be valid")]
        public string EmailEn { get; set; }

        [Required(ErrorMessage = "Mobile phone is required")]
        public int MobileEn { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string MessageEn { get; set; }
    }
}