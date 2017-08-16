using System.Collections.Generic;
using AGL.Pets.Repository;

namespace AGL.Pets.Data
{
    public interface IDataContext
    {
        List<Owner> GetPetOwners();
    }
}
