using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Forms_Notes_App
{
    public partial class Form1 : Form
    {
        /* ===================================================================================
         * TODO LIST
         * ---------
         * Add functionality to create a new note
         * Add functionality to delete a note
         * Update note content to contentEditor.Text
         * Update last modified to be the date/time of when a note was last edited (content changed)
         * Add an icon for a note
         * Integrate a SaveFileDialog
         * Integrate an OpenFileDialog
         * ===================================================================================
         */ 




        // Main Form Member Variables
        List<Note> noteStack = new List<Note>();


        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            generateTestData(30);
            loadNotesListView();
        }

        //------------------------------------------------------------------------------------
        // NotesListView
        //------------------------------------------------------------------------------------
        private void loadNotesListView()
        {
            if(noteStack.Count > 0)
            {
                foreach(Note note in noteStack)
                {
                    ListViewItem noteItem = new ListViewItem();
                    noteItem.Tag = note;
                    noteItem.Text = note.Title + "    " + note.LastModified.ToString();
                    notesListView.Items.Add(noteItem);
                }             
            }
        }

        private void notesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate Note Details Fields
            if(notesListView.SelectedItems.Count != 0)
            {
                Note selectedNote = notesListView.SelectedItems[0].Tag as Note;
                contentEditor.Text = selectedNote.Content;
            }
            else
            {
                contentEditor.Text = "";
            }
        }
        //------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------
        // FILE > QUIT
        //------------------------------------------------------------------------------------
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //------------------------------------------------------------------------------------



        private void generateTestData(int max)
        {
            Random randomgenerator = new Random();
            int total = randomgenerator.Next(5, max);
            for(int i=0; i < total; i++)
            {
                Note noteToAdd = new Note();
                noteToAdd.Content = "She exposed painted fifteen are noisier mistake led waiting. " +
                    "Surprise not wandered speedily husbands although yet end. Are court tiled " +
                    "cease young built fat one man taken. We highest ye friends is exposed equally in. " +
                    "Ignorant had too strictly followed. Astonished as travelling assistance or " +
                    "unreserved oh pianoforte ye. Five with seen put need tore add neat. Bringing it " +
                    "is he returned received raptures.\n\n" + "Compliment interested discretion estimating " +
                    "on stimulated apartments oh. Dear so sing when in find read of call. As distrusts " +
                    "behaviour abilities defective is. Never at water me might.On formed merits hunted " +
                    "unable merely by mr whence or. Possession the unpleasing simplicity her uncommonly.";
                noteToAdd.Title = noteToAdd.Content.Substring(0, 12);
                noteToAdd.LastModified = new DateTime();
                noteStack.Add(noteToAdd);
            }


        }
    }
}
