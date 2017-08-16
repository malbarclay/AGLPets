using System.Collections.Generic;

namespace AGL.Pets.Repository
{
    public interface IPetOwnerRepository
    {
        Dictionary<Gender, List<Pet>> GetCatsByOwnerGender();
    }
}
