using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace BlogModel
{
    public interface IBlogRepository
    {
        void Add(Post newPost);
        void Delete(int id);
        Post GetById(int id);
        List<Post> ListAll();
        void Edit(Post editPost);
        List<Author> GetName();
    }
}
