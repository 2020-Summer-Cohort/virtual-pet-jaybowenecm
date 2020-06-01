using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VirtualPet
{
    public static class PetShelters
    {
        private static List<Shelter> shelters = new List<Shelter>();

        public static ReadOnlyCollection<Shelter> Shelters
        { get { return shelters.AsReadOnly(); } }

        public static void AddShelter(string shelterName)
        {
            shelters.Add(new Shelter(shelterName));
        }

        public static Shelter DefaultShelter
        { get { return shelters[0]; } }

        static PetShelters()
        {
            //Initialize our game
            Shelter myShelter = new Shelter("Atari Pet Shelter");
            foreach (String petName in Constants.ORGANIC_PET_NAMES)
                myShelter.AddPet(petName, Constants.PET_TYPE.ORGANIC, Constants.SPECIES_TYPE.DOG);


            foreach (String petName in Constants.INORGANIC_PET_NAMES)
                myShelter.AddPet(petName, Constants.PET_TYPE.INORGANIC, Constants.SPECIES_TYPE.CAT);

            shelters.Add(myShelter);
        }
    }
}