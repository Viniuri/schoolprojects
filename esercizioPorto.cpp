<<<<<<< HEAD
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
    const float tariffa_Vela = 10;
    const float tariffa_Motore = 20;
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
        	return giorni*tariffa_Vela*barche[i-1].lunghezza;
        	occupato[i-1] = false;
    	}
    	else
    	{
        	return giorni*tariffa_Motore*barche[i-1].stazza;
        	occupato[i-1] = false;
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
};
int main(void)
{
    Porto porto;
    Barca barca, barche[100];
    int scelta, i, n , posto, giorni, importo;
    float lunghezza, stazza;
    string nome, nazionalita, tipo;
    do {
        cout<<"Premi 1 per parcheggiare le tua barca a MOTORE\n";
        cout<<"Premi 2 per parcheggiare le tua barca a VELA\n";
        cout<<"Premi 3 per terminare la sosta nel parcheggio\n";
        cout<<"Premi 4 per cercare informazioni su una BARCA\n";
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
                            cout<<"Questo posto e' gia libero, non puo' essere il suo!!!\n";
                            }
                            else
                            {
                                cout<<"Importo: " + importo;
                            }
                            break;
                case 4:		
                            cout<<"In quale posto si trova la barca -> "; cin>>posto;
                            barca = porto.ricercaInfo(posto);
                            if (barca.stazza == 0)
                            {
                                cout<<"Questo posto è libero, non può essere il suo!!!\n";
                            }
                            else
                            {
                                cout<<"Informazioni riguardanti la barca" + barca.nome + ", " + barca.nazionalita;
                                //cout<<" " + barca.lunghezza + ", " + barca.stazza;
                            }
                            break;
                default:break;
            }
    }while (scelta!=0);
}