using Khadamati.BLL.DTO.Request;
namespace Khadamati.BLL;

public interface IRequestmanager
{
    int Add(RequestAddDTO request);

    bool Update(RequestUpdateDTO request);
    
    bool Delete(int id);

    List<RequestDetailsDTO> GetbyUserId(string UserId);

    List<RequestDetailsDTO> GetbyIdDetails(int DetailsId);

    List<RequestDetailsDTO> GetbyProviderId(string ProviderId);
}
