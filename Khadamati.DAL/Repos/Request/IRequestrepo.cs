namespace Khadamati.DAL
{
    public interface IRequestrepo:IGenericRepos<ServiceRequest>
    {
        void Add(ServiceRequest request);

        ServiceRequest GetbyId(int UserId);
        List<ServiceRequest> GetbyUserId(string UserId);

        List<ServiceRequest> GetbyProviderId(string ProviderId);

        void Remove(ServiceRequest request);

        int SaveChanges();

        void Update(ServiceRequest request);

        List<ServiceRequest> GetRequestDetails(int RequestId);

    }
}
