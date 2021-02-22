using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeutralNews.Pages
{
  public class ContactModel : PageModel
  {
    public string Message { get; set; }
    public string InputEmail { get; set; }
    public string SubmittedConcerns { get; set; }

        public void OnGet()
    {
      
    }
  }
}
