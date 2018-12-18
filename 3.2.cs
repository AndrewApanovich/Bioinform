using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP
{
    class Program
    {
        static Dictionary<char, int> AAM = new Dictionary<char, int>()
        { { 'G',57 },{ 'A',71 },{ 'S',87 },{ 'P',97 },{ 'V',99 },{ 'T',101 },{ 'C',103 },{ 'I',113 },{ 'L',113 },{ 'N',114 },
        { 'D',115 },{ 'K',128 },{ 'Q',128 },{ 'E',129 },{ 'M',131 },{ 'H',137 },{ 'F',147 },{ 'R',156 },{ 'Y',163 },{ 'W',186 } };

        static int calcmass(string belok)
        {
            int m=0;
            for (int i=0; i<belok.Length; i++)
                m+=AAM[belok[i]];
            return m;
        }

        static string cyclospectrum(string belok)
        {
            List<int> cyclospectrum = new List<int>();
            string sub = " ";
          

            cyclospectrum.Add(0);

            for (int i = 1; i < belok.Length; i++)
            {
                for (int j = 0; j < belok.Length; j++)
                {
                    if ((i + j)<=belok.Length)
                        sub=belok.Substring(j, i);
                    else
                        sub=belok.Substring(j)+belok.Substring(0, i +j-belok.Length);

                    cyclospectrum.Add(calcmass(sub));
                }
            }

            cyclospectrum.Add(calcmass(belok));

            cyclospectrum.Sort();
            return string.Join(" ", cyclospectrum);
        }

        static int Score(string belok, string spectrum)
        {
            List<string> belokM = cyclospectrum(belok).Split(' ').ToList();
            List<string> spectrumM = spectrum.Split(' ').ToList();

            int tmpscr = 0;

            foreach (var mass in belokM)
            {
                if (spectrumM.Contains(mass))
                {
                    spectrumM.Remove(mass);
                    tmpscr++;
                }
            }

            return tmpscr;
        }
        static void Main(string[] args)
        {
            string Peptide = Console.ReadLine();
            string Spectrum = Console.ReadLine();

            Console.WriteLine(Score(Peptide, Spectrum));
        }
    }
}