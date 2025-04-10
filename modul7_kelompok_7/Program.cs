using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GlossaryItem2311104046
{
    public Glossary? glossary { get; set; }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_3_2311104046.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' tidak ditemukan.");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var data = JsonSerializer.Deserialize<GlossaryItem2311104046>(jsonData, options);

        var entry = data?.glossary?.GlossDiv?.GlossList?.GlossEntry;
        if (entry != null)
        {
            Console.WriteLine("GlossEntry:");
            Console.WriteLine($"ID: {entry.ID}");
            Console.WriteLine($"Term: {entry.GlossTerm}");
            Console.WriteLine($"Acronym: {entry.Acronym}");
            Console.WriteLine($"Abbreviation: {entry.Abbrev}");
            Console.WriteLine($"Definition: {entry.GlossDef?.para}");
            Console.WriteLine("See Also: " + string.Join(", ", entry.GlossDef?.GlossSeeAlso ?? new List<string>()));
            Console.WriteLine($"GlossSee: {entry.GlossSee}");
        }
    }
}

// Semua class pendukung
public class Glossary
{
    public string? title { get; set; }
    public GlossDiv? GlossDiv { get; set; }
}

public class GlossDiv
{
    public string? title { get; set; }
    public GlossList? GlossList { get; set; }
}

public class GlossList
{
    public GlossEntry? GlossEntry { get; set; }
}

public class GlossEntry
{
    public string? ID { get; set; }
    public string? SortAs { get; set; }
    public string? GlossTerm { get; set; }
    public string? Acronym { get; set; }
    public string? Abbrev { get; set; }
    public GlossDef? GlossDef { get; set; }
    public string? GlossSee { get; set; }
}

public class GlossDef
{
    public string? para { get; set; }
    public List<string>? GlossSeeAlso { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        GlossaryItem2311104046.ReadJSON();
    }
}
