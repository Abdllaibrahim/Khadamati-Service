namespace Khadamati.DAL;
public class GenericRepo<Tentity> : IGenericRepos<Tentity>
        where Tentity : class
{
    KhadamatiContext KhadamatiContext { get; set; }
    public GenericRepo(KhadamatiContext context)
    {
        KhadamatiContext = context;
    }
    public List<Tentity> GetAll()
    {
        return KhadamatiContext.Set<Tentity>().ToList();
    }
    public Tentity GetbyID(int id)
    {
        return KhadamatiContext.Set<Tentity>().Find(id);
    }
    public void Add(Tentity entity)
    {
        KhadamatiContext.Set<Tentity>().Add(entity);
    }
    public void Remove(int id)
    {
        Tentity? t = KhadamatiContext.Set<Tentity>().Find(id);
        if (t != null)
        { KhadamatiContext.Set<Tentity>().Remove(t); }  
    }
    public void RemoveEntity(Tentity tentity)
    {
        { KhadamatiContext.Set<Tentity>().Remove(tentity); }
    }
    public void Update(Tentity entity)
    {
      KhadamatiContext.Set<Tentity>().Update(entity);
    }
    public int SaveChanges()
    {
        return KhadamatiContext.SaveChanges();
    }

   
}

