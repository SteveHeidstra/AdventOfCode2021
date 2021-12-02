using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Submarine
    {
        public Submarine()
        {
            HorizontalPosition = 0;
            Depth = 0;
            Aim = 0;
        }

        public string command
        {
            set
            {
                string[] x = value.Split(' ');

                switch (x[0])
                {
                    case "forward":
                        Forward = int.Parse(x[1]);
                        break;
                    case "up":
                        Up = int.Parse(x[1]);
                        break;
                    case "down":
                        Down = int.Parse(x[1]);
                        break;
                    default:
                        break;
                }
            }
        }
        public int Forward
        {
            set
            {
                HorizontalPosition += value;
                Depth += (Aim * value);
            }
        }

        public int Up
        {
            set
            {
                Aim -= value;
            }
        }
        public int Down
        {
            set
            {
                Aim += value;
            }
        }

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }




    }

}
