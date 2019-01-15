#include <iostream>
#include <string.h>
/*!
\file input.cpp
*/
class StrumentoLaboratorio {
    private:
        int numero_id;
        string descrizione;
        int costo;
        int anno_acqusizione;
        int anni_garanzia;
    public:
        //Get
        int getNumeroIdentificativo() { return numero_id; }
        string getDescrizione() { return descrizione; }
        int getCosto() { return costo; }
        int getAnnoAcquisizione() { return anno_acqusizione; }
        int getAnniGaranzia() { return anni_garanzia; }
        //Set
        void setNumeroIdentificativo(int nid) { numero_id = nid; }
        void setDescrizione() { descrizione = descr; }
        void setCosto() { costo = c; }
        void setAnnoAcquisizione(int a) { anno_acqusizione = a; }
        void setAnniGaranzia(int a) { anni_garanzia = a; }
        //Costruttore di default
        StrumentoLaboratorio(void) {
            setNumeroIdentificativo(0);
            setDescrizione(" ");
            setCosto(0);
            setAnnoAcquisizione(0000);
            setAnniGaranzia(0);
        }
        //Costruttore principale
        StrumentoLaboratorio(int id, string descr, int c, int anno_a , int anni_g) {
            setNumeroIdentificativo(id);
            setDescrizione(descr);
            setCosto(c);
            setAnnoAcquisizione(anno_a);
            setAnniGaranzia(anni_g);
        }
};
class SistemaSoftware {
    //Array di n strumenti
    StrumentoLaboratorio strumenti[100];
    bool aggiungiStrumento(StrumentoLaboratorio s) {
        for(int i = 0; i < 100; i++) {
            if(strumenti[i].getCosto() != 0) {
                strumenti[i] = s;
                return true; //Se strumento inserito allora ritorna "true"
            }

        }
        return false; //Se strumento non inserito allora ritorna "false"
    }
    bool eliminaStrumento(int id) {
        for(int i = 0; i < 100; i++) {
            if(strumenti[i].getNumeroIdentificativo() == id) {
                strumenti[i] = null;
                return true; //Se strumento eliminato allora ritorna "true"
            }

        }
        return false; //Se strumento non eliminato allora ritorna "false"
    }
    StrumentoLaboratorio ricercaSpecificaId(StrumentoLaboratorio s) {
        for(int i = 0; i < 100; i++) {
            if(strumenti[i].getNumeroIdentificativo() == s.getNumeroIdentificativo()) {
                return strumenti[i];
            }
        }
    }
    StrumentoLaboratorio ricercaSpecificaDescr(StrumentoLaboratorio s) {
        for(int i = 0; i < 100; i++) {
            if(strumenti[i].getDescrizione() == s.getDescrizione()) {
                return strumenti[i];
            }
        }
    }
    int valoreTotale(int a1, int a2) {
        int valore;
        for(int i = 0; i < 100; i++) {
            if(strumenti[i].getAnnoAcquisizione() == a1 || strumenti[i].getAnnoAcquisizione() == a2) {
                valore = strumenti[i].getCosto() + valore;
            }
        }
        return valore;
    }
}
