﻿using DTOLayer.DTOs.AppUserDtos;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "",
                    District = "",
                    ImageUrl="",
                    ConfirmCode=code

                };


                    var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                    if (result.Succeeded)
                    {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy CashAdmin", "ramin.haciyev.2014@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                        
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    
                    var bodyBuilder=new BodyBuilder();
                    bodyBuilder.TextBody = "Your verification code:" + code;
                    mimeMessage.Body=bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Verification Code";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com",587,false);
                    smtpClient.Authenticate("ramin.haciyev.2014@gmail.com", "mukniridzqooytbb");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    TempData["Mail"] = appUser.Email;

                    return RedirectToAction("Index", "ConfirmMail");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                
               
                
            }
            return View();
        }
    }
}
