namespace Linq;

public class Linq
{
    private readonly IEnumerable<Employee> Employees = new Employee[]
    {
        new()
        {
            Id = "1",
            Name = "John Doe",
            Position = "Program Manager"
        },
        new()
        {
            Id = "2",
            Name = "Jane Doe",
            Position = "Facility Manager"
        },
        new()
        {
            Id = "3",
            Name = "Chris Mark",
            Position = "Node Dev"
        },
        new()
        {
            Id = "4",
            Name = "Pamela Houston",
            Position = "Java Dev"
        },
        new()
        {
            Id = "1",
            Name = "Abraham Lincoln",
            Position = ".NET Dev"
        },
    };

    private readonly IEnumerable<Pay> Pays = new Pay[]
    {
        new()
        {
            EmployeeId = "1",
            Salary = 200000m
        },
        new()
        {
            EmployeeId = "2",
            Salary = 100000m
        },
        new()
        {
            EmployeeId = "3",
            Salary = 300000m
        },
        new()
        {
            EmployeeId = "4",
            Salary = 350000m
        },
        new()
        {
            EmployeeId = "5",
            Salary = 400000m
        },
    };

    public IEnumerable<Employee> EmployeesWithGivenId(string employeeId)
    {
        var employeeList = new List<Employee>();

        foreach (var employee in Employees)
        {
            if (employee.Id == employeeId)
            {
                employeeList.Add(employee);
            }
        }

        return employeeList;
    }

    public IEnumerable<Employee> EmployeesWithGivenIdLinq(string employeeId)
    {
        var employeeList = Employees.Where(employee => employee.Id == employeeId);

        return employeeList;
    }

    public Employee? FindEmployeeById(string employeeId)
    {
        foreach (var employee in Employees)
        {
            if (employee.Id == employeeId)
            {
                return employee;
            }
        }

        return null;
    }

    public Employee? FindEmployeeByIdLinq(string employeeId)
    {
        var employee = Employees.Where(employee => employee.Id == employeeId).FirstOrDefault();

        return employee;
    }

    public IEnumerable<Employee> SortEmployeesByName()
    {
        return Employees.OrderBy(employee => employee.Name).ToList();
    }

    public IEnumerable<object> JoinData()
    {
        return Employees.Join(Pays, employee => employee.Id, pay => pay.EmployeeId, (employee, pay) => new
        {
            Id = employee.Id,
            Name = employee.Name,
            Position = employee.Position,
            Salary = pay.Salary
        });
    }

    public IEnumerable<object> GroupByNameFirstCharacter()
    {
        return Employees.GroupBy(employee => employee.Name[0]).Select(x => new
        {
            Character = x.Key,
            Employees = x
        });
    }
}