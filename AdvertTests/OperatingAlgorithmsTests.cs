using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace Advert.Tests
{
    public class ListComparer : Comparer<AdInfo>
    {
        public override int Compare(AdInfo x, AdInfo y)
        {
            if (x.Person.Equals(y.Person) && x.AdvertizeDescription.Equals(y.AdvertizeDescription)
                    && x.PhoneNumber.Equals(y.PhoneNumber) && x.Price.Equals(y.Price))
            {
                return 0;
            }
            throw new Exception("CompareFailed");
        }
    }
    [TestClass()]
    public class OperatingAlgorithmsTests
    {
        [TestMethod()]
        public void FindSingleEntryTest()
        {
            //Initialize
            OperatingAlgorithms test = new OperatingAlgorithms();
            List<AdInfo> testExpected = new List<AdInfo>
            {
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 120),
            };
            test.CurrentOperating = new List<AdInfo>
            {
                new AdInfo("Cleaning","Dasha", "1", "+380991234567", 100),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 120),
                new AdInfo("Cleaning","Denis", "3", "+380991234567", 130)
            };

            // Act
            List<AdInfo> testActual = test.FindEntryInCurrentList("Viktor");

            //Assert
            CollectionAssert.AreEqual(testExpected, testActual, new ListComparer());
        }
        [TestMethod()]
        public void FindMultipleEntryTest()
        {
            // Initialize
            OperatingAlgorithms test = new OperatingAlgorithms();
            List<AdInfo> testExpected = new List<AdInfo>
            {
                new AdInfo("Cleaning","Dasha", "1", "+380991234567", 100),
                new AdInfo("Cleaning","Denis", "3", "+380991234567", 130)
            };
            test.CurrentOperating = new List<AdInfo>
            {
                new AdInfo("Cleaning","Dasha", "1", "+380991234567", 100),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 120),
                new AdInfo("Cleaning","Denis", "3", "+380991234567", 130)
            };

            // Act
            List<AdInfo> testActual = test.FindEntryInCurrentList("Cleaning");

            // Assert
            CollectionAssert.AreEqual(testExpected, testActual, new ListComparer());
        }
        [TestMethod()]
        public void SortByIntTest()
        {
            //Initialize
            OperatingAlgorithms test = new OperatingAlgorithms();
            List<AdInfo> testExpected = new List<AdInfo>
            {
                new AdInfo("Cleaning","Denis", "3", "+380991234567", 100),
                new AdInfo("Cleaning","Dasha", "1", "+380991234567", 120),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 130)
            };
            test.CurrentOperating = new List<AdInfo>
            {
                new AdInfo("Cleaning","Dasha", "1", "+380991234567", 120),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 130),
                new AdInfo("Cleaning","Denis", "3", "+380991234567", 100)
            };

            // Act    
            List<AdInfo> testActual = test.SortAllEntriesInList(SortingType.Price);

            // Assert
            CollectionAssert.AreEqual(testExpected, testActual, new ListComparer());
        }
        [TestMethod()]
        public void SortByStringTest()
        {
            // Initialize
            OperatingAlgorithms test = new OperatingAlgorithms();
            List<AdInfo> testExpected = new List<AdInfo>
            {
                new AdInfo("Cleaning","Dasha", "3", "+380991234567", 100),
                new AdInfo("Cleaning","Denis", "1", "+380991234567", 120),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 130)
            };
            test.CurrentOperating = new List<AdInfo>
            {
                new AdInfo("Cleaning","Denis", "1", "+380991234567", 120),
                new AdInfo("Delivering","Viktor", "2", "+380991234567", 130),
                new AdInfo("Cleaning","Dasha", "3", "+380991234567", 100)
            };

            // Act
            List<AdInfo> testActual = test.SortAllEntriesInList(SortingType.PersonName);

            // Assert
            CollectionAssert.AreEqual(testExpected, testActual, new ListComparer());
        }
    }
}