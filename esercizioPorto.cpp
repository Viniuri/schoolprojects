#include <iostream>
#include <math.h>
#include <cstdio>
#include <string.h>
using namespace std;
class Barca {
    public:

    string nome;
    string nazionalita;
    int lunghezza;
    int stazza;
    bool vela;
    Barca(string Nome, string Nazionalita, int Lun, int Stazza, bool Vela) {
        nome = Nome;
        nazionalita = Nazionalita;
        lunghezza = Lun;
        stazza = Stazza;
        vela = Vela;
    };
    Barca(void) {
        nome = "";
        nazionalita = "";
        lunghezza = 0;
        stazza = 0;
    };
};

class Porto {
    public:
    const int tariffa_Vela = 10;
    const int tariffa_Motore = 20;
    Barca barche[100];
    bool occupato[100];
    Porto(void) {
        for(int i=0; i < 100; i++) //Scorro tutto l'array
        { 
            occupato[i] = false;
        }
    };
    //Parcheggio barca
    int occupaPosto(Barca barca)
    {
    if (barca.vela == true)
        {
        for (int i=51; i<=100; i++)
            if (occupato[i-1] == false)
            {
            barche[i-1] = barca;
            occupato[i-1] = true;
            return i;
            }
        return -1; // nessun posto libero per barche a vela
        }
    else
        {
        if (barca.lunghezza < 10)
            for (int i=1; i<=20; i++)
                if (occupato[i-1] == false)
                {
                barche[i-1] = barca;
                occupato[i-1] = true;
                return i;
                }
            for (int i=21; i<=100; i++)
                if (occupato[i-1] == false)
                {
                barche[i-1] = barca;
                occupato[i-1] = true;
                return i;
                }
            return -1; // nessun posto libero
        }
    }
    int liberaPosto(int i, int giorni)
    {
    	if (i<=0 || i>= 100)
    	{
        	return 0;
    	}
    	if (occupato[i-1] == false)
    	{
        	return 0;
    	}
    	if (barche[i-1].vela == true)
    	{
    		occupato[i-1] = false;
        	return giorni*tariffa_Vela*barche[i-1].lunghezza;
    	}
    	else
    	{
    		occupato[i-1] = false;
        	return giorni*tariffa_Motore*barche[i-1].stazza;
    	}
    }

    Barca ricercaInfo(int i)
    {
        Barca barca;
        if ((occupato[i-1] == false) || (i<=0 || i>= 100))
        {
            return barca;
        }
        return barche[i-1];
    }
    int ricercaSpecifica(int minimo, int massimo, Barca barche[])
	{
		int n[100];
		int c = 0;
		for (int i=1; i<=100; i++)
		{
			if (occupato[i-1] == true)
	    	{
				if (barche[i-1].lunghezza >= minimo && barche[i-1].lunghezza <= massimo)
		    	{
					n[c] = i-1;
					c++;
		    	}
		    }
		}
		for(int i = 0; i < sizeof(n)/sizeof(n[0]); i++)
		{
			if(n[i] == 0)
			{
				i = 100;
			}
			else
			{
				print(n[i], barche);
			}
		}
		return 0;
	}
	void print(int n, Barca barche[])
	{
		cout<<"Informazioni riguardanti la barca: Nome -> " + barche[n].nome + ", Nazionalita' -> " + barche[n].nazionalita;
        cout<<", Lunghezza -> ";
        cout<<barche[n].lunghezza;
    	cout<<", Stazza -> ";
        cout<<barche[n].stazza;
        cout<<"\n";
	}
};
int main(void)
{
    Porto porto;
    Barca barca, barche[100];
    int scelta, i, n , posto, giorni, importo, minimo, massimo;
    int nBarche[100];
    float lunghezza, stazza;
    string nome, nazionalita, tipo;
    do {
        cout<<"Premi 1 per parcheggiare la tua barca a MOTORE\n";
        cout<<"Premi 2 per parcheggiare la tua barca a VELA\n";
        cout<<"Premi 3 per terminare la sosta nel parcheggio\n";
        cout<<"Premi 4 per cercare informazioni su una BARCA\n";
        cout<<"Premi 5 per cercare informazioni su BARCHE aventi una determinata lunghezza MINIMA e MASSIMA\n";
        cout<<"Scelta: ";
        cin>>scelta;
        switch (scelta)
            {
                case 1:		
                            cout<<"Digiti il nome: "; cin>>nome;
                            cout<<"Digiti la nazionalita: "; cin>>nazionalita;
                            cout<<"Digiti la lunghezza: "; cin>>lunghezza;
                            cout<<"Digiti la stazza: "; cin>>stazza;
                            barca = Barca(nome, nazionalita, lunghezza, stazza, false);
                            if ((posto = porto.occupaPosto(barca)) < 0)
                            {
                                cout<<"Tutti i posti sono occupati";
                            }
                            else
                            {
                                cout<<"\nAssegnato il : ";
                                cout<<posto;
                                cout<<" posto\n";
                            }
                            break;
                case 2:		
                            cout<<"Digiti il nome: "; cin>>nome;
                            cout<<"Digiti la nazionalita: "; cin>>nazionalita;
                            cout<<"Digiti la lunghezza: "; cin>>lunghezza;
                            cout<<"Digiti la stazza: "; cin>>stazza;
                            barca = Barca(nome, nazionalita, lunghezza, stazza, true);
                            if ((posto = porto.occupaPosto(barca)) < 0)
                            {
                                cout<<"Tutti i posti sono occupati\n";
                            }
                            else
                            {
                                cout<<"\nAssegnato il : ";
                                cout<<posto;
                                cout<<" posto\n";
                            }
                            break;
                case 3:		
                            cout<<"In quale posto si trovava la barca -> "; cin>>posto;
                            cout<<"Per quanti giorni ha sostato -> "; cin>>giorni;
                            importo = porto.liberaPosto(posto, giorni);
                            if(importo == 0)
                            {
                            cout<<"\nQuesto posto e' gia libero, non puo' essere il suo!!!\n";
                            }
                            else
                            {
                                cout<<"Importo: ";
                                cout<<importo;
                                cout<<"\n";
                            }
                            break;
                case 4:		
                            cout<<"In quale posto si trova la barca -> "; cin>>posto;
                            barca = porto.ricercaInfo(posto);
                            if (barca.lunghezza == 0)
                            {
                                cout<<"Questo posto e' gia libero, non puo' essere il suo!!!\n";
                            }
                            else
                            {
                                cout<<"Informazioni riguardanti la barca: Nome -> " + barca.nome + ", Nazionalita' -> " + barca.nazionalita;
                                cout<<", Lunghezza -> ";
                                cout<<barca.lunghezza;
                                cout<<", Stazza -> ";
                                cout<<barca.stazza;
                                cout<<"\n";
                            }
                            break;
                case 5:		cout<<"Lunghezza minima -> "; cin>>minimo;
							cout<<"Lunghezza massima -> "; cin>>massimo;
							porto.ricercaSpecifica(minimo, massimo, barche);
						break;           
                default:break;
            }
    }while (scelta!=0);
}
