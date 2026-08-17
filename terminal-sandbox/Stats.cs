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
        ///if the file does not exist, create the file and add the new goal with its stats as a dictionary to the file
        if (!File.Exists(filePath))
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
            return;
        }
        ///if the file exists but the goal does not exist, add the new goal with its stats to the file
        string jsonFile = await File.ReadAllTextAsync(filePath);
        Dictionary<string, Stats> statsByGoal = string.IsNullOrWhiteSpace(jsonFile)
            ? new Dictionary<string, Stats>()
            : JsonSerializer.Deserialize<Dictionary<string, Stats>>(jsonFile) 
                ?? new Dictionary<string, Stats>();
        
        statsByGoal[goalName] = stats;

        var updatedOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string UpdatedJsonFile = JsonSerializer.Serialize(statsByGoal, updatedOptions);
        await File.WriteAllTextAsync(filePath, UpdatedJsonFile);


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
  

