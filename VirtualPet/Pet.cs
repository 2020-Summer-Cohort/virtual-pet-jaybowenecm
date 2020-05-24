using System;
using System.Reflection;

namespace VirtualPet
{
    public class Pet
    {
        private Guid id = Guid.NewGuid();
        public string Name { get; private set; }
        public int LevelHunger { get; private set; }
        public int LevelThirst { get; private set; }
        public int LevelWaste { get; private set; }
        public int LevelSleepiness { get; private set; }
        public int LevelSickness { get; private set; }
        public int LevelBoredom { get; private set; }

        public int LevelHealth { get; private set; }

        public Guid Id
        { get { return id; } }

        public string Species { get; set; }

        public Pet(String petName)
        {
            this.Name = petName;
            this.Species = "Iguana";
            LevelHunger = 50;
            LevelBoredom = 60;
            LevelHealth = 30;
        }

       internal void GetStatus()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.AppendLine("Health: " + LevelHealth);
            //sb.AppendLine("Boredom: " + LevelBoredom);
            //sb.AppendLine("Hunger: " + LevelHunger);
            //sb.AppendLine("LevelHealth: " + LevelHealth);
            //sb.AppendLine("Sickness: " + LevelSickness);
            //sb.AppendLine("Sleepiness: " + LevelSleepiness);
            //sb.AppendLine("Thirst: " + LevelThirst);
            //sb.AppendLine("Waste: " + LevelWaste);

            PropertyInfo[] properties = typeof(Pet).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(this, null);
                sb.AppendLine(property.Name + ": " + value.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        public void SetName(string petName)
        {
            if (string.IsNullOrEmpty(petName))
                throw new Exception("The pet name cannot be null");
            else
                this.Name = petName;
        }

        public void Tick()
        {
            //Examine internal state.... are we hungry, sleepy, or full of food]
            LevelBoredom += 5;
            LevelHunger += 5;
            LevelHealth -= 5;
        }

       

        public void SetSpecies(string newSpecies)
        {
            this.Species = newSpecies;
        }

        public string GetSpecies()
        {
            return this.Species;
        }

        public void SeeDoctor()
        {
            LevelHealth += 30;
            LevelSickness = 0;
        }

        public void Play()
        {
            LevelHunger += 10;
            LevelBoredom -= 20;
            LevelHealth += 10;
        }

        /// <summary>
        /// Decrease_Hunger_By_40
        /// </summary>
        public void Feed()
        {
            LevelHunger -= 40;
            if (LevelHunger < 0)
                LevelHunger = 0;
        }

        internal void Rest()
        {
            LevelSleepiness = 0;
        }
    }
}