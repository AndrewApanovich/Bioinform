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
        {{'G', 57}, {'A', 71}, {'S', 87}, {'P', 97}, {'V', 99}, {'T', 101}, {'C', 103}, {'I', 113}, {'L', 113}, {'N', 114}, {'D', 115}, {'K', 128},
         { 'Q', 128}, {'E', 129}, {'M', 131}, {'H', 137}, {'F', 147}, {'R', 156}, {'Y', 163}, {'W', 186}};

        static int calcmass(string belok)
        {
            int m=0;
            for (int i=0; i<belok.Length; i++)
                m +=AAM[belok[i]];
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

        static string cyclospectrum(string belok)
        {
            List<int> cyclospectrum=new List<int>();
            string sub=" ";
            

            cyclospectrum.Add(0);

            for (int i=1; i<belok.Length; i++)
            {
                for (int j=0; j<belok.Length; j++)
                {
                    if ((i+j)<=belok.Length)
                        sub=belok.Substring(j, i);
                    else
                        sub=belok.Substring(j)+belok.Substring(0, i+j - belok.Length);
                    cyclospectrum.Add(calcmass(sub));
                }
            }

            cyclospectrum.Add(calcmass(belok));

            cyclospectrum.Sort();
            return string.Join(" ", cyclospectrum);
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

        static bool Consist(string belok, string spectrum)
        {
            List<string> specM = spectrum.Split(' ').ToList();
            List<string> belokM = linearSpectrum(belok).Split(' ').ToList();

            foreach (var mas in belokM)
            {
                if (specM.Contains(mas) != true)
                {
                    return false;
                }
            }
            return true;
        }

        static int parentM(string spectrum)
        {
            int parentmass = int.Parse(spectrum.Split(' ').Last());
            return parentmass;
        }

        static List<string> CyclopeptideSequencing(string Spectrum)
        {
            List<string> Peptides = new List<string>() { "" };
            List<string> PeptideOut = new List<string>();

            while (Peptides.Count > 0)
            {
                Peptides = expand(Peptides);
                List<string> PeptidesExemple = new List<string>(Peptides);
                foreach (var Peptide in PeptidesExemple)
                {
                    if (calcmass(Peptide) == parentM(Spectrum))
                    {
                        if (cyclospectrum(Peptide) == Spectrum)
                            PeptideOut.Add(Peptide);
                        Peptides.Remove(Peptide);
                    }
                    else if (Consist(Peptide, Spectrum) != true)
                    {
                        Peptides.Remove(Peptide);
                    }
                }
            }
            return PeptideOut;
        }

        static void Main(string[] args)
        {
            string Spectrum = Console.ReadLine();

            List<string> PeptideOut=new List<string>();
            PeptideOut=CyclopeptideSequencing(Spectrum);

            List<string> MassOutput = new List<string>();

            foreach (var peptide in PeptideOut)
            {
                List<string> mass = new List<string>();
                foreach (var i in peptide)
                {
                    mass.Add(AAM[i].ToString());
                }

                MassOutput.Add(string.Join("-", mass));
            }

            Console.WriteLine(string.Join(" ", MassOutput.Distinct()));
        }
    }
}