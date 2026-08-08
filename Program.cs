namespace SearchTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("How many numbers do you want to enter?");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter numbers:");

            for (int i = 0; i < count; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                numbers.Add(number);
            }

            try
            {
                foreach (int number in numbers)
                {
                    int counter = 0;

                    foreach (int x in numbers)
                    {
                        if (number == x)
                        {
                            counter++;
                        }
                    }

                    if (counter > 1)
                    {
                        throw new Exception("Duplicate number found: " + number);
                    }
                }

                Console.WriteLine("No duplicates found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}