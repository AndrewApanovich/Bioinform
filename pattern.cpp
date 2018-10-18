#include <iostream> 
#include <string> 
 
using namespace std; 
 
int main() { 
   string genom;
   string pattern;
   cin>>pattern;
   cin>>genom;
   int count = 0, p = 0; 
   while ( (p = genom.find(pattern, p)) != genom.npos)
   {
     ++count; 
     ++p; 
   } 
   cout<<count;
   return 0; 
}
