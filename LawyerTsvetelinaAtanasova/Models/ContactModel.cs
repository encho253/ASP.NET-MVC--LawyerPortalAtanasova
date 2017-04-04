using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyerTsvetelinaAtanasova.Models
{
    public class ContactModel
    {

        [Required(ErrorMessage = "Името е задължително")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Имейла е задължителен")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Имейла трябва да е валиден")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Мобилният телефон е задължителен")]
        public int Mobile { get; set; }


        [Required(ErrorMessage = "Съобщението е задължително")]
        public string Message { get; set; }

    }
}