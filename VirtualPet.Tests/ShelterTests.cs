using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VirtualPet.Tests
{
   public class ShelterTests
    {


        [Fact]
        public void PetShelter_DisplayAllPets()
        {
            //Arrange

            //Act
            string petList = PetShelters.DefaultShelter.DisplayPetsForAdoption();

            //Assert
            Assert.Contains(Constants.PET_NAMES[1], petList);


        }

        [Fact]
        public void PetShelter_AddPet()
        {


            String petName = "Pac Man";
            PetShelters.DefaultShelter.AddPet(petName);
            bool hasPet = PetShelters.DefaultShelter.HasPet(petName);

            Assert.True(hasPet);


        }

        

        [Fact]
        public void PetShelter_AllPet_Interact()
        {


            int totalHunger = PetShelters.DefaultShelter.AllAnimalHungerLevel;
            PetShelters.DefaultShelter.FeedPets();
            int newHungerLevel = PetShelters.DefaultShelter.AllAnimalHungerLevel;
            Assert.NotEqual(totalHunger, newHungerLevel);

        }

        [Fact]
        public void PetShelter_OnePet_Interact()
        {

            int petIndex = 0;
            int petActivity = 2;
            int level = PetShelters.DefaultShelter.AllPets[petIndex].LevelBoredom;
            PetShelters.DefaultShelter.PerformActivity(petIndex, petActivity);

            level = level - PetShelters.DefaultShelter.AllPets[petIndex].LevelBoredom;
            Assert.Equal(20, level);



        }

        [Fact]
        public void PetShelter_Adopt()
        {

            String petName = Constants.PET_NAMES[0];
            PetShelters.DefaultShelter.AdoptPet(0);
            bool hasPet = PetShelters.DefaultShelter.HasPet(petName);

            Assert.False(hasPet);



        }






    }
}
