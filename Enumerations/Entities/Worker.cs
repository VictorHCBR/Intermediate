using Enumerations.Entities.Enums;

namespace Enumerations.Entities;

public class Worker
{
    public string Name { get; set; }
    public WorkerLevel WorkerLevel { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public List<HourContract> Contracts { get; set; } = new();
    public Worker()
    {
    }

    public Worker(string name, WorkerLevel workerLevel, double baseSalary,
        Department department)
    {
        Name = name;
        WorkerLevel = workerLevel;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddContract(HourContract contract)
    {
        Contracts.Add(contract);
    }

    public void RemoveContract(HourContract contract)
    {
        if (Contracts.Count > 0)
            Contracts.Remove(contract);
    }

    public double Income(int month, int year)
    {
        double totalIncome = BaseSalary;

        foreach (var contract in Contracts)
        {
            if (contract.Date.Year == year && contract.Date.Month == month)
            {
                totalIncome += contract.TotalValue();
            }
        }

        return totalIncome;
    }
}
