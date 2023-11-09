namespace Khadamati.DAL
{
    public class PictureRepo : GenericRepo<Picture>,IPictureRepo
    {
        public PictureRepo(KhadamatiContext context) : base(context)
        {
        }
    }
}
