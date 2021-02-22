using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeutralNews.Models
{
    public class ArticleData
    {
        public int ReferenceID { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceURL { get; set; }
        public decimal isCredible { get; set; }
    }
}
