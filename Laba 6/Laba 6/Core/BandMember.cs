using System.Xml.Serialization;

namespace BandApp.Models
{
    [XmlInclude(typeof(Member))]
    [XmlInclude(typeof(Leader))]
    public abstract class BandMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }

    public class Member : BandMember
    {
        public string Instrument { get; set; }
    }

    public class Leader : BandMember
    {
        public int YearsOfExperience { get; set; }
    }
}