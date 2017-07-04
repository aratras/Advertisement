using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advert
{
    public class Validator
    {
        private const int DescriptionMaxLength = 100;
        private const int NameMaxLenght = 20;
        private const int SurnameMaxLenght = 20;
        private const string PhonePattern1 = @"^[+]380\d{9}";
        private const string PhonePattern2 = @"^[0]\d{9}";

        public static void Validate(AdInfo toValidate)
        {
            bool isValid = true;
            string exceptionString = string.Empty;
            if (!Regex.IsMatch(toValidate.PhoneNumber, PhonePattern1) && !Regex.IsMatch(toValidate.PhoneNumber, PhonePattern2))
            {
                exceptionString += "Wrong phone number! ";
                isValid = false;
            }
            if (toValidate.AdvertizeDescription.Count() > DescriptionMaxLength)
            {
                exceptionString += "Description too big! ";
                isValid = false;
            }
            if (toValidate.Person.Name.Count() > NameMaxLenght)
            {
                exceptionString += "Name too big! ";
                isValid = false;
            }
            if (toValidate.Person.Surname.Count() > SurnameMaxLenght)
            {
                exceptionString += "Surname too big! ";
                isValid = false;
            }
            if (!isValid)
            {
                throw new Exception(exceptionString + "Entry not Saved!");
            }
        }
    }
}
