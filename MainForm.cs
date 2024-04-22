using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        private Graphics graphics;

        private const int rectUnit = 25;
        private const int topOverlayEndsAt = 75;
        private const int nMaxBombs = 10;

        private const char Clear = 'C';
        private const char Bomb = 'B';
        private const char Discovered = 'D';

        private readonly Size rectSize = new Size(rectUnit, rectUnit);

        private readonly Pen blackPen = new Pen(Color.Black, 2);
        private readonly Pen darkGrayPen = new Pen(Color.DarkGray, 2);
        private readonly Brush bgColorBrush;
        private readonly Brush grayBrush = new SolidBrush(Color.Gray);

        private readonly Random random = new Random();

        private readonly List<Label> addedLabels = new List<Label>();

        private char[,] Map;

        private int nClicks = 0;

        public MainForm()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();

            Map = new char[this.Width, this.Height];

            this.Shown += new EventHandler(this.MainForm_Shown);

            this.MouseClick += onMouseClick;

            bgColorBrush = new SolidBrush(this.BackColor);
        }

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y < topOverlayEndsAt) return;

            if(e.Button == MouseButtons.Left)
            {
                ClicksLabel.Text = (++nClicks).ToString();

                Point clampedLocation = new Point();

                clampedLocation.X = (int)Math.Floor(e.X / (decimal)rectUnit) * rectUnit;
                clampedLocation.Y = (int)Math.Floor(e.Y / (decimal)rectUnit) * rectUnit;

                int x = clampedLocation.X;
                int y = clampedLocation.Y;

                if (Map[x, y] == Bomb)
                {
                    if(nClicks == 1)
                    {
                        ReplaceBomb(x, y);
                        return;
                    }
                    else { MessageBox.Show("Meghaltal xdd balfasz"); }
                }

                DiscoverCellsFrom(x, y);
            }
        }

        private void CreateAndDrawGrid()
        {
            for (int x = 0; x < this.Width; x += rectUnit)
            {
                for (int y = topOverlayEndsAt; y < this.Height; y += rectUnit)
                {
                    Rectangle rect = new Rectangle(new Point(x, y), rectSize);

                    graphics.FillRectangle(bgColorBrush, rect);
                    graphics.DrawRectangle(blackPen, rect);

                    Map[x, y] = Clear;
                }
            }

            PlaceBombs();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CreateAndDrawGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlaceBombs()
        {
            for (int i = nMaxBombs; i > 0; i--)
            {
                int randX, randY;

                do
                {
                    randX = random.Next(0, this.Width / rectUnit) * rectUnit;
                    randY = random.Next(topOverlayEndsAt / rectUnit, (this.Height / rectUnit) - 1) * rectUnit;
                }
                while (Map[randX, randY] == Bomb);

                Map[randX, randY] = Bomb;

                graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(randX, randY), rectSize));
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            CreateAndDrawGrid();

            foreach(Label label in addedLabels)
            {
                this.Controls.Remove(label);
            }
        }

        private void ReplaceBomb(int x, int y)
        {
            Map[x, y] = Clear;

            int randX, randY;

            do
            {
                randX = random.Next(0, this.Width / rectUnit) * rectUnit;
                randY = random.Next(topOverlayEndsAt / rectUnit, (this.Height / rectUnit) - 1) * rectUnit;
            }
            while (Map[randX, randY] == Bomb || (randX == x && randY == y));

            Map[randX, randY] = Bomb;
        }

        private void DiscoverCellsFrom(int x, int y)
        {
            int bombCount = GetAdjacentBombCount(x, y);

            Label label = new Label()
            {
                Location = new Point(x + 3, y + 2),
                Text = bombCount.ToString(),
                Width = 15,
                Height = 18,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            switch (bombCount)
            {
                case 1:
                    label.ForeColor = Color.Blue;
                    break;
                case 2:
                    label.ForeColor = Color.Green;
                    break;
                case 3:
                    label.ForeColor = Color.Red;
                    break;
                case 4:
                    label.ForeColor = Color.DarkBlue;
                    break;
                default:
                    break;
            }
            this.Controls.Add(label);

            addedLabels.Add(label);
        }

        private int GetAdjacentBombCount(int x, int y)
        {
            int bombCount = 0;

            int lowerX = (x - rectUnit) < 0 ? 0 : (x - rectUnit);
            int lowerY = (y - rectUnit) < 0 ? 0 : (y - rectUnit);

            int higherX = (x + rectUnit) > this.Width ? this.Width : (x + rectUnit);
            int higherY = (y + rectUnit) > this.Height ? this.Height : (y + rectUnit);

            for (int X = lowerX; X <= higherX; X += rectUnit)
            {
                for(int Y = lowerY; Y <= higherY; Y += rectUnit)
                {
                    if (X == x && Y == y) continue;

                    if (Map[X, Y] == Bomb) bombCount++;
                }
            }

            return bombCount;
        }
    }
}
