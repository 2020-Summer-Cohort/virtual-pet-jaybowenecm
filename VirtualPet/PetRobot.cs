using System;
using System.Reflection;

namespace VirtualPet
{
    public class PetRobot : Pet
    {
        public int LevelOil { get; private set; }
        public int LevelPerformance { get; private set; }

        public int LevelMaintenance{get;internal set;}


        public PetRobot(String petName, Constants.SPECIES_TYPE species):base(petName,species)
        {
            
            LevelOil = 100;
            LevelPerformance = 100;
            LevelMaintenance = 100;
        }

       public override void GetStatus()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
           

            PropertyInfo[] properties = typeof(PetRobot).GetProperties();
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
            LevelMaintenance -= 5;
            LevelOil -= 5;
            LevelPerformance -= 5;
        }
               

        public override void Play()
        {

            //when we play with the robot lets put wear on the machine by callin tick
            //Requirements do not state what should happen when we play with the robot

            LevelBoredom -= 5;
            LevelOil -= 5;
            LevelPerformance += 5;

        }



        public void SeeMechanic()
        {
            LevelMaintenance = 100;

        }


        public void GiveOil()
        {
            LevelOil = 100;
        }

        internal void PerformMaintenence()
        {
            LevelPerformance = 100;
        }

       
    }
}