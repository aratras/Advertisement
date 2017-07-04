using System;
using System.Collections.Generic;
using System.Linq;

namespace Advert
{
    public enum SortingType
    {
        AdvertizeDescription,
        PersonName,
        PersonSurname,
        PhoneNumber,
        Price
    }
    public class OperatingAlgorithms
    {
        public List<AdInfo> CurrentOperating;
        public List<List<AdInfo>> AllLists;

        public OperatingAlgorithms()
        {
            CurrentOperating = new List<AdInfo>();
            AllLists = new List<List<AdInfo>>();
        }

        public void ChooseList(int index)
        {
            CurrentOperating = AllLists.ElementAt(index);
        }
        public void CreateEmptyList()
        {
            AllLists.Add(new List<AdInfo>());
        }
        public void AddEntryToList(AdInfo ad)
        {
            CurrentOperating.Add(ad);
        }
        public void DeleteEntryFromList(int index)
        {
            CurrentOperating.RemoveAt(index);
        }
        public List<AdInfo> SortAllEntriesInList(SortingType type)
        {
            List<AdInfo> sorted = new List<AdInfo>();
            switch (type)
            {
                case SortingType.AdvertizeDescription:
                    sorted = CurrentOperating.OrderBy(sort => sort.AdvertizeDescription).ToList();
                    break;
                case SortingType.PersonName:
                    sorted = CurrentOperating.OrderBy(sort => sort.Person.Name).ToList();
                    break;
                case SortingType.PersonSurname:
                    sorted = CurrentOperating.OrderBy(sort => sort.Person.Surname).ToList();
                    break;
                case SortingType.PhoneNumber:
                    sorted = CurrentOperating.OrderBy(sort => sort.PhoneNumber).ToList();
                    break;
                case SortingType.Price:
                    sorted = CurrentOperating.OrderBy(sort => sort.Price).ToList();
                    break;
                default:
                    break;
            }
            return sorted;
        }
        public List<AdInfo> FindEntryInCurrentList(string findKey)
        {
            int priceKey;
            List<AdInfo> result = new List<AdInfo>();
            try
            {
                priceKey = int.Parse(findKey);
            }
            catch (Exception)
            {
                priceKey = int.MinValue;
            }
            foreach (AdInfo item in CurrentOperating)
            {
                if (item.AdvertizeDescription.Contains(findKey) || item.Person.Name.Contains(findKey)
                        || item.Person.Surname.Contains(findKey) || item.PhoneNumber.Contains(findKey)
                        || item.Price.Equals(priceKey))
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0)
            {
                throw new Exception("No Matches found");
            }
            return result;
        }
    }
}
