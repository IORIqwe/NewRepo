using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

struct Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }

    Employee(string name, string position, DateTime hireDate)
    {
        Name = name;
        Position = position; 
        HireDate = hireDate;
    }
}

class Program
{
    static List<Employee> ReadEmployeesFromXml(string filePath)
    {
        XDocument doc = XDocument.Load(filePath);
        return doc.Descendants("Employee")
                  .Select(x => new Employee
                  {
                      Name = x.Element("Name")?.Value,
                      Position = x.Element("Position")?.Value,
                      HireDate = DateTime.Parse(x.Element("HireDate")?.Value)
                  })
                  .ToList();
    }

    static void WriteEmployeesToXml(List<Employee> employees, string filePath)
    {
        XDocument doc = new XDocument(
            new XElement("Employees",
                employees.Select(e =>
                    new XElement("Employee",
                        new XElement("Name", e.Name),
                        new XElement("Position", e.Position),
                        new XElement("HireDate", e.HireDate.ToString("yyyy-MM-dd"))
                    )
                )
            )
        );
        doc.Save(filePath);
    }

    static void WriteEmployeesToText(List<Employee> employees, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var employee in employees)
            {
                writer.WriteLine($"Name: {employee.Name} Position: {employee.Position} HireDate: {employee.HireDate:yyyy-MM-dd}");
            }
        } 
    }

    static void Main()
    {
        string inputFilePath = "employees.xml";
        string outputXmlFilePath = "sorted_employees.xml";
        string outputTextFilePath = "employees.txt";

        List<Employee> employees = ReadEmployeesFromXml(inputFilePath);

        var sortedEmployees = employees.OrderBy(e => e.HireDate).ToList();

        WriteEmployeesToXml(sortedEmployees, outputXmlFilePath);

        WriteEmployeesToText(sortedEmployees, outputTextFilePath);

        Console.WriteLine("Successfully !");
    }
}
