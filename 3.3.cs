using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSP
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
        
        static List<string> expand(List<string> belki)
        {
            List<string> nBelki=new List<string>();

            foreach (var belok in belki)
            {
                foreach (var key in AAM.Keys)
                {
                    nBelki.Add(belok+key);
                }
            }
            return nBelki;
        }
        
        static string linearSpectrum(string belok)
        {
            List<int> linearspectrum = new List<int>();
            string sub = " ";
            int mass = 0;

            if (belok.Length == 1)
                return AAM[belok[0]].ToString();

            linearspectrum.Add(0);

            for (int i=1; i<belok.Length; i++)
            {
                for (int j=0; j<belok.Length; j++)
                {
                    if ((i+j)<=belok.Length)
                    {
                        sub=belok.Substring(j, i);
                        linearspectrum.Add(calcmass(sub));
                    }
                }
            }

            linearspectrum.Add(calcmass(belok));
            linearspectrum.Sort();
            return string.Join(" ", linearspectrum);
        }
        
         static int Score(string belok, string spectrum)
        {
            List<string> belokM = linearSpectrum(belok).Split(' ').ToList();
            List<string> spectrumM = spectrum.Split(' ').ToList();

            int tmpscr = 0;

            foreach (var m in belokM)
            {
                if (spectrumM.Contains(m))
                {
                    spectrumM.Remove(m);
                    tmpscr++;
                }
            }

            return tmpscr;
        }
             
        static List<string> Trim(List<string> Leadboard, string Spectrum, int n)
        {
            Leadboard.Sort((a, b) => Score(b, Spectrum).CompareTo(Score(a, Spectrum)));
            if (Leadboard.Count > n)
            {
                int fin = n;
                for (int i = n; i < Leadboard.Count; i++)
                {
                    if (Score(Leadboard[n - 1], Spectrum) == Score(Leadboard[i], Spectrum))
                    {
                        fin = i;
                    }
                    else break;
                }

                Leadboard = Leadboard.Take(fin + 1).ToList();
            }

            return Leadboard;
        }

        static int parentM(string spectrum)
        {
            int parentmass = int.Parse(spectrum.Split(' ').Last());
            return parentmass;
        }

        static string LeadboardCS(string spectrum, int n)
        {
            List<string> Leadboard = new List<string>() { "" };
            string LeadBelok = "";
            while(Leadboard.Count() > 0)
            {
                Leadboard = expand(Leadboard);

                List<string> LeadboardExemple = new List<string>(Leadboard);
                foreach (var Belok in LeadboardExemple)
                {
                    if(calcmass(Belok) == parentM(spectrum))
                    {
                        if(Score(Belok, spectrum) > Score(LeadBelok, spectrum))
                        {
                            LeadBelok = Belok;
                        }
                    }
                    else if(calcmass(Belok) > parentM(spectrum))
                    {
                        Leadboard.Remove(Belok);
                    }
                }
                Leadboard = Trim(Leadboard, spectrum, n);
            }
            return LeadBelok;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string spectrum = Console.ReadLine();

            string LeadBelok = LeadboardCS(spectrum, n);

            List<string> M = new List<string>();
            foreach (var Belok in LeadBelok)
            {
                M.Add(AAM[Belok].ToString());
            }

            Console.WriteLine(string.Join("-", M));
        }
    }
}