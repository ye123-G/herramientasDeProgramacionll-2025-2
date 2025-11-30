public interface IEmployeePort
{
    Employee FindByDocument(string documentNumber);
    Employee FindByUserName(string userName);
    void Save(Employee employee);
    bool ExistsDocument(string documentNumber);
    bool ExistsUserName(string userName);
    IEnumerable<Employee> GetAll();
    void Deactivate(string documentNumber);
    void Update(Employee employee);
}
