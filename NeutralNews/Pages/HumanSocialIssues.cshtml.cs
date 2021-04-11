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
    public class HumanSocialIssuesModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<HumanSocialIssuesData> HumanSocialIssuesArticles = new List<HumanSocialIssuesData>();
        public string connectionString;
        public HumanSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            HumanSocialIssuesData SocicalIssuesArticle = new HumanSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            HumanSocialIssuesArticles = SocicalIssuesArticle.GetHumanSocialIssuesDatas(connectionString);
        }

    }
}