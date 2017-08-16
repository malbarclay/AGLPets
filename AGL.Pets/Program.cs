using System;
using System.Collections.Generic;
using AGL.Pets.Data;
using AGL.Pets.Repository;
using Autofac;

namespace AGL.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<PetOwnerRepository>().As<IPetOwnerRepository>();
            var container = builder.Build();
            var petRepository = container.Resolve<IPetOwnerRepository>();

            ViewCatsByGender(petRepository.GetCatsByOwnerGender());
            Console.ReadLine();
        }

        static void ViewCatsByGender(Dictionary<Gender, List<Pet>> owners)
        {
            foreach (var owner in owners)
            {
                Console.WriteLine(owner.Key);
                foreach (var pet in owner.Value)
                {
                    Console.WriteLine("\t{0}", pet.Name);
                }
            }

        }
    }
}

