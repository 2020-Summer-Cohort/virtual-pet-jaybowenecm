using System;
using Xunit;

namespace VirtualPet.Tests
{
    public class PetTests
    {
        private Pet testPet;

        public PetTests()
        {
            testPet = new Pet("Pebbles");
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
            testPet.SetName("Fido");

            string testPetName = testPet.Name;

            Assert.Equal("Fido", testPetName);
        }

        [Fact]
        public void Pet_Should_Have_Species()
        {
            Assert.NotNull(testPet.Species);
        }

        [Fact]
        public void SetSpecies_Should_Assign_Pet_Species_Property()
        {
            testPet.SetSpecies("Cat");

            Assert.Equal("Cat", testPet.Species);
        }

        [Fact]
        public void GetSpecies_Should_Get_Pet_Species_Value()
        {
            testPet.SetSpecies("Dog");

            string testPetSpecies = testPet.GetSpecies();

            Assert.Equal("Dog", testPetSpecies);
        }

        [Fact]
        public void Pet_Should_Have_Hunger()
        {
            Assert.NotNull(testPet.LevelHunger.ToString());
        }

        [Fact]
        public void GetHunger_Should_Return_Initial_Hunger_Level_Of_50()
        {
            int testPetHunger = testPet.LevelHunger;

            Assert.Equal(50, testPetHunger);
        }

        [Fact]
        public void Pet_Should_Have_Boredom()
        {
            Assert.NotNull(testPet.LevelBoredom.ToString());
        }

        [Fact]
        public void GetBoredom_Should_Return_Initial_Boredom_Level_Of_60()
        {
            int testPetBoredom = testPet.LevelBoredom;

            Assert.Equal(60, testPetBoredom);
        }

        [Fact]
        public void Pet_Should_Have_Health()
        {
            Assert.NotNull(testPet.LevelHealth.ToString());
        }

        [Fact]
        public void GetHealth_Should_Return_Initial_Health_Level_Of_30()
        {
            
            int testPetHealth = testPet.LevelHealth;
            Assert.Equal(30, testPetHealth);
        }

        [Fact]
        public void Feed_Should_Decrease_Hunger_By_40()
        {
            testPet.Feed();

            Assert.Equal(10, testPet.LevelHunger);
        }

        [Fact]
        public void SeeDoctor_Should_Increase_Health_By_30()
        {

            int healthChange = testPet.LevelHealth;
            testPet.SeeDoctor();
            healthChange = testPet.LevelHealth - healthChange;

            Assert.Equal(30, healthChange);
        }

        [Fact]
        public void Play_Should_Increase_Hunger_By_10()
        {

            int activityLevel = testPet.LevelHunger;
            testPet.Play();
            activityLevel = testPet.LevelHunger - activityLevel;

            Assert.Equal(10, activityLevel);
        }

        [Fact]
        public void Play_Should_Decrease_Boredom_By_20()
        {
            int activityLevel = testPet.LevelBoredom;
            testPet.Play();
            activityLevel = testPet.LevelBoredom - activityLevel;
            Assert.Equal(40, testPet.LevelBoredom);
        }

        [Fact]
        public void Play_Should_Increase_Health_By_10()
        {

            int activityLevel = testPet.LevelHealth;
            testPet.Play();
            activityLevel = testPet.LevelHealth - activityLevel;
            
            Assert.Equal(40, testPet.LevelHealth);
        }

        [Fact]
        public void Tick_Should_Increase_Hunger_By_5()
        {
            testPet.Tick();

            Assert.Equal(55, testPet.LevelHunger);
        }

        [Fact]
        public void Tick_Should_Increase_Boredom_By_5()
        {

            int Level = testPet.LevelBoredom;
            testPet.Tick();
            bool isLevelSet = testPet.LevelBoredom == (Level + 5);
            Assert.True(isLevelSet);
        }

        [Fact]
        public void Tick_Should_Decrease_Health_By_5()
        {
            testPet.Tick();

            Assert.Equal(25, testPet.LevelHealth);
        }
    }
}
