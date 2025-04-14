using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GlossaryItem2311104076
{
    public Glossary? glossary { get; set; }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_1_2311104076.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' tidak ditemukan.");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var data = JsonSerializer.Deserialize<GlossaryItem2311104076>(jsonData, options);
        var entry = data?.glossary?.GlossDiv?.GlossList?.GlossEntry;

        if (entry != null)
        {
            Console.WriteLine("=== GlossEntry ===");
            Console.WriteLine($"ID          : {entry.ID}");
            Console.WriteLine($"Term        : {entry.GlossTerm}");
            Console.WriteLine($"Acronym     : {entry.Acronym}");
            Console.WriteLine($"Abbreviation: {entry.Abbrev}");
            Console.WriteLine($"Definition  : {entry.GlossDef?.para}");
            Console.WriteLine("See Also    : " + string.Join(", ", entry.GlossDef?.GlossSeeAlso ?? new List<string>()));
            Console.WriteLine($"GlossSee    : {entry.GlossSee}");
        }
    }
}

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

public class Address
{
    public string? streetAddress { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
}

public class Course
{
    public string? code { get; set; }
    public string? name { get; set; }
}

public class DataMahasiswa2311104076
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? gender { get; set; }
    public int age { get; set; }
    public Address? address { get; set; }
    public List<Course>? courses { get; set; }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_3_2311104076.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' tidak ditemukan.");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<DataMahasiswa2311104076>(jsonData, options);

        Console.WriteLine("=== Data Mahasiswa ===");
        Console.WriteLine($"Nama       : {data?.firstName} {data?.lastName}");
        Console.WriteLine($"Gender     : {data?.gender}");
        Console.WriteLine($"Usia       : {data?.age}");
        Console.WriteLine($"Alamat     : {data?.address?.streetAddress}, {data?.address?.city}, {data?.address?.state}");

        Console.WriteLine("Mata Kuliah:");
        if (data?.courses != null)
        {
            foreach (var course in data.courses)
            {
                Console.WriteLine($"  - {course.code}: {course.name}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Kamu bisa panggil salah satu saja atau dua-duanya
        GlossaryItem2311104076.ReadJSON();
        Console.WriteLine();
        DataMahasiswa2311104076.ReadJSON();
    }
}
