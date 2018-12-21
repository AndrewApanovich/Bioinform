using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP
{
    class Program
    {
       
        static bool Valmismatches(string text,string copy,int mismatches)
        {
            int differs=0;
            int length=text.Length;
            for (int i=0; i<length; i++)
            {
                if (text[i]!=copy[i])
                {
                    differs++;
                }

                if (differs>mismatches)
                {
                    return false;
                }
            }
            return true;
        }
        
        static void collectWords(ref List<string> words,string text,int len,string pref)
        {
            if (len==0)
            {
                words.Add(pref);
            }
            else
                foreach (char x in text)
                {
                    collectWords(ref words,text,len-1,pref+x);
                }
        }
        
        static List<string> collectionWords(string text,int len)
        {
            List<string> words = new List<string>((int)Math.Pow(4, len));
            collectWords(ref words,text, len, "");
            return words;
        }
        
        static List<string> collectMotifs(string kmer,int mismatches)
        {
            string text = "AGCT";
            List<string> patterns = new List<string>();

            foreach (var f in collectionWords(text,kmer.Length))
            {
                if (Valmismatches(f.ToString(),kmer,mismatches))
                {
                    patterns.Add(f.ToString());
                }
            }

            return patterns;
        }

        static void Main(string[] args)
        {
            string[] marks = Console.ReadLine().Split(' ');
            int k = int.Parse(marks[0]);
            int q = int.Parse(marks[1]);
            string str = "";
            while (true)
            {
                string tmp = Console.ReadLine();
                if (string.IsNullOrEmpty(tmp))
                    break;

                str += tmp + ' ';
            }
            string[] DNA = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> patterns = new List<string>();
            foreach (string str2 in DNA)
            {
                int len = str2.Length;
                for (int i = 0; i < len - k + 1; i++)
                {
                    string kmer = str2.Substring(i, k);

                    foreach (string pattern in collectMotifs(kmer, q))
                    {
                        int am = 0;
                        foreach (string strsub in DNA)
                        {
                            for (int j = 0; j < len - k + 1; j++)
                            {
                                if (Valmismatches(strsub.Substring(j, k), pattern, q))
                                {
                                    am++;
                                    break;
                                }
                            }
                        }
                        if (am == DNA.Length)
                        {
                            patterns.Add(pattern);
                        }
                    }
                }
            }
            patterns = patterns.Distinct().ToList();
            Console.WriteLine(string.Join(" ", patterns));
            Console.ReadKey();
        }
    }
}