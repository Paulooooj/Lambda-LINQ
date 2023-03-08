using ExercicioFixacaoLinQ.Entities;
using System.Globalization;
namespace ExercicioFixacaoLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                List<Product> list = new List<Product>();

                using(StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] fieds = sr.ReadLine().Split(',');
                        string name = fieds[0];
                        double price = double.Parse(fieds[1], CultureInfo.InvariantCulture);

                        list.Add(new Product(name, price));
                    }
                }

                var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
                Console.WriteLine("Average price = " + avg.ToString("F2", CultureInfo.InvariantCulture));

                var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
                foreach(string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}