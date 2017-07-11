using System;
using System.ComponentModel.DataAnnotations;

namespace AdvertMVC
{
    public class ResponsiblePerson
    {
        public int ID
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Name too long")]
        public string Name
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Surname too long")]
        public string Surname
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [EmailAddress(ErrorMessage = "E-mail is not valid" )]
        [UniqueEmail(ErrorMessage ="E-mail already exists")]
        public string Email
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^[+]?\d{1,3}?\d{9}$", ErrorMessage ="Phone is not valid")]
        [UniquePhone(ErrorMessage = "Phone already exists")]
        public string Phone
        {
            get; set;
        }
    }
    public class UniqueEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DataBase db = new DataBase();
            return db.CheckEmailDuplicates(value as string);
        }
    }
    public class UniquePhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DataBase db = new DataBase();
            return db.CheckPhoneDuplicates(value as string);
        }
    }

}

