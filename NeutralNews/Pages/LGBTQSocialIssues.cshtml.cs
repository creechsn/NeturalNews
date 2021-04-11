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
    public class LGBTQSocialIssuesModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<LGBTQSocialIssuesData> LGBTQSocialIssuesArticles = new List<LGBTQSocialIssuesData>();
        public string connectionString;
        public LGBTQSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            LGBTQSocialIssuesData LGBTQSocicalIssuesArticle = new LGBTQSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            LGBTQSocialIssuesArticles = LGBTQSocicalIssuesArticle.GetLGBTQSocialIssuesDatas(connectionString);
        }

    }
}