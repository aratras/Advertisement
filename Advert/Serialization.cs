using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Advert
{
    public class Serialization
    {
        public List<AdInfo> ReadFROMJson(string filePath)
        {
            List<AdInfo> advInfoList = new List<AdInfo>();
            AdInfo temp = new AdInfo();
            string jsonString;
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                while ((jsonString = fileStream.ReadLine()) != null)
                {
                    temp = (AdInfo)JsonConvert.DeserializeObject(jsonString, typeof(AdInfo));
                    advInfoList.Add(temp);
                }
            }
            return advInfoList;
        }
        public List<AdInfo> ReadFROMXml(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AdInfo>));
            List<AdInfo> advInfoList = new List<AdInfo>();
            using (TextReader filestream = new StreamReader(filePath))
            {
                advInfoList = (List<AdInfo>)xmlSerializer.Deserialize(filestream);
            }
            return advInfoList;
        }
        public void WriteTOJson(List<AdInfo> toWrite, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter filestream = new StreamWriter(filePath, append: false))
            {
                foreach (AdInfo item in toWrite)
                {
                    jsonSerializer.Serialize(filestream, item);
                    filestream.WriteLine();
                }
            }
        }
        public void WriteTOXml(List<AdInfo> toWrite, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<AdInfo>));
            using (TextWriter filestream = new StreamWriter(filePath))
                xmlSerializer.Serialize(filestream, toWrite);
        }
    }
}
