﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AnswerQuestionWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AnswerQuestionWebApp.Models.UsersProfiles;
using AnswerQuestionWebApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AnswerQuestionWebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _iHostingEnvironment;

        public RegisterModel(
            UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext db,
            IHostingEnvironment iHostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public List<SelectListItem> Langues { get; set; }

        public class InputModel
        {
            [Required]
            public IFormFile Photo { get; set; }

            [Required]
            [StringLength(15)]
            public string Name { get; set; }

            public Gender Gender { get; set; }
            [Required]
            [Display(Name = "Gender")]
            public int GenderId { get; set; }

            
            [Required]
            [Display(Name = "Country")]
            public int CountryId { get; set; }

            
            [Required]
            [Display(Name = "Langues")]
            public int LanguesId { get; set; }




            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Phone]
            [Display(Name = "Mobile No.")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {

            ReturnUrl = returnUrl;

            Countries = _db.Countries.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            Gender= _db.Genders.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            Langues = _db.Langues.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string uniqphotoname = null;
                if (Input.Photo!=null)
                {
                  string userphotofolder=  Path.Combine(_iHostingEnvironment.WebRootPath, "userphoto");
                 uniqphotoname= Guid.NewGuid().ToString() + "_" + Input.Photo.FileName;
                  string photopath= Path.Combine(userphotofolder, uniqphotoname);
                  Input.Photo.CopyTo(new FileStream(photopath,FileMode.Create));
                }
                var user = new ApplicationUsers {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name,                   
                    GenderId = Input.GenderId,
                    CountryId = Input.CountryId,
                    LanguesId = Input.LanguesId,
                    PhoneNumber = Input.PhoneNumber, 
                    Photo = uniqphotoname
                };
               

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form


            return Page();
        }
    }
}
