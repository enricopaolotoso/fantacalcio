using System;

namespace fantacalcio
{

    class main
    {

        static public string CalciatoreDiSquadra = "";
        static public string nomeSquadraUtente = "";
        static public int creditiSquadra = 0;
        static public int punteggioSquadra = 0;
        static public int numeroSquadre;
        public static squadra[] squadra = new squadra[numeroSquadre];

        static void Main(string[] args)//main
        {
            calciatore calciatore = new calciatore();

            intNomeSquadre();
            intNomeCognome();
            intGol();
            intPunteggio();
            Console.ReadKey();


            static void intNomeSquadre()
            {
               Console.WriteLine("Quante squadre parteciperanno al fantacalcio?");
               numeroSquadre = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i<numeroSquadre; i++)
                {
                    squadra[i] = new squadra();
                    string nomeSquadra = "";
                    Console.WriteLine("inserisci il nome della Squadra");
                    nomeSquadra = Console.ReadLine();
                    squadra[i].creaSquadra(nomeSquadra);
                }
            }
            static void intNomeCognome()
            {
                string nome = "";
                string cognome = "";
                Console.WriteLine("inserire il nome del calciatore");
                nome = Console.ReadLine();
                Console.WriteLine("inserire il cognome del calciatore");
                cognome = Console.ReadLine();
                calciatore.creaCalciatore(nome, cognome);
            }


            static void intGol()
            {
                int g = 0;
                Console.WriteLine("inserisci il numero di gol effettuati");
                g = Convert.ToInt32(Console.ReadLine());
                calciatore.incrementoGol(g);
                Console.WriteLine("{0}", calciatore.ngolCalciatore);
            }


            static void intPunteggio()
            {
                Console.WriteLine("inserisci il punteggio di:{0}{1}", calciatore.nomeCalciatore, calciatore.cognomeCalciatore);
                string toconvert = Console.ReadLine();//controllo inserimento stringa numerica
                int converted = 0;
                bool result = int.TryParse(toconvert, out converted);
                if (result == false)
                {
                    calciatore.inserisciPunteggio(converted);
                }
                else
                {
                    Console.WriteLine("{0}", converted);
                }
            }
        }
    }
    class calciatore
    {

        static public string nomeSquadra;
        static public string nomeCalciatore;
        static public string cognomeCalciatore;
        static public int prezzoCalciatore;
        static public int ngolCalciatore;
        static public int punteggioCalciatore;

        public calciatore()//costruttore
        {
            nomeCalciatore = "";
            cognomeCalciatore = "";
            prezzoCalciatore = 0;
            ngolCalciatore = 0;
            punteggioCalciatore = 0;
        }


        static public void creaCalciatore(string nome, string cognome)//crea l'istanza Calciatore
        {

            nomeCalciatore = nome;

            cognomeCalciatore = cognome;

        }


        static public void incrementoGol(int gol)
        {
            ngolCalciatore = gol;
        }

        static public void inserisciPunteggio(int p)//metodo per inserire il punteggio di ogni giocatore a fine partita
        {
            punteggioCalciatore = p;
        }



    }
    class squadra
    {

        static string nomeSquadra;
        static int punteggioSquadra;
        static int[,] a = new int[2, 1];


        public squadra()
        {
            nomeSquadra = "";
        }

        public void creaSquadra(string nomeSquadraUtente)
        {
            nomeSquadra = nomeSquadraUtente;
        }


        public void Classifica()
        {

        }

        public void creaRosa()
        {

        }

        public void asta()
        {

        }
    }
}
