using CURRENCY.Models;
using System.Globalization;
using System.Xml.Serialization;

namespace CURRENCY.Services
{
    public class ConverterService
    {
        public decimal ConvertCurrency(decimal value, string fromCode, string toCode, ValCursModel valCursModel)
        {
            var fromValute = valCursModel.ValTypes
                .SelectMany(valType => valType.Valutes)
                .FirstOrDefault(val => val.Code == fromCode);

            var toValute = valCursModel.ValTypes
                .SelectMany(valType => valType.Valutes)
                .FirstOrDefault(val => val.Code == toCode);

            if (fromValute != null && toValute != null)
            {
                decimal fromRate = decimal.Parse(fromValute.Value, CultureInfo.InvariantCulture);
                decimal toRate = decimal.Parse(toValute.Value, CultureInfo.InvariantCulture);

                decimal result = Math.Round((value * fromRate) / toRate, 2, MidpointRounding.AwayFromZero);
                return result;
            }

            throw new ArgumentException("Invalid currency code.");
        }
    }
}