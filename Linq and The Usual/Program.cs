using Linq_and_The_Usual.Classes;

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
            //Console.WriteLine("New groups (Ordinary way):");
            //Console.WriteLine("Even Numbers(" + arr.EvenSum + "): ");
            //for (int i = 0; i < arr.EvenNumbers.Length; i++)
            //{
            //    Console.Write(arr.EvenNumbers[i] + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Odd Numbers(" + arr.OddSum + "): ");
            //for (int i = 0; i < arr.OddNumbers.Length; i++)
            //{
            //    Console.Write(arr.OddNumbers[i] + " ");
            //}
            //Console.WriteLine();


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


            //2

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
            //Overall<Worker> overall = new(collection);

            //for (int i = 0; i < overall.AllSalary.Length; i++)
            //{
            //    Console.WriteLine("Name: " + overall.AllSalary[i].Name + "; Salary: " +
            //        overall.AllSalary[i].Salary);
            //}
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
            //Console.WriteLine("Collection of elements that recur only 3 times (Ordinary way).");
            Random rand = new();
            int[] lottaNumbers = new int[] { 5, 5, 277, 5, 7, 2, 7, 1, 7, 21, 54, 277, 3, 11, 11, 11, 4234, 27, 277 };
            /*int[] lottaNumbers = new int[100000];
            for (int i = 0; i < lottaNumbers.Length; i++)
            {
                lottaNumbers[i] = rand.Next(100);
            }*/


            //StupidClass<int> numbers = new(lottaNumbers);
            //for (int i = 0; i < numbers.NewArray.Length; i++)
            //{
            //    Console.Write(numbers.NewArray[i] + " ");
            //}
            //Console.WriteLine();
            #region LINQ Query 12.3.3

            Console.WriteLine("LINQ Query 12.3.3");

            var queryLinqArray3 = (from element in lottaNumbers select element).Distinct();

            Console.Write("Initial Array : [");

            foreach (var item in lottaNumbers)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");

            Console.Write("\nDistinct Array : [");

            foreach (var item in queryLinqArray3)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");


            #endregion

            #region LINQ Method 12.3.3

            Console.WriteLine("\n\nLINQ Method 12.3.3");


            var methodLinqArray3 = lottaNumbers.Distinct();

            Console.Write("Initial Array : [");

            foreach (var item in lottaNumbers)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");

            Console.Write("\nDistinct Array : [");

            foreach (var item in queryLinqArray3)
            {
                Console.Write($" {item}");
            }
            Console.Write(" ]");


            #endregion

        }
    }
}