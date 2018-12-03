class Rfid {
    private:
    //Variabili private
    public:
        int codiceNumericoId;
        string descrizione;
        int giornoScadenza;
        int meseScadenza;
        int annoScadenza;
        string tipologia;
        int numeroPorzioni;
        //Costruttore di default
        Rfid(void) {
            codiceNumericoId = 0;
            descrizione = "";
            giornoScadenza = 0;
            meseScadenza = 0;
            annoScadenza = 0;
            tipo = "";
            numeroPorzioni=0;
        }
        //Tag per prodotto PRECOTTO
        Rfid(int cId, string descr, int giorniS, int meseS, int annoS, string tipo, int nP) {
            codiceNumericoId = cId;
            descrizione = descr;
            giornoScadenza = giorniS;
            meseScadenza = meseS;
            annoScadenza = annoS;
            tipologia = tipo;
            numeroPorzioni = nP;
        }
        //Tag per prodotto NON-PRECOTTO
        Rfid(int cId, string descr, int giorniS, int meseS, int annoS) {
            codiceNumericoId = cId;
            descrizione = descr;
            giornoScadenza = giorniS;
            meseScadenza = meseS;
            annoScadenza = annoS;
        }
};
class Prodotto {
    //Ogni prodotto ha una tag RFID
    Rfid tagRfid;
};
class Frigorifero {
    private:
    //Variabili private
    public:
        Prodotto prodotti[50];
        Frigorifero(void) {
            for(int i = 0;i < 50; i++) {
                prodotti[i] = Prodotto();
            }
        }
};