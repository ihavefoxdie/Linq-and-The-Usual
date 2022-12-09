namespace Linq_and_The_Usual.Classes
{
    public class Overall<T> : IComparer<T> where T : Worker
    {
        public int Compare(T? x, T? y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            if (x.Name == y.Name)
                return 0;
            return 1;
        }

        public T[] AllSalary { get; private set; }
        public Overall(T[] arr)
        {
            if (arr.Length == 0)
                throw new IndexOutOfRangeException();

            T[] allSalary = new T[arr.Length];
            allSalary[0] = arr[0];
            int match = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (allSalary[j] is null)
                    {
                        allSalary[j] = arr[i];
                        break;
                    }
                    if (Compare(allSalary[j], arr[i]) == 0)
                    {
                        allSalary[j].Salary += arr[i].Salary;
                        match++;
                    }
                }
            }
            Array.Resize(ref allSalary, allSalary.Length - match);
            AllSalary = allSalary;
        }
    }
}