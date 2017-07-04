namespace Advert
{
    public struct ResponsiblePerson
    {
        public string Name
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public int ID
        {
            get;
            set;
        }
    }

    public class AdInfo
    {
        public ResponsiblePerson Person;
        public int ID
        {
            get;
            set;
        }
        public string AdvertizeDescription
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }

        public AdInfo(string advertizeDescription, string responsibleName, string responsibleSurname, string phoneNumber, int price)
        {
            Person = new ResponsiblePerson();
            Person.Name = responsibleName;
            Person.Surname = responsibleSurname;
            AdvertizeDescription = advertizeDescription;
            PhoneNumber = phoneNumber;
            Price = price;
        }
        public AdInfo()
        {

        }
        public override string ToString()
        {
            return string.Format("AdvertizeDescription: {0}, Responsible: Name - {1} Surname - {2}, Phone: {3}, Price: {4}", AdvertizeDescription, Person.Name, Person.Surname, PhoneNumber, Price);
        }
    }
}
