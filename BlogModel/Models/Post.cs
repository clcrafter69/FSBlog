using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogModel
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PermaLink { get; set; }


        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Creation Date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Publication Date")]
        public DateTime PubDate { get; set; }

        public Author Author { get; set; }

        //navigation properties
        //public int BlogId { get; set; }
        //public Blog Blog { get; set; }
    }

}
