using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Advert
{
    class DataBase
    {
        MySqlConnection Connection;
        string ConnectionString = "server = localhost; user id = root; persistsecurityinfo=True;database=advert;password";
        DataBase()
        {
            Connection = new MySqlConnection(ConnectionString);
        }
        #region Loading from DB
        public List<AdInfo> LoadAllFromDB()
        {
            List<AdInfo> returnList = new List<AdInfo>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand
                {
                    CommandText = @"SELECT Person.ID, Person.Name, Person.Surname, ad.AdID, ad.Description, ad.PhoneNumber, ad.Price 
                        FROM [person] INNER JOIN [ad] ON Person.ID = ad.ID"
                };
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int personID = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        int adID = reader.GetInt32(3);
                        string description = reader.GetString(4);
                        string phone = reader.GetString(5);
                        int price = reader.GetInt32(6);
                        returnList.Add(new AdInfo
                        {
                            ID = adID,
                            AdvertizeDescription = description,
                            PhoneNumber = phone,
                            Price = price,
                            Person = new ResponsiblePerson
                            {
                                Name = name,
                                Surname = surname,
                                ID = personID
                            }
                        });
                    }
                }
                reader.Close();
            }
            return returnList;
        }
        public List<ResponsiblePerson> LoadPersonFromDB()
        {
            List<ResponsiblePerson> returnList = new List<ResponsiblePerson>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = @"Select * FROM [person]"
                };
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        returnList.Add(new ResponsiblePerson
                        {
                            ID = id,
                            Name = name,
                            Surname = surname
                        });
                    }
                }
                reader.Close();
            }
            return returnList;
        }
        public List<AdInfo> LoadAdFromDB()
        {
            List<AdInfo> returnList = new List<AdInfo>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = @"SELECt * FROM [ad]"
                };
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int adID = reader.GetInt32(1);
                        string description = reader.GetString(2);
                        string phone = reader.GetString(3);
                        int price = reader.GetInt32(4);
                        returnList.Add(new AdInfo
                        {
                            ID = adID,
                            AdvertizeDescription = description,
                            PhoneNumber = phone,
                            Price = price
                        });
                    }
                }
                reader.Close();
            }
            return returnList;
        }
        #endregion

        #region Insert into DB
        public void InsertAllIntoDB(List<AdInfo> insertList)
        {
            using (Connection)
            {
                foreach (AdInfo item in insertList)
                {
                    MySqlCommand command = new MySqlCommand()
                    {
                        CommandText = string.Format("INSERT INTO person (Name, Surname) " +
                        "VALUES ({0}, {1})", item.Person.Name, item.Person.Surname)
                    };
                    command.CommandText += string.Format(" INSERT INTO ad (Description, PhoneNumber, Price, ID) " +
                        "VALUES ({0}, {1}, {2}, LAST_INSERT_ID())", item.AdvertizeDescription, item.PhoneNumber, item.Price);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertPersonIntoDB(List<ResponsiblePerson> insertList)
        {
            using (Connection)
            {
                foreach (ResponsiblePerson item in insertList)
                {
                    MySqlCommand command = new MySqlCommand()
                    {
                        CommandText = string.Format("INSERT INTO person (Name, Surname) " +
                        "VALUES ({0}, {1})", item.Name, item.Surname)
                    };
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertAdIntoDB(List<AdInfo> insertList, int personID)
        {
            using (Connection)
            {
                foreach (AdInfo item in insertList)
                {
                    MySqlCommand command = new MySqlCommand()
                    {
                        CommandText = string.Format(" INSERT INTO ad (Description, PhoneNumber, Price, ID) " +
                          "VALUES ({0}, {1}, {2}, {3})", item.AdvertizeDescription, item.PhoneNumber, item.Price, personID)
                    };
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update DB
        public void UpdateAllInDB(List<AdInfo> updateList)
        {
            using (Connection)
            {
                foreach (AdInfo item in updateList)
                {
                    MySqlCommand command = new MySqlCommand()
                    {
                        CommandText = string.Format("UPDATE person, ad SET person.Name = {1}, person.Surname = {2}, ad.Description = {3}" +
                        "ad.PhoneNumber = {4}, ad.Price = {5} WHERE person.ID = ad.ID AND person.ID = {0}", item.Person.ID,
                        item.Person.Name, item.Person.Surname, item.AdvertizeDescription, item.PhoneNumber, item.Price)
                    };
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdatePersonInDB(List<ResponsiblePerson> updateList)
        {
            using (Connection)
            {
                foreach (ResponsiblePerson item in updateList)
                {
                    MySqlCommand command = new MySqlCommand()
                    {
                        CommandText = string.Format("UPDATE person SET person.Name = {1}, person.Surname = {2} WHERE person.ID = {0}", item.ID,
                        item.Name, item.Surname)
                    };
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateAdInDB(AdInfo update)
        {
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("UPDATE ad SET Description = {1}, PhoneNumber = {2}, Price = {3} WHERE person.ID = {0}", update.ID, update.PhoneNumber, update.Price)
                };
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Delete From DB
        public void DeleteFromDB(int IDDel)
        {
            using (Connection)
            {

            }
        }
        #endregion
    }
}

