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
    public partial class DifficultySelectForm : Form
    {
        private MainForm active;
        public DifficultySelectForm(MainForm active)
        {
            InitializeComponent();

            this.active = active;
        }

        private void BeginnerButton_Click(object sender, EventArgs e)
        {
            active.SetDifficulty(Difficulty.Beginner);

            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void IntermediateButton_Click(object sender, EventArgs e)
        {
            active.SetDifficulty(Difficulty.Intermediate);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            active.SetDifficulty(Difficulty.Expert);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
