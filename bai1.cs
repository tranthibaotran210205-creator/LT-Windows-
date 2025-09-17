using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();

        Console.Write("Nhap so luong hoc sinh: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thong tin hoc sinh thu {i + 1}:");
            Student s = new Student();

            Console.Write("Ma so hoc sinh: ");
            s.Id = int.Parse(Console.ReadLine());

            Console.Write("Ten hoc sinh: ");
            s.Name = Console.ReadLine();

            Console.Write("Tuoi hoc sinh: ");
            s.Age = int.Parse(Console.ReadLine());

            students.Add(s);
        }

        // a. In danh sach hoc sinh
        Console.WriteLine("\nDanh sach hoc sinh:");
        students.ForEach(s => Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}"));

        // b. Tim hoc sinh tuoi 15-18
        var hs15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
        Console.WriteLine("\nHoc sinh tuoi 15-18:");
        foreach (var s in hs15to18)
            Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

        // c. Tim hoc sinh ten bat dau bang A
        var hsA = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("\nHoc sinh ten bat dau bang A:");
        foreach (var s in hsA)
            Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

        // d. Tong tuoi
        int tongTuoi = students.Sum(s => s.Age);
        Console.WriteLine($"\nTong tuoi hoc sinh: {tongTuoi}");

        // e. Hoc sinh co tuoi lon nhat
        int maxAge = students.Max(s => s.Age);
        var hsMaxTuoi = students.Where(s => s.Age == maxAge);
        Console.WriteLine("\nHoc sinh co tuoi lon nhat:");
        foreach (var s in hsMaxTuoi)
            Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");

        // f. Sap xep tang dan theo tuoi
        var sapXep = students.OrderBy(s => s.Age);
        Console.WriteLine("\nDanh sach hoc sinh sau khi sap xep theo tuoi:");
        foreach (var s in sapXep)
            Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
    }
}
