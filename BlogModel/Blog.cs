using System;
using System.Collections.Generic;
using System.Text;

namespace BlogModel
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }


        //navigation properties
        public List<Post> Posts { get; set; }
    }
}
