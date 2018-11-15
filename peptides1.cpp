#include <iostream>
#include <string>

int main()
{
	std::string codonAccord="AAA-K AAC-N AAG-K AAU-N ACA-T ACC-T ACG-T ACU-T AGA-R AGC-S AGG-R AGU-S AUA-I AUC-I AUG-M AUU-I CAA-Q CAC-H CAG-Q CAU-H CCA-P CCC-P CCG-P CCU-P CGA-R CGC-R CGG-R CGU-R CUA-L CUC-L CUG-L CUU-L GAA-E GAC-D GAG-E GAU-D GCA-A GCC-A GCG-A GCU-A GGA-G GGC-G GGG-G GGU-G GUA-V GUC-V GUG-V GUU-V UAA-   UAC-Y UAG-   UAU-Y UCA-S UCC-S UCG-S UCU-S UGA   UGC-C UGG-W UGU-C UUA-L UUC-F UUG-L UUU-F";
	std::string rnk;
	std::cin >> rnk;
	std::string belok="";
	int step=4;
	for (int i=0;i<rnk.size();i)
	{
		std::string tmp=rnk.substr(i,3);
		int pos=codonAccord.find(tmp);
		belok=belok+codonAccord[pos+step];
        i=i+3;
	}
	std::cout<<belok<<std::endl;
	return 0;
}