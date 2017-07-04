using Advert;
using System;
using System.IO;

namespace AdvertConsole
{
    class Program
    {
        enum Menu
        {
            AddNewList, ShowAllLists, SelectList, WriteAllEntriesInList, AddNewEntryToList, DeleteEntryFromList,
            SortEntries, FindEntries, WrtiteToFile, Quit
        }
        public static void Main(string[] args)
        {

            OperatingAlgorithms OperatingAlgorithms = new OperatingAlgorithms();
            Serialization SaveLoadAlgorithms = new Serialization();
            ConsoleAlgorithms ConsoleOperating = new ConsoleAlgorithms();
            int index;
            string filePath;
            SortingType type;
            Menu menu;
            Console.WriteLine("Choose:\n 0 - Add new list;\n 1 - Show all lists;\n 2 - Select list; "
                + "3 - Write all entries in current list;\n 4 - Add new entry to current list;\n "
                + "5 - Delete entry in current list by index;\n 6 - Sort all entries in current list;\n 7 - NOT IMPLEMENTED;\n "
                + "8 - Write all entries from current list to file;\n 9- Quit");
            while (true)
            {
                Console.WriteLine("------------------");
                menu = (Menu)Enum.Parse(typeof(Menu), Console.ReadLine());
                switch (menu)
                {
                    case Menu.AddNewList:
                        Console.WriteLine("Choose file type: 0 - Json; 1 - XML; 2 - Create empty list");
                        try
                        {
                            index = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        try
                        {
                            switch (index)
                            {
                                case 0:
                                    Console.WriteLine("Specify file Path:");
                                    filePath = Console.ReadLine();
                                    OperatingAlgorithms.AllLists.Add(SaveLoadAlgorithms.ReadFROMJson(filePath));
                                    break;
                                case 1:
                                    Console.WriteLine("Specify file Path:");
                                    filePath = Console.ReadLine();
                                    OperatingAlgorithms.AllLists.Add(SaveLoadAlgorithms.ReadFROMXml(filePath));
                                    break;
                                case 2:
                                    OperatingAlgorithms.CreateEmptyList();
                                    break;
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File not found!");
                            break;
                        }
                        catch (AccessViolationException)
                        {
                            Console.WriteLine("Access restricted!");
                            break;
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine("Directory not found!");
                            break;
                        }
                        break;
                    case Menu.ShowAllLists:
                        ConsoleOperating.ShowAllLists(OperatingAlgorithms.AllLists);
                        break;
                    case Menu.SelectList:
                        Console.WriteLine("------------------");
                        Console.WriteLine("Specify index:");
                        try
                        {
                            index = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        OperatingAlgorithms.ChooseList(index);
                        Console.WriteLine("List Choosen: {0}", index);
                        break;
                    case Menu.WriteAllEntriesInList:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        ConsoleOperating.ShowEntriesInCurrentList(OperatingAlgorithms.CurrentOperating);
                        break;
                    case Menu.AddNewEntryToList:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        AdInfo toValidate = ConsoleOperating.ReadFromConsole();
                        try
                        {
                            Validator.Validate(toValidate);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        OperatingAlgorithms.AddEntryToList(toValidate);
                        break;
                    case Menu.DeleteEntryFromList:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        try
                        {
                            index = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        try
                        {
                            OperatingAlgorithms.DeleteEntryFromList(index);

                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Wrong element");
                        }
                        break;
                    case Menu.SortEntries:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        Console.WriteLine("Sort by: 0 - Name; 1 - Name of responsible person; 2 - Surname of responsible person; 3 - Phone; 4 - Price");
                        try
                        {
                            type = (SortingType)Enum.Parse(typeof(SortingType), Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        OperatingAlgorithms.SortAllEntriesInList(type);
                        break;
                    case Menu.FindEntries:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        Console.WriteLine("Write find key:");
                        string key = Console.ReadLine();
                        try
                        {
                            OperatingAlgorithms.FindEntryInCurrentList(key);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case Menu.WrtiteToFile:
                        if (OperatingAlgorithms.CurrentOperating == null)
                        {
                            Console.WriteLine("Choose list first!");
                            break;
                        }
                        Console.WriteLine("Choose file type: 0 - Json; 1 - XML");
                        try
                        {
                            index = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            continue;
                        }
                        Console.WriteLine("Specify file Path:");
                        filePath = Console.ReadLine();
                        switch (index)
                        {
                            case 0:
                                SaveLoadAlgorithms.WriteTOJson(OperatingAlgorithms.CurrentOperating, filePath);
                                break;
                            case 1:
                                SaveLoadAlgorithms.WriteTOXml(OperatingAlgorithms.CurrentOperating, filePath);
                                break;
                        }
                        break;
                    case Menu.Quit:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}