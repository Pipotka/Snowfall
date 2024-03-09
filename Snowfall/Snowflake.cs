using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    struct Snowflake
    {
        public int X {  get; set; }
        public int Y { get; set; }
        private int speedOfSnowflake;
        public int SizeOfSnowflake { get; set; }

        public Snowflake()
        {
            var randomNumber = new Random();
            X = randomNumber.Next(0, 1920);
            Y = randomNumber.Next(-500, -200);
            SizeOfSnowflake = randomNumber.Next(9, 20);
            speedOfSnowflake = 40 / SizeOfSnowflake;
        }
        public void FallingSnowflake()
        {
            if (Y < 1080)
            {
                Y += speedOfSnowflake;
            }
            else
            {
                ChangingSnowflake();
            }
        }
        private void ChangingSnowflake()
        {
            var randomNumber = new Random();
            X = randomNumber.Next(0, 1920);
            Y = -30;
            SizeOfSnowflake = randomNumber.Next(9, 20);
            speedOfSnowflake = 40 / SizeOfSnowflake;

        }
    }
}
