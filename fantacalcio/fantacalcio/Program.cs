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

        static public void creaCalciatore(string nome, string cognome)//metodo per aggiungere calciatori al programma
        {
            
            nomeCalciatore = nome;
            
            cognomeCalciatore = cognome;

        }


        static void inserisciPunteggio()//metodo per inserire il punteggio di ogni giocatore a fine partita
        {
            Console.WriteLine("inserisci il punteggio di:{0}{1}", calciatore.nomeCalciatore, calciatore.cognomeCalciatore);

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

        static public void incrementoGol(int gol)
        {
            ngolCalciatore = gol;

        }


        static void Main(string[] args)
        {
            calciatore calciatore = new calciatore();
            intGol();
            Console.ReadKey();

            intNomeCognome();
            Console.ReadKey();
        }

        static public void intGol()
        {
            int gol = 0;
            Console.WriteLine("inserisci il numero di gol effettuati");
            gol = Convert.ToInt32(Console.ReadLine());
            calciatore.incrementoGol(gol);
            Console.WriteLine("{0}", calciatore.ngolCalciatore);
        }

        static public void intNomeCognome()
        {
            string nome = "";
            string cognome = "";
            Console.WriteLine("inserire il nome del calciatore");
            nome = Console.ReadLine();
            Console.WriteLine("inserire il cognome del calciatore");
            cognome = Console.ReadLine();
            calciatore.creaCalciatore(nome,cognome);

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
