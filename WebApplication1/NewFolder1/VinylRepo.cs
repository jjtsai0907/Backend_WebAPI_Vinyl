using WebApplication1.NewFolder;

namespace WebApplication1.NewFolder1
{
    public class VinylRepo : IVinylRepo
    {


        private List<Vinyl> _vinyls;

        public VinylRepo()
        {
            _vinyls = PopulateVinylData();
            
        }

        public Vinyl CreateVinyl(Vinyl vinyl)
        {
            vinyl.Created = DateTime.Now;
            vinyl.Id = _vinyls.Max(x => x.Id) + 1; // to secure the id in the database, like UUID
            _vinyls.Add(vinyl);
            return vinyl;
        }

        public void DeleteVinyl(int id)
        {
            /* another way:
             * Vinyl vinyl = _vinyls.FirstOrDefault(x => x.Id == id);
             * _vinyls.Remove(vinyl);
             * */
         
            _vinyls.Remove(GetByID(id));
        }

        public List<Vinyl> GetAll()
        {
            return _vinyls;
        }

        public Vinyl GetByID(int id)
        {
            Vinyl vinyl = _vinyls.Find(x => x.Id == id);
            return vinyl;
        }

        public Vinyl UpdateVinyl(Vinyl vinyl)
        {
            Vinyl existingVinyl = _vinyls.FirstOrDefault(x => x.Id == vinyl.Id);
            if (existingVinyl is not null)
            {
                existingVinyl.Title = vinyl.Title;
                existingVinyl.Artist = vinyl.Artist;
            }
            return existingVinyl;
        }

        private List<Vinyl> PopulateVinylData()
        {
            return new List<Vinyl>
            {
                new Vinyl
                {
                  Id = 1,
                  Artist = "Nicke",
                  Title = "Appetite for destruction1",
                  Created = DateTime.Now,

                },
                new Vinyl
                {
                  Id = 2,
                  Artist = "Oscar",
                  Title = "Appetite2",
                  Created = DateTime.Now,

                },
                new Vinyl
                {
                  Id = 3,
                  Artist = "James",
                  Title = "Appetite3",
                  Created = DateTime.Now,

                },
                new Vinyl
                {
                  Id = 4,
                  Artist = "Mikael",
                  Title = "Appetite4",
                  Created = DateTime.Now,

                },
            };
        }


    }
}
