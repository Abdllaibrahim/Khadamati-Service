namespace Khadamati.DAL;
public interface IServiceRepo
{
    List<Service> GetAll();
    List<Service> GetAllDetails();
    Service? GetById(int id);
    void Add(Service service);
    void Update(Service service);
    void DeleteById(int id);
    Service? GetDetailsById(int id);
    int SaveDbChange();
}