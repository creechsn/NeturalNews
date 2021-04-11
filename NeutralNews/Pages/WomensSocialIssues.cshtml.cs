using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NeutralNews.Models;

namespace NeutralNews.Pages
{
    public class WomensSocialIssuesModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<WomensSocialIssuesData> WomensSocialIssuesArticles = new List<WomensSocialIssuesData>();
        public string connectionString;
        public WomensSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            WomensSocialIssuesData WomensSocicalIssuesArticle = new WomensSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            WomensSocialIssuesArticles = WomensSocicalIssuesArticle.GetWomensSocialIssuesDatas(connectionString);
        }

    }
}
