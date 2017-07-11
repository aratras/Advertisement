using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AdvertMVC.Scripts
{
    public class Validator
    {
        public const string EmailTemplate = @" ^ ([a - zA - Z0 - 9_\-\.] +)@((\[[0-9]{1,3}" 
            + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" 
            + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string PhoneTemplate1 = @"^[+]\d{2,3}\d{9}";
        public bool ValidateName(ResponsiblePerson toValidate)
        {
            if (toValidate.Name.Length > 20)
                return false;
            return true;
        }
        public bool ValidateSurname(ResponsiblePerson toValidate)
        {
            if (toValidate.Surname.Length > 20)
                return false;
            return true;
        }
        public bool ValidateEmail(ResponsiblePerson toValidate)
        {
            if (Regex.IsMatch(toValidate.Email, EmailTemplate))
                return true;
            return false;
        }
        public bool ValidatePhone(ResponsiblePerson toValidate)
        {
            if (Regex.IsMatch(toValidate.Phone, PhoneTemplate1))
                return true;
            return false;
        }
    }
}