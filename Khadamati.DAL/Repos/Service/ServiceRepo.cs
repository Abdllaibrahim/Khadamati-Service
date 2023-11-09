

using Microsoft.EntityFrameworkCore;

namespace Khadamati.DAL;
public class ServiceRepo : IServiceRepo
{
    private readonly KhadamatiContext _context;

    public ServiceRepo(KhadamatiContext context)
    {
      _context=context;
    }

    public List<Service> GetAll()
    {
        return _context.Set<Service>().ToList();   
    }

    public List<Service> GetAllDetails()
    {
       return _context.Set<Service>()
            .Include(s=>s.Provider)
            .Include(s=>s.Category)
            .Include(s=>s.Pictures)
            .Include(s=>s.Ratings)
            .Include(s=>s.Requests)
            .Include(s=>s.BookMarks)
            .ToList();
        
    }

    public Service? GetById(int id)
    {
        return _context.Set<Service>().Find(id);
    }

    public Service? GetDetailsById(int id)
    {
       return _context.Set<Service>()
            .Include(s=>s.Provider)
            .Include(s=>s.Category)
            .Include(s=>s.Pictures)
            .Include(s=>s.Ratings)
            .Include(s=>s.Requests)
            .Include(s=>s.BookMarks)
            .FirstOrDefault(s=>s.Id==id);      
    }

    public void Add(Service service)
    {
        _context.Set<Service>().Add(service);
    }

    public void DeleteById(int id)
    {
        var service = _context.Set<Service>().Find(id);
        _context.Set<Service>().Remove(service);
    }

    public void Update(Service service)
    {
        _context.Set<Service>().Update(service);
    }
    public int SaveDbChange()
    {
       return _context.SaveChanges();
    }

}