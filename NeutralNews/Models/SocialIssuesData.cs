using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NeutralNews.Models
{
    public class SocialIssuesData
    {
        public int ReferenceID { set; get; }
        [DisplayName("Reference Name")]
        public string ReferenceName { set; get; }
        [DisplayName("Reference URL")]
        public string ReferenceURL { set; get; }
        [DisplayName("Is Credible")]
        public bool isCredible { set; get; }

    }
}
