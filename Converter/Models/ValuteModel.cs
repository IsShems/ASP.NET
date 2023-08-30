using System.Xml.Serialization;

namespace CURRENCY.Models;

public class ValuteModel
{
    [XmlAttribute(AttributeName = "Code")]
    public string Code { get; set; }

    [XmlElement(ElementName = "Nominal")]
    public string Nominal { get; set; }

    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "Value")]
    public string Value { get; set; }
}
