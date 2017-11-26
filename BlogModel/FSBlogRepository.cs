using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


namespace BlogModel
{
    public class PostRepository : IBlogRepository
    {
        private static List<Post> _posts = new List<Post>();
        private static int nextId = 1;
        private static string path = @"c:\codecareer\post";
        //private static string fileName = "postData.json";
        private static string fileName = "postData.json";

        public PostRepository()
        {
            //TODO --check For file
            if (_posts.Count < 1)
            {
                //check for file
                //load from json file
                retrieveFile();
            }
            else
            {
                //incrementNextID();
            }

            //if missing, Create

            //if not determine if any objects in json file retrieved

        }

        private void createFile()
        {

        }

        private void retrieveFile()
        {
            //if path exists, save post info, else create file
            DirectoryInfo dir = Directory.CreateDirectory(path);
            FileInfo[] file = dir.GetFiles();
            if (file.Length == 0)
            {
                File.Create(Path.Combine(path, fileName));
            }
            else
            {
                foreach (FileInfo pfile in file)
                {
                    if (pfile.Name == fileName)
                    {
                        // LoadFromFile();
                        var serializedPosts = File.ReadAllText(Path.Combine(path, fileName));
                        _posts = JsonConvert.DeserializeObject<List<Post>>(serializedPosts);
                        _posts = _posts.OrderByDescending(x => x.Id).ToList();

                        var orderedPosts = from post in _posts
                                           orderby post.Id descending
                                           select post.Id;
                       

                    }
                }

            }
        }

        private void SaveToFile()
        {

            var serializedPosts = JsonConvert.SerializeObject(_posts);
            File.WriteAllText(Path.Combine(path, fileName), serializedPosts);

           

         


        }

        private int getNextID()
        {
            var orderedPosts = from post in _posts
                               orderby post.Id descending
                               select new { ID = post.Id };
            return(orderedPosts.Max(post => post.ID)+ 1);
        }

        public void Add(Post newPost)
        {
            newPost.Id = getNextID();
            newPost.CreateDate = DateTime.Now;
            _posts.Add(newPost);
            SaveToFile();

        }

        public void Delete(int id)
        {
            Post originalBook = GetById(id);

            _posts.Remove(originalBook);
            SaveToFile();

            //throw new NotImplementedException();
        }

        public void Edit(Post editPost)
        {
            //Post originalBook = GetById(editPost.Id);
            _posts.Remove(GetById(editPost.Id));

            _posts.Add(editPost);
            _posts = _posts.OrderByDescending(x => x.Id).ToList();
            SaveToFile();
            //throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _posts.Find(b => b.Id == id);
            //throw new NotImplementedException();
        }

        public List<Post> ListAll()
        {
            _posts = _posts.OrderByDescending(x => x.PubDate).ToList();
            return _posts;
            //throw new NotImplementedException();
        }
    }
}
