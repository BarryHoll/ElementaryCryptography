using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ElementaryCryptography
{
    class ElemCryptography
    {
        static void Main(string[] args)
        {
            // To hold given alphabeth - from file
            String alphabeth;

            // To hold given cyphertext - from file
            String cyphertext;

            // To hold all decripted versions of the cyphertext - one for each shift
            List<Attempt> AttemptsCollection = new List<Attempt>();

            // To hold all valid solutions - should only be one.
            List<Attempt> SolutionCollection = new List<Attempt>();

            alphabeth = FileHandler.getAlphabeth();
            System.Console.WriteLine("Alphabeth:");
            System.Console.WriteLine(alphabeth);
            System.Console.WriteLine("");

            cyphertext = FileHandler.getCypherText();
            System.Console.WriteLine("Original CypherText:");
            System.Console.WriteLine(cyphertext);
            System.Console.WriteLine("");

            Decrypted thisGo = new Decrypted(alphabeth, cyphertext);

            AttemptsCollection = Decrypted.allAttempts;

            int countShift = 1;
            foreach (Attempt at in AttemptsCollection)
            {
                if (at.isEnglish == true)
                {
                    String ans = "Yes it is!";

                    Console.WriteLine("*** SOLUTION ***");
                    Console.WriteLine("Ceasar Shift " + countShift + ": " + at.shiftedAlphabeth);
                    Console.WriteLine("");
                    Console.WriteLine("Decrypted Message:");
                    Console.WriteLine(at.decryptedCypherText);
                    Console.WriteLine("");
                    Console.WriteLine("English? " + ans);
                    Console.WriteLine("");

                    SolutionCollection.Add(at);
                }
                countShift++;                
            }

            FileHandler.writeSolutionToFile(SolutionCollection);            
            
            System.Console.WriteLine("");
            
        }
    }
}
