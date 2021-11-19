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
            squadra s1 = new squadra();//dichiara l'oggetto s1
            squadra s2 = new squadra();//dichiara l'oggetto s2
            calciatore c = new calciatore();//dichiara l'oggetto calciatore

            Asta(s1,s2,c);//richiama funzione asta
            intGolSquadre(s1,s2,g1,g2);//richiama funzione per assegnare il numero di gol alle squadre
            CalcolaPunteggio(g1, g2,s1,s2);//richiama funzione per calcolare il punteggio post partita


            static void intNomeSquadre()//funzione per assegnare un nome alle squadre
            {
                Console.WriteLine("inserisci il nome di squadra 1");
                nomeSquadra1 = Console.ReadLine();//assegna a nomeSquadra1 il nome inserito dall'utente
                Console.WriteLine("inserisci il nome di squadra 2");
                nomeSquadra2 = Console.ReadLine();//assegna a nomeSquadra2 il nome inserito dall'utente

            }

            static void Asta(squadra s1, squadra s2, calciatore c)//funzione asta
            {
                Console.WriteLine("Inizia l'Asta");
                Console.WriteLine("Tutte le squadre hanno 999 crediti, se li termini prima hai automaticamente perso.");

                for (int a = 0; a < 3; a++)//for ripetuto finchè non vengono inseriti 22 calciatori (11 per squadra)
                {
                    if (nCalciatori1 < 11 && nCalciatori2 < 11 || controllo == false)//viene controllato che nCalciatori1 abbia 11 giocatori
                    {
                        Console.WriteLine("{0}° ACQUISTO", a + 1);
                        Console.WriteLine("Inserisci il cognome del calciatore: {0}" , a + 1);
                        cognomeCalciatore = Console.ReadLine();//assegna a cognomeCalciatore la variabile inserita dall'utente
                        do
                        {
                            do
                            {
                                Console.WriteLine("Offerta squadra {0}:", nomeSquadra1);//chiede di fare un'offerta
                                offerta1 = ControlloQuantita();//prende l'offerta
                            } while (offerta1 > 999 || offerta1 < 0);//controlla che l'offerta di nSquadra1 non superi il tetto massimo (999 crediti)
                            do
                            {
                                Console.WriteLine("Offerta squadra {0}:", nomeSquadra2);//chiede di fare un'offerta
                                offerta2 = ControlloQuantita();//prende l'offerta
                            } while (offerta2 > 999 || offerta2 < 0);//controlla che l'offerta di nSquadra1 non superi il tetto massimo (999 crediti)
                        } while (offerta1 == offerta2);//se le offerte risultano uguali, viene rifatta un'altra offerta

                        if (offerta1 > offerta2)//se l'offerta1 > offerta2 il calciatore viene assegnato a Squadra1
                        {
                            c.creaCalciatore(cognomeCalciatore, nomeSquadra1, a);//richiama il metodo creaCalciatore
                            s1.creaSquadra(cognomeCalciatore, offerta1, nCalciatori1);//richiama il metodo creaSquadra
                            nCalciatori1++;//per ogni nuovo calciatore, aumenta di 1 il numero di calciatori
                        }

                        if (offerta2 > offerta1)//se l'offerta2 < offerta1 il calciatore viene assegnato a Squadra2
                        {
                            c.creaCalciatore(cognomeCalciatore, nomeSquadra2, a);//richiama il metodo creaCalciatore
                            s2.creaSquadra(cognomeCalciatore, offerta2, nCalciatori2);//richiama il metodo creaSquadra
                            nCalciatori2++;//per ogni nuovo calciatore, aumenta di 1 il numero di calciatori
                            controllo = false;
                        }
                    }


                    if (nCalciatori1 == 11 && nCalciatori2 < 11)//controlla se squadra1 ha 11 giocatori e se il squadra2 ha meno di 11
                    {
                        controllo = true;
                        Console.WriteLine("{0}° ACQUISTO", a + 2);
                        Console.WriteLine("Inserisci il cognome del calciatore: {0}", a +1);
                        cognomeCalciatore = Console.ReadLine();//assegna a cognomeCalciatore la variabile inserita dall'utente
                        do
                        {
                            Console.WriteLine("Offerta squadra {0}:", nomeSquadra2);
                            offerta2 = Convert.ToInt32(Console.ReadLine());
                        } while (offerta2 > 999 || offerta2 < 0);
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
                        } while (offerta1 > 999 || offerta1 < 0);
                        c.creaCalciatore(cognomeCalciatore, nomeSquadra1, a);
                        s1.creaSquadra(cognomeCalciatore, offerta1, nCalciatori1);
                        nCalciatori1++;
                    }
                }
            }



            static void intGolSquadre(squadra s1, squadra s2, int g1, int g2)//funzione per inserire il numero di gol segnati da entrambe le squadre
            {
                for(int j = 0; j < 2; j++)//for ripetuto 2 volte (una per squadra)
                {
                    if(j == 0)//squadra 1
                    {
                        g1 = 0;//variabile gol s1
                        Console.WriteLine("inserisci il numero di gol effettuati dalla squadra {0}", nomeSquadra1);
                        g1 = Convert.ToInt32(Console.ReadLine());
                        s1.incrementoGol(g1);//viene richiamata la funzione per incrementare il numero di gol
                    }
                    else//squadra 2
                    {
                        g2 = 0;//variabile gol s2
                        Console.WriteLine("inserisci il numero di gol effettuati dalla squadra {0}" , nomeSquadra2);
                        g2 = Convert.ToInt32(Console.ReadLine());
                        s2.incrementoGol(g2);//viene richiamata la funzione per incrementare il numero di gol
                    }
                }

            }


            static void CalcolaPunteggio(int g1, int g2, squadra s1, squadra s2)//funzione che calcola il punteggio di ambedue le squadre, vengono assegnati 5 punti per gol e aggiunto un punteggio generato da un random che comprende il punteggio derivante da skills, cross, passaggi a buon fine, ecc 
            {
                int p1 = 0;//punteggio s1
                int p2 = 0;//punteggio s2
                Random rnd = new Random();//dichiarato il random
                for (int j = 0; j < 2; j++)//for eseguito 2 volte(una per squadra)
                {
                    if(j == 0)//s1
                    {
                        p1 = (g1 * 5) + rnd.Next(1, 70);//assegna a p1 il risultato del punteggio dei gol + un punteggio randomico
                        s1.Punteggio(p1);//assegna a s1 il punteggio
                        Console.WriteLine("Il punteggio finale della squadra {0} è {1}" , nomeSquadra1 , p1);
                    }
                    else//s2
                    {
                        p2 = (g2 * 5) + rnd.Next(1, 70);//assegna a p2 il risultato del punteggio dei gol + un punteggio randomico
                        s2.Punteggio(p2);//assegna a s2 il punteggio
                        Console.WriteLine("Il punteggio finale della squadra {0} è {1}", nomeSquadra2, p2);

                    }
                }

                if( p1 > p2 )//ciclo if che stampa il vincitore o il pareggio
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
        }//FINE MAIN
    }
            

        

        class calciatore
        {

            static public string cognomeCalciatore;//variabile che identifica i calciatori
            static public int prezzoCalciatore;//variabile per assegnare un prezzo ai calciatori
            string[,] calciatori;//array di stringhe (calciatori)

            public calciatore()//costruttore in cui inizializzo le variabili
        {
                cognomeCalciatore = "";
                prezzoCalciatore = 0;
                this.calciatori = new string[22, 4];//definisce l'array
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
            string[,] calciatore;//array di stringhe (calciatori)
            static string nomeSquadra;//variabile che assegna un nome alla squadra
            int nGolSquadra;//variabile numero di gol segnati
            int crediti;//variabile numero di crediti


            public int punti { get; set; }//accede alla variabile privata punti

            public squadra()//costruttore
            {
                this.calciatore = new string[11, 3];//definisce l'array
                crediti = 999;//assegno il limite di crediti
                punti = 0;//inizializzo i punti
            }


            public void creaSquadra(string cognomeCalciatore, int offerta, int nCalciatori)//funzione per creare la squadra
            {
                this.calciatore[nCalciatori, 0] = cognomeCalciatore;
                this.calciatore[nCalciatori, 1] = Convert.ToString(offerta);

            }



            public void incrementoGol(int gol)//funzione che incrementa il numero di gol segnati
            {
                nGolSquadra = gol;//assegna il parametro gol a nGolSquadra
            }

            
            public void Punteggio(int p)
            {
                punti = p;
            }


        }
}
