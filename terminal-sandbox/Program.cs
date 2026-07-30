using System;

namespace TerminalSandbox;

internal class Program
{
    private static async Task Main(string[] args)
    {
        
        await CreateGoalFromUserInput();
        ///Or check goalStats??
    }

    private static async Task CreateGoalFromUserInput()
    {
        Console.Write("Hello, what achievements would you like to accomplish? >>");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty. Please enter a valid achievement.");
            return;
        }

        Console.WriteLine($"You entered: {input}");
        Console.Write("how many times a day can the goal be accomplished? >>");
        string? input2 = Console.ReadLine();
        Console.WriteLine($"You entered: {input2}");

        string filePath = "stats.json";
        await GoalCreater(input, filePath);

        ///bool resultOfToday = QuestionTodaysGoalCompleted(input);
    }

    public static bool QuestionTodaysGoalCompleted(string goal)
    {
        while (true)
        {
            Console.Write($"Did you complete your goal of {goal} today? (yes/no) >>");
            string? input = Console.ReadLine();

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


    public static async Task GoalCreater(string goalName, string filePath)
    {
        await Stats.CreateNewGoal(filePath, goalName);
    }
}
