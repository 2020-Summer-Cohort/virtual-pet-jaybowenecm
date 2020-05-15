using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace VirtualPet
{
    public class PetState
    {
        public Constants.PET_STATES petState = Constants.PET_STATES.SLEEPING;
        private int activityLevel = 0;

        public int GetActivityLevel
        { get { return activityLevel; } }


        public void IncreaseActivity()
        {

            activityLevel += 1;
            Console.WriteLine(this.petState.ToString() + ":" + this.activityLevel);

            if(activityLevel >= 10)
            {

                Console.WriteLine(this.petState.ToString() + " is starting over");
                activityLevel = 0;
            }

        }

        public void ChangeActivity(Constants.PET_STATES newState)
        {

            petState = newState;
            


        }

        public PetState(Constants.PET_STATES currentState)
        {

            Random rnd = new Random();
            this.petState = currentState;
            this.activityLevel = rnd.Next(1, 10);



        }


    }
}
