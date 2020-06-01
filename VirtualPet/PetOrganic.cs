using System;
using System.Reflection;

namespace VirtualPet
{
    public class PetOrganic:Pet
    {
        public int LevelHunger { get; private set; }
        public int LevelThirst { get; private set; }
        public int LevelWaste { get; private set; }
        public int LevelSleepiness { get; private set; }
        public int LevelSickness { get; private set; }

        public int LevelHealth { get; private set; }



        public PetOrganic(String petName, Constants.SPECIES_TYPE species) :base(petName,species)
        {
            
            LevelHunger = 50;
            LevelBoredom = 60;
            LevelHealth = 30;
        }

       public override void GetStatus()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
           

            PropertyInfo[] properties = typeof(PetOrganic).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(this, null);
                sb.AppendLine(property.Name + ": " + value.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

      

        public override void Tick()
        {
            //Examine internal state.... are we hungry, sleepy, or full of food]
            LevelBoredom += 5;
            LevelHunger += 5;
            LevelHealth -= 5;
        }
               

        public void SeeDoctor()
        {
            LevelHealth += 30;
            LevelSickness = 0;
            Console.WriteLine("Visited the doctor");
        }

        public override void Play()
        {
            LevelHunger += 10;
            LevelBoredom -= 20;
            LevelHealth += 10;
            Console.WriteLine("Played with pet");
        }

        /// <summary>
        /// Decrease_Hunger_By_40
        /// </summary>
        public void Feed()
        {
            LevelHunger -= 40;
            if (LevelHunger < 0)
                LevelHunger = 0;

            Console.WriteLine("Fed the pet");
        }

        internal void Rest()
        {
            LevelSleepiness = 0;
            Console.WriteLine("Rested pet");
        }

       
    }
}