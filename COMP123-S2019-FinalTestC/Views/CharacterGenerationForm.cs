using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

/*
 * STUDENT NAME:
 * STUDENT ID:
 * DESCRIPTION: This is the main form for the application
 */

namespace COMP123_S2019_FinalTestC.Views
{
    public partial class CharacterGenerationForm : COMP123_S2019_FinalTestC.Views.MasterForm
    {
        Random random = new Random();
        public CharacterGenerationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        private string GetRandomItemFromFileList(string _fileName)
        {
            //Populate a list with file content
            List<string> _listFromFile = File.ReadAllLines(_fileName).ToList();

            //Get number of list items
            int _listLength = _listFromFile.Count;

            //Populate _result with a random item from list
            string _result = _listFromFile[random.Next(_listLength)];

            return _result;
        }
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            string firstName = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\firstNames.txt"));
            string lastName = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\lastNames.txt"));

            Program.characterPortfolio.Identity.FirstName = GetRandomItemFromFileList(firstName);
            FirstNameDataLabel.Text = Program.characterPortfolio.Identity.FirstName;

            Program.characterPortfolio.Identity.LastName = GetRandomItemFromFileList(lastName);
            LastNameDataLabel.Text = Program.characterPortfolio.Identity.LastName;

        }
        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
