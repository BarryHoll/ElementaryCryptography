using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElementaryCryptography
{
    class Decrypted
    {
        // To hold given alphabeth - from file
        public String alphabeth;

        // To hold given cyphertext - from file
        public String cyphertext;

        // To hold each char from alphabeth
        public List<char> alpha = new List<char>();

        // To hold each char from cyphertext
        public List<char> cypher = new List<char>();

        // Used to get currentShift this holds two alphabets, one after the other.
        public List<char> shiftAlpha = new List<char>();

        // Used to decrypt cyphertext for each shift.
        public List<char> currentShift = new List<char>();

        public static List<Attempt> allAttempts = new List<Attempt>();

        // To hold each decrypted message.
        public String decryptedText;

        public Boolean isEnglish;

        public Decrypted()
        {
            alphabeth = "";
            cyphertext = "";
            alpha = null;
            cypher = null;
            shiftAlpha = null;
            currentShift = null;
            decryptedText = null;
            allAttempts = null;
            isEnglish = false;
        }

        public Decrypted(string al, string cyp)
        {
            alphabeth = al;
            cyphertext = cyp;
            alpha = convertStringToCharList(alphabeth);
            cypher = convertStringToCharList(cyphertext);
            shiftAlpha = getShiftAlpha(alphabeth);

            int startIndex;

            for (int i = 1; i < alphabeth.Length; i++)
            {
                startIndex = i;
                currentShift = getCurrentShift(startIndex, shiftAlpha);

                String currShft;
                currShft = convertCharListToString(currentShift);

                decryptedText = getDecryptedText(currentShift, cyphertext, shiftAlpha);

                isEnglish = checkForEnglish(decryptedText);

                Attempt currAttempt = new Attempt(alphabeth, currShft, cyphertext, decryptedText, isEnglish);

                allAttempts.Add(currAttempt);
            }
        }

        /// <summary>
        /// Take a string representing the letters in the given alphabeth
        /// return a generic list of chars the size of the alphabeth twice, one after the other.
        /// </summary>
        /// <param name="alp">Holds the alphabeth.</param>
        /// <returns>Holds the alphabeth twice.</returns>
        private static List<char> getShiftAlpha(string alp)
        {
            List<char> shiftAlp = new List<char>();

            for (int i = 0; i < 2; i++)
            {
                foreach (char c in alp)
                {
                    shiftAlp.Add(c);
                }
            }

            return shiftAlp;
        }

        private static List<char> getCurrentShift(int indx, List<char> originalAlpha)
        {
            List<char> currShift = new List<char>();
            int alpLength;
            char currChar;

            alpLength = originalAlpha.Count / 2;

            for (int i = 0; i < alpLength; i++)
            {
                currChar = originalAlpha[indx];
                currShift.Add(currChar);
                indx++;
            }

            return currShift;
        }

        public String getDecryptedText(List<char> currAlp, String cypherTxt, List<char> originalAlpha)
        {
            String Decrypted = "";
            char decChar;
            int alpLength;
            List<char> orgAlph = new List<char>();

            alpLength = originalAlpha.Count / 2;

            for (int i = 0; i < alpLength - 1; i++)
            {
                orgAlph.Add(originalAlpha[i]);
            }

            foreach (char txtChar in cypherTxt)
            {
                for (int j = 0; j < currAlp.Count - 1; j++)
                {
                    if (txtChar == currAlp[j])
                    {
                        decChar = orgAlph[j];
                        Decrypted = Decrypted + decChar;
                    }
                }
            }

            return Decrypted;
        }

        /// <summary>
        /// This method is used to decide whether the message is in English.
        /// Two key numbers are used with this.
        /// 1/ The average vowel distribution for written English is 40% - so 100/40 = 2.5, I'm looking for 2.0 - 3.0.
        /// 2/ The average word length in written English is 5.1 - I'll look for 3.6 - 6.6.
        /// </summary>
        /// <param name="decryptedText"></param>
        /// <returns></returns>
        public Boolean checkForEnglish(String decryptedText)
        {
            Boolean isEng = false;
            
            double currVowelDist = 0.0;
            double vowelCount = 0.0;
            double charCount = 0.0;
            double wordCount = 0.0;
            double currAverWordSize = 0.0;

            String[] words = decryptedText.Split(' ');
            wordCount = Convert.ToDouble(words.Length);

            foreach (String w in words)
            {
                foreach (Char c in w)
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        vowelCount++;
                    }
                    charCount++;
                }
            }

            currAverWordSize = charCount / wordCount;
            currVowelDist = charCount / vowelCount;


            if ((currVowelDist > 2.00 && currVowelDist < 3.00)&&(currAverWordSize > 3.6 && currAverWordSize < 6.6))
            {
                isEng = true;
            }

            return isEng;
        }

        public List<char> convertStringToCharList(string st)
        {
            List<char> charList = new List<char>();

            foreach (char c in st)
            {
                charList.Add(c);
            }

            return charList;
        }

        public String convertCharListToString(List<char> chrL)
        {
            String st = "";

            foreach (Char c in chrL)
            {
                st = st + c;
            }

            return st;
        }
    }
}
