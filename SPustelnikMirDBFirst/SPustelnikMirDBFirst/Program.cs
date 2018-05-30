using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPustelnikMirDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new simpleDBSPustelnikEntities())
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Enter a number: ");
                        var console_text = Console.ReadLine();
                        var number = Int32.Parse(console_text);

                        var tab = new simpleTab { val = number };
                        db.simpleTab.Add(tab);
                        db.SaveChanges();

                        var query = from st in db.simpleTab
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
}
