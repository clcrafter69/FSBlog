using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogModel.Models
{
    [NotMapped]
    public class PostViewModel
    {
        public SelectList Authors { get; set; }
        public Post Post { get; set; }
    }
}
