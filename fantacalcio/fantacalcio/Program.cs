using System;

namespace fantacalcio
{
    class calciatore
    {

        static string nomeCalciatore;
        static string cognomeCalciatore;
        static int prezzoCalciatore;
        static int ngolCalciatore;
        static int punteggioCalciatore;

        public calciatore()//costruttore
        {
            nomeCalciatore = "";
            cognomeCalciatore = "";
            prezzoCalciatore = 0;
            ngolCalciatore = 0;
            punteggioCalciatore = 0;
        }

        public void creaCalciatore()//metodo per aggiungere calciatori al programma
        {
            Console.WriteLine("inserire il nome del calciatore");
            nomeCalciatore = Console.ReadLine();
            Console.WriteLine("inserire il cognome del calciatore");
            cognomeCalciatore = Console.ReadLine();

        }


        static void inserisciPunteggio()//metodo per inserire il punteggio a fine partita di ogni giocatore
        {
            Console.WriteLine("inserisci il punteggio di:", calciatore.nomeCalciatore);

            string toconvert = Console.ReadLine();//controllo inserimento stringa numerica
            int converted = 0;
            bool result = int.TryParse(toconvert, out converted);
            if (result == false)
            {
                Console.WriteLine("inserisci un valore numerico!");
                inserisciPunteggio();

            }
            else
            {
                Console.WriteLine("{0}", converted);
            }

        }

        public void incrementoGol()
        {
            Console.WriteLine("inserisci il numero di gol effettuati");
            
            //algoritmo di ricerca specifico giocatore
        }


        
        
        static void Main(string[] args)
        {
            calciatore calciatore = new calciatore();
            calciatore.cognomeCalciatore="";
            calciatore.incrementoGol();

            inserisciPunteggio();
        }
    }

    class utente
    {

        static string nomeUtente;
        static string passwordUtente;
        static int punteggioUtente;
        static int[,] a = new int[2,1];


        public utente()
        {
            nomeUtente = "";
            passwordUtente = "";
        }

        public void creaUtente()
        {
            Console.WriteLine("inserisci il nome utente");
            nomeUtente = Console.ReadLine();
            Console.WriteLine("inserisci la password");
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
