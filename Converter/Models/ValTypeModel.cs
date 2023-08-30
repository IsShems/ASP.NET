using System.Xml.Serialization;

namespace CURRENCY.Models
{
    public class ValTypeModel
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Valute")]
        public List<ValuteModel> Valutes { get; set; }
    }

}