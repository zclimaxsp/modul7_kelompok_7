using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
public class TeamMember
{
    public string? nim { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? gender { get; set; }
    public int age { get; set; }
}

public class TeamMembers2311104076
{
    public List<TeamMember>? members { get; set; }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_2_2311104076.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' tidak ditemukan.");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var data = JsonSerializer.Deserialize<TeamMembers2311104076>(jsonData, options);

        Console.WriteLine("Team member list:");
        if (data?.members != null)
        {
            foreach (var member in data.members)
            {
                Console.WriteLine($"{member.nim} {member.firstName} {member.lastName} ({member.age} {member.gender})");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TeamMembers2311104076.ReadJSON();
    }
}