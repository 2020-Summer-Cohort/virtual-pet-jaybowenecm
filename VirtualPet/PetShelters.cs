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
            foreach (String petName in Constants.PET_NAMES)
                myShelter.AddPet(petName);

            shelters.Add(myShelter);
        }
    }
}