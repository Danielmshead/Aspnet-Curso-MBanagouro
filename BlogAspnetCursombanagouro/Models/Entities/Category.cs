using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAspnetCursombanagouro.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Permalink { get; set; }

        ICollection<Post> _posts;
        public ICollection<Post> Posts
        {
            get { return _posts ?? (_posts = new List<Post>()); }
            set { _posts = value; }
        }
    }
}