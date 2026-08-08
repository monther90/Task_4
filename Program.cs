namespace SearchTask4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();
            try 
            {
                CheckVowels(text);
                Console.WriteLine("The string contains vowels.");
            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CheckVowels(string text)
        {
            bool hasVowel = false;
            foreach (char letter in text)
            { 
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                { hasVowel = true;
                    break;
                } 
            } 
            if (hasVowel == false)
            {
                throw new Exception("The string does not contain vowels.");
            }
        }
    }
}
  
