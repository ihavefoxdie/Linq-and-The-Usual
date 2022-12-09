namespace Linq_and_The_Usual.Classes
{
    public class ArrayGroups
    {
        public int[] EvenNumbers { get; private set; }
        public int[] OddNumbers { get; private set; }

        public int EvenSum { get; private set; }
        public int OddSum { get; private set; }

        public ArrayGroups(int[] arr)
        {
            int[] evenNumbers = new int[arr.Length];
            int[] oddNumbers = new int[arr.Length];

            int n = 0, f = 0;
            for (int i = 0; i < arr?.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenNumbers[n] = arr[i];
                    n++;
                }
                else
                {
                    oddNumbers[f] = arr[i];
                    f++;
                }
            }

            Array.Resize(ref evenNumbers, n);
            Array.Resize(ref oddNumbers, f);

            EvenNumbers = evenNumbers;
            OddNumbers = oddNumbers;

            EvenSum = Sum(EvenNumbers);
            OddSum = Sum(OddNumbers);
        }

        private static int Sum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }
    }
}