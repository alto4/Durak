﻿using CardLib;
using ControlsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class frmGame : Form
    {

        #region FIELDS AND PROPERTIES

        // generate PlayingCard objects from a Deck
        Deck mainDeck = new Deck(true);

        // enlarge a card by this value
        private const int ENLARGE = 30;

        // The default size of a card
        static private Size normalCardSize = new Size(151,180);

        // makes card draggable
        private CardBox.CardBox dragCard;

        #endregion

        #region FORM AND STATIC CONTROL EVENT HANDLERS 

        /// <summary>
        /// Constructor for the main form
        /// </summary>
        public frmGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the main form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGame_Load(object sender, EventArgs e)
        {
            // TEST SHUFFLE
            mainDeck.Shuffle();

            // seeing the order of the deck in debug console for debugging
            mainDeck.ShowDeck();
            System.Diagnostics.Debug.WriteLine(mainDeck.ToString());
            

            //Wire out the out of cards event handler
            //mainDeck.OutOfCards MAKE A METHOD TO TRIGGER AN OUT OF CARDS EVENT
            //Show the number of cards left in the deck

        }

        /// <summary>
        /// Event for when the index changes on a combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the user clicks on the deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDeck_Click(object sender, EventArgs e)
        {
            
            lblClickedState.Text = cbxDeck.ToString() + " was last clicked.";
            txtPlayHistory.Text += "Loaded!" + Environment.NewLine;

            /* NOTE: idk why the cards need to switch between horizontal and vertical - @Ed
            if (cbxDeck.CardOrientation == Orientation.Horizontal)
            {
                cbxDeck.CardOrientation = Orientation.Vertical;
            }
            else
            {
                cbxDeck.CardOrientation = Orientation.Horizontal;
            }
            */

            //If the deck is empty (no image)
            //if (stmt)
            //{
            //Reset the dealer

            //}
            //else //otherwise           
            CardBox.CardBox card = new CardBox.CardBox(mainDeck.DrawCard());
            // card.FaceUp = true;
            txtPlayHistory.Text += card.ToString();
            if (card != null )
            {
                //Draw a card from the deck (if it worked)
                //if (stmt) 
                //{ 
                //TESTING

                //wire the event handlers
                //click or drag logic here at a later date
                

                //wire cardbox mouse enter

                //wire cardbox mouse leave

                //add new controls to the appropriate panel
                pnlPlayerCards.Controls.Add(card);
                //realign the controls

            }

            //display the number of cards left

            //}

        }

        /// <summary>
        /// When the Flip Card button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlipCard_Click(object sender, EventArgs e)
        {
            cbxDeck.FaceUp = !cbxDeck.FaceUp;
        }
        /// <summary>
        /// When the selected index is changed for cbxSuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDeck.Suit = (CardLib.CardSuit)cbxSuit.SelectedIndex;
        }
        /// <summary>
        /// When the selected index is changed for cbxRank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDeck.Rank = (CardLib.CardRank)cbxRank.SelectedIndex + 1;
        }
        /// <summary>
        /// When the exit button is clicked by the user. In case user did not mean to press this button
        /// there is a cancel option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // to check if they player meant to go back to the main menu
            DialogResult result = MessageBox.Show("Are you sure you want to go back to the main menu?", "Back To Main Menu", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // hidding frmGame
                this.Hide();

                // new frmMainMenu instance
                frmMainMenu mainMenu = new frmMainMenu();

                // show the frmMainMenu form
                mainMenu.ShowDialog();

                // close frmMainMenu
                this.Close();
            }
        }
        /// <summary>
        /// Sets the card back image to null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDeck_OutOfCards(object sender, EventArgs e )
        {
            cbxDeck.BackgroundImage = null;
        }

        /// <summary>
        /// Button that shows the rules form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRules_Click(object sender, EventArgs e)
        {
            // new frmMainMenu instance
            frmRules rules = new frmRules();

            // show the frmRules form
            rules.ShowDialog();
        }


        #endregion

        #region CARDBOX EVENT HANDLERS
        #endregion

        #region HELPER METHODS
        #endregion

        #region EMPTY EVENT HANDLERS
        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void cbxDeck_Load(object sender, EventArgs e)
        {

        }

        private void lblClickedState_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
