using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeutralNews.Pages
{
    public class UploadModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Insert a valid link to an article/website you would like to know the political leaning of.";
        }
    }
}