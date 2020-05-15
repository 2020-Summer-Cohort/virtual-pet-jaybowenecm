using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualPet
{
    public class Pet
    {

        public static List<Pet> AllPets = new List<Pet>();
        public String petName;
        public List<PetState> petActivity = new List<PetState>();
        private Guid id = Guid.NewGuid();

        public Guid Id
        { get { return id; } }




       
        public Pet(String petName)
        {

            this.petName = petName;

            
            foreach (int i in Enum.GetValues(typeof(Constants.PET_STATES)))
            {

                Constants.PET_STATES petState = (Constants.PET_STATES)i;
                this.petActivity.Add(new PetState(petState));


            }


            AllPets.Add(this);


        }

        public void IncreaseActivityLevel(Constants.PET_STATES petStateToUpdate)
        {

            this.petActivity.Where(x => x.petState == petStateToUpdate).FirstOrDefault().IncreaseActivity();


        }

       



    }
}
