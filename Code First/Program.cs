using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
    public class dbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var db = new dbContext())
            {
                var user = new User
                {
                    Name = "Hosein",
                    Family = "Khadem"
                };
                db.Users.Add(user);
                db.SaveChanges();
                var selected = db.Users.FirstOrDefault(x => x.Name == "Hosein");
                Console.WriteLine(selected.Id);
                Console.WriteLine(selected.Name);
                Console.WriteLine(selected.Family);
                Console.WriteLine("====================");

                Console.ReadKey();
            }
        }
    }
}
