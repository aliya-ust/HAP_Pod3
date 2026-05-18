using System;

public class InputRequired
{
    public static string GetRequiredInput(string message)
    {
        string input;

        while (true)
        {
            Console.Write(message);
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Input cannot be empty. Please try again.\n");
        }
    }
    
}
