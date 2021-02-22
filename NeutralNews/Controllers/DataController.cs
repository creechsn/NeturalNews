using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using NeutralNews.Models;

namespace NeutralNews
{
    public class DataController : ApiController
    {

   
        ArticleData[] articles = new ArticleData[]
        {
            new ArticleData { ReferenceID = 1, ReferenceName = "ABC12", ReferenceURL = "https://abc12.com/", isCredible = 1 },
            new ArticleData { ReferenceID = 2, ReferenceName = "ABCNY", ReferenceURL = "https://abc7ny.com/", isCredible = 1 },
            new ArticleData { ReferenceID = 3, ReferenceName = "ABC7Chicago", ReferenceURL = "https://abc7chicago.com/", isCredible = 1 }
        };

        public IEnumerable<ArticleData> GetAllArticles()
        {
            return articles;
        }

        public IHttpActionResult GetArticles(int id)
        {
            var article = articles.FirstOrDefault((p) => p.ReferenceID == id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
    }
}