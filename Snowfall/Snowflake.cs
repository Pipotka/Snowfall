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
        public int sizeOfSnowflake { get;}

        public Snowflake()
        {
            var randomNumber = new Random();
            X = randomNumber.Next(0, 1920);
            Y = randomNumber.Next(-500, -200);
            sizeOfSnowflake = randomNumber.Next(9, 20);
            speedOfSnowflake = 40 / sizeOfSnowflake;
        }
        public void FallingSnowflake()
        {
            if (Y < 1080)
            {
                Y += speedOfSnowflake;
            }
            else
            {
                Y = -30;
                var randomNumber = new Random();
                X = randomNumber.Next(0, 1920);
            }
        }
    }
}
