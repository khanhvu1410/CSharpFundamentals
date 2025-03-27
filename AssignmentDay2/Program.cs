﻿using System.Globalization;

namespace AssignmentDay2;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            var make = GetValidString("Enter car make: ");
            var model = GetValidString("Enter car model: ");
            Console.WriteLine();
            var year = GetValidYear("Enter car year (e.g., 2020): ");
            Console.WriteLine();
            var lastMaintenanceDate = GetValidDate("Enter last maintenance date (yyyy-MM-dd): ", year);
            var type = GetValidCarType("Is this a FuelCar or ElectricCar? (F/E): ");
            Car car;

            if (type == CarType.Fuel)
            {
                car = new FuelCar
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    Type = type,
                    LastMaintenanceDate = lastMaintenanceDate
                };
                car.DisplayDetails();
                RefuelOrChargeCar(car);
            } 
            else if (type == CarType.Electric)
            {
                car = new ElectricCar
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    Type = type,
                    LastMaintenanceDate = lastMaintenanceDate
                };
                car.DisplayDetails();
                RefuelOrChargeCar(car);
            }

            Console.WriteLine();
        }   
    }

    private static void RefuelOrChargeCar(Car car)
    {
        var choice = GetValidRefuelChoice("Do you want to refuel/charge? (Y/N): ");
        Console.WriteLine();

        if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            var refuelDate = GetValidDate("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ", car.Year, true);
            if (car is FuelCar fuelCar)
            {
                fuelCar.Refuel(refuelDate);
            }
            else if (car is ElectricCar electricCar)
            {
                electricCar.Charge(refuelDate);
            }
        }
    }

    // Method to validate none-empty string input
    private static string GetValidString(string message)
    {
        string? input;
        Console.Write(message);
        while(string.IsNullOrWhiteSpace(input = Console.ReadLine()?.Trim())) 
        {
            Console.WriteLine($"Invalid input. Please enter a valid value.");
            Console.Write(message);
        }
        return input;
    }

    // Method to validate year input 
    private static int GetValidYear(string message)
    {
        int result;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine()?.Trim(), out result) || result < 1886 || result > DateTime.UtcNow.Year) 
        {
            Console.WriteLine($"Invalid year! Please enter a valid year between 1886 and the current year.");
            Console.Write(message);
        }
        return result;
    }

    // Method to validate date input
    private static DateTime GetValidDate(string message, int year, bool isRefuelDate = false)
    {
        DateTime result;
        Console.Write(message);
        
        string dateFormat = "yyyy-MM-dd";
        if (isRefuelDate == true)
        {
            dateFormat = "yyyy-MM-dd HH:mm";
        }

        while (!DateTime.TryParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out result) || result.Year < year)
        {
            Console.WriteLine("Invalid date format! Please enter a valid date.");
            Console.Write(message);
        }
        return result;
    }

    // Method to validate and parse CarType input
    private static CarType GetValidCarType(string message)
    {
        var typeInput = GetValidString(message);
        while (!typeInput.Equals("F", StringComparison.OrdinalIgnoreCase)  && 
                !typeInput.Equals("E", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
            typeInput = GetValidString(message);
        }
        CarType type = typeInput.Equals("F", StringComparison.OrdinalIgnoreCase) ? CarType.Fuel : CarType.Electric;
        return type;
    }

    // Method to validate refuel choice input
    private static string GetValidRefuelChoice(string message)
    {
        var choice = GetValidString(message);
        while (!choice.Equals("Y", StringComparison.OrdinalIgnoreCase)  && !choice.Equals("N", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid choice! Please enter 'Y' for Yes or 'N' for No.");
            choice = GetValidString(message);
        }
        return choice;
    }
}
