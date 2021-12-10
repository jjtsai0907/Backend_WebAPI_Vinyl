using WebApplication1.NewFolder;

namespace WebApplication1.NewFolder1
{
    public interface IVinylRepo
    {
        List<Vinyl> GetAll();

        Vinyl GetByID(int id);

        Vinyl CreateVinyl(Vinyl vinyl);

        Vinyl UpdateVinyl(Vinyl vinyl);

        void DeleteVinyl(int id);


    }
}
