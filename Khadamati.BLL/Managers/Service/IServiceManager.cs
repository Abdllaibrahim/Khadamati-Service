using Khadamati.BLL.DTO.Service.ChildDto;

namespace Khadamati.BLL;
public interface IServiceManager
{
    List<GetAllServicesDTO> GetAll();
    List<GetAllServicesDetailsDTO> GetAllDetails();
    GetServiceByIdDTO? GetById(int id);
    void Add(AddServiceDTO service);
    bool Update(UpdateServiceDTO service);
    void DeleteById(int id);
    GetServiceDetailsByIdDTO? GetDetailsById(int id);
    List<GetSpecificServicesDetailsDTO> GetSpecificDetails(string loction, string categoryName);
    bool approve(int id);
    List<GetAllServicesDetailsDTO> GetSearch(string loction, string categoryName);
}