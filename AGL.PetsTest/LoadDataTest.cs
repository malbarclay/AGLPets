using AGL.Pets.Data;
using AGL.Pets.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGLPetsTest
{
    [TestClass]
    public class LoadDataTest
    {
        [TestMethod]
        public void LoadPetOwnerData_CountOwners_Test()
        {
            var context = new DataContext();
            var owners = context.GetPetOwners();

            Assert.IsTrue(owners.Count == 6);
        }

        [TestMethod]
        public void LoadPetOwnerData_Record_Test()
        {
            var context = new DataContext();
            var owners = context.GetPetOwners();

            Assert.IsTrue(owners[5].Name == "Alice");
            Assert.IsTrue(owners[5].Gender == Gender.Female);
            Assert.IsTrue(owners[5].Age == 64);
            Assert.IsTrue(owners[5].Pets.Count == 2);
            Assert.IsTrue(owners[5].Pets[1].Name == "Nemo");
            Assert.IsTrue(owners[5].Pets[1].Type == "Fish");
        }
    }
}
