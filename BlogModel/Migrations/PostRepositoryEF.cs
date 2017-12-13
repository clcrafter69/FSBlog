using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogModel
{
   public class PostRepositoryEF : IBlogRepository

    {
        protected readonly BloggingContext _dbContext;

        public PostRepositoryEF(BloggingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Post newPost)
        {

            newPost.CreateDate = DateTime.Now;
            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChanges();
           

           // return newPost;
           
        }

        public void Delete(int id)
        {
            Post originalPost = GetById(id);

            _dbContext.Posts.Remove(originalPost);
        }

        public void Edit(Post editPost)
        {
            _dbContext.Entry<Post>(editPost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.Find(id);
        }

        public List<Author> GetName()
        {
            throw new NotImplementedException();
        }

        public List<Post> ListAll()
        {
            return _dbContext.Posts.ToList();
        }
    }
}
