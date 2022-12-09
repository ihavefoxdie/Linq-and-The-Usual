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
            #region Ordinary
            Console.WriteLine("New groups (Ordinary way):");
            Console.WriteLine("Even Numbers(" + arr.EvenSum + "): ");
            for (int i = 0; i < arr.EvenNumbers.Length; i++)
            {
                Console.Write(arr.EvenNumbers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Odd Numbers(" + arr.OddSum + "): ");
            for (int i = 0; i < arr.OddNumbers.Length; i++)
            {
                Console.Write(arr.OddNumbers[i] + " ");
            }
            Console.WriteLine();
            #endregion

            #region LINQ
            Console.WriteLine();
            /*var Output = sex.GroupBy(
            number => number = number ,
            number => number % 2 != 0,
            (even, odd) => new
            {
            Odd = odd,
            Even = even
            });*/

            /*var Output = from element in sex
            group element by element % 2 == 0;*/

            /*foreach(var item in Output)
            {
            //Console.WriteLine("Even numbers: ");
            foreach (var element in item)
            {

            }

            }*/


            #endregion


            //2
            #region Ordinary
            Console.WriteLine();
            Console.WriteLine("Collection of summed salaries for recurring names (Ordinary way).");
            var collection = new Worker[]
            {
                new("Obama", 1999),
                new("Roomba", 100000),
                new("Obama", 10000)
            };

            Overall<Worker> overall = new(collection);

            for (int i = 0; i < overall.AllSalary.Length; i++)
            {
                Console.WriteLine("Name: " + overall.AllSalary[i].Name + "; Salary: " +
                    overall.AllSalary[i].Salary);
            }
            #endregion

        }
    }
}