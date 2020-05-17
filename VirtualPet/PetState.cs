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


        /// <summary>
        /// Accepts positive and negative values
        /// </summary>
        /// <param name="activetyLevelChange"></param>
        public void UpdateActivityLevel(int activetyLevelChange)
        {

            this.activityLevel += activetyLevelChange;
            if (activityLevel >= 100)
            {

                Console.WriteLine(this.petState.ToString() + " is starting over");
                activityLevel = 0;
            }

        }

        
        public void UpdateActivityLevel()
        {

            activityLevel += 1;
            Console.WriteLine(this.petState.ToString() + ":" + this.activityLevel);

            if(activityLevel >= 100)
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

            //Apply defaults based on state
            switch (petState)
            {
                case Constants.PET_STATES.HUNGER:
                    this.activityLevel = 50;
                    break;
                case Constants.PET_STATES.THIRST:
                    break;
                case Constants.PET_STATES.WASTE:
                    break;
                case Constants.PET_STATES.BOREDOM:
                    this.activityLevel = 60;
                    break;
                case Constants.PET_STATES.SLEEPING:
                    break;

                case Constants.PET_STATES.HEALTH:
                    this.activityLevel = 30;
                    break;
                default:
                    break;
            }



        }


    }
}
