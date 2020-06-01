using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            bool wasRemoved = containedPets.Remove(myPet);
            
            Console.WriteLine("Pet was successfully (t/f)" + wasRemoved + " adopted from the shelter: " + myPet.Name);
        }

        public void AdoptPet(string petToRemove)
        {
            var myPet = containedPets.FirstOrDefault(x => x.Name == petToRemove);
            containedPets.Remove(myPet);
            Console.WriteLine("Pet was successfully adopted from the shelter: " + myPet.Name);
        }

        public void AddPet(String petName, Constants.PET_TYPE petType, Constants.SPECIES_TYPE speciesType)
        {

            if (petType == Constants.PET_TYPE.INORGANIC)
                this.containedPets.Add(new PetRobot(petName, speciesType));
            else
                this.containedPets.Add(new PetOrganic(petName, speciesType));


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

                int totalHunger = 0;
                foreach (Pet myPet in containedPets)
                {
                    if (myPet is PetOrganic)
                        totalHunger += ((PetOrganic)myPet).LevelHunger;

                }

                return totalHunger;
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
                if (pet is PetOrganic)
                    ((PetOrganic)pet).Feed();
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
                if (pet is PetOrganic)
                    ((PetOrganic)pet).SeeDoctor();
            }
        }

        public void DisplayPetStatus(int petIndex)
        {


            this.containedPets[petIndex].GetStatus();

        }

        public void PerformActivity(int petIndex, int petActivity)
        {
            
            
            PetOrganic myPet = (PetOrganic)PetShelters.DefaultShelter.AllPets[petIndex];
            myPet.Play();




        }

        public void PerformActivity()
        {


            Console.WriteLine("Please select the pet you wish to update");

            for (int i = 0; i < PetShelters.DefaultShelter.AllPets.Count; i++)
                Console.WriteLine("Enter [" + i + "] for pet " + PetShelters.DefaultShelter.AllPets[i].Name);


            String petNumberInput = Console.ReadLine();
            int petNumber = -1;
            int petActivity = -1;
            bool isValid = int.TryParse(petNumberInput, out petNumber) && petNumber >= 0 && petNumber < PetShelters.DefaultShelter.AllPets.Count;


            if (!isValid)
                Console.WriteLine("You entered an invalid value: " + petNumberInput);

            else
            {
                
                
                Pet myPet = this.AllPets[petNumber];
                Console.WriteLine("Based on the pet selected you can perform the following activities....");
                //MethodInfo[] methodInfos = typeof(PetOrganic).GetMethods();

                MethodInfo[] methodInfos = myPet.GetType().GetMethods();
                for (int i = 0; i < methodInfos.Length; i++)
                {

                    Console.WriteLine("Enter: [" + i + "] for activity: " + methodInfos[i].Name);


                }

                //foreach (MethodInfo methodInfo in methodInfos)
                //    Console.WriteLine("Activity: " + methodInfo);

                Console.WriteLine("Please enter your selection");
                petNumberInput = Console.ReadLine();
                petActivity = int.Parse(petNumberInput);

                methodInfos[petActivity].Invoke(myPet, new object[] { });


            }




        }

       

      

    }
}