using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElementaryCryptography
{
    class Attempt
    {
        public String origAlphabeth;
        public String shiftedAlphabeth;
        public String origCypherText;
        public String decryptedCypherText;
        public Boolean isEnglish;

        public Attempt()
        {
            origAlphabeth = "";
            shiftedAlphabeth = "";
            origCypherText = "";
            decryptedCypherText = "";
            isEnglish = false;
        }

        public Attempt(string orAlp, string sftAlp, string orCyp, string decCyp, Boolean isEngl)
        {
            origAlphabeth = orAlp;
            shiftedAlphabeth = sftAlp;
            origCypherText = orCyp;
            decryptedCypherText = decCyp;
            isEnglish = isEngl;
        }
    }
}
