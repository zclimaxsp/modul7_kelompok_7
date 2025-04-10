using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GlossaryItem2311104076
{
    public class GlossDef
    {
        public string para { get; set; }
        public string[] GlossSeeAlso { get; set; }
    }

    public class GlossEntry
    {
        public string ID { get; set; }
        public string SortAs { get; set; }
        public string GlossTerm { get; set; }
        public string Acronym { get; set; }
        public string Abbrev { get; set; }
        public GlossDef GlossDef { get; set; }
        public string GlossSee { get; set; }
    }

    public class GlossList
    {
        public GlossEntry GlossEntry { get; set; }
    }

    public class GlossDiv
    {
        public string title { get; set; }
        public GlossList GlossList { get; set; }
    }

    public class Glossary
    {
        public string title { get; set; }
        public GlossDiv GlossDiv { get; set; }
    }

    public class Root
    {
        public Glossary glossary { get; set; }
    }

    public void ReadJSON()
    {
        try
        {
            string filePath = "jurnal7_3_2311104076.json";
            string json = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<Root>(json);

            Console.WriteLine("=== GlossEntry ===");
            var entry = data.glossary.GlossDiv.GlossList.GlossEntry;
            Console.WriteLine($"ID: {entry.ID}");
            Console.WriteLine($"Term: {entry.GlossTerm}");
            Console.WriteLine($"Acronym: {entry.Acronym}");
            Console.WriteLine($"Definition: {entry.GlossDef.para}");
            Console.WriteLine($"GlossSee: {entry.GlossSee}");
            Console.WriteLine("GlossSeeAlso: " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading JSON: " + ex.Message);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var glossary = new GlossaryItem2311104076();
        glossary.ReadJSON();
    }
}
