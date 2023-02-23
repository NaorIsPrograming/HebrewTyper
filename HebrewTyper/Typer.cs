using System.Diagnostics;
using System.Transactions;
using System.Windows.Forms;

namespace HebrewTyper
{
    public partial class Typer : Form
    {

        StartingScreen prvScreen;
        public int currentIndex = 0;
        bool preventEvent = false;
        bool stopWatchflag = true;
        Stopwatch Stopwatch=new Stopwatch();
        int prvWpm = 0,avgIndex=0;
        int[] avgWpm= {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        public Typer(string text,StartingScreen s)
        {
            
            InitializeComponent();
            TextToType.Text = text;
            prvScreen = s;
            backColorCurrentLetter(0);
        }


        // this event handles almost all of the situation where you colour the letters in rich text box, it works in conjunction with TypedText_KeyDown and uses the private 
        // methods findIndexOFNextletter,backColourCurrentLetter,removeBackColor and paintLetter
        private void TypedText_TextChanged(object sender, EventArgs e)
        {
            if(stopWatchflag)
            {
                Stopwatch.Start();
                stopWatchflag = false;
            }
            if(preventEvent)
            {
                preventEvent= false;
                return;
            }// this is written in to prevent the event from triggering after backspace was used
            if(TypedText.Text.Length > 0&&currentIndex<TextToType.Text.Length) // this main if is where the magic happens and the coloring of the richTextBox ThingsToType Occurs
            {
                removeBackColor(currentIndex);
                
                if (TypedText.Text.Last() == ' ')// this if addresses all of the situations where the user typed space
                {
                    if (TextToType.Text[currentIndex] == ' ')// if there is a space in the system
                    {
                        currentIndex++;
                        backColorCurrentLetter(currentIndex);
                        TypedText.Text = "";// the textBox TypedText will be reset after each space.
                    }
                        
                    else// if the space was placed incorrectly skip to the first letter of the first word and error out everything.
                    {
                        TextToType.Select(currentIndex,1);
                        TextToType.SelectionColor = Color.Red;
                        TextToType.SelectionBackColor = Color.LightSalmon;
                        currentIndex++;
                        backColorCurrentLetter(currentIndex);
                        
                    }
                }
                else// this adresses all of the situations where the user typed a letter
                {
                    if (TextToType.Text[currentIndex] == TypedText.Text.Last())// if he typed correctly color green and move to the next letter
                    {
                        paintLetter(Color.Green, currentIndex);
                        currentIndex++;
                        backColorCurrentLetter(currentIndex);
                    }
                            
                    else// if he typed incorrectly color red and move to the next letter
                    {
                        paintLetter(Color.Red,currentIndex);
                        currentIndex++;
                        backColorCurrentLetter(currentIndex);
                    }


                }
                    

            }
            else if(currentIndex>=TextToType.Text.Length)
            {
                Stopwatch.Stop();
                prvWpm = (int)(wordCounter() / (Stopwatch.Elapsed.TotalSeconds / 60));
                prvWpmLabel.Text = "Previous WPM: " + prvWpm;
                MessageBox.Show($"wpm: {(int)wordCounter()/(Stopwatch.Elapsed.TotalSeconds/60)}\n Average WPM: {doAverageWpm()} ");
                Stopwatch.Reset();
                stopWatchflag = true;

                prvScreen.Show();
                this.Hide();
                prvScreen.Focus();
                
            }// a placeholder for what happens when the user finished the test. TBR
        }
        private int findIndexOfNextLetter(int i)
        {
            while (i < TextToType.Text.Length && TextToType.Text[i] != ' ')
                i++;
            if (i < TextToType.Text.Length)
            {
                //backColorCurrentLetter(i++);
                return i++;
            }
            //backColorCurrentLetter(TextToType.Text.Length - 1);
            return TextToType.Text.Length - 1;
        }// finds the index of the next letter by looking for spaces
        private void backColorCurrentLetter(int i)//backColors the letter the user should type
        {
            if (TextToType.Text.Length <= i)
                return;
            TextToType.Select(currentIndex, 1);
            TextToType.SelectionBackColor = Color.PaleGreen;
        }
        private void removeBackColor(int i)
        {
            if (TextToType.Text.Length <= i)
                return;
            TextToType.Select(currentIndex, 1);
            TextToType.SelectionBackColor = Color.FromKnownColor(KnownColor.Control);
        }//removes the backColor of the letter the user typed either because of backspace or to show the next letter
        private void paintLetter(Color c ,int i)
        {
            if (i < 0 || i > TextToType.Text.Length - 1)
                return;
            else
            {
                TextToType.Select(i, 1);
                TextToType.SelectionColor = c;
                if(c==Color.Red)
                    TextToType.SelectionBackColor = Color.LightSalmon;
            }
        }//paint a letter in a colour you choose, if you choose red also backColors it
        private void removePaint(int i)//removes all letter paint and backColor, only used when the user presses backspace
        {
            if (i < 0 || i > TextToType.Text.Length - 1)
                return;
            else
            {
                TextToType.Select(i, 1);
                TextToType.SelectionColor = Color.Black;
                removeBackColor(i);
            }
        }

        private void TypedText_KeyDown(object sender, KeyEventArgs e)// this method addresses what happens when the user presses backspace
        {
            if (TypedText.Text == "" || TypedText.Text == null || currentIndex==0)
                return;
            if (e.KeyCode == Keys.Back)
            {
                removeBackColor(currentIndex);
                currentIndex--;
                removePaint(currentIndex);
                backColorCurrentLetter(currentIndex);
                
                
                preventEvent= true;// bool to close up the inevitable TypedText_TextChanged event that will be triggered after this event
            }
                

        }
        private int wordCounter()
        {
            bool streak = false;
            string text = TextToType.Text;
            int count=0;
            string test="";
            for (int i=0; i<text.Length; i++) 
            {
                if (!streak && text[i] != ' ')
                {
                    count++;
                    streak= true;
                    test += text[i].ToString() + "|";
                }
                else if(text[i] == ' ')
                {
                    streak = false;
                }
                    
            }
            return count;

        }
        private int CalculateAcuracy()
        {
            int counter = 0;
            for(int i=0; i<currentIndex; i++)
            {
                TextToType.Select(i, 1);
                if (TextToType.SelectionBackColor == Color.Red)
                    counter++;
            }
            return (int)(counter / (currentIndex+1.0)) * 100;
        }

        private void Typer_FormClosed(object sender, FormClosedEventArgs e)
        {
            prvScreen.Close();
        }
        private float doAverageWpm()
        {

            int avgTillIndex = 0;
            float avg=0;
            if(avgIndex==10)
                avgIndex=0;
            avgWpm[avgIndex] = prvWpm;
            avgIndex++;
            for(int i=0;i<avgWpm.Length;i++) 
            {
                if (avgWpm[i]!=-1)
                    avgTillIndex++;
            }
            for(int i=0;i<avgTillIndex;i++)
            {
                avg += avgWpm[i];
            }
            avg/=avgTillIndex;
            AvgWPMLabel.Text = "Average WPM: " + avg;
            return avg;
            
        }
        private int CurrentWpm()//uses methoud of calculation as discussed with ido- total chars/
        {
            return 2;// placeholder thing
        }
      
    }
}