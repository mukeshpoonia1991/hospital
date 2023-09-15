// ApiWeb.Webapi.Controllers/HomeController.cs

using Api.Domain;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWelcomeLetterRepository _welcomeLetterRepository;
        private readonly IEmailService _emailService;

        public HomeController(IWelcomeLetterRepository welcomeLetterRepository, IEmailService emailService)
        {
            _welcomeLetterRepository = welcomeLetterRepository;
            _emailService = emailService;
        }

        [HttpPost("SendWelcomeLetter")]
        public async Task<IActionResult> SendWelcomeLetter(WelcomeLetterModel model)
        {
            try
            {
                string pdfFilePath = GeneratePdf(model);

                await _emailService.SendEmailAsync(model.ToEmail, model.Subject, model.Body, pdfFilePath);

                _welcomeLetterRepository.Add(model);

                return Ok("Welcome letter sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error sending welcome letter: {ex.Message}");
            }
        }

        private string GeneratePdf(WelcomeLetterModel model)
        {
            string pdfFilePath = "WelcomeLetter.pdf";

            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12, XFontStyle.Regular);

                gfx.DrawString("Welcome to Our Bank!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);
                gfx.DrawString("Dear Customer,", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopCenter);
                gfx.DrawString("Thank you for choosing our bank. We're excited to have you as a customer.", font, XBrushes.Black, new XRect(50, 80, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);

                document.Save(pdfFilePath);
            }

            return pdfFilePath;
        }
    }
}
