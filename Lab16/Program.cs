using Lab16.Models;
static void Seed(StudentContext context)
{
    if (!context.Students.Any())
    {
        var students = new[]
        {
                new Student { FirstName = "John", LastName = "Doe", Age = 22, Specialization = Specialization.Informatica },
                new Student { FirstName = "Jane", LastName = "Smith", Age = 21, Specialization = Specialization.Litere },
                new Student { FirstName = "Mark", LastName = "Johnson", Age = 23, Specialization = Specialization.Constructii },
                new Student { FirstName = "Emily", LastName = "Davis", Age = 20, Specialization = Specialization.Informatica },
                new Student { FirstName = "Michael", LastName = "Brown", Age = 24, Specialization = Specialization.Constructii },
                // Add more students as needed
            };

        context.Students.AddRange(students);
        context.SaveChanges();
    }
}

using (var context = new StudentContext())
{
    context.Database.EnsureCreated();
    Seed(context);

    // Display all students in alphabetical order
    var students = context.Students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
    foreach (var student in students)
    {
        Console.WriteLine($"{student.FirstName} {student.LastName}");
    }

    // Display the youngest student in construction over 20 years old
    var youngestStudent = context.Students
        .Where(s => s.Specialization == Specialization.Constructii && s.Age > 20)
        .OrderBy(s => s.Age)
        .FirstOrDefault();

    if (youngestStudent != null)
    {
        Console.WriteLine($"Youngest student in construction over 20: {youngestStudent.FirstName} {youngestStudent.LastName}, Age: {youngestStudent.Age}");
    }

    // Optional: Display summary of students in Informatica
    var informaticaStudents = context.Students
        .Where(s => s.Specialization == Specialization.Informatica)
        .Select(s => new { s.Id, s.FirstName, s.LastName })
        .ToList();

    Console.WriteLine("Informatica Students Summary:");
    foreach (var student in informaticaStudents)
    {
        Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}");
    }

    // Optional: Display students grouped by specialization
    var groupedStudents = context.Students
        .GroupBy(s => s.Specialization)
        .ToList();

    foreach (var group in groupedStudents)
    {
        Console.WriteLine($"Specialization: {group.Key}");
        foreach (var student in group)
        {
            Console.WriteLine($"- {student.FirstName} {student.LastName}");
        }
    }
}

