#include <iostream>
#include <string.h>
using namespace std;

class Time
{
    public:
    int ora = ...; //Assegna automaticamente ora e minuti
    int minuti = ...;
}

class Automobile
{
        private:
        string Targa;
        int PostoAssegnato;
        int OraEntrata;
        int MinutiEntrata;
    public:
        string targa {get {return Targa;} set {Targa = value;}}
        int postoAssegnato {get {return PostoAssegnato;} set {PostoAssegnato = value;}}
        int oraEntrata {get {return OraEntrata;} set {OraEntrata = Time.ora}}
        int minutiEntrata {get {return MinutiEntrata;} set {MinutiEntrata = Time.minuti}}
        Automobile(string t)
        {
            this.targa = t;
        }
        void occupaPosto(int p) {}
        void liberaPosto() {}
        void pagaCosto(int c) {}
}

class Parcheggio
{
    private:
        int Posti[];
    public:
        int posti []{get {return Posti;} set {Posti = value;}}
        bool PostoLibero;
    int fornirePostoLibero() {return 0;}
    int fornireCosto() {return 0;}
    string comunicaErrore() {}
}

class GestoreParcheggio
{
    private:
        int Posti[];
        int Incasso;
    public:
        int posti []{get {return Posti;} set {Posti = value;}}
        bool PostoLibero;
        int incasso {get {return Incasso;} set {Incasso = value;}}
        void salvareDatiSuFile()
}

int main()
{
    Automobile a = new Automobile("CY787NY");
    a.occupaPosto(Parcheggio.PostoLibero());
    a.liberaPosto();
    a.pagaCosto(Parcheggio.fornireCosto());
}
