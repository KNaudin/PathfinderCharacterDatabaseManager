using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinder_Character_Database
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Console.WriteLine("[MainWindow] Loaded main window.");
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                Stream saveStream;

                saveFileDialog.Filter = "csv files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Saving the future database to: " + saveFileDialog.FileName);
                    // To-Do handle data saving and loading in another class
                    if ((saveStream = saveFileDialog.OpenFile()) != null)
                    {
                        saveStream.Close();
                    }
                    this.Text = "Pathfinder Character Database - " + Path.GetFileName(saveFileDialog.FileName);
                }
            }
        }

        private void loadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    this.Text = "Pathfinder Character Database - " + Path.GetFileName(filePath);
                    Console.WriteLine("Selected database is: " + filePath);
                }
            }
        }
    }
}
