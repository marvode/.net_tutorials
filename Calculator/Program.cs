

var linqClass = new Linq.Linq();

var employeeData = linqClass.GroupByNameFirstCharacter();

foreach (var employee in employeeData)
{
    Console.WriteLine(employee);
}