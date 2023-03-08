
using System.Globalization;

using ExercicioFinalLinQ.Entities;
using System.Globalization;


namespace ExercicioFinalLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double firstSalary = double.Parse(Console.ReadLine());

            try
            {
                List<Employee> list = new List<Employee>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fieds = sr.ReadLine().Split(',');
                        string name = fieds[0];
                        string email = fieds[1];
                        double salary = double.Parse(fieds[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(name, email, salary));

                    }


                }
                var emails = list.Where(p => p.Salary > firstSalary).OrderBy(p => p.Email).Select(p => p.Email);
                Console.WriteLine("Email of people whose salary is more than 2000.00:");

                var sumSalary = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                
                foreach(string email in emails)
                {
                    Console.WriteLine(email);
                }
                Console.Write("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}