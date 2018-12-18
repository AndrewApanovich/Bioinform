#include <unordered_map>  
#include <iostream>
#include <string>
using namespace std;

int main() 
{
	int AAM[18]={57,71,87,97,99,101,103,113/*!*/,114,115,128/*!*/,129,131,137,147,156,163,186 };
	int m;
	unordered_map<int,long> cont = {{0,1}};
    cin>>m;
    cont.reserve(m - 57);
	for (int i=57;i<=m;i++) 
    {
		cont[i]=0;
		for (int j=0; j<18;j++) 
        {
			if (cont.find(i-AAM[j])!=cont.end()) 
            {
				cont[i]+=cont[i-AAM[j]];
			}
		}
	}
	cout<<cont[m];
	return 0;
}