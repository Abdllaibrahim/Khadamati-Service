using Azure.Core;
using Khadamati.BLL.DTO.Service.ChildDto;
using Khadamati.DAL;
namespace Khadamati.BLL;
public class ServiceManager : IServiceManager
{
    private readonly IUnitofWork unitofWork;

    public ServiceManager(IUnitofWork serviceRepo)
    {
        unitofWork = serviceRepo;
    }
    public void Add(AddServiceDTO serviceDTO)
    {
        var service=new Service
        {
          Name=serviceDTO.Name,
          Price=serviceDTO.Price,
          Location=serviceDTO.Location,
          Description=serviceDTO.Description,
          date=DateTime.Now,
          ProviderId=serviceDTO.providerId,
          CategoryId=serviceDTO.CategoryID,
        };
        unitofWork.ServiceRepo.Add(service);
        unitofWork.ServiceRepo.SaveDbChange();
    }

    public void DeleteById(int id)
    {
        Service s = unitofWork.ServiceRepo.GetDetailsById(id);
        List<Picture>PICS= s.Pictures.ToList();
        List<Rating> ratings = s.Ratings.ToList();
        List<ServiceRequest> requests = s.Requests.ToList();
        List<BookMark> bookMarks = s.BookMarks.ToList();
        foreach (Picture p in PICS)
        {
            unitofWork.PictureRepo.RemoveEntity(p);
        }
        foreach (Rating r in ratings)
        {
            unitofWork.RatingRepo.RemoveEntity(r);
        }
        foreach (BookMark b in bookMarks)
        {
            unitofWork.BookmarkRepo.RemoveEntity(b);
        }
        foreach (ServiceRequest r in requests)
        {
            unitofWork.RequestRepo.RemoveEntity(r);
        }
        unitofWork.ServiceRepo.DeleteById(id);
        unitofWork.ServiceRepo.SaveDbChange();
    }
    public void Addpicture(PictureAddDto pictureAdd)
    {
        unitofWork.PictureRepo.Add(
            new Picture() { Url = pictureAdd.Url, ServiceId = pictureAdd.ServiceId }
            ); 
    }
    public void RemovePicture(int id)
    {
        unitofWork.PictureRepo.Remove( id );
    }
    public void UpdatePicture(PictureUpdateDTO updateDTO)
    {
        unitofWork.PictureRepo.GetbyID(updateDTO.id).Url=updateDTO.Url;
    }
    public List<GetAllServicesDTO> GetAll()
    {
        List<Service>services= unitofWork.ServiceRepo.GetAll();
        return services.Select(s=>new GetAllServicesDTO
        {
          Name=s.Name,
          Price=s.Price,
          Location=s.Location,
          Rating=s.Rating,
          date=s.date,
          Description=s.Description,
          ProviderID=s.ProviderId
        }).ToList();
    }

    public List<GetAllServicesDetailsDTO> GetAllDetails()
    {
        List<Service> services= unitofWork.ServiceRepo.GetAllDetails();
        return services.Select(s=> new GetAllServicesDetailsDTO
        {
           Name=s.Name,
           Price=s.Price,
           Location=s.Location,
           Rating=s.Rating,
           Description=s.Description,
           date=s.date,
           ProviderId=s.ProviderId,
           ProviderName=s.Provider.UserName,
           ProviderPhone=s.Provider.PhoneNumber,
           CategoryName=s.Category.Name,
           pictures=s.Pictures.Select(p=>new GetAllPicturesDTO
           {
             Id=p.Id,
             Url=p.Url
           }).ToList(),
           ratings=s.Ratings.Select(r=>new GetAllRatingsDTO
           {
             Id=r.Id,
             UserId=r.UserId,
             Comment=r.Comment,
             rating=r.rating,
             date=r.date
           }).ToList()
           
        }).ToList();
    }

    public GetServiceByIdDTO? GetById(int id)
    {
        var service= unitofWork.ServiceRepo.GetById(id);
        return new GetServiceByIdDTO
        {
            Name=service.Name,
            Price=service.Price,
            Location=service.Location,
            Rating=service.Rating,
            Description=service.Description,
            date=service.date
        };
    }

    public GetServiceDetailsByIdDTO? GetDetailsById(int id)
    {
        var service= unitofWork.ServiceRepo.GetDetailsById(id);
        return new GetServiceDetailsByIdDTO
        {
            Name=service.Name,
            Price=service.Price,
            Location=service.Location,
            Rating=service.Rating,
            Description=service.Description,
            date=service.date,
            ProviderId=service.Provider.Id,
            ProviderName=service.Provider.UserName,
            ProviderPhone=service.Provider.PhoneNumber,
            CategoryName=service.Category.Name,
            pictures=service.Pictures.Select(p=> new GetAllPicturesDTO
            {
              Id=p.Id,
              Url=p.Url
            }).ToList(),
            ratings=service.Ratings.Select(r=>new GetAllRatingsDTO
            {
                Id=r.Id,
                UserId=r.UserId,
                Comment=r.Comment,
                rating=r.rating,
                date=r.date
            }).ToList()
        };
    }


    public bool Update(UpdateServiceDTO serviceDTO)
    {
       var service= unitofWork.ServiceRepo.GetById(serviceDTO.Id);
       if(service==null)
       {
        return false;
       }
       service.Name=serviceDTO.Name;
       service.Price=serviceDTO.Price;
       service.Location=serviceDTO.Location;
       service.Description=serviceDTO.Description;

        unitofWork.ServiceRepo.SaveDbChange();
       return true;
    }
}