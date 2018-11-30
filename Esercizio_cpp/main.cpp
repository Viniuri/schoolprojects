#include <iostream>
#include <string.h>
using namespace std;
class CBarca {
    public:
    string nome;
    string nazionalita;
    int lunghezza;
    int stazza;
    int tipologia;
    CBarca(string Nome, string Nazionalita, int Lun, int Stazza, int Tipo) {
        nome = Nome;
        nazionalita = Nazionalita;
        lunghezza = lun;
        stazza = Stazza;
        tipologia = Tipo;
    }
    CBarca(void) {}
}
class CPostibarca : CBarca {
    public:
    int num;
}
class CPorto {
    //CPorto è fatto di n Posti Barca
}