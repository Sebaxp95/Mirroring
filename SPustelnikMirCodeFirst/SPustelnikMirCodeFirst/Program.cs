using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SPustelnikMirCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SimpleTabContext())
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Enter a number: ");
                        var console_text = Console.ReadLine();
                        var number = Int32.Parse(console_text);

                        var tab = new SimpleTab { val = number };
                        db.Tabs.Add(tab);
                        db.SaveChanges();

                        var query = from st in db.Tabs
                                    orderby st.val
                                    select st;

                        Console.WriteLine("All rows in database:");
                        foreach (var item in query)
                        {
                            Console.WriteLine(item.id + " " + item.val);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            } 
        }
    }

    public class SimpleTab
    {
        public int id { get; set; }
        public int val { get; set; }

    }

    public class SimpleTabContext : DbContext
    {
        public DbSet<SimpleTab> Tabs { get; set; }
    }
}
