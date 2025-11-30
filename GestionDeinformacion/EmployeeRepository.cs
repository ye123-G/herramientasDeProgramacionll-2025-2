using Dapper;
using MySql.Data.MySqlClient;

public class EmployeeRepository : IEmployeePort
{
    private readonly string connectionString;

    public EmployeeRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Employee FindByDocument(string documentNumber)
    {
        using var connection = new MySqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employee WHERE DocumentNumber = @DocumentNumber",
            new { DocumentNumber = documentNumber });
    }

    public Employee FindByUserName(string userName)
    {
        using var connection = new MySqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employee WHERE UserName = @UserName",
            new { UserName = userName });
    }

    public void Save(Employee employee)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Execute(
            @"INSERT INTO Employee (FullName, DocumentNumber, Email, Phone, BirthDate, Address, Role, UserName, PasswordHash, Active)
              VALUES (@FullName, @DocumentNumber, @Email, @Phone, @BirthDate, @Address, @Role, @UserName, @PasswordHash, @Active)",
            employee);
    }

    public bool ExistsDocument(string documentNumber)
    {
        using var connection = new MySqlConnection(connectionString);
        return connection.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM Employee WHERE DocumentNumber = @DocumentNumber",
            new { DocumentNumber = documentNumber }) > 0;
    }

    public bool ExistsUserName(string userName)
    {
        using var connection = new MySqlConnection(connectionString);
        return connection.ExecuteScalar<int>(
            "SELECT COUNT(1) FROM Employee WHERE UserName = @UserName",
            new { UserName = userName }) > 0;
    }

    public IEnumerable<Employee> GetAll()
    {
        using var connection = new MySqlConnection(connectionString);
        return connection.Query<Employee>("SELECT * FROM Employee");
    }

    public void Deactivate(string documentNumber)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Execute(
            "UPDATE Employee SET Active = 0 WHERE DocumentNumber = @DocumentNumber",
            new { DocumentNumber = documentNumber });
    }

    public void Update(Employee employee)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Execute(
            @"UPDATE Employee SET FullName = @FullName, Email = @Email, Phone = @Phone, BirthDate = @BirthDate, 
              Address = @Address, Role = @Role, UserName = @UserName, PasswordHash = @PasswordHash, Active = @Active
              WHERE DocumentNumber = @DocumentNumber",
            employee);
    }
}

// Definición mínima de Employee para evitar CS0246
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string DocumentNumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Role { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public bool Active { get; set; }
    public string DisplayName { get; internal set; }
    public Dictionary<string, object> AdditionalData { get; internal set; }

   
}
