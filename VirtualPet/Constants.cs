using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public static class Constants
    {

        static HashSet<int> validVals = new HashSet<int>((int[])Enum.GetValues(typeof(PET_STATES)));

        public static String[] PET_NAMES = { "Fido", "Binky", "Bella", "Lucy", "Smokey", "Animal" };

     public enum PET_STATES
        {
            HUNGER,
            THIRST,
            WASTE,
            BOREDOM,
            SLEEPING            
            
        }


        public static bool isValidPetState(int PetState)
        {


            return validVals.Contains(PetState);


        }


    }

    
}
