using CURRENCY.Models;
using System.Xml.Serialization;

namespace CURRENCY.Models

{
    [XmlRoot(ElementName = "ValCurs")]
    public class ValCursModel
    {
        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "ValType")]
        public List<ValTypeModel> ValTypes { get; set; }
    }
}