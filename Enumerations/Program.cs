#region WORKER
using Enumerations.Entities;
using Enumerations.Entities.Enums;
using System.Globalization;

Console.Write("Enter department's name: ");
string departmentName = Console.ReadLine();

Console.WriteLine("Enter worker's data: ");
Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Level, type as it is: (Junior/MidLevel/Senior): ");
WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base Salary: ");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Department department = new(departmentName);

Worker worker = new(name, workerLevel, baseSalary, department);

Console.Write("How many contracts are assigned to this worker? ");
int numberOfContracts = int.Parse(Console.ReadLine());

for (int i = 1; i <= numberOfContracts; i++)
{
    Console.WriteLine($"Enter the #{i} contract data");

    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Console.Write("Duration (hours): ");
    int duration = int.Parse(Console.ReadLine());

    var contractToAdd = new HourContract(date, valuePerHour, duration);

    worker.AddContract(contractToAdd);
}

Console.WriteLine();

Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string[] monthAndYear = Console.ReadLine().Split('/');
int month = int.Parse(monthAndYear[0]);
int year = int.Parse(monthAndYear[1]);
double totalIncome = worker.Income(month, year);

Console.WriteLine($"Name: {worker.Name}");
Console.WriteLine($"Department: {worker.Department.Name}");
Console.WriteLine($"Income for {monthAndYear[0]}/{monthAndYear[1]}: {totalIncome}");

#endregion