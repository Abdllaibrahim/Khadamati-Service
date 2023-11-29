namespace Khadamati.DAL
{
    public interface IPictureRepo
    {
        void Add(Picture picture);
        void Update(Picture picture);
        Picture? GetById(int id);
        int SaveDbChange();
        void Delete(Picture pic);
    }
}