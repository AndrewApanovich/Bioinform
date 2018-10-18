#include <iostream> 
#include <string> 
using namespace std; 
 
int main() { 
   string dnk;
   
   cin>>dnk;
   
   
   for(int i=0;i<dnk.length();i++)
   {
	   switch(dnk[i])
	   {
			case 65: 
			{
				dnk[i] = 84;
				break;
			}
			case 84: 
			{
				dnk[i] = 65;
				break;
			}
			case 67:
			{
				dnk[i] = 71;
				break;
			}
			case 71: 
			{
				dnk[i] = 67;
				break;
			}
			default: break;
	   }
   }
  
   for(int i=dnk.length()-1;i>=0;i--)
   {
		cout<<dnk[i];
   }
}