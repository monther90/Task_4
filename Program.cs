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

        //======================================================================================
        //   -----------search_Task2------------------
        //======================================================================================
        //static void Main(string[] args)
        //{
        //    Console.Write("Enter a string: ");
        //    string text = Console.ReadLine();
        //    try
        //    {
        //        CheckVowels(text);
        //        Console.WriteLine("The string contains vowels.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        //static void CheckVowels(string text)
        //{
        //    bool hasVowel = false;
        //    foreach (char letter in text)
        //    {
        //        if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
        //        {
        //            hasVowel = true;
        //            break;
        //        }
        //    }
        //    if (hasVowel == false)
        //    {
        //        throw new Exception("The string does not contain vowels.");
        //    }
        //}
    }
}