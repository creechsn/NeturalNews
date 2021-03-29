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
  public class IndexModel : PageModel
  {
        readonly IConfiguration _configuration;
        public List<ArticleData> ArticleData = new List<ArticleData>();
        public string connectionString;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            GetData();
        }
        void GetData()
        {
            ArticleData ArticleDataView = new ArticleData();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            ArticleData = ArticleDataView.GetArticleData(connectionString).GetRange(0, 15);
        }
    }
}