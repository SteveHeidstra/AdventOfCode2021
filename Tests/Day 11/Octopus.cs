using System;
using System.Collections.Generic;

namespace AoC2021.Day_11
{
    public class Octopus
    {
        public Octopus(int row, int col, int enery)
        {
            Location = new Location(row, col, enery);
            Energylevel = enery;
        }

        public void ProcessStep(int step)
        {
            currentStep = step;
            Energylevel++;
           
        }

        private int currentStep;

        private int _energyLevel;
        public int Energylevel
        {
            get { return _energyLevel; }
            set
            {
                _energyLevel = value;
                
                if (_energyLevel > 9 && LastFlashedDuringStep < currentStep)
                {
                    FlashNow(currentStep);
                }
            }
        }

        public Location Location { get; private set; }

        internal void RegisterNeighbours(List<Octopus> neigbours)
        {
            foreach (Octopus octopus in neigbours)
            {
                octopus.Flash += this.NeighbourFlased;
            }
        }

        public void FlashNow(int step)
        {
            LastFlashedDuringStep = step;
            OctoEventArgs args = new OctoEventArgs(step);
            Flash.Invoke(this, args);
            Energylevel = 0;
        }

        public int LastFlashedDuringStep { get; set; }

        private void NeighbourFlased(object sender, OctoEventArgs e)
        {
            currentStep = e.Step;
            Energylevel++;

        }

        public event EventHandler<OctoEventArgs> Flash;
    }

    public class OctoEventArgs : EventArgs
    {
        public OctoEventArgs(int step)
        {
            this.Step = step;
        }

        public int Step { get; private set; }
    }
}
