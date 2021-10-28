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

        public calciatore()
        {
            nomeCalciatore = "";
            cognomeCalciatore = "";
            prezzoCalciatore = 0;
            ngolCalciatore = 0;
            punteggioCalciatore = 0;
        }

        public void creaCalciatore()
        {
            Console.WriteLine("inserire il nome del calciatore");
            nomeCalciatore = Console.ReadLine();
            Console.WriteLine("inserire il cognome del calciatore");
            cognomeCalciatore = Console.ReadLine();

        }

        public void incrementoGol()
        {

        }


        
        
        static void Main(string[] args)
        {
            calciatore calciatore = new calciatore();
            calciatore.cognomeCalciatore="";
            calciatore.incrementoGol();
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
