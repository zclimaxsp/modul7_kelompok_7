using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

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
}

class Program
{
    static void Main()
    {
        ReadJSON();
    }

    static void ReadJSON()
    {
        string filePath = "jurnal7_1_2311104076.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' tidak ditemukan.");
            return;
        }

        string jsonData = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

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