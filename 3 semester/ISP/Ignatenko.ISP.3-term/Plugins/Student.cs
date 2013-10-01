using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using PluginInfoLib;

namespace Lab5.Plugins
{
    [Serializable]
    [DataContract(Name = "student")]
    [XmlRoot("student")]
    public class Student : IStudent
    {
        public Student(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Student()
        {
        }

        [DataMember(Name = "id")]
        [XmlElement("id")]
        public int ID { get; set; }

        [DataMember(Name = "firstName")]
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        [XmlElement("lastName")]
        public string LastName { get; set; }
    }
}
