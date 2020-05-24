using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualPet
{
    public class Shelter
    {
        private Guid id = Guid.NewGuid();
        public string Name { get; private set; }
        private List<Pet> containedPets = new List<Pet>();

        public System.Collections.ObjectModel.ReadOnlyCollection<Pet> AllPets
        { get { return containedPets.AsReadOnly(); } }

        public bool HasPet(string petName)
        {

            var myPet = containedPets.FirstOrDefault(x => x.Name == petName);

            return myPet != null;

        }

        public Shelter(string shelterName)
        {
            if (string.IsNullOrEmpty(shelterName))
                throw new Exception("Shelter name is null and not permitted");

            this.Name = shelterName;
        }

        public void AdoptPet(int petToRemove)
        {
            Pet myPet = containedPets[petToRemove];
            containedPets.Remove(myPet);
            Console.WriteLine("Pet was successfully adopted from the shelter: " + myPet.Name);
        }

        public void AdoptPet(string petToRemove)
        {
            var myPet = containedPets.FirstOrDefault(x => x.Name == petToRemove);
            containedPets.Remove(myPet);
            Console.WriteLine("Pet was successfully adopted from the shelter: " + myPet.Name);
        }

        public void AddPet(String petName)
        {
            this.containedPets.Add(new Pet(petName));
            Console.WriteLine("Pet was successfully added: " + petName);
        }

        public string DisplayPetsForAdoption()
        {
            string petList = "";
            foreach (Pet pet in containedPets)
                petList += pet.Name + Environment.NewLine;

            Console.WriteLine(petList);

            return petList;
                
        }

        public int AllAnimalHungerLevel
        {

            get
            {

                return this.containedPets.Sum(x => x.LevelHunger);


            }


        }


        public void GetAllAnimalStatus()
        {

            foreach (Pet pet in containedPets)
                pet.GetStatus();
                    
                    }


        public void FeedPets()
        {
            foreach (Pet pet in containedPets)
            {
                Console.WriteLine("Feeding pet: " + pet.Name);
                pet.Feed();
            }
        }

        public void PlayWithPets()
        {
            foreach (Pet pet in containedPets)
            {
                Console.WriteLine("Playing with pet: " + pet.Name);
                pet.Play();
            }
        }

        public void HealthCheckPets()
        {
            foreach (Pet pet in containedPets)
            {
                Console.WriteLine("Dr Poll is now checking on: " + pet.Name);
                pet.SeeDoctor();
            }
        }

        public void DisplayPetStatus(int petIndex)
        {


            this.containedPets[petIndex].GetStatus();

        }

        public void PerformActivity(int petIndex, int petActivity)
        {
            Pet selectedPet = this.containedPets[petIndex];

            switch (petActivity)
            {

                case 1:
                    selectedPet.Feed();
                    break;

                case 2:
                    selectedPet.Play();
                    break;
                case 3:
                    selectedPet.SeeDoctor();
                    break;
                case 4:
                    selectedPet.Rest();
                    break;
                default:
                    Console.WriteLine("Invalid selection made");
                    break;

            }



        }
    }
}