using System;
using System.Text.Json;


namespace TerminalSandbox;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Hello, what achievements would you like to accomplish? >>");
        string ? input = Console.ReadLine();
        Console.WriteLine($"You entered: {input}");
        Console.Write("how many times a day can the goal be accomplished? >>");
        string ? input2 = Console.ReadLine();
        Console.WriteLine($"You entered: {input2}");
        bool resultOfToday = QuestionTodaysGoalCompleted(input);

    }

    public static bool QuestionTodaysGoalCompleted(string goal)
    {
        while (true)
        {    
            Console.Write($"Did you complete your goal of {goal} today? (yes/no) >>");
            string ? input = Console.ReadLine();


           if (input != null)
           {
                input = input.Trim().ToLower();
                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
            else
            {
                Console.WriteLine("Input cannot be null. Please enter 'yes' or 'no'.");
                
            }

        }
    }

    public static void GoalTracker(bool result)
    {
        string filePath = "stats.json";

        var stats = new
        {
            daysCompleted = 0,
            Streak = 0
        };

        if (result == true)
        {

            Console.WriteLine("Congratulations! You completed your goal today.");

        }
        else
        {
            Console.WriteLine("Don't worry! You can try again tomorrow.");
        }
    }
    
}
