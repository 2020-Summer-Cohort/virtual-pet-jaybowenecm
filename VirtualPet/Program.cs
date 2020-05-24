using System;

namespace VirtualPet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
           Console.WriteLine("Hello! Welcome to Virtual Pets");
            RunVirtualPet();
           
        }

        private static void RunVirtualPet()
        {

            foreach (Pet pet in PetShelters.DefaultShelter.AllPets)
                Console.WriteLine("Added pet: " + pet.Name);
            

            bool cancelRequested = false;
            while (!cancelRequested)
            {
                
                Console.WriteLine("Enter A to update all pets, N to add a new pet, U to update a pet, L to list pets for adoption, P to print the status for all pets or X to close.");

                String userCommand = Console.ReadLine().ToLower();
                switch(userCommand)
                {

                    case "a":
                        ShelterAllAnimalActivities();
                        break;

                    case "x":
                        cancelRequested = true;
                        break;

                    case "l":
                        ListPetsForAdoption();
                        break;

                    case "n":
                        AddNewPet();
                        break;


                    case "u":
                        UpdatePetActivity();
                        break;

                    case "p":
                        DisplayShelterStatus();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;

                }

                    

                        
                    




            }




        }

        private static void ShelterAllAnimalActivities()
        {

            
            Console.WriteLine("Enter F to feed the pets, P to play or H to have the vet check all animals");
            String userInput = Console.ReadLine();

            if (userInput == "F")
                PetShelters.DefaultShelter.FeedPets();

            else if (userInput == "P")
                PetShelters.DefaultShelter.PlayWithPets();

            else if (userInput == "H")
                PetShelters.DefaultShelter.HealthCheckPets();



        }

        private static void DisplayShelterStatus()
        {
            PetShelters.DefaultShelter.GetAllAnimalStatus();
        }

        private static void ListPetsForAdoption()
        {

            PetShelters.DefaultShelter.DisplayPetsForAdoption();


        }

        private static void GetPetStatus()
        {

            Console.WriteLine("Please select the pet you are interested in adopting");

            for (int i = 0; i < PetShelters.Shelters[0].AllPets.Count; i++)
                Console.WriteLine("Enter [" + i + "] for pet " + PetShelters.Shelters[0].AllPets[i].Name);


            String petNumberInput = Console.ReadLine();
            int petIndex = -1;
            bool isValid = int.TryParse(petNumberInput, out petIndex) && petIndex >= 0 && petIndex < PetShelters.DefaultShelter.AllPets.Count;

            if (isValid)
                PetShelters.DefaultShelter.DisplayPetStatus(petIndex);


        }

        private static void AddNewPet()
        {

            Console.WriteLine("Please enter the pets name");
            String petName = Console.ReadLine();
            PetShelters.DefaultShelter.AddPet(petName);

            Console.WriteLine("You created a new pet: " + petName);
           

        }

       


        private static void UpdatePetActivity()
        {


            Console.WriteLine("Please select the pet you wish to update");

            for (int i = 0; i< PetShelters.DefaultShelter.AllPets.Count;i++)
               Console.WriteLine("Enter [" + i + "] for pet " + PetShelters.DefaultShelter.AllPets[i].Name);


            String petNumberInput = Console.ReadLine();
            int petNumber = -1;
            int petActivity = -1;
            bool isValid = int.TryParse(petNumberInput, out petNumber) && petNumber >= 0 && petNumber < PetShelters.DefaultShelter.AllPets.Count;


            if(!isValid)
                Console.WriteLine("You entered an invalid value: " + petNumberInput);

            else
            {

                Console.WriteLine("What would you like your pet to do?");
                Console.WriteLine("[1] Eat, [2]Play, [3] Visit Dr, [4] Rest");


                petNumberInput = Console.ReadLine();
                isValid = int.TryParse(petNumberInput, out petActivity);

                if (!isValid)
                    Console.WriteLine("You entered an invalid value: " + petNumberInput);
                else
                    PetShelters.DefaultShelter.PerformActivity(petNumber, petActivity);
                   

            }




        }

    }
}