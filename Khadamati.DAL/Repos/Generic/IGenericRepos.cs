namespace Khadamati.DAL
{
    public interface IGenericRepos<Tentity> where Tentity : class
    {
        void Add(Tentity entity);
        List<Tentity> GetAll();
        Tentity GetbyID(int id);
        void Remove(int id);
        void RemoveEntity(Tentity tentity);
        int SaveChanges();
        void Update(Tentity entity);
    }
}