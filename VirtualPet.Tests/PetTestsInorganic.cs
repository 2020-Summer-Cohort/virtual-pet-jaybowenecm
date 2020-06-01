using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VirtualPet.Tests
{
    public class PetTestsInorganic
    {

        private PetRobot testPet;



        public PetTestsInorganic()
        {
            testPet = new PetRobot("CEPTAR", Constants.SPECIES_TYPE.DOG);
        }

        [Fact]
        public void Pet_Constructor_Should_Instantiate_Pet_Object()
        {
            Assert.NotNull(testPet);
        }

        // INSTRUCTIONS:
        // Uncomment code in the test body one test at a time
        // Add source code to eliminate the build errors (red squiggle) and pass the test

        [Fact]
        public void Pet_Should_Have_Name()
        {
            Assert.NotNull(testPet.Name);
        }

        [Fact]
        public void SetName_Should_Assign_Pet_Name_Property()
        {
            testPet.SetName("Fluffy");
            Assert.Equal("Fluffy", testPet.Name);
        }

        [Fact]
        public void GetName_Should_Get_Pet_Name_Value()
        {
            testPet.SetName("Klingon");

            string testPetName = testPet.Name;

            Assert.Equal("Klingon", testPetName);
        }

        [Fact]
        public void Pet_Should_Have_Species()
        {
            Assert.NotNull(testPet.Species.ToString());
        }

        [Fact]
        public void SetSpecies_Should_Assign_Pet_Species_Property()
        {
            testPet.SetSpecies(Constants.SPECIES_TYPE.CAT);

            Assert.Equal(Constants.SPECIES_TYPE.CAT, testPet.Species);
        }

        [Fact]
        public void GetSpecies_Should_Get_Pet_Species_Value()
        {
            testPet.SetSpecies(Constants.SPECIES_TYPE.DOG);

            string testPetSpecies = testPet.Species.ToString();

            Assert.Equal(Constants.SPECIES_TYPE.DOG.ToString(), testPetSpecies);
        }

        [Fact]
        public void Pet_Should_Have_Oil()
        {
            Assert.NotNull(testPet.LevelOil.ToString());
        }

       
        [Fact]
        public void Pet_Should_Have_Performance()
        {
            Assert.NotNull(testPet.LevelPerformance.ToString());
        }

 
        [Fact]
        public void Pet_Should_Have_Maintenance()
        {
            Assert.NotNull(testPet.LevelMaintenance.ToString());
        }

      
        [Fact]
        public void Tick_Should_Decrease_All_By_5()
        {
            testPet.Tick();

            Assert.Equal(95, testPet.LevelMaintenance);
        }

        [Fact]
        public void Pet_Play()
        {

            int Level = testPet.LevelBoredom;
            testPet.Play();


            Assert.True(Level > testPet.LevelBoredom);
        }

        [Fact]
        public void Pet_See_Mechanic()
        {

            int Level = testPet.LevelMaintenance;
            testPet.Tick(); // put some wear on this

            Assert.True(Level > testPet.LevelMaintenance);
            testPet.SeeMechanic();            

            Assert.True(Level<= testPet.LevelMaintenance);
        }

        [Fact]
        public void Pet_Perform_Oil()
        {

            // Combine tests, put wear verify oil levels change then give oil and recheck

            int Level = testPet.LevelOil;
            testPet.Tick(); 

            Assert.True(Level > testPet.LevelOil);
            testPet.GiveOil();


            Assert.True(Level <= testPet.LevelOil);
        }

        [Fact]
        public void Pet_Perform_Maintenance()
        {

            int Level = testPet.LevelMaintenance;
            testPet.Tick(); // put some wear on this

            Assert.True(Level > testPet.LevelMaintenance);
            testPet.SeeMechanic();


            Assert.True(Level <= testPet.LevelMaintenance);
        }


    }
}
