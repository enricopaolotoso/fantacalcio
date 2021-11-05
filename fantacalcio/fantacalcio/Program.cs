using System;

namespace fantacalcio
{

    class main
    {

        static public string CalciatoreDiUtente = "";
        static public string nomeUtente = "";
        static public string passwordUtente = "";
        static public int creditiUtente = 0;
        static public int punteggioUtente = 0;
        static public int numeroUtenti = 0;
        static public utente[] utente = new utente[1];
        static public string file = "0::";
        static public char divisore = ':';
        static public int righeFile = 0;
        static public string[,] elementiFileOrdinati;

        static void Main(string[] args)//main
        {
            calciatore calciatore = new calciatore();

            intNomeCognome();
            intGol();
            intPunteggio();
            Console.ReadKey();
        }

        static public void signIn()//viene eseguito in seguito al click del pulsante registrati
        {

            int UnicitàID = 0;//variabile per il controllo unicità id
            if (variabileControlloInserimenti == true)//se la funzione controlloinserimenti non rivela problemi esegue le seguenti operazioni 
            {
                for (int j = 0; j < righeFile; j++)//ciclo for che controlla che non vi sia un altro ID con lo stesso username
                {
                    if (nomeUtente == elementiFileOrdinati[j, 0])
                    {
                        UnicitàID = 1;
                        Console.WriteLine("il nome utente esiste già");
                        
                    }
                }
                if (UnicitàID == 0)//se non vengono riscontrati problemi esegue le seguenti operazioni 
                {
                    righeFile++;//aumenta di 1 il numero delle righe del file
                    string[,] arrayDiSalvataggio = new string[righeFile, 3];//array utilizzato per il salvataggio su File
                    for (int i = 0; i < righeFile; i++)//ciclo che inserisce i valori nell'array di salvataggio
                    {
                        if (i == 0)//se i=0, quindi si sta lavorando della prima riga dell'array, salva il nuovo ID con punteggio=0
                        {
                            arrayDiSalvataggio[i, 0] = nomeUtente + divisore;
                            arrayDiSalvataggio[i, 1] = passwordUtente + divisore;
                            arrayDiSalvataggio[i, 2] = punteggioUtente + divisore + "\n";
                        }
                        else if (i >= 1)//dopodichè inserirà quelli già presenti nel file
                        {
                            for (int j = 0; j < 3; j++)//ciclo che permette di variare colonna
                            {
                                if (i == (righeFile - 1) && j == 2)//se si tratta dell'ultimo elemento del file non viene aggiunto il carattere divisore
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j];
                                }
                                else//in caso contrario si
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j] + divisore;
                                }
                            }
                        }
                    }
                    int variabileDiControllo = 0;
                    for (int i = 0; i < righeFile; i++)//ciclo che inserisce i valori dell'array di salvataggio nella stringa utilizzata per la scrittura su file
                    {
                        if (variabileDiControllo == 0)//inserisce come primo valore il numero di righe del file
                        {
                            salvataggioID = Convert.ToString(righeFile) + divisore;
                            variabileDiControllo = 1;
                        }
                        for (int j = 0; j < 3; j++)//dopodichè inserisce gli ID e punteggi
                        {
                            salvataggioID = salvataggioID + arrayDiSalvataggio[i, j];
                        }
                        //salvataggioID = salvataggioID + "\n";//dopo ogni ID e punteggio va a capo per salvare il successivo
                    }
                    File.WriteAllText(@"C:\Users\Asus\Desktop\IDePunteggi", salvataggioID);//esegue la scrittura su file
                    salvataggioID = "";//svuota la stringa salvataggioID
                    rigaGiocatore = 0;//rigagiocatore assume il valore 0 poichè l'ID dell'utente appena rigistrato si trova nalla prima riga dell'array
                    accessoEseguito = true;//l'utente è loggato
                    lb4 = "registrazione eseguita, BENVENUTO " + username;
                    acquisizioneFile();//il programma riacquisisce il file con le modifiche applicate
                }
            }
        }

        private void logIn()//viene eseguito in seguito al click del pulsante accedi
        {
            controlloInserimenti();//viene chiamata la funzione per il controllo del rimepimento delle textbox
            bool variabileDiControllo = false;
            if (variabileControlloInserimenti == true)//se la funzione controlloinserimenti non rivela problemi esegue le seguenti operazioni 
            {
                for (int j = 0; j < righeFile; j++)//ciclo for che controlla se nel file è presente l'ID indicato
                {
                    if (nomeUtente == elementiFileOrdinati[j, 0] && passwordUtente == elementiFileOrdinati[j, 1] || "\n" + nomeUtente == elementiFileOrdinati[j, 0] && passwordUtente == elementiFileOrdinati[j, 1])//se l'ID è presente esegue le seguenti operazioni
                    {
                        variabileDiControllo = true;
                        punteggio = Convert.ToInt32(elementiFileOrdinati[j, 2]);//converte in intero il punteggio
                        rigaGiocatore = j;//"salva" la riga del giocatore 
                        accessoEseguito = true;//l'utente è loggato
                        Console.WriteLine("BENVENUTO " + nomeUtente);
                    }
                }
                if (variabileDiControllo == false)//se l'ID non è presente lo segnala
                {
                    Console.WriteLine("nome utente o password");
                }
            }
        }

        private static void creaFile()//funzione che gestisce l'eventuale creazione e caricamento di dati presenti su file nel programma
        {
            try
            {
                file = File.ReadAllText(@"C:\Users\Asus\Desktop\IDePunteggi");//il programma prova a leggere il file
            }
            catch (FileNotFoundException)//in caso si verifichi l'eccezione in cui non viene trovato il file il programma ne creerà uno 
            {
                MessageBox.Show("ERRORE: il file che contiene gli ID non è stato trovato. Il gioco ne creerà uno per te");
                File.WriteAllText(@"C:\Users\Asus\Desktop\IDePunteggi", file);
                MessageBox.Show("Il file è stato creato con successo.");
            }
            catch (IOException)//Se si verifica questo errore, cioè errore di lettura, esegue le operazioni seguenti.
            {
                Console.WriteLine("ERRORE: si è verificato un errore durante la lettura dei file. Prova ad aprilo di nuovo.");
                Environment.Exit(0);
            }
            string[] elementiFileDaOrdinare = file.Split(divisore);//gli elementi presenti su file vengono inseriti nell'array 
            righeFile = Convert.ToInt32(elementiFileDaOrdinare[0]);//la variabile righefile assume il valore del primo elemento dell'array elementiFileDaOrdinare(infatti questa cella contiene il numero delle righe)
            elementiFileOrdinati = new string[righeFile, 3];//viene modificata la lunghezza dell'array
            int n1 = 1; //Si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi.
            for (int i = 0; i < righeFile; i++) //Inserisce nell'array multidimensionale elementiFileOrdinati il contenuto dell'array monodimensionale elementiFileDaOrdinare, 
            {
                for (int j = 0; j < 3; j++)
                {
                    elementiFileOrdinati[i, j] = elementiFileDaOrdinare[n1];
                    n1++;
                }
            }
            letturaFileEseguita = true;
        }
        static public void intNomeCognome()
        {
            string nome = "";
            string cognome = "";
            Console.WriteLine("inserire il nome del calciatore");
            nome = Console.ReadLine();
            Console.WriteLine("inserire il cognome del calciatore");
            cognome = Console.ReadLine();
            calciatore.creaCalciatore(nome, cognome);
        }


        static public void intGol()
        {
            int g = 0;
            Console.WriteLine("inserisci il numero di gol effettuati");
            g = Convert.ToInt32(Console.ReadLine());
            calciatore.incrementoGol(g);
            Console.WriteLine("{0}", calciatore.ngolCalciatore);
        }


        static public void intPunteggio()
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
        
    class calciatore
    {

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
