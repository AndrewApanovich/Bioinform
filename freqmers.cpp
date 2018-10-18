#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main() 
{
    int k;
    string dnk;
    vector<string> kmers;
    int max_count = 0;
    cin >> dnk;
	cin >> k;
	for (int i = 0; i <= dnk.size() - k; ++i) 
	{
        string tmp = dnk.substr(i, k);
        int st_elem = i;
        int count = 0;
        while ((st_elem = dnk.find(tmp, st_elem)) != string::npos) 
		{
            ++st_elem;
            ++count;
        }
        if (count > max_count) 
		{
            kmers.clear();
            max_count = count;
            kmers.push_back(tmp);
        } else if (count == max_count) 
		{
            kmers.push_back(tmp);
        }
    }
    
    for (string& substring : kmers) 
	{
        cout << substring << ' ';
    }
    return 0;
	
}