using System;

namespace fantacalcio
{
 
    class Program
    {
        static public string cognomeCalciatore;
        static public string nomeSquadra1, nomeSquadra2;
        static public int nCalciatori1, nCalciatori2;
        static public int offerta1, offerta2;
        static public int nGiornate;
        static public int creditiSquadra = 999;
        static public int punteggioSquadra = 0;
        //static public int Squadra1, Squadra2;
        static public bool controllo;

        //Inizializzo le classi





        //public static squadra[] squadra1 = new squadra[Squadra1];
        //public static squadra[] squadra2 = new squadra[Squadra2];

        static void Main(string[] args)//main
        {

            intNomeSquadre();
            //intCognome();
            //intGol();
            //intPunteggio();
            Console.ReadKey();


            squadra s1 = new squadra();
            squadra s2 = new squadra();
            calciatore c = new calciatore();


            static void intNomeSquadre()
            {
                Console.WriteLine("inserisci il nome di squadra 1");
                nomeSquadra1 = Console.ReadLine();
                Console.WriteLine("inserisci il nome di squadra 2");
                nomeSquadra2 = Console.ReadLine();

            }


            Console.WriteLine("Inizia l'Asta");
            Console.WriteLine("Ogni squadra ha a disposizione 999 crediti, se li termini prima hai automaticamente perso.");

            for (int a = 0; a < 22; a++)//il ciclo for viene ripetuto fino a che non vengono inseriti 22 giocatori (11 per squadra)
            {
                if (nCalciatori1 < 11 && nCalciatori2 < 11 || controllo == false)//viene controllato che nGiocatore1 abbia preso 11 giocatori
                {
                    Console.WriteLine("{0}° ACQUISTO", a + 1);
                    Console.WriteLine("Cognome:");
                    cognomeCalciatore = Console.ReadLine();
                    do
                    {
                        do
                        {
                            Console.WriteLine("Offerta squadra {0}:", nomeSquadra1);//chiede di fare un offerta
                            offerta1 = ControlloQuantita();//prende l'offerta fatta
                        } while (offerta1 > 500 || offerta1 < 0);//controlla che l'offerta di nSquadra1 non sia maggiore di 500
                        do
                        {
                            Console.WriteLine("Offerta squadra {0}:", nomeSquadra2);//chiede di fare un offerta
                            offerta2 = ControlloQuantita();//prende l'offerta fatta
                        } while (offerta2 > 500 || offerta2 < 0);//controlla che l'offerta di nSquadra2 non sia maggiore di 500
                    } while (offerta1 == offerta2);//se offerta1 = offerta2 allora richiede di rifare un'altra offerta ad entrambi

                    if (offerta1 > offerta2)//se l'offerta1 > offerta2 il calciatore viene comprato da nSquadra1
                    {
                        c.creaCalciatore(cognomeCalciatore, nomeSquadra1, a);
                        s1.creaSquadra(cognomeCalciatore, offerta1, nCalciatori1);
                        nCalciatori1++;
                    }

                    if (offerta2 > offerta1)//se l'offerta1 < offerta2 il calciatore viene comprato da nSquadra1
                    {
                        c.creaCalciatore(cognomeCalciatore, nomeSquadra2, a);
                        s2.creaSquadra(cognomeCalciatore, offerta2, nCalciatori2);
                        nCalciatori2++;
                        controllo = false;
                    }
                }


                if (nCalciatori1 == 11 && nCalciatori2 < 11)//controlla se il giocatore1 ha 11 giocatori e se il giocatore2 ha meno di 11
                {
                    controllo = true;
                    Console.WriteLine("{0}° ACQUISTO", a + 2);
                    Console.WriteLine("Cognome:");
                    cognomeCalciatore = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Offerta squadra {0}:", nomeSquadra2);
                        offerta2 = Convert.ToInt32(Console.ReadLine());
                    } while (offerta2 > 500 || offerta2 < 0);
                    c.creaCalciatore(cognomeCalciatore, nomeSquadra2, a);
                    s1.creaSquadra(cognomeCalciatore, offerta2, nCalciatori2);
                    nCalciatori2++;
                }


                if (nCalciatori2 == 11 && nCalciatori1 < 11)
                {
                    controllo = true;
                    Console.WriteLine("{0}° ACQUISTO", a + 2);
                    Console.WriteLine("Cognome:");
                    cognomeCalciatore = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Offerta squadra {0}:", nomeSquadra1);
                        offerta1 = ControlloQuantita();
                    } while (offerta1 > 500 || offerta1 < 0);
                    c.creaCalciatore(cognomeCalciatore, nomeSquadra1, a);
                    s1.creaSquadra(cognomeCalciatore, offerta1, nCalciatori1);
                    nCalciatori1++;
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
                    Console.WriteLine("inserisci il punteggio di:{0}{1}", calciatore.cognomeCalciatore);
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


                public static int ControlloQuantita()
                {
                    try
                    {
                        int numero = int.Parse(Console.ReadLine());
                        return numero;
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }

        }






        class calciatore
        {


            static public string cognomeCalciatore;
            static public int prezzoCalciatore;
            static public int ngolCalciatore;
            static public int punteggioCalciatore;
            string[,] calciatori;

            public calciatore()//costruttore
            {
                cognomeCalciatore = "";
                prezzoCalciatore = 0;
                ngolCalciatore = 0;
                punteggioCalciatore = 0;
                this.calciatori = new string[22, 4];
            }


            public void creaCalciatore(string cognome, string nomeSquadra, int livello)//crea l'istanza Calciatore
            {
                calciatori[livello, 0] = cognomeCalciatore;
                calciatori[livello, 1] = nomeSquadra;
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
            string[,] calciatore;
            static string nomeSquadra;
            int crediti;
            public int punti { get; set; }

            public squadra()
            {
                this.calciatore = new string[11, 3];
                crediti = 999;
                punti = 0;
            }


            public void creaSquadra(string cognomeCalciatore, int offerta, int nCalciatori)
            {
                this.calciatore[nCalciatori, 0] = cognomeCalciatore;
                this.calciatore[nCalciatori, 1] = Convert.ToString(offerta);

            }


           




        }
    }
}
