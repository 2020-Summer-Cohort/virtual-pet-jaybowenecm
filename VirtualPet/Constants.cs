using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPet
{
    public static class Constants
    {

        public static String[] ORGANIC_PET_NAMES = { "Fido", "Binky", "Bella", "Lucy", "Smokey", "Animal" };

        public static String[] INORGANIC_PET_NAMES = { "Terminator", "Iron Giant", "WALL-E" };

        public enum PET_TYPE
        {
           
            ORGANIC, 
            INORGANIC
            
        }

        public enum SPECIES_TYPE
        {

            CAT,
            DOG

        }



    }

    
}
