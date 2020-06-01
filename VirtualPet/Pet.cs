using System;

namespace VirtualPet
{
    public abstract class Pet
    {
        private Guid id = Guid.NewGuid();
        public string Name { get; private set; }
        public Constants.SPECIES_TYPE Species { get; private set; }

        public Guid Id
        { get { return id; } }


        public override bool Equals(object obj)
        {
            return obj is Pet pet &&
                   id.Equals(pet.id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }


        public int LevelBoredom { get; internal set; }

        public Pet(String petName, Constants.SPECIES_TYPE speciesType)
        {
            this.Name = petName;
            this.Species = speciesType;
        }


        public abstract void GetStatus();

        public abstract void Tick();

        public abstract void Play();


        public void SetName(string petName)
        {
            if (string.IsNullOrEmpty(petName))
                throw new Exception("The pet name cannot be null");
            else
                this.Name = petName;
        }

      

        public Constants.SPECIES_TYPE GetSpecies()
        {
            return this.Species;
        }

        public void SetSpecies(Constants.SPECIES_TYPE newSpecies)
        {
            this.Species = newSpecies;
        }

    }
}