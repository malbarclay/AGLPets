using System.Collections.Generic;
using System.Linq;
using AGL.Pets.Data;

namespace AGL.Pets.Repository
{
    public class PetOwnerRepository : IPetOwnerRepository
    {
        public IDataContext DataContext { get; set; }

        public PetOwnerRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Dictionary<Gender, List<Pet>> GetCatsByOwnerGender()
        {
            var owners = DataContext.GetPetOwners();

            var genderGroups = owners.Where(p => p.Pets != null).GroupBy(x => x.Gender);

            return genderGroups.ToDictionary(g => g.Key, g => g.SelectMany(x => x.Pets).Where(p => p.Type == "Cat").OrderBy(n => n.Name).ToList());
        }
    }
}
