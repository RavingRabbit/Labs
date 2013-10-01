using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PluginInfoLib
{
    public interface IStudent
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        int ID { get; set; }

        [DataMember(Name = "firstName")]
        [XmlElement("firstName")]
        string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        [XmlElement("lastName")]
        string LastName { get; set; }
    }
}
