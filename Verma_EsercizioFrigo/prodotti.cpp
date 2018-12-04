#include <iostream>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <cstdio>
using namespace std;
class Rfid {
    private:
    //Variabili private
    public:
        int codiceNumericoId, giornoScadenza, meseScadenza, annoScadenza, calorie, numeroPorzioni;
        string descrizione, tipologia;
        //Costruttore di default
        Rfid(void) {
            codiceNumericoId = 0;
            descrizione = "";
            giornoScadenza = 0;
            meseScadenza = 0;
            annoScadenza = 0;
            calorie = 0;
            tipologia = "";
            numeroPorzioni=0;
        }
        //Tag per prodotto PRECOTTO
        Rfid(int cId, string descr, int giorniS, int meseS, int annoS, int cal, string tipo, int nP) {
            codiceNumericoId = cId;
            descrizione = descr;
            giornoScadenza = giorniS;
            meseScadenza = meseS;
            annoScadenza = annoS;
            calorie = cal;
            tipologia = tipo;
            numeroPorzioni = nP;
        }
        //Tag per prodotto NON-PRECOTTO
        Rfid(int cId, string descr, int giorniS, int meseS, int annoS, int cal) {
            codiceNumericoId = cId;
            descrizione = descr;
            giornoScadenza = giorniS;
            meseScadenza = meseS;
            annoScadenza = annoS;
            calorie = cal;
        }
};
class Prodotto : Rfid{
    //Ogni prodotto ha una tag RFID
    Rfid tagRfid;
    string nome;
    int posto;
    public:
        Prodotto(void) {
            tagRfid = Rfid();
        }
        //Tag per prodotto PRECOTTO
        Prodotto(string n, int cId, string descr, int giorniS, int meseS, int annoS, int cal, string tipo, int nP) : Rfid(cId, descr, giorniS, meseS, annoS, cal, tipo, nP) {
            nome = n;
        }
        //Tag per prodotto NON-PRECOTTO
        Prodotto(string n, int cId, string descr, int giorniS, int meseS, int annoS, int cal) : Rfid(cId, descr, giorniS, meseS, annoS, cal) {
            nome = n;
        }
};
class Frigorifero {
    private:
    //Variabili private
    public:
        Prodotto prodotti[50];
        bool occupato[50];
        Frigorifero(void) {
            for(int i = 0;i < 50; i++) {
                occupato[i] = false; //Quando vai a scrivere la funzione del prodotto che va ad occupato un posto
            }						//Metti occupato come true ed aggiorni Prodotto prodotti[50]
        }
        int inserisciP(Prodotto prodotto){
		    for (int i=0; i<50; i++) {
		        if (occupato[i] == false) {
		            prodotti[i] = prodotto;
		            occupato[i] = true;
		            return i;
		        }
		    }
		    return -1; // nessun posto libero per barche a vela
		}
        /*
        int liberaP(Prodotto prodotto) {
            if (prodotto.posto<=0 || prodotto.posto>= 50) {
                return 0;
            }
            if (occupato[prodotto.posto] == false) {
                return 0;
            }
            else {
    	        occupato[prodotto.posto] = false;
            }
        }
        */
}	
};
int main(int argc, char const *argv[])
{
    Frigorifero frigorifero;
    Prodotto p, prodotti[50];
    int scelta, cId, giorno, mese, anno, cal, nP, posto;
    string nome, descr, tipo;
    do{
    	cout<<"Premi [1] per inserire un prodotto PRECOTTO nel frigorifero\n";
    	cout<<"Premi [2] per inserire un prodotto NON-PRECOTTO nel frigorifero\n";
    	cout<<"Scelta ->> ";cin>>scelta;
    	switch(scelta)
    	{
    		case 1:	
				cout<<"Inserisci il nome del prodotto: ";cin>>nome;
				cout<<"Inserisci il codice identificativo del prodotto: ";cin>>cId;
				cout<<"Inserisci una breve descrizione del prodotto: ";cin>>descr;
				cout<<"Inserisci la data di scadenza del prodotto,\nGIORNO: ";cin>>giorno;
				cout<<"MESE: ";cin>>mese;
				cout<<"ANNO: ";cin>>anno;
				cout<<"Inserisci le calorie del prodotto: ";cin>>cal;
				cout<<"Inserisci la tipologia del prodotto: ";cin>>tipo;
				cout<<"Inserisci il numero delle porzioni del prodotto: ";cin>>nP;
				p = Prodotto(nome, cId, descr, giorno, mese, anno, cal, tipo, nP);
				if ((posto = frigorifero.inserisciP(p)) < 0)
                {
                	cout<<"Il frigorifero � pieno!\n";
                }
            	else
                {
                    cout<<"Prodotto inserito correttamente nel frigorifero\n";
                    prodotti[posto] = p;
                    p.posto = posto;
                }
				break;
			case 2:	
				cout<<"Inserisci il nome del prodotto: ";cin>>nome;
				cout<<"Inserisci il codice identificativo del prodotto: ";cin>>cId;
				cout<<"Inserisci una breve descrizione del prodotto: ";cin>>descr;
				cout<<"Inserisci la data di scadenza del prodotto,\nGIORNO: ";cin>>giorno;
				cout<<"MESE: ";cin>>mese;
				cout<<"ANNO: ";cin>>anno;
				cout<<"Inserisci le calorie del prodotto: ";cin>>cal;
				p = Prodotto(nome, cId, descr, giorno, mese, anno, cal);
				if ((posto = frigorifero.inserisciP(p)) < 0)
                {
                	cout<<"Il frigorifero � pieno";
                }
            	else
                {
                    cout<<"Prodotto inserito correttamente nel frigo";
                    prodotti[posto] = p;
                    p.posto = posto;
                }
				break;		
		}
	}while(scelta!=0);
    return 0;
}
