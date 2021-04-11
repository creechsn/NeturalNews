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
    public class BLMSocialIssuesModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<BLMSocialIssuesData> BLMSocialIssuesArticles = new List<BLMSocialIssuesData>();
        public string connectionString;
        public BLMSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            BLMSocialIssuesData SocicalIssuesArticle = new BLMSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            BLMSocialIssuesArticles = SocicalIssuesArticle.GetBLMSocialIssuesDatas(connectionString);
        }

    }
}