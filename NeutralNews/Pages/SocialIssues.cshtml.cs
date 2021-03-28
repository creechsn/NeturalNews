using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NeutralNews.Models;

namespace NeutralNews.Pages
{
    public class SocialModel : PageModel
    {

        readonly IConfiguration _configuration;
        public List<SocialIssuesData> SocialIssuesArticles = new List<SocialIssuesData>();
        public string connectionString;
        public SocialModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            SocialIssuesData SocicalIssuesArticle = new SocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            SocialIssuesArticles = SocicalIssuesArticle.GetSocialIssuesDatas(connectionString);
        }

    }
}