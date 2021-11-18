using System;

namespace fantacalcio
{

    class Program
    {
        static public string cognomeCalciatore;//variabile che assegna il cognome a un calciatore
        static public string nomeSquadra1, nomeSquadra2;//variabile che assegna il nome alle squadre
        static public int nCalciatori1, nCalciatori2;//variabile che assegna il numero di calciatori presenti nel fantacalcio
        static public int offerta1, offerta2;//variabile che assegna un valore alle offerte
        static public int creditiSquadra = 999;//variabile che assegna un valore con un tetto massimo di crediti
        static public int punteggioSquadre = 0;//variabile che assegna un punteggio alle squadre
        static public bool controllo;//variabile usata per eseguire un controllo booleano




        static void Main(string[] args)//main
        {

            intNomeSquadre();//richiama funzione per assegnare un nome alle squadre
            Console.ReadKey();

            int g1 = 0, g2 = 0;//
            int p1 = 0, p2 = 0;
            squadra s1 = new squadra();
            squadra s2 = new squadra();
            calciatore c = new calciatore();

            Asta(s1,s2,c);
            intGolSquadre(s1,s2,g1,g2);
            CalcolaPunteggio(g1, g2,s1,s2);


            static void intNomeSquadre()
            {
                Console.WriteLine("inserisci il nome di squadra 1");
                nomeSquadra1 = Console.ReadLine();
                Console.WriteLine("inserisci il nome di squadra 2");
                nomeSquadra2 = Console.ReadLine();

            }

            static void Asta(squadra s1, squadra s2, calciatore c)
            {
                Console.WriteLine("Inizia l'Asta");
                Console.WriteLine("Ogni squadra ha a disposizione 999 crediti, se li termini prima hai automaticamente perso.");

                for (int a = 0; a < 3; a++)//il ciclo for viene ripetuto fino a che non vengono inseriti 22 giocatori (11 per squadra)
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
                }
            }



            static void intGolSquadre(squadra s1, squadra s2, int g1, int g2)
            {
                for(int j = 0; j < 2; j++)
                {
                    if(j == 0)
                    {
                         g1 = 0;
                        Console.WriteLine("inserisci il numero di gol effettuati dalla squadra {0}", nomeSquadra1);
                        g1 = Convert.ToInt32(Console.ReadLine());
                        s1.incrementoGol(g1);
                    }
                    else
                    {
                        g2 = 0;
                        Console.WriteLine("inserisci il numero di gol effettuati dalla squadra {0}" , nomeSquadra2);
                        g2 = Convert.ToInt32(Console.ReadLine());
                        s2.incrementoGol(g2);
                    }
                }

            }


            static void CalcolaPunteggio(int g1, int g2, squadra s1, squadra s2)
            {
                int p1 = 0;
                int p2 = 0;
                Random rnd = new Random();
                for (int j = 0; j < 2; j++)
                {
                    if(j == 0)
                    {
                        p1 = (g1 * 5) + rnd.Next(1, 70);
                        s1.Punteggio(p1);
                        Console.WriteLine("Il punteggio finale della squadra {0} è {1}" , nomeSquadra1 , p1);
                    }
                    else
                    {
                        p2 = (g2 * 5) + rnd.Next(1, 70);//ogni gol vale 5 punti ma viene creato anche un random che include il punteggio derivante da skills, cross, passaggi a buon fine, ecc
                        s2.Punteggio(p2);
                        Console.WriteLine("Il punteggio finale della squadra {0} è {1}", nomeSquadra2, p2);

                    }
                }

                if( p1 > p2 )
                {
                    Console.WriteLine("La squadra vincente è {0}", nomeSquadra1);
                }
                else if ( p1 < p2 )
                {
                    Console.WriteLine("La squadra vincente è {0}" , nomeSquadra2);
                }
                else if( p1 == p2)
                {
                    Console.WriteLine("La partita è finita in pareggio");
                }
            }


            static int ControlloQuantita()
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
            string[,] calciatori;

            public calciatore()//costruttore
            {
                cognomeCalciatore = "";
                prezzoCalciatore = 0;
                this.calciatori = new string[22, 4];
            }


            public void creaCalciatore(string cognome, string nomeSquadra, int livello)//crea l'istanza Calciatore
            {
                calciatori[livello, 0] = cognomeCalciatore;
                calciatori[livello, 1] = nomeSquadra;
                cognomeCalciatore = cognome;

            }


        }



        class squadra
        {
            string[,] calciatore;
            static string nomeSquadra;
            int nGolSquadra;
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



            public void incrementoGol(int gol)
            {
                nGolSquadra = gol;
            }

            
            public void Punteggio(int p)
            {
                punti = p;
            }




        }
    
}
