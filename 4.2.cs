using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSP
{
    class Program
    {             
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
        
        static int HammDist(string str1, string str2)
        {
            int j = 0;
            int len = str1.Length;
            for (int i = 0; i < len; i++)
            {
                if (str1[i] != str2[i])
                {
                    j++;
                }
            }
            return j;
        }
        
        static int getD(string pattern, string str)
        {
            int len = str.Length;
            int k = pattern.Length;
            List<int> distance = new List<int>();
            for (int i = 0; i < len - k + 1; i++)
            {
                distance.Add(HammDist(pattern, str.Substring(i, k)));
            }
            return distance.Min();
        }
        
        static int dDNA(string pattern, string[] DNA)
        {
            int s = 0;
            foreach (string DNAi in DNA)
            {
                s += getD(pattern, DNAi);
            }
            return s;
        }
        
        static string MedianStr(string[] DNA, int k)
        {
            int distance = int.MaxValue;
            string med = "";
            List<string> kMers = collectionWords("AGCT", k);

            foreach (string kmer in kMers)
            {
                if (distance > dDNA(kmer, DNA))
                {
                    distance = dDNA(kmer, DNA);
                    med = kmer;
                }
            }
            return med;
        }
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            string str = "";
            while (true)
            {
                string tmp = Console.ReadLine();
                if (string.IsNullOrEmpty(tmp))
                    break;
                str += tmp + ' ';
            }
            string[] DNA = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);          
            Console.WriteLine(MedianStr(DNA, k));
            Console.ReadKey();
        }
    }
}