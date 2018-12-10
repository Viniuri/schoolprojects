#include <iostream>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <cstdio>
#include <time.h>
using namespace std;
class Data {
	public:
		int giornoScadenza, meseScadenza, annoScadenza;
		Data(void) {
			giornoScadenza = 0;
			meseScadenza = 0;
			annoScadenza = 0;
		}
		Data(int g, int m, int a) {
			giornoScadenza = g;
			meseScadenza = m;
			annoScadenza = a;
		}
};
class Rfid : public Data{
    public:
        int codiceNumericoId, giornoScadenza, meseScadenza, annoScadenza, calorie, numeroPorzioni;
        string descrizione, tipologia;
        Data data;
        //Costruttore di default
        Rfid(void) {
            codiceNumericoId = 0;
            descrizione = "";
 			data = Data();
            calorie = 0;
            tipologia = "";
            numeroPorzioni=0;
        }
        //Tag per prodotto PRECOTTO
        Rfid(int cId, string descr, int giornoS, int meseS, int annoS, int cal, string tipo, int nP) {
            codiceNumericoId = cId;
            descrizione = descr;
			data = Data(giornoS, meseS, annoS);
            calorie = cal;
            tipologia = tipo;
            numeroPorzioni = nP;
        }
        //Tag per prodotto NON-PRECOTTO
        Rfid(int cId, string descr, int giornoS, int meseS, int annoS, int cal) {
            codiceNumericoId = cId;
            descrizione = descr;
            data = Data(giornoS, meseS, annoS);
            calorie = cal;
        }
};
class Prodotto : public Rfid{
    //Ogni prodotto ha una tag RFID
    public:
    	Rfid tagRfid;
    	int posto;
    	string nome;
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
        bool scaduto(int giorno, int mese, int anno)
		{
			if (anno > data.annoScadenza) {
				return true;
			}
			if (anno < data.annoScadenza) {
				return false;
			}
			if (mese > data.meseScadenza) {
				return true;
			}
			if (mese < data.meseScadenza) {
				return false;
			}
			if (giorno > data.giornoScadenza) {
				return true;
			}
		 return false;
	 	}
};
class Frigorifero {
    public:
        Prodotto prodotti[50];
        bool occupato[50];
        Frigorifero(void) {
            for(int i = 0;i < 50; i++) {
                occupato[i] = false;
            }						
        }
        int inserisciProdotto(Prodotto prodotto){
		    for (int i=0; i<50; i++) {
		        if (occupato[i] == false) {
		            prodotti[i] = prodotto;
		            occupato[i] = true;
		            return i;
		        }
		    }
		    return -1; // nessun posto libero all'interno del frigorifero
		}
        bool estraiProdotto(int codiceId, int g, int m, int a) {
			for(int i=0; i < 50; i++) {
				if((prodotti[i].codiceNumericoId == codiceId) && (prodotti[i].data.giornoScadenza == g && prodotti[i].data.meseScadenza == m && prodotti[i].data.annoScadenza == a)) {
					prodotti[i] = Prodotto();
					occupato[i] = false;
					return true;
				}
			}
			return false;	
        }
        void elencoProdotti() {
        	for(int i=0; i < 50; i++) {
        		cout<<i<<") "<<prodotti[i].nome<<" - ";
        		if(i != 0 &&i % 10 == 0) {
        			cout<<"\n";
				}
			}
			cout<<"\n";
		}
		void elencoProdottiScaduti(int g, int m, int a) {
        	for(int i=0; i < 50; i++) {
        		if(prodotti[i].scaduto(g,m,a)) {
        		cout<<i<<") "<<prodotti[i].nome<<" - ";
        			if(i != 0 &&i % 10 == 0) {
        				cout<<"\n";
					}
				}
			}
			cout<<"\n";
		}
		int quantitaProdotto(int codiceId) {
			int n = 0;
			for(int i=0; i < 50; i++) {
				if(prodotti[i].codiceNumericoId == codiceId) {
					n++;
				}
			}
			return n;
		}
};
int main(int argc, char const *argv[])
{
    Frigorifero frigorifero;
    Prodotto p, prodotti[50];
    Data data;
    int scelta, cId, giorno, mese, anno, cal, nP, posto, n;
    int giornoOggi, meseOggi, annoOggi;
    string nome, descr, tipo;
    time_t t = time(NULL);
	struct tm tm = *localtime(&t);
	annoOggi = tm.tm_year + 1900;
	meseOggi = tm.tm_mon + 1;
	giornoOggi = tm.tm_mday;
	cout<<"Data: "<<giornoOggi<<"/"<<meseOggi<<"/"<<annoOggi<<"\n";
    do{
    	cout<<"Premi [1] per inserire un prodotto PRECOTTO nel frigorifero\n";
    	cout<<"Premi [2] per inserire un prodotto NON-PRECOTTO nel frigorifero\n";
    	cout<<"Premi [3] per prelevare un prodotto dal frigorifero\n";
    	cout<<"Premi [4] per stampare tutti i prodotti presenti nel frigorifero\n";
    	cout<<"Premi [5] per stampare tutti i prodotti scaduti presenti nel frigorifero\n";
    	cout<<"Premi [6] per stampare quante confezioni  di prodotti sono presenti nel frigorifero, dato il codice identificativo\n";
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
				cout<<"Inserisci la tipologia del prodotto(antipasto, primo , secondo, contorno, dolce): ";cin>>tipo;
				cout<<"Inserisci il numero delle porzioni del prodotto: ";cin>>nP;
				p = Prodotto(nome, cId, descr, giorno, mese, anno, cal, tipo, nP);
				if ((posto = frigorifero.inserisciProdotto(p)) < 0)
                {
                	cout<<"Il frigorifero e' pieno!\n";
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
				if ((posto = frigorifero.inserisciProdotto(p)) < 0)
                {
                	cout<<"Il frigorifero e' pieno";
                }
            	else
                {
                    cout<<"Prodotto inserito correttamente nel frigo\n";
                    prodotti[posto] = p;
                    p.posto = posto;
                }
				break;
			case 3:
				cout<<"Inserisci il codice identificativo del prodotto -> ";cin>>cId;
				cout<<"Inserisci la data di scadenza del prodotto, del quale hai fornito il codice identificativo,\nGIORNO: ";cin>>giorno;
				cout<<"MESE: ";cin>>mese;
				cout<<"ANNO: ";cin>>anno;
				if(frigorifero.estraiProdotto(cId, giorno, mese, anno)) {
					cout<<"Prodotto prelevato correttamente dal frigorifero\n";
				}
				else {
					cout<<"Inserisci un codice ESISTENTE!\n";
				}
				break;
			case 4:
				frigorifero.elencoProdotti();
				break;
			case 5:
				frigorifero.elencoProdottiScaduti(giornoOggi, meseOggi, annoOggi);
				break;
			case 6:
				cout<<"Inserisci il codice identificativo del prodotto -> ";cin>>cId;
				n = frigorifero.quantitaProdotto(cId);
				cout<<"Sono presenti "<<n<<" confezioni nel frigorifero!\n";
		}
	}while(scelta!=0);
    return 0;
}
