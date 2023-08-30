using CURRENCY.Models;
using System.Xml.Serialization;


namespace CURRENCY.Services;

public class CurrencyService
{
    public async Task<ValCursModel> GetConverterInfoAsync()
    {
        DateTime dateTime = DateTime.Now;
        string date = dateTime.ToString("dd.MM.yyyy");

        HttpClient client = new HttpClient();
        HttpResponseMessage message = await client.GetAsync($"https://www.cbar.az/currencies/{date}.xml");
        if (message.IsSuccessStatusCode)
        {
            string result = await message.Content.ReadAsStringAsync();
            if (result != null)
            {
                XmlSerializer xml_serializer = new XmlSerializer(typeof(ValCursModel));
                using (TextReader reader = new StringReader(result))
                {
                    ValCursModel info = (ValCursModel)xml_serializer.Deserialize(reader);
                    return info;
                }
            }
            throw new NullReferenceException();
        }
        throw new HttpRequestException();
    }
}