namespace Khadamati.DAL
{
    public interface INotificationRepo:IGenericRepos<Notification>
    {
        void AddNotification(Notification notification);
        void DeleteNotification(int id);
        void UpdateNotification(Notification notification);
        Notification GetNotificationById(int id);
        List<Notification> GetNotificationByUserId(string id);
        Notification GetNotification(int id);

    }
}
