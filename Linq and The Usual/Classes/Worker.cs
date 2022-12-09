namespace Linq_and_The_Usual.Classes
{
    public class Worker
    {
        

        public string Name { get; private set; }
        public int Salary { get; set; }

        public Worker(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}