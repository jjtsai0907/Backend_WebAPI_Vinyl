using WebApplication1.DTOs;
using WebApplication1.NewFolder;

namespace WebApplication1.NewFolder1
{
    public interface IVinylRepo
    {
        List<Vinyl> GetAll();

        Vinyl GetByID(int id);

        Vinyl CreateVinyl(CreateVinylDTO vinyl);

        Vinyl UpdateVinyl(Vinyl vinyl);

        void DeleteVinyl(int id);


    }
}
