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
    void Addpicture(PictureAddDto pictureAdd);
    void RemovePicture(int id);
    void UpdatePicture(PictureUpdateDTO updateDTO);
}