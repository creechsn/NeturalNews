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
    public class RefugeeSocialIssuesModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<RefugeeSocialIssuesData> RefugeeSocialIssuesArticles = new List<RefugeeSocialIssuesData>();
        public string connectionString;
        public RefugeeSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            RefugeeSocialIssuesData SocicalIssuesArticle = new RefugeeSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            RefugeeSocialIssuesArticles = SocicalIssuesArticle.GetRefugeeSocialIssuesDatas(connectionString);
        }

    }
}