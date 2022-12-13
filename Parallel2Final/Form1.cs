using System;

namespace Parallel2Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            random = new Random();
            InitializeComponent();
        }
        //int k = 5; //Number of workers, below values lines can be commented out to and run to check execution time
        //int k = 20;
        int k = 100;
        int delay = 20; //delay in miliseconds
        int NumberOfCircles = 1500; //number of circles

        int i = 0;
        int Coordinate1, Coordinate2;

        private Random random;
        private static readonly Random Random = new Random();
        private void Form1_Paint (object sender, PaintEventArgs e) 
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            int Radius = 15;
            Random Coordinates = new Random();
            while (i < NumberOfCircles)
            {
                for (int j = 1; j <= k; j++)
                {
                    Coordinate1 = Coordinates.Next(0, 600);
                    Coordinate2 = Coordinates.Next(0, 1200);
                    Graphics g = e.Graphics;
                    Pen RandomColor = new Pen(Color.FromArgb(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100)));
                    Rectangle circle = new Rectangle(Coordinate1, Coordinate2, Radius * 2, Radius * 2);
                    g.DrawEllipse(RandomColor, circle);
                }
                i = i + k;
                Thread.Sleep(delay);
            }
            stopwatch.Stop();

            if (i >= NumberOfCircles)
            {
                MessageBox.Show($"Execution completed, time elapsed: {stopwatch.ElapsedMilliseconds} miliseconds");
            }
        }
    }
}