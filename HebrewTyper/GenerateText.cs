using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebrewTyper
{
    internal class GenerateText
    {


        public GenerateText(int aprxlengthInWords,bool hasSpecialCharacters,string pathOfFile)//the basic constructor with one path
        {
            this.pathOfFile = new string[1];
            this.pathOfFile[0] = pathOfFile;
            random = new Random();
        }
        public GenerateText(string[] pathOfFile)//the basic constructor but it can recieve multiple Paths
        {
            this.pathOfFile = new string[pathOfFile.Length];
            Array.Copy(pathOfFile,this.pathOfFile,this.pathOfFile.Length);
            random = new Random();
        }
        int aprxLengthInWords;//might be used in future updates currently not required for functionality
        bool hasSpecialCharacters;//might be used in future updates currently not required for functionality
        string[] pathOfFile;
        string FullText="";
        Random random;
        bool flag;
        public string GenerateWithoutParams()//generates the first random sentence from the a random text in the pathOfFile arr
        {
            generateFullText(random.Next(0, pathOfFile.Length));
            int numOfDots=random.Next(1,4),startIndex,endIndex,currentIndex;
            currentIndex = random.Next(FullText.Length);
            startIndex=findEndOfSentence(currentIndex);
            startIndex = findNextSentence(startIndex);
            startIndex=findNextLetter(startIndex);
            currentIndex = startIndex;
            for(int i=0;i<numOfDots-1;i++)
            {
                currentIndex = findEndOfSentence(currentIndex);
                currentIndex=findNextLetter(currentIndex+1);
            }
            endIndex = findEndOfSentence(currentIndex);
            if(flag)
            {
                flag= false;
                return GenerateWithoutParams();
            }
            return generateTextToType(startIndex, endIndex);
            
        }
        private void generateFullText(int numOfPath)// generates the full text and removes new lines
        {
            FullText = File.ReadAllText(pathOfFile[numOfPath]);
            FullText=FullText.Replace("\r\n", " ");
        }
        private string generateTextToType(int startIndex, int endIndex)// method to remove all of the pesky annoying characters in books
        {
            string text= FullText.Substring(startIndex, endIndex - startIndex + 1);
            text= text.Replace("–", "-");
            text= text.Replace("…", "...");
            text = text.Replace("  ", " ");
            
            return text;
        }
        private int findNextSentence(int i)//find the first character of the closest sentance after the given index. if there is no sentence returns -1
        {
            while(i<FullText.Length && FullText[i]!=' ')
                i++;
            i++;
            if (i >= FullText.Length)
            {
                flag = true; return i;
            }
            if (FullText[i + 1] == ' ')
                i = findNextLetter(i);
            return i;
        }
        private int findEndOfSentence(int i)// finds the ending of your current sentence using dots. if theres no sentence returns -1
        {
            while (i < FullText.Length && FullText[i] != '.')
                i++;
            if (i >= FullText.Length)
            {
                flag = true; return i;
            }
            return i;
        }
        private int findNextLetter(int i)//finds the end of a sequence of space chars, if it reaches the end of the string return -1
        {
            while (i < FullText.Length && FullText[i]==' ')
                i++;
            if (i >= FullText.Length)
            {
                flag = true; return i;
            }
            return i;
        }
        
    }
}
