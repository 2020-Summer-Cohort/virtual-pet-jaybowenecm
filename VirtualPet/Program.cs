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

            foreach (String petName in Constants.PET_NAMES)
            {
                Pet mypet = new Pet(petName);
                Console.WriteLine("Added pet: " + petName);
            }
               



            bool cancelRequested = false;
            while (!cancelRequested)
            {
                
                Console.WriteLine("Enter N to add a new pet, U to update a pet or X to close.");

                String userCommand = Console.ReadLine().ToLower();
                switch(userCommand)
                {

                    case "x":
                        cancelRequested = true;
                        break;

                    case "n":
                        AddNewPet();
                        break;


                    case "u":
                        UpdatePetActivity();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;

                }

                    

                        
                    




            }




        }

        private static void AddNewPet()
        {

            Console.WriteLine("Please enter the pets name");
            String petName = Console.ReadLine();
            Pet myPet = new Pet(petName);
            //Pet.AllPets.Add(myPet);

            Console.WriteLine("You created a new pet: " + petName);
            foreach (PetState ps in myPet.petActivity)
                Console.WriteLine("Activity is: " + ps.petState + " with a level of: " + ps.GetActivityLevel);


        }

        private static void UpdatePetActivity()
        {


            Console.WriteLine("Please select the pet you wish to update");

            for (int i = 0; i< Pet.AllPets.Count;i++)
            {

                Console.WriteLine("Enter [" + i + "] for pet " + Pet.AllPets[i].petName);

            }


            String petNumberInput = Console.ReadLine();
            int petNumber = -1;
            bool isValid = int.TryParse(petNumberInput, out petNumber) && petNumber >= 0 && petNumber < Pet.AllPets.Count;




            if(isValid)
            {

                Pet selectedPet = Pet.AllPets[petNumber];
                foreach(PetState ps in selectedPet.petActivity)
                {
                    int kbShortcut = (int)ps.petState;
                    String msg = "Which activity would you like to update? Enter the number [" + kbShortcut + "] for " + ps.petState + " and current level is: " + ps.GetActivityLevel;
                    Console.WriteLine(msg);

                }
                   


                petNumberInput = Console.ReadLine();
                isValid = int.TryParse(petNumberInput, out petNumber) && petNumber >= 0 && Constants.isValidPetState(petNumber);
                
                if (isValid)
                {
                    Constants.PET_STATES stateToUpdate = (Constants.PET_STATES)petNumber;
                    selectedPet.IncreaseActivityLevel(stateToUpdate);
                   
                }
                else
                    Console.WriteLine("You entered an invalid value: " + petNumberInput);
                


            }




        }

        private static void PerformAction(int petNumber, Constants.PET_STATES action)
        {
            if (Pet.AllPets.Count <= petNumber)

            {
                Pet mypet = Pet.AllPets[petNumber];
                mypet.IncreaseActivityLevel(action);
            }
        }
    }
}