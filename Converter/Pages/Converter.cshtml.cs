using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CURRENCY.Models;
using CURRENCY.Services;
using System.Globalization;

namespace CURRENCY.Pages;

public class Converter : PageModel
{
    private readonly ConverterService _converterService;

    public List<ValuteModel> Valutes { get; set; }
    public ValCursModel? Response { get; set; }
    public string? Result { get; set; }

    [Required(ErrorMessage = "Please select a 'From' currency.")]
    public string? FromCode { get; set; }

    [Required(ErrorMessage = "Please select a 'To' currency.")]
    public string? ToCode { get; set; }

    [Required(ErrorMessage = "Please enter an amount.")]
    public decimal Value { get; set; }


    public Converter()
    {
        _converterService = new ConverterService();
    }

    public async Task<IActionResult> OnGet()
    {
        await LoadData();
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        await LoadData();

        if (decimal.TryParse(Request.Form["Value"], out decimal value))
        {
            FromCode = Request.Form["FromCode"];
            ToCode = Request.Form["ToCode"];

            if (Response != null)
            {
                try
                {
                    Result = _converterService.ConvertCurrency(value, FromCode, ToCode, Response).ToString();
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
        }
        else
        {
            ModelState.AddModelError("Value", "Please enter a valid amount.");
        }
        return Page();
    }

    private async Task LoadData()
    {
        var currencyService = new CurrencyService();
        Response = await currencyService.GetConverterInfoAsync();
    }
}








