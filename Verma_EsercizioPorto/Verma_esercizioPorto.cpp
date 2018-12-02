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
    Barca(string Nome, string Nazionalita, int Lun, int Stazza, bool Vela) { //Costruttore
        nome = Nome;
        nazionalita = Nazionalita;
        lunghezza = Lun;
        stazza = Stazza;
        vela = Vela;
    };
    Barca(void) { //Costruttore di default
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
            occupato[i] = false; //Posti all'inizio non occupati, cio� false
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
        	return giorni*tariffa_Vela*barche[i-1].lunghezza; //Per metro
    	}
    	else
    	{
    		occupato[i-1] = false;
        	return giorni*tariffa_Motore*barche[i-1].stazza; //Per metro
    	}
    }

    Barca ricercaInfo(int i)
    {
        Barca barca; //Utilizzo il costruttore di default per assegnare una lunghezza e stazza uguale a zero
        if ((occupato[i-1] == false) || (i<=0 || i>= 100)) //Controllo per vedere se � sbagliato il posto fornito
        {
            return barca;
        }
        return barche[i-1];
    }
    void ricercaSpecifica(int minimo, int massimo, Barca trovate[])
	{
		int c = 0;
		for (int i=1; i<=100; i++)
		{
			if (occupato[i-1] == true)
	    	{
				if (barche[i-1].lunghezza >= minimo && barche[i-1].lunghezza <= massimo)
		    	{
					cout<<c<<". POSTO["<<i<<"] -> ";
					cout<<"Informazioni riguardanti la barca: Nome -> " + barche[i-1].nome + ", Nazionalita' -> " + barche[i-1].nazionalita;
            		cout<<", Lunghezza -> "<<barche[i-1].lunghezza<<", Stazza -> "<<barche[i-1].stazza;
            		if(barche[i-1].vela == true)
                    {
                        cout<<", Tipologia -> Vela\n";
					}
					else
					{
						cout<<", Tipologia -> Motore\n";
					}
            		c++;
		    	}
		    }
		}
	}
};
int main(void)
{
    Porto porto;
    Barca barca, barche[100];
    int scelta, i, n , posto, giorni, importo, minimo, massimo, lunghezza, stazza;
    string nome, nazionalita, tipo;
    do {
        cout<<"Premi [1] per parcheggiare la tua barca a MOTORE\n";
        cout<<"Premi [2] per parcheggiare la tua barca a VELA\n";
        cout<<"Premi [3] per terminare la sosta nel parcheggio\n";
        cout<<"Premi [4] per cercare informazioni su una BARCA\n";
        cout<<"Premi [5] per cercare informazioni su BARCHE aventi una determinata lunghezza MINIMA e MASSIMA\n";
        cout<<"Scelta: ";
        cin>>scelta;
        switch (scelta)
            {
                case 1:	//Barca  a motore	
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
                                cout<<"Assegnato il : "<<posto<<" posto\n";
                                barche[posto] = barca;
                            }
                            break;
                case 2:	//Barca a vela	
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
                                cout<<"Assegnato il : "<<posto<<" posto\n";
                                barche[posto] = barca;
                            }
                            break;
                case 3:	//Libera il posto dalla barca	
                            cout<<"In quale posto si trovava la barca -> "; cin>>posto;
                            cout<<"Per quanti giorni ha sostato -> "; cin>>giorni;
                            importo = porto.liberaPosto(posto, giorni);
                            if(importo == 0)
                            {
                            cout<<"Questo posto e' gia LIBERO, non puo' essere il suo!\n";
                            }
                            else
                            {
                                cout<<"Importo: "<<importo<<" Euro\n";
                            }
                            break;
                case 4:	//Ricerca info su una barca	
                            cout<<"In quale posto si trova la barca -> "; cin>>posto;
                            barca = porto.ricercaInfo(posto);
                            if (barca.lunghezza == 0)
                            {
                                cout<<"Questo posto e' gia libero, non puo' essere il suo!!!\n";
                            }
                            else
                            {
                                cout<<"Informazioni riguardanti la barca: Nome -> " + barca.nome + ", Nazionalita' -> " + barca.nazionalita;
                                cout<<", Lunghezza -> "<<barca.lunghezza<<", Stazza -> "<<barca.stazza;
                                if(barca.vela == true)
                                {
                                	cout<<", Tipologia -> Vela\n";
								}
								else
								{
									cout<<", Tipologia -> Motore\n";
								}
                            }
                            break;
                case 5:	//Ricerca barche dando un range minimo e massimo di lunghezza	
							cout<<"Lunghezza minima -> "; cin>>minimo;
							cout<<"Lunghezza massima -> "; cin>>massimo;
							porto.ricercaSpecifica(minimo, massimo, barche);
						break;           
                default:
						break;
            }
    }
	while (scelta!=0);
}
