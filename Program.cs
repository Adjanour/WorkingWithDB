using Microsoft.EntityFrameworkCore;

namespace WorkingWithDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(BlogDbContext context = new BlogDbContext())
            {
                context.Database.EnsureCreated();

                //Create enitites
                Post post1 = new Post() { Body = "Test1", Title = "Test 1 title" };

                context.Posts.Add(post1);

                context.SaveChanges();

                foreach(Post post in context.Posts)
                {
                    Console.WriteLine(post.Title);
                }
            }
        }

        public class Post
        {
            public string Body { get; set; }

            public DateTime DatePublished { get; set; } = DateTime.Now;

            public int Id { get; set; }

            public string Title { get; set; }
        }

        public class BlogDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=KIRKPC\SALEMSERVER; Initial Catalog=dbPost; Integrated Security = True ; TrustServerCertificate=True");
            }

            public DbSet<Post> Posts { get; set; }
        }
    }
}