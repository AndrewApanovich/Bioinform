#include <map>
#include <vector> 
#include <string>
#include <algorithm>
#include <iostream>

using namespace std;


map<char, int> massAccord = { { 'G', 57 },{ 'A', 71 },{ 'S', 87 },{ 'P', 97 },{ 'V', 99 },{ 'T', 101 },{ 'C', 103 },{ 'I', 113 },{ 'L', 113 },{ 'N', 114 },
{ 'D', 115 },{ 'K', 128 },{ 'Q', 128 },{ 'E', 129 },{ 'M', 131 },{ 'H', 137 },{ 'F', 147 },{ 'R', 156 },{ 'Y', 163 },{ 'W', 186 } };

int calcmass(string str) {
	int m=0;
	for (int i=0; i<str.length(); i++) {
		m+=massAccord.at(str[i]);
	}
	return m;
}

int main() 
{
	string belok,str;
	vector<int> m = { 0 }; 
	cin >> belok;
	str=belok;
	str+=belok;

	for (int i = 1; i < belok.length(); i++) {
		for (int j = 0; j < belok.length(); j++) {
			m.push_back(calcmass(str.substr(j, i)));
		}
	}
	m.push_back(calcmass(belok));
	sort(m.begin(),m.end());
	for (int i = 0; i < m.size(); i++)
		cout<<m[i]<<" ";
	return 0;
}