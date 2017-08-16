using System.Collections.Generic;
using System.Linq;
using AGL.Pets.Data;
using AGL.Pets.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AGLPetsTest
{
    [TestClass]
    public class PetOwnerRepositoryTest
    {
        [TestMethod]
        public void CatsByOwnerGender_Count_Test()
        {
            Mock<IDataContext> repMock = new Mock<IDataContext>();

            repMock.Setup(r => r.GetPetOwners()).Returns(TestOwnerData);

            var rep = new PetOwnerRepository(repMock.Object);
            var cats = rep.GetCatsByOwnerGender();

            Assert.IsTrue(GetCatList(cats, Gender.Male).Count == 2);
            Assert.IsTrue(GetCatList(cats, Gender.Female).Count == 2);
        }

        [TestMethod]
        public void CatsByOwnerGender_Gender_Test()
        {
            Mock<IDataContext> repMock = new Mock<IDataContext>();

            repMock.Setup(r => r.GetPetOwners()).Returns(TestOwnerData);
                
            var rep = new PetOwnerRepository(repMock.Object);
            var cats = rep.GetCatsByOwnerGender();

            Assert.IsTrue(cats.Keys.ToList()[0] == Gender.Male);
            Assert.IsTrue(cats.Keys.ToList()[1] == Gender.Female);
        }

        [TestMethod]
        public void CatsByOwnerGender_Sorted_Test()
        {
            Mock<IDataContext> repMock = new Mock<IDataContext>();

            repMock.Setup(r => r.GetPetOwners()).Returns(TestOwnerData);

            var rep = new PetOwnerRepository(repMock.Object);
            var cats = rep.GetCatsByOwnerGender();
            

            Assert.IsTrue(GetCatList(cats, Gender.Male)[0].Name == "Ace");
            Assert.IsTrue(GetCatList(cats, Gender.Male)[1].Name == "Zac");

            Assert.IsTrue(GetCatList(cats, Gender.Female)[0].Name == "Alistair");
            Assert.IsTrue(GetCatList(cats, Gender.Female)[1].Name == "Sebastian");
        }

        [TestMethod]
        public void CatsByOwnerGender_Null_Test()
        {
            Mock<IDataContext> repMock = new Mock<IDataContext>();

            repMock.Setup(r => r.GetPetOwners()).Returns(new List<Owner>());

            var rep = new PetOwnerRepository(repMock.Object);
            var cats = rep.GetCatsByOwnerGender();

            Assert.IsTrue(cats.Count == 0);
        }

        [TestMethod]
        public void CatsByOwnerGender_NoCats_Test()
        {
            Mock<IDataContext> repMock = new Mock<IDataContext>();

            repMock.Setup(r => r.GetPetOwners()).Returns(TestOwnerData_NoCats);

            var rep = new PetOwnerRepository(repMock.Object);
            var cats = rep.GetCatsByOwnerGender();

            Assert.IsTrue(GetCatList(cats, Gender.Male).Count == 0);
            Assert.IsTrue(GetCatList(cats, Gender.Female).Count == 0);
        }

        // Helper method to pull the list of cats from the dictionary by owner gender
        private List<Pet> GetCatList(Dictionary<Gender, List<Pet>> cats, Gender gender)
        {
            List<Pet> pets;
            cats.TryGetValue(gender, out pets);
            return pets;
        }

        public List<Owner> TestOwnerData()
        {
            return new List<Owner>()
            {
                new Owner()
                {
                    Gender = Gender.Male,
                    Age = 34,
                    Name = "John",
                    Pets = new List<Pet>()
                    {
                        new Pet() {Name = "Fluffy", Type = "Dog"},
                        new Pet() {Name = "Zac", Type = "Cat"}
                    }
                },
                new Owner()
                {
                    Gender = Gender.Female,
                    Age = 21,
                    Name = "Grace",
                    Pets = new List<Pet>()
                    {
                        new Pet() {Name = "Russell", Type = "Dog"}
                    }
                },
                new Owner()
                {
                    Gender = Gender.Male,
                    Age = 38,
                    Name = "Aaron",
                    Pets = new List<Pet>()
                    {
                        new Pet() {Name = "Ace", Type = "Cat"}
                    }
                },
                new Owner()
                {
                    Gender = Gender.Female,
                    Age = 60,
                    Name = "John",
                    Pets = new List<Pet>()
                    {
                        new Pet() {Name = "Tweety", Type = "Bird"},
                        new Pet() {Name = "Sebastian", Type = "Cat"},
                        new Pet() {Name = "Alistair", Type = "Cat"}
                    }
                }
            };

        }

        public List<Owner> TestOwnerData_NoCats()
        {
            return new List<Owner>()
            {             
                new Owner()
                {
                    Gender = Gender.Female,
                    Age = 21,
                    Name = "Grace",
                    Pets = new List<Pet>()
                    {
                        new Pet() {Name = "Russell", Type = "Dog"}
                    }
                },
                new Owner()
                {
                    Gender = Gender.Male,
                    Age = 38,
                    Name = "Aaron",
                    Pets = new List<Pet>()
                }

            };
        }
    }
}
