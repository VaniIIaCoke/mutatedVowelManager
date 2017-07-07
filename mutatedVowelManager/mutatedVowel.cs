using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mutatedVowelManager
{
    public class mutatedVowelHandler
    {
        private mutatedVowel[] arMutatedVowelCatalog;

        //Constructor fills catalog of mutatedvowels and translations.
        public mutatedVowelHandler()
        {
            arMutatedVowelCatalog = new mutatedVowel[4];
            arMutatedVowelCatalog[0] = new mutatedVowel("Ä", "AE");
            arMutatedVowelCatalog[1] = new mutatedVowel("Ö", "OE");
            arMutatedVowelCatalog[2] = new mutatedVowel("Ü", "UE");
            arMutatedVowelCatalog[3] = new mutatedVowel("ß", "SS");
        }

        //Step 1: Solution for the first task. The function compares the sInput Parameter with Data of the mutatedVowelCatalog and every match is changed from the translation to the mutatedVowel.
        public string ConvertMutatedVowelsToAbbroviation(string sInput)
        {
          
            for(int i = 0; i < arMutatedVowelCatalog.Length; i++)
            {
                sInput = sInput.Replace(arMutatedVowelCatalog[i].getSMutatedVowel(), arMutatedVowelCatalog[i].getAbbroviation());
            }
            return sInput;

        }

        //writes the whole Data from the mutatedvowelcatalog to an stringarray
        private string[] MutatedVowelCatalogTostrar()
        {
            string[] arMutatedVowelChars = new string[arMutatedVowelCatalog.Length * 2];
            int j = 0;

            for(int i = 0; i < arMutatedVowelCatalog.Length; i += 1)
            {

                arMutatedVowelChars[j] = arMutatedVowelCatalog[i].getAbbroviation();
                j++;
                arMutatedVowelChars[j] = arMutatedVowelCatalog[i].getSMutatedVowel();
                j++;
               

            }


            return arMutatedVowelChars;


        }
        
        //sorts out every mutatedVowel and returns the other stringsnippets
        private string[] getSnippets( string sInput)
        {
           
            return  sInput.Split(MutatedVowelCatalogTostrar(), StringSplitOptions.None);
        }

        //Looping through the catalog and looking for the right entry. Function return the entiry entry.
        private mutatedVowel getMutatedVowel(string sMutatedVowel)
        {
            for(int i = 0; i < arMutatedVowelCatalog.Length; i++)
            {
                if (sMutatedVowel.Length != 1)
                {
                    if(sMutatedVowel == arMutatedVowelCatalog[i].getSMutatedVowel())
                    {
                        return arMutatedVowelCatalog[i];
                    }
                }
                else
                {
                    if (sMutatedVowel == arMutatedVowelCatalog[i].getAbbroviation())
                    {
                        return arMutatedVowelCatalog[i];
                    }
                }
            }

            return null;
        }

        //returns a List of Possibilities of different spellings of the given Inputparameter.
        public List<string> getAllPossibilities(string sInput)
        {
            List<string> lMutatedVowals = getAllMutatedVowels(sInput);
            string[] arSnippets = getSnippets( sInput);
            List<string> Possibilities = new List<string>();
            int Combinations = Convert.ToInt32(Math.Pow(2.0, lMutatedVowals.Count));
            int[] iCNT = new int[lMutatedVowals.Count];
            byte byteValue = 0;

            for(int i = 0; i < lMutatedVowals.Count; i++)
            {
                iCNT[i] = 0;
            }

            for (int i = 0; i < Combinations; i++)
            {
                string Possibility = "";
                

                for (int j = 0; j < arSnippets.Length; j++)
                {
                    if (j == lMutatedVowals.Count && arSnippets.Length > lMutatedVowals.Count)
                    {
                        Possibility += arSnippets[j];
                    }
                    else
                    {
                        mutatedVowel mv = getMutatedVowel(lMutatedVowals[j]);
                        if (iCNT[j] == 0)
                        {
                            Possibility += arSnippets[j] + mv.getAbbroviation();
                        }

                        if (iCNT[j] == 1)
                        {
                            Possibility += arSnippets[j] + mv.getSMutatedVowel();
                        }

                    }
                }

                byteValue++;
                iCNT = Varietyhandler(iCNT, byteValue);

                Possibilities.Add(Possibility);
            }
            return Possibilities;
        }
        
        //This function turns a byteValue into an chararray and converts it to an int array. The function return the intarray.
        private int[] Varietyhandler(int[] iCNT, byte byteValue)
        {
            byte[] bitValues = { 128, 64, 32, 16, 8, 4, 2, 1 };
            byte[] bits = new byte[8];
            string bitstring = string.Empty;


            for (int i = 0; i < 8; i++)
            {
                if (byteValue >= bitValues[i])
                {
                    bits[i] = 1;
                    byteValue -= bitValues[i];
                }
                bitstring += Convert.ToString(bits[i]);
            }
            bitstring = bitstring.Substring(bitstring.Length - iCNT.Length);

            char[] chCNT = bitstring.ToCharArray();

            for (int i = 0;  i < iCNT.Length; i++)
            {
                int.TryParse(chCNT[i].ToString(), out iCNT[i]);
            }

            Array.Reverse(iCNT);

            return iCNT;
        }
        

        //Returns a list of all given mutatedVowels inside of the inputparameter.
        private List<string> getAllMutatedVowels(string sInput)
        {
            List<string> lMutatedVowels = new List<string>();
            string sPartialString = "";

            for (int i = 0; i < sInput.Length - 1; i++)
            {

                sPartialString = sInput.Substring(i, 2);
                for (int j = 0; j < arMutatedVowelCatalog.Length; j++)
                {
                    string sMutatedVowel = arMutatedVowelCatalog[j].CompareStringWithMutatedVowel(sPartialString);
                    if (sMutatedVowel != null)
                    {
                        i++;
                        lMutatedVowels.Add(sMutatedVowel);
                        break;
                    }

                }
            }

            return lMutatedVowels;
        }

        private class mutatedVowel
        {
            private string sAbbroviation;
            private string sMutatedVowel;

            
            public mutatedVowel(string Abbroviation, string MutatedVowel)
            {
                this.sAbbroviation = Abbroviation;
                this.sMutatedVowel = MutatedVowel;
            }

            public string getSMutatedVowel()
            {
                return sMutatedVowel;
            }

            public string getAbbroviation()
            {
                return sAbbroviation;
            }

            //returns the match of the comparisons
            public string CompareStringWithMutatedVowel(string sInput)
            {
                if (sInput.Contains(sAbbroviation))
                {
                    return sInput.Substring(sInput.IndexOf(sAbbroviation), 1);
                }

                if (sInput == sAbbroviation)
                {
                    return sAbbroviation;
                }
                else if (sInput == sMutatedVowel)
                {
                    return sMutatedVowel;
                }
                else
                {
                    return null;
                }

            }


        }
    } 
}
