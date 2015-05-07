using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ElementaryCryptography
{
    class FileHandler
    {
        /// <summary>
        /// Reads file 'cyphertext.txt' and returns contents as a string.
        /// </summary>
        /// <returns>String to hold contents of 'cyphertext.txt'.</returns>
        public static String getCypherText()
        {
            FileStream cypherFile = new FileStream("cyphertext.txt", FileMode.Open);

            String cyph;

            using (StreamReader sr = new StreamReader(cypherFile))
            {
                cyph = sr.ReadToEnd();
            }

            return cyph;
        }

        /// <summary>
        /// Reads file 'alphabeth.txt' and returns all contents except for "plaintext=".
        /// </summary>
        /// <returns>String to hold contents of 'alphabeth.txt'.</returns>
        public static String getAlphabeth()
        {
            FileStream alphaFile = new FileStream("alphabeth.txt", FileMode.Open);

            String alph;
            String alphTemp;

            using (StreamReader sr = new StreamReader(alphaFile))
            {
                alph = sr.ReadToEnd();
            }

            alphTemp = alph.TrimStart();

            if (alphTemp.Contains("plaintext="))
            {
                alph = alphTemp.Remove(0, 10);
            }
            else
            {
                alph = alphTemp;
            }

            return alph;
        }

        /// <summary>
        /// Writes the 
        /// </summary>
        /// <param name="at"></param>
        public static void writeSolutionToFile(List<Attempt> atList)
        {
            FileStream solutionFile = new FileStream("solution.txt", FileMode.Create);
            DateTime today = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(solutionFile))
            {
                foreach (Attempt at in atList)
                {
                    sw.WriteLine("Date:" + today);
                    sw.WriteLine("");
                    sw.WriteLine("Original alphabeth: " + at.origAlphabeth);
                    sw.WriteLine("");
                    sw.WriteLine("Original cyphertext: " + at.origCypherText);
                    sw.WriteLine("");
                    sw.WriteLine("Shifted alphabeth: " + at.shiftedAlphabeth);
                    sw.WriteLine("");
                    sw.WriteLine("Decrypted message: ");
                    sw.WriteLine(at.decryptedCypherText);
                    sw.WriteLine("");
                    sw.WriteLine("English? " + at.isEnglish);
                    sw.WriteLine("");
                }
            }
        }
    }
}
