﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeutralNews.Pages
{
  public class ContactModel : PageModel
  {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string InputEmail { get; set; }
        [Required]
        public string Message { get; set; }

        public void OnGet()
    {
      
    }
  }
}
