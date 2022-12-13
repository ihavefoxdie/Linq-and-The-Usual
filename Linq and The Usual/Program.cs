using Linq_and_The_Usual.Classes;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace _12._3
{

    class Program
    {
        static void Main()
        {
            int[] sex = new int[] { 1, 10, 123, 4, 3, 34, 48, 100, 11, 5, 8, 16, 27 };
            ArrayGroups arr = new(sex);
            Console.WriteLine();

            Console.WriteLine("Initial array: ");
            for (int i = 0; i < sex.Length; i++)
            {
                Console.Write(sex[i] + " ");
            }
            Console.WriteLine("\n");
            //1
            #region Query 12.3.1


            var queryLinqArray = from element in sex.Select((number, even) => new { number, even = number % 2 })
                                 group element.number by element.even into groups
                                 select new { Group = groups.Key, Sum = groups.Sum() };

            Console.WriteLine("Query LINQ : ");
            foreach (var group in queryLinqArray)
            {
                Console.Write($"{group.Group} : {group.Sum}");
                Console.WriteLine();
            }


            #endregion

            #region Method 12.3.1
            Console.WriteLine();

            var methodLinqArray = sex.GroupBy((int groups) => groups % 2).Select(p => new { Group = p.Key, Sum = p.Sum() });
            Console.WriteLine();
            Console.WriteLine("Method LINQ : ");

            foreach (var groups in methodLinqArray)
            {
                Console.WriteLine($"{groups.Group} : {groups.Sum}");
            }


            #endregion


            Console.WriteLine();
            Console.WriteLine("Collection of summed salaries for recurring names (Ordinary way).");
            var collection = new Worker[]
            {
                new("Obama", 1999),
                new("Roomba", 100000),
                new("Roomba", 120000),
                new("Obama", 10000),
                new("Grey", 50)
            };

            #region LINQ Query 12.3.2

            Console.WriteLine("\nLINQ Query 12.3.2:");
            var queryLinqArray2 = from element in collection
                                  group element.Salary by element.Name into workers
                                  select new { Name = workers.Key, Sum = workers.Sum() };

            foreach (var group in queryLinqArray2)
            {
                Console.Write($"{group.Name} : {group.Sum}");
                Console.WriteLine();
            }
            #endregion

            #region LINQ Method 12.3.2


            Console.WriteLine("\nLINQ Method 12.3.2:");

            var methodLinqArray2 = collection
                .GroupBy(name => name.Name)
                .Select(result => new
                {
                    Name = result.Key,
                    Sum = result.Select(p => p.Salary).Sum()
                }
                );

            foreach (var groups in methodLinqArray2)
            {
                Console.WriteLine($"{groups.Name} : {groups.Sum}");
            }

            #endregion





            Console.WriteLine();

            int[] lottaNumbers = new int[] { 5, 5, 277, 5, 7, 2, 7, 1, 7, 21, 54, 277, 3, 11, 11, 11, 4234, 27, 277 };

            Console.Write("Initial Array : [");

            foreach (var item in lottaNumbers)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");

            #region LINQ Query 12.3.3

            Console.WriteLine("LINQ Query 12.3.3");

            var queryLinqArray3 = from element in lottaNumbers
                                  group element by element into grouped
                                  where grouped.Count() == 3
                                  select grouped.Key;



            Console.Write("\nDistinct Array : [");

            foreach (var item in queryLinqArray3)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");


            #endregion

            #region LINQ Method 12.3.3

            Console.WriteLine("\n\nLINQ Method 12.3.3");


            var methodLinqArray3 = lottaNumbers.GroupBy(element => element)
                .Where(x => x.Count() == 3)
                .Select(x => x.Key);

            Console.Write("\nDistinct Array : [");

            foreach (var item in methodLinqArray3)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");


            #endregion




            #region LINQ Query 12.3.4
            Console.WriteLine();

            Console.WriteLine("LINQ Query 12.3.4");

            var collectionOf2 = new List<int[]> {
                new[] {4, 5},
                new[] {2, 3},
                new[] {3, 4},
                new[] {10, 11},
                new[] {0, 1},
                new[] {30, 2},
                new[] {5, 5}
            };
            var quaryLinqCollOf2 = from element in collectionOf2
                                   orderby element[0] ascending
                                   orderby element[1] descending
                                   select element;


            foreach (var item in quaryLinqCollOf2)
            {
                Console.WriteLine("{0}, {1}", item[0], item[1]);
            }

            #endregion

            #region LINQ Method 12.3.5
            Console.WriteLine("LINQ Method 12.3.4");

            quaryLinqCollOf2 = collectionOf2.
                OrderBy(x => x[0]).
                OrderByDescending(y => y[1]);

            foreach (var item in quaryLinqCollOf2)
            {
                Console.WriteLine("{0}, {1}", item[0], item[1]);
            }
            #endregion
        }
    }
}