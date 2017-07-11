using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace AdvertMVC
{
    public class DataBase
    {
        MySqlConnection Connection;
        string ConnectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["Advertisement"].ConnectionString;
        public DataBase()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }
        public List<ResponsiblePerson> GetAllPerson()
        {
            List<ResponsiblePerson> returnList = new List<ResponsiblePerson>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("SELECT * FROM person"),
                    Connection = Connection
                };
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        returnList.Add(new ResponsiblePerson
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.GetString(4)
                        });
                    }
                }
            }
            return returnList;
        }
        public ResponsiblePerson GetOnePerson(int id)
        {
            ResponsiblePerson returnPerson = new ResponsiblePerson();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("SELECT * FROM person WHERE person.PersonID={0}", id),
                    Connection = Connection
                };
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnPerson = new ResponsiblePerson
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.GetString(4)
                        };
                    }
                }
            }
            return returnPerson;
        }
        public void UpdatePerson(ResponsiblePerson person)
        {
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("UPDATE person SET person.Name='{1}', person.Surname='{2}'," +
                        " person.EMail='{3}', person.Phone='{4}' WHERE person.PersonID = {0}",
                        person.ID, person.Name, person.Surname, person.Email, person.Phone),
                    Connection = Connection
                };
                command.ExecuteNonQuery();
            }
        }
        public void DeletePerson(ResponsiblePerson person)
        {
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("DELETE FROM person WHERE person.PersonID={0}", person.ID),
                    Connection = Connection
                };
                command.ExecuteNonQuery();
            }
        }
        public void CreatePerson(ResponsiblePerson person)
        {
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("INSERT INTO person (Name, Surname, EMail, Phone) " +
                    "VALUES ('{0}','{1}','{2}','{3}')", 
                    person.Name, person.Surname, person.Email, person.Phone),
                    Connection = Connection
                };
                command.ExecuteNonQuery();
            }
        }
        public bool CheckEmailDuplicates(string check)
        {
            List<ResponsiblePerson> list = new List<ResponsiblePerson>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("SELECT * FROM person WHERE person.EMail='{0}'",check),
                    Connection = Connection
                };
                command.ExecuteNonQuery();
            }
            if (list.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckPhoneDuplicates(string check)
        {
            List<ResponsiblePerson> list = new List<ResponsiblePerson>();
            using (Connection)
            {
                MySqlCommand command = new MySqlCommand()
                {
                    CommandText = string.Format("SELECT * FROM person WHERE person.Phone='{0}'", check),
                    Connection = Connection
                };
                command.ExecuteNonQuery();
            }
            if (list.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}