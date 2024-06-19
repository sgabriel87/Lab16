
using Car.Models;


using (var context = new CarDbContext())
{
    context.Database.EnsureCreated();
if (!context.Cars.Any())
    {
        var cars = new List<CarModel>
            {
                new CarModel { Name = "Model S", ChassisNumber = "ABC123", YearOfManufacture = 2020, Manufacturer = "Tesla" },
                new CarModel { Name = "Camry", ChassisNumber = "XYZ789", YearOfManufacture = 2018, Manufacturer = "Toyota" },
                new CarModel { Name = "Civic", ChassisNumber = "DEF456", YearOfManufacture = 2019, Manufacturer = "Honda" },
                new CarModel { Name = "Accord", ChassisNumber = "GHI789", YearOfManufacture = 2017, Manufacturer = "Honda" },
                new CarModel { Name = "Mustang", ChassisNumber = "JKL012", YearOfManufacture = 2021, Manufacturer = "Ford" }
                
            };
context.Cars.AddRange(cars);
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Database already seeded with cars. Skipping seeding process.");
    }
}

using (var context = new CarDbContext())
{
    var cars = context.Cars.OrderByDescending(c => c.YearOfManufacture).ToList();

    Console.WriteLine("Cars ordered by Year of Manufacture (descending):");
    foreach (var car in cars)
    {
        Console.WriteLine($"{car.Name} - {car.Manufacturer} ({car.YearOfManufacture})");
    }
    DeleteCarById(24);
}

var hondaCars = GetCarsByManufacturer("Honda");
Console.WriteLine("Honda cars:");
foreach (var car in hondaCars)
{
    Console.WriteLine($"{car.Name} - {car.ChassisNumber} ({car.YearOfManufacture})");
}

static int AddCar(string name, string chassisNumber, int yearOfManufacture, string manufacturer)
{
    using (var context = new CarDbContext())
    {

        var existingCar = context.Cars.FirstOrDefault(c => c.ChassisNumber == chassisNumber);
        if (existingCar != null)
        {
            Console.WriteLine($"A car with chassis number {chassisNumber} already exists.");
            return existingCar.Id; 
        }

        var newCar = new CarModel
        {
            Name = name,
            ChassisNumber = chassisNumber,
            YearOfManufacture = yearOfManufacture,
            Manufacturer = manufacturer
        };

        context.Cars.Add(newCar);
        context.SaveChanges();

        return newCar.Id;
    }
}

static List<CarModel> GetCarsByManufacturer(string manufacturer)
{
    using (var context = new CarDbContext())
    {
        var cars = context.Cars.Where(c => c.Manufacturer == manufacturer).ToList();
        return cars;
    }
}

static void DeleteCarById(int id)
{
    using (var context = new CarDbContext())
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == id);
        if (car != null)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
            Console.WriteLine($"Car with ID {id} has been deleted.");
        }
        else
        {
            Console.WriteLine($"Car with ID {id} not found.");
        }
    }
}