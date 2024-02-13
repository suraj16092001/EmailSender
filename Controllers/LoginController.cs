using Email_Sender.Models;
using Email_Sender.Repository.Interface;
using Email_Sender.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace Email_Sender.Controllers
{
    public class LoginController : Controller
    {
        IEmailSender _EmailSender;
        public LoginController(IEmailSender emailSender)
        {
            _EmailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginSuccess([FromBody]GetEmailSetting email)
        {
            await _EmailSender.EmailSendAsync(email.Email, "Booking Confirm", "Congratulation Your Appointment Is confirmed!");

          return RedirectToAction("Index");
        }

  
    }
}
