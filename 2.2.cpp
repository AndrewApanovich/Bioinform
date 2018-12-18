#include <map>  
#include <iostream>
#include <string>
using namespace std;

map<string, char> codonAccord = { { "AAA", 'K' },{ "AAC", 'N' },{ "AAG", 'K' },{ "AAU", 'N' },{ "ACA", 'T' },{ "ACC", 'T' },{ "ACG", 'T' },{ "ACU", 'T' },
{ "AGA", 'R' },{ "AGC", 'S' },{ "AGG", 'R' },{ "AGU", 'S' },{ "AUA", 'I' },{ "AUC", 'I' },{ "AUG", 'M' },{ "AUU", 'I' },
{ "CAA", 'Q' },{ "CAC", 'H' },{ "CAG", 'Q' },{ "CAU", 'H' },{ "CCA", 'P' },{ "CCC", 'P' },{ "CCG", 'P' },{ "CCU", 'P' },
{ "CGA", 'R' },{ "CGC", 'R' },{ "CGG", 'R' },{ "CGU", 'R' },{ "CUA", 'L' },{ "CUC", 'L' },{ "CUG", 'L' },{ "CUU", 'L' },
{ "GAA", 'E' },{ "GAC", 'D' },{ "GAG", 'E' },{ "GAU", 'D' },{ "GCA", 'A' },{ "GCC", 'A' },{ "GCG", 'A' },{ "GCU", 'A' },
{ "GGA", 'G' },{ "GGC", 'G' },{ "GGG", 'G' },{ "GGU", 'G' },{ "GUA", 'V' },{ "GUC", 'V' },{ "GUG", 'V' },{ "GUU", 'V' },
{ "UAA", ' ' },{ "UAC", 'Y' },{ "UAG", ' ' },{ "UAU", 'Y' },{ "UCA", 'S' },{ "UCC", 'S' },{ "UCG", 'S' },{ "UCU", 'S' },
{ "UGA", ' ' },{ "UGC", 'C' },{ "UGG", 'W' },{ "UGU", 'C' },{ "UUA", 'L' },{ "UUC", 'F' },{ "UUG", 'L' },{ "UUU", 'F' } };


string reverse(string pat)
{
	string newpat;

	for (int i = 0; i < pat.length(); i++)
	{
		switch (pat[i])
		{
		case 'T':
			newpat = 'A' + newpat;
			break;
		case 'A':
			newpat = 'T' + newpat;
			break;
		case 'G':
			newpat = 'C' + newpat;
			break;
		case 'C':
			newpat = 'G' + newpat;
			break;
		}
	}

	return newpat;
}

string trnscr(string str)
{
	string RNA = "";
	for (int i = 0; i < str.length(); i++) {
		if (str[i] == 'T') {
			RNA += 'U';
		}
		else {
			RNA += str[i];
		}
	}
	return RNA;
}

string trnslt(string p) 
{
	string belok = "";
	for (int i = 0; i < p.length(); i += 3) {
		belok += codonAccord.at(p.substr(i, 3));
	}
	return belok;
}



int main() 
{
	string DNA,RNA,nRNA,belok,str;
	cin>>DNA;
	cin>>belok;
	for (int i=0; i<DNA.length()-belok.length()*3+1; i++)
	{
		RNA=trnscr(DNA.substr(i, belok.length()*3));
		str=reverse(DNA.substr(i, belok.length()*3));
		nRNA=trnscr(str);

		if (belok==trnslt(RNA) || belok==trnslt(nRNA))
		{
			cout<<DNA.substr(i, belok.length()*3) <<endl;
		}
	}
	return 0;
}