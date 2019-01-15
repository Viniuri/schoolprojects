#include <iostream>
#include <fstream>
#include <string>
using namespace std;
//various things

int main(int argc, char** argv)
{
	string line;
	unsigned int posLine = 0;
	ifstream file_data("input.cpp", ios::in);
	string tag [] = {"\\file","\\author","\\date","\\version","\\class","\\fn","\\var","\\property","\\brief","\\short","\\details","\\param[in]","\\param[out]","\\retval","\\return","\\result","\\note","\\bug","\\todo"};
	bool end = false;
	if (file_data.is_open())
	{
		//cout<<data_file.rdbuf(); Stampa tutto il file
		while (getline (file_data, line))
		{
			posLine++;
			for(int i = 0; i < 16; i++) {
			if (line.find(tag[i]) != string::npos) {
        		cout << "Trovato: " << tag[i] << " - Linea: " << posLine <<endl;
    			}
    		}	
		}
	}
	else
	{
		cout<<"Non posso aprire il file\n"<<endl;
		end=true;
	}
	file_data.close();
        //other things
	return 0;
}