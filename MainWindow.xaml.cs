/*
 * I McTavish
 * Feb 19, 2018
 * Multiple Buttons
 * Create multiple buttons and manage them in one button click
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace multipleButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global Variables - an array of buttons
        Button[] btnButtons = new Button[3];
        public MainWindow()
        {
            InitializeComponent();
            //Loop through the buttons
            for (int i = 0; i < btnButtons.Length; i++)
            {
                //Create the button and set attributes
                btnButtons[i] = new Button();
                btnButtons[i].Content = "Button " + i.ToString();
                btnButtons[i].Name = "btn" + i.ToString();
                //Add button click event
                btnButtons[i].Click += new RoutedEventHandler(btn_Click);
                //Set the first button to be visible
                if (i == 0)
                {
                    btnButtons[i].Visibility = Visibility.Visible;
                }
                else//hide the rest of the buttons
                {
                    btnButtons[i].Visibility = Visibility.Hidden;
                }
                //Add the buttons to the StackPanel (x:Name is spMainPanel)
                spMainPanel.Children.Add(btnButtons[i]);
            }
        }

        /// <summary>
        /// Runs all the button clicks
        /// </summary>
        /// <param name="sender">This is the button that was pressed</param>
        /// <param name="e">Any arguments that get sent</param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //Get the button that was pressed
            Button bThatWasPressed = (Button)sender;
            //Output the name to the console - the programmer
            //can see this and use it for troubleshooting
            Console.WriteLine(bThatWasPressed.Name);
            //Loop through all the controls in the StackPanel
            foreach (var b in spMainPanel.Children) {
                //More troubleshooting
                Console.WriteLine(b.GetType().ToString());
                //Check if it is a button
                if (b.GetType().ToString().Contains("Button")) {
                    //Collapsing the button hides it and does not save the space for it
                    ((Button)b).Visibility = Visibility.Collapsed;
                }
                //Check which button and make the next button visible
                if (bThatWasPressed.Name == "btn0")
                {
                    //Do btn0 specfic code
                    btnButtons[1].Visibility = Visibility.Visible;
                }
                else if (bThatWasPressed.Name == "btn1")
                {
                    btnButtons[2].Visibility = Visibility.Visible;
                }
                else {
                    //Must be the last button (only 3 buttons) so make the first one visible
                    btnButtons[0].Visibility = Visibility.Visible;
                }//end if

            }//end for loop
        }//end btn_Click
    }//end MainWindow class
}//end Namespace
