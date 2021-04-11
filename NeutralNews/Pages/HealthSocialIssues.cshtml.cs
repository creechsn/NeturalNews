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
    public class HealthSocialIssuesModel : PageModel
    {

        readonly IConfiguration _configuration;
        public List<HealthSocialIssuesData> HealthSocialIssuesArticles = new List<HealthSocialIssuesData>();
        public string connectionString;
        public HealthSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            HealthSocialIssuesData HealthSocialIssuesArticle = new HealthSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            HealthSocialIssuesArticles = HealthSocialIssuesArticle.GetHealthSocialIssuesDatas(connectionString);
        }

    }
}