using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlogAspnetCursombanagouro.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Permalink { get; set; }
        public string Title  { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public Category Category { get; set; }
        public DateTime PublishedOn { get; set; }

        ICollection<Comment> _comments;
        public ICollection<Comment> Comments
        {
            get { return _comments ?? (_comments = new List<Comment>()); }
            set { _comments = value; }
        }

        public Post()
        {
            PublishedOn = DateTime.Now;
        }
    }
}