using System.Data;
using System.Text.Json;
using Microsoft.VisualBasic;


namespace TerminalSandbox;

public class Stats
{
    public DateTime StartDateOfGoal { get; set; }
    public int Streak { get; set; }
    public int DaysCompleted { get; set; }

    public static async Task CreateNewGoal(string filePath, string goalName)
    {
        var stats = new Stats
        {
            StartDateOfGoal = DateTime.Now,
            Streak = 0, 
            DaysCompleted = 0
        };

        await SaveNewGoal(filePath, goalName, stats);
    }

    public static async Task SaveNewGoal(string filePath, string goalName, Stats stats)
    {
        var newGoal = new Dictionary<string, Stats>
        {
            { goalName, stats }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(newGoal, options);
        await File.WriteAllTextAsync(filePath, jsonString);

    }

    public static async Task<Stats?> LoadGoalStats(string filePath, string goalName)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        string jsonFile = await File.ReadAllTextAsync(filePath);

        var statsByGoal = JsonSerializer.Deserialize<Dictionary<string, Stats>>(jsonFile);

        if (statsByGoal != null && statsByGoal.TryGetValue(goalName, out var goalStats))
        {
            return goalStats;
        }

        return null;
      
    }

    public static async Task IncrementStreakOfGoal(string filePath, string goalName, bool completedToday)
    { 
        var goalStats = await LoadGoalStats(filePath, goalName);

        if (goalStats == null)
        {
            return;
        }

        if (!completedToday)
        {
            goalStats.Streak = 0;
        }
        else 
        {
            goalStats.Streak++;
            goalStats.DaysCompleted++;
        }
        
       






    }



}
  

