using System.Drawing;
namespace Snowfall
{
    public partial class SnowfallForm : Form
    {
        private const int countSnowflakesInSnowfall = 200;
        private Graphics canvas;
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics buffer;
        private Bitmap background;
        private Bitmap snowflakeBitmap;
        private Snowflake[] SnowFall = new Snowflake[countSnowflakesInSnowfall]; 

        public SnowfallForm()
        {
            InitializeComponent();
            canvas = CreateGraphics();
            snowflakeBitmap = new Bitmap(Properties.Resources.Snowflake);
            background = new Bitmap(Properties.Resources.Background);
            InitializationOfSnowflakesOfSnowfall();
            snowflakeBitmap.MakeTransparent(Color.White);
            SnowTimer.Start();
            currentContext = BufferedGraphicsManager.Current;
            buffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }              

        private void SnowTimerTick(object sender, EventArgs e)
        {
            DrawSnowflakesInBuffer();
            buffer.Render();
            FallingSnowflakes();
        }

        private void InitializationOfSnowflakesOfSnowfall()
        {
            for (int indexOfSnowflake = 0; indexOfSnowflake < countSnowflakesInSnowfall; indexOfSnowflake++)
            {
                SnowFall[indexOfSnowflake] = new Snowflake();
            }
        }

        private void FallingSnowflakes()
        {
            for(int indexOfSnowflake = 0; indexOfSnowflake < countSnowflakesInSnowfall;indexOfSnowflake++)
            {
                SnowFall[indexOfSnowflake].FallingSnowflake();
            }
        }

        private void DrawSnowflakesInBuffer()
        {
            buffer.Graphics.Clear(Color.White);
            buffer.Graphics.DrawImage(background, 0,0);
            foreach(Snowflake snowflake in SnowFall)
            {
                buffer.Graphics.DrawImage(snowflakeBitmap, snowflake.X, snowflake.Y, snowflake.sizeOfSnowflake, snowflake.sizeOfSnowflake);
            }
        }
    }
}
