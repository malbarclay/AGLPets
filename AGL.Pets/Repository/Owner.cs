using System.Collections.Generic;

namespace AGL.Pets.Repository
{
    public class Owner
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

}
