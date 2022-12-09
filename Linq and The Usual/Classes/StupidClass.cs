namespace Linq_and_The_Usual.Classes
{
    public class StupidClass<T>
    {
        public T[] NewArray { get; private set; }

        public StupidClass(T[] newArray)
        {
            T[] array = new T[0];
            int counter = 0;
            int match = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] == null)
                    throw new ArgumentNullException(nameof(newArray), "Array element is null!");

                if (StupidClass<T>.CheckIfIncluded(newArray[i], array))
                    continue;
                for (int j = 1; j < newArray.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (newArray[i]!.Equals(newArray[j]))
                    {
                        counter++;
                        if (counter > 2)
                            break;
                    }
                }
                if (counter == 2)
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[match] = newArray[i];
                    match++;
                }
                counter = 0;
            }

            Array.Resize(ref array, match);
            NewArray = array;
        }

        private static bool CheckIfIncluded(T element, T[] array)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element), "The element passed is null!");
            for (int i = 0; i < array.Length; i++)
            {
                if (element!.Equals(array[i]))
                    return true;
            }
            return false;
        }
    }
}