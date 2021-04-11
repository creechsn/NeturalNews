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
    public class ClimateSocialIssuesModel : PageModel
    {

        readonly IConfiguration _configuration;
        public List<ClimateSocialIssuesData> ClimateSocialIssuesArticles = new List<ClimateSocialIssuesData>();
        public string connectionString;
        public ClimateSocialIssuesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            ClimateSocialIssuesData ClimateSocicalIssuesArticle = new ClimateSocialIssuesData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            ClimateSocialIssuesArticles = ClimateSocicalIssuesArticle.GetClimateSocialIssuesDatas(connectionString);
        }

    }
}