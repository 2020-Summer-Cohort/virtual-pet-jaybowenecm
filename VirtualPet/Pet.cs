using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualPet
{
    public class Pet
    {
        public static List<Pet> AllPets = new List<Pet>();
        public string Name { get; private set; }
        public List<PetState> petActivity = new List<PetState>();
        private Guid id = Guid.NewGuid();
       

        public Guid Id
        { get { return id; } }

        public string Species { get; set; }

        public Pet(String petName)
        {
            this.Name = petName;
            this.Species = "Iguana";

            foreach (int i in Enum.GetValues(typeof(Constants.PET_STATES)))
            {
                Constants.PET_STATES petState = (Constants.PET_STATES)i;
                this.petActivity.Add(new PetState(petState));
            }

            AllPets.Add(this);
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
            //Examine internal state.... are we hungry, sleepy, or full of food
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HUNGER).FirstOrDefault().UpdateActivityLevel(5);
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.BOREDOM).FirstOrDefault().UpdateActivityLevel(5);
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HEALTH).FirstOrDefault().UpdateActivityLevel(-5);
        }

        public void IncreaseActivityLevel(Constants.PET_STATES petStateToUpdate)
        {
            this.petActivity.Where(x => x.petState == petStateToUpdate).FirstOrDefault().UpdateActivityLevel();
        }

        public void SetSpecies(string newSpecies)
        {
            this.Species = newSpecies;
        }

        public string GetSpecies()
        {
            return this.Species;

          
    }

        public int GetHunger()
        {
            return this.petActivity.Where(x => x.petState == Constants.PET_STATES.HUNGER).FirstOrDefault().GetActivityLevel;
        }

        public int GetBoredom()
        {
            return this.petActivity.Where(x => x.petState == Constants.PET_STATES.BOREDOM).FirstOrDefault().GetActivityLevel;
        }

        public int GetHealth()
        {
            return this.petActivity.Where(x => x.petState == Constants.PET_STATES.HEALTH).FirstOrDefault().GetActivityLevel;
        }

        public void SeeDoctor()
        {
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HEALTH).FirstOrDefault().UpdateActivityLevel(30);
        }

        public void Play()
        {
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HUNGER).FirstOrDefault().UpdateActivityLevel(10);
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.BOREDOM).FirstOrDefault().UpdateActivityLevel(-20);
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HEALTH).FirstOrDefault().UpdateActivityLevel(10);
        }

        /// <summary>
        /// Decrease_Hunger_By_40
        /// </summary>
        public void Feed()
        {
            this.petActivity.Where(x => x.petState == Constants.PET_STATES.HUNGER).FirstOrDefault().UpdateActivityLevel(-40);
        }
    }
}