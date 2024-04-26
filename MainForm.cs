using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        private Graphics graphics;

        private const int rectUnit = 25;
        private const int penWidth = 2;
        private const int topOverlayEndsAt = 75;

        private int nMaxBombs = 0;
        private int nRemainingBombs;

        private int widthCells = 0;
        private int heightCells = 0;

        private int clientWidth = 0;
        private int clientHeight = 0;
        private int clientOffset = 0;

        private bool areClickEventsEnabled = false;

        private const char Undiscovered = 'U';
        private const char Bomb = 'B';
        private const char Discovered = 'D';
        private const char FlaggedClear = 'F';
        private const char FlaggedBomb = 'O';

        private Difficulty difficulty = Difficulty.None;

        private static readonly Image flagImage = Image.FromFile(@"assets\flag.png");
        private static readonly Image mineImage = Image.FromFile(@"assets\mine.png");

        private readonly Size rectSize = new Size(rectUnit, rectUnit);

        private readonly Pen blackPen = new Pen(Color.Black, penWidth);
        private readonly Pen darkGrayPen = new Pen(Color.DarkGray, penWidth);
        private readonly Brush bgColorBrush;
        private readonly Brush grayBrush = new SolidBrush(Color.Gray);

        private readonly Random random = new Random();

        private readonly List<Control> addedControls = new List<Control>();

        private char[,] Map;

        private int nClicks = 0;

        public MainForm()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();

            DifficultySelectForm diffSelectForm = new DifficultySelectForm(this);
            DialogResult result = diffSelectForm.ShowDialog();

            // Means a difficulty was selected
            if (result == DialogResult.OK)
            {
                nMaxBombs = (int)difficulty;
                nRemainingBombs = nMaxBombs;

                switch(difficulty)
                {
                    case Difficulty.Beginner:
                        widthCells = 9;
                        heightCells = 9;

                        clientOffset = 300;
                        break;

                    case Difficulty.Intermediate:
                        widthCells = 16;
                        heightCells = 16;

                        clientOffset = 200;
                        break;

                    case Difficulty.Expert:
                        widthCells = 30;
                        heightCells = 16;

                        clientOffset = 25;
                        break;

                    default:
                        return;
                }

                clientWidth = widthCells * rectUnit;
                clientHeight = (heightCells * rectUnit) + topOverlayEndsAt;     
            }
            else return;

            diffSelectForm.Dispose();

            Map = new char[this.Width, this.Height];

            this.Shown += new EventHandler(this.MainForm_Shown);

            EnableClickEvents();

            bgColorBrush = new SolidBrush(this.BackColor);

            BombsRemainingLabel.Text = nMaxBombs.ToString();
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Y < topOverlayEndsAt) return;

            Point clampedLocation = new Point();

            clampedLocation.X = (int)Math.Floor(e.X / (decimal)rectUnit) * rectUnit;
            clampedLocation.Y = (int)Math.Floor(e.Y / (decimal)rectUnit) * rectUnit;

            int x = clampedLocation.X;
            int y = clampedLocation.Y;

            char current = Map[x, y];

            if (e.Button == MouseButtons.Left)
            {
                nClicks++;

                if (!(current == Undiscovered || current == Bomb)) return;

                if (current == Bomb)
                {
                    if(nClicks == 1)
                    {
                        ReplaceBomb(x, y);
                        DiscoverCellsFrom(x, y);
                        return;
                    }
                    else 
                    {
                        GameLost("You blew up!");
                    }
                }

                DiscoverCellsFrom(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (current == FlaggedClear || current == FlaggedBomb)
                {
                    Unflag(x, y);
                    return;
                }

                Flag(x, y);
            }
        }

        private void CreateAndDrawGrid()
        {
            for (int x = clientOffset; x < clientOffset + clientWidth; x += rectUnit)
            {
                for (int y = topOverlayEndsAt; y < clientHeight; y += rectUnit)
                {
                    SetUndiscovered(x, y);
                }
            }

            PlaceBombs();
        }

        private void SetUndiscovered(int x, int y)
        {
            DrawRectAt(new Point(x, y), blackPen, bgColorBrush, graphics);

            Map[x, y] = Undiscovered;
        }

        private void DrawRectAt(Point p, Pen pen, Brush brush, Graphics graphics)
        {
            Rectangle rect = new Rectangle(p, rectSize);

            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(pen, rect);
        }

        private void Unflag(int x, int y)
        {
            Control toRemove = addedControls.FirstOrDefault(c => c.Tag != null && c.Tag.Equals(FlaggedClear) && c.Location.X == x && c.Location.Y == y);

            this.Controls.Remove(toRemove);
            addedControls.Remove(toRemove);

            toRemove.Dispose();

            string displayText = BombsRemainingLabel.Text;
            BombsRemainingLabel.Text = (int.Parse(displayText) + 1).ToString();

            if (Map[x, y] == FlaggedBomb)
            {
                nRemainingBombs++;

                Map[x, y] = Bomb;

                DrawRectAt(new Point(x, y), blackPen, bgColorBrush, graphics);
            }
            else SetUndiscovered(x, y);
        }

        private void GameLost(string msg)
        {
            // Display all bombs
            for (int x = 0; x < this.Width; x += rectUnit)
            {
                for (int y = topOverlayEndsAt; y < this.Height; y += rectUnit)
                { 
                    char current = Map[x, y];

                    if (current == Bomb || current == FlaggedBomb)
                    {
                        if (current == FlaggedBomb) Unflag(x, y);
                        
                        PictureBox bombBox = new PictureBox()
                        {
                            Size = rectSize,
                            Location = new Point(x, y),
                            Image = mineImage,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = Bomb
                        };

                        this.Controls.Add(bombBox);
                        addedControls.Add(bombBox);
                    }
                }
            }
            DisableClickEvents();

            MessageBox.Show(msg);
        }

        private void GameWon(string msg)
        {
            MessageBox.Show(msg);

            DisableClickEvents();
        }

        private void DisableClickEvents()
        {
            areClickEventsEnabled = false;
            this.MouseClick -= onMouseClick;
        }

        private void EnableClickEvents()
        {
            if (areClickEventsEnabled) return;
            this.MouseClick += onMouseClick;
            areClickEventsEnabled = true;
        }

        private void Flag(int x, int y)
        {
            char current = Map[x, y];

            if (current == Discovered) return; 

            PictureBox flagBox = new PictureBox()
            {
                Size = rectSize,
                Location = new Point(x, y),
                Image = flagImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = FlaggedClear
            };

            this.Controls.Add(flagBox);
            addedControls.Add(flagBox);

            flagBox.Enabled = false;

            string displayText = BombsRemainingLabel.Text;
            BombsRemainingLabel.Text = (int.Parse(displayText) - 1).ToString();

            if (current == Bomb)
            {
                Map[x, y] = FlaggedBomb;
                nRemainingBombs--;
            }
            else { Map[x, y] = FlaggedClear; }

            if(nRemainingBombs == 0) GameWon("Congrats! You won in " + nClicks + " clicks!");
        }

        private void Discover(int x, int y)
        {
            DrawRectAt(new Point(x, y), darkGrayPen, grayBrush, graphics);

            Map[x, y] = Discovered;
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
                    randX = random.Next(clientOffset / rectUnit, (clientWidth + clientOffset) / rectUnit) * rectUnit;
                    randY = random.Next(topOverlayEndsAt / rectUnit, clientHeight / rectUnit) * rectUnit;
                }
                while (Map[randX, randY] == Bomb);

                Map[randX, randY] = Bomb;
            }
        }
        
        private void RestartButton_Click(object sender, EventArgs e)
        {
            foreach(Control control in addedControls)
            {
                this.Controls.Remove(control);

                control.Dispose();
            }

            CreateAndDrawGrid();

            EnableClickEvents();

            nClicks = 0;

            BombsRemainingLabel.Text = nMaxBombs.ToString();

            nRemainingBombs = nMaxBombs;
        }

        private void ReplaceBomb(int x, int y)
        {
            Map[x, y] = Undiscovered;

            int randX, randY;

            do
            {
                randX = random.Next(clientOffset / rectUnit, (clientWidth + clientOffset) / rectUnit) * rectUnit;
                randY = random.Next(topOverlayEndsAt / rectUnit, clientHeight / rectUnit) * rectUnit;
            }
            while (Map[randX, randY] == Bomb || (randX == x && randY == y));

            Map[randX, randY] = Bomb;
        }

        private void DiscoverCellsFrom(int x, int y)
        {
            if(x > this.Width || x < 0 || y > this.Height || y < 0) return;

            if (Map[x, y] != Undiscovered) return;

            Discover(x, y);

            int bombCount = GetAdjacentBombCount(x, y);

            if (bombCount == 0)
            {
                int lowX = (x - rectUnit) < 0 ? 0 : (x - rectUnit);
                int lowY = (y - rectUnit) < 0 ? 0 : (y - rectUnit);

                int highX = (x + rectUnit) > this.Width ? this.Width : (x + rectUnit);
                int highY = (y + rectUnit) > this.Height ? this.Height : (y + rectUnit);

                for(int X = lowX; X <= highX; X += rectUnit)
                {
                    for(int Y = lowY; Y <= highY; Y += rectUnit)
                    {
                        if (X == x && Y == y) continue;

                        DiscoverCellsFrom(X, Y);
                    }
                }

                return;
            }

            Label label = new Label()
            {
                Location = new Point(x + 3, y + 2),
                Text = bombCount.ToString(),
                Width = 15,
                Height = 18,
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.Gray
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

            addedControls.Add(label);
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

                    char current = Map[X, Y];

                    if (current == Bomb || current == FlaggedBomb) bombCount++;
                }
            }

            return bombCount;
        }
    }
}
