using System;
using System.Threading;
namespace tombola_prova_ferrari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, x, y = 2;//dichiarazione della variabile num, x, y e assegnazione del valore 2 a y
            Random ran = new Random();//dichiarazione della variabile ran
            bool[] v = new bool[90];//dichiarazione dell'array di bool v, di 90 valori
            int car1v = 0, car2v = 0;//dichiarazione delle variabili car1v e car2v, per segnalare la tombola
            int[,] cart1 = new int[9, 3];//dichiarazione della matrice cart1, di 9*3 valori, utilizzata per la cartella 1
            int[,] cart2 = new int[9, 3];//dichiarazione della matrice cart2, di 9*3 valori, utilizzata per la cartella 2
            Console.WriteLine("Tabellone: ");//generazione del tabellone
            ptab();//stampa del tabellone iniziale in rosso
            ccart1();//generazione dei numeri appartenenti alla cartella 1
            ccart2();//generazione dei numeri appartenenti alla cartella 2
            pcart1();//generazione della cartella 1
            pcart2();//generazione della cartella 2
            for (int i = 0; i < 90; i++)//ciclo di estrazione e controllo 
            {
                num = estrazione();//estrazione del numero
                x = coordx();//calcolo delle x
                y = coordy();//calcolo delle y
                for (int j = 0; j < 3; j++)//stampa del numero sul tabellone
                {
                    Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                    Console.ForegroundColor = ConsoleColor.Green;//impostare il colore della scritta a verde
                    Console.WriteLine(num);//output del numero in verde
                    Thread.Sleep(500);//attesa per lampeggiare
                    Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                    Console.ForegroundColor = ConsoleColor.White;//impostare il colore della scritta a bianco
                    Console.WriteLine(num);//output del numero in bianco
                    Thread.Sleep(500);//attesa per lampeggiare
                }
                hcart1();//verifica della presenza di un numero nella cartella 1, di eventuale tombola e cambio del colore dello sfondo
                hcart2();//verifica della presenza di un numero nella cartella 2, di eventuale tombola e cambio del colore dello sfondo
                Thread.Sleep(1000);//attesa tra 2 turni
            }
            void ptab()
            {
                int numt = 1;//dichiarazione della variabile numt e assegnazione del valore 1 ad essa
                Console.ForegroundColor= ConsoleColor.Red;//imposta il colore del testo a rosso
                for (int i = 0; i < 9; i++)//ciclo di stampa della colonna del tabellone
                {
                    x = 13;//assegnazione del valore 13 a x
                    for (int j = 0; j < 10; j++)//ciclo di stampa della riga del tabellone
                    {
                        Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                        Console.Write(numt);//output degli asterischi
                        x += 3;//incremento della variabile x
                        numt++;//incremento della variabile numt
                    }
                    y++;//incremento della variabile y
                }
                Console.ForegroundColor = ConsoleColor.White;//imposta il colore del testo a rosso
            }
            int estrazione()//funzione di estrazione del numero
            {
                int nume;//dichiarazione della variavile locale nume
                do//ciclo do while per ò'estrazione di un numero non ancora estratto
                {
                    nume = ran.Next(1, 91);//estrazione di un numero casuale tra 1 e 90
                } while (v[nume - 1] == true);//verifica che il numero non sia ancora uscito
                v[nume - 1] = true;//segna il numero estratto come estratto tramite un array do bool (true == estratto)
                return nume;//ritorna il valore di numero, ovvero il numero estratto
            }
            int coordx()//funzione che restituisce le coordinate x dove scrivere il numero estratto sul tabellone
            {
                if (num / 10 == 0)//condizione che verifica se il numero ha 0 come decina
                {
                    x = 10 + (num % 10 * 3);//calcolo della x se la condizione è verificata
                }
                else//istruzioni da eseguire se la condizione non è verificata
                {
                    if (num % 10 != 0)//condizione che verifica se il numero non ha 0 come unità
                    {
                        x = 11 + (num % 10 * 3 - 1);//calcolo della x se la condizione è verificata
                    }
                    else//istruzioni da eseguire se la condizione non è verificata
                    {
                        x = 11 + num / (num / 10) * 3 - 1;//calcolo della x se la condizione non è verificata
                    }
                }
                return x;//ritorna il valore di x
            }
            int coordy()//funzione che restituisce le coordinate y dove scrivere il numero estratto sul tabellone
            {
                if (num / 10 == 0)//condizione che verifica se il numero ha 0 come decina
                {
                    y = 2;//calcolo della y se la condizione è verificata
                }
                else//istruzioni da eseguire se la condizione non è verificata
                {
                    if (num % 10 != 0)//condizione che verifica se il numero non ha 0 come unità
                    {
                        y = 2 + num / 10;//calcolo della y se la condizione è verificata
                    }
                    else//istruzioni da eseguire se la condizione non è verificata
                    {
                        y = 1 + num / 10;//calcolo della y se la condizione non è verificata
                    }
                }
                return y;//ritorna il valore di y
            }
            int ccart1()//funzione di caricamento della matrice della prima cartella
            {
                bool[] cartv = new bool[90];//dichiarazione di un array di 90 elementi per verificare l'univocità dei numeri sulla cartella
                int numr;//dichiarazione della variabile intera locale numr
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    bool[] decv = new bool[10];//dichiarazione di un array di 10 elementi per verificare l'univocità della decina dei numeri sulla riga
                    for (int j = 0; j < 5; j++)//ciclo che identifica i numeri da generare per ogni riga
                    {
                        do//ciclo do while che estrae il numero finchè non rispetta la condizione di univocità della cartella e della decina nella riga
                        {
                            numr = ran.Next(1, 91);//estrazione di un numero casuale tra 1 e 90
                            if (numr == 90)//verifica che il numero casuale sia 90, in quel caso va applicata una modifica al procedimento
                            {
                                j--;//diminuire il contatore in caso di 90, poichè appartenendo ala colonna 8 potrebbe sovrascrivere un numero 8?, avendo come decina 9
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);//verifica che il numero sia univoco nella cartella e che la decina sia univoca nella riga
                        cartv[numr - 1] = true;//segna il numero generato come già presente tramite un array do bool (true == presente)
                        decv[numr / 10] = true;//segna la decina del numero come già presente all'interno della riga tramite un array do bool (true == presente)
                        if (numr == 90)//condizione che sposta il 90 nella colona con decina 8
                        {
                            cart1[8, k] = 90;//assegnazione del valore 90 in caso di condizione verificata
                        }
                        else//istruzioni da eseguire se la condizione non è verificata
                        {
                            cart1[numr / 10, k] = numr;//assegnazione del valore di numr in caso di condizione non verificata
                        }
                    }
                    for (int i = 0; i < 9; i++)//ciclo che imposta a false di tutti gli elementi dell'array decv
                    {
                        decv[i] = false;//assegnazione di false a decv con in dice il contatore i
                    }
                }
                return 0;//ritona 0;
            }
            int ccart2()//funzione di caricamento della matrice della seconda cartella
            {

                bool[] cartv = new bool[90];//dichiarazione di un array di 90 elementi per verificare l'univocità dei numeri sulla cartella
                int numr;//dichiarazione della variabile intera locale numr
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    bool[] decv = new bool[10];//dichiarazione di un array di 10 elementi per verificare l'univocità della decina dei numeri sulla riga
                    for (int j = 0; j < 5; j++)//ciclo che identifica i numeri da generare per ogni riga
                    {
                        do//ciclo do while che estrae il numero finchè non rispetta la condizione di univocità della cartella e della decina nella riga
                        {
                            numr = ran.Next(1, 91);//estrazione di un numero casuale tra 1 e 90
                            if (numr == 90)//verifica che il numero casuale sia 90, in quel caso va applicata una modifica al procedimento
                            {
                                j--;//diminuire il contatore in caso di 90, poichè appartenendo ala colonna 8 potrebbe sovrascrivere un numero 8?, avendo come decina 9
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);//verifica che il numero sia univoco nella cartella e che la decina sia univoca nella riga
                        cartv[numr - 1] = true;//segna il numero generato come già presente tramite un array do bool (true == presente)
                        decv[numr / 10] = true;//segna la decina del numero come già presente all'interno della riga tramite un array do bool (true == presente)
                        if (numr == 90)//condizione che sposta il 90 nella colona con decina 8
                        {
                            cart2[8, k] = 90;//assegnazione del valore 90 in caso di condizione verificata
                        }
                        else//istruzioni da eseguire se la condizione non è verificata
                        {
                            cart2[numr / 10, k] = numr;//assegnazione del valore di numr in caso di condizione non verificata
                        }
                    }
                    for (int i = 0; i < 9; i++)//ciclo che imposta a false di tutti gli elementi dell'array decv
                    {
                        decv[i] = false;//assegnazione di false a decv con in dice il contatore i
                    }
                }
                return 0;//ritona 0;
            }
            void pcart1()//funzione di stampa della prima cartella
            {
                x = 0;//assegnazione del valore 0 a x
                y = 12;//assegnazione del valore 12 a y
                Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                Console.WriteLine("Cartella 1: ");//stampa dei "Cartella 1: "
                y++;//incremento di y 
                for (int i = 0; i < 5; i++)//ciclo che stampa le righe della cartella, comprese quelle di divisione
                {
                    x = 0;//assegnazione del valore 0 a x
                    y++;//incremento di y
                    if (i % 2 == 1)//condizione che verifica se la riga è da trattini (o da numeri)
                    {
                        Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                        Console.WriteLine("-------------------------");//output della riga di trattini
                    }
                    else//istruzioni da eseguire se la condizione non è verificata (riga composta da numeri)
                    {
                        Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                        for (int j = 0; j < 9; j++)//ciclo per scrivere i numeri o gli eventuali spazi all'interno della riga
                        {
                            if (cart1[j, i / 2 + i % 2] != 0)//condizione che verifica se è necessario stampare un numero o lo spazio
                            {
                                Console.Write($"{cart1[j, i / 2 + i % 2]} ");//stampa del numero (condizione verificata) seguito da uno spazio per distanziarlo dai seguenti numeri/spazi
                            }
                            else//istruzioni da eseguire se la condizione non è verificata (stampa degli spazi)
                            {
                                if (j == 0)//condizione che verifica se il numero da stampare occupa 1 spazop (decina == 0)
                                {
                                    Console.Write("  ");//stampa di uno spazio seguito dallo spazio per distanziarlo dai seguenti numeri/spazi
                                }
                                else//istruzioni da eseguire se la condizione non è verificata (decina != 0)
                                {
                                    Console.Write("   ");//stampa di due spazi seguiti dallo spazio per distanziarli dai seguenti numeri/spazi
                                }
                            }
                        }
                        Console.WriteLine();//a capo
                    }
                }
            }
            void pcart2()//funzione di stampa della seconda cartella
            {
                x = 30;//assegnazione del valore 30 a x
                y = 12;//assegnazione del valore 12 a y
                Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                Console.WriteLine("Cartella 2: ");//stampa dei "Cartella 2: "
                y++;//incremento di y 
                for (int i = 0; i < 5; i++)//condizione che verifica se la riga è da trattini (o da numeri)
                {
                    x = 30;//assegnazione del valore 30 a x
                    y++;//incremento di y
                    if (i % 2 == 1)//condizione che verifica se la riga è da trattini (o da numeri)
                    {
                        Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                        Console.WriteLine("-------------------------");//output della riga di trattini
                    }
                    else//istruzioni da eseguire se la condizione non è verificata (riga composta da numeri)
                    {
                        Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                        for (int j = 0; j < 9; j++)//ciclo per scrivere i numeri o gli eventuali spazi all'interno della riga
                        {
                            if (cart2[j, i / 2 + i % 2] != 0)//condizione che verifica se è necessario stampare un numero o lo spazio
                            {
                                Console.Write($"{cart2[j, i / 2 + i % 2]} ");//stampa del numero (condizione verificata) seguito da uno spazio per distanziarlo dai seguenti numeri/spazi
                            }
                            else//istruzioni da eseguire se la condizione non è verificata (stampa degli spazi)
                            {
                                if (j == 0)//condizione che verifica se il numero da stampare occupa 1 spazop (decina == 0)
                                {
                                    Console.Write("  ");//stampa di uno spazio seguito dallo spazio per distanziarlo dai seguenti numeri/spazi
                                }
                                else//istruzioni da eseguire se la condizione non è verificata (decina != 0)
                                {
                                    Console.Write("   ");//stampa di due spazi seguiti dallo spazio per distanziarli dai seguenti numeri/spazi
                                }
                            }
                        }
                        Console.WriteLine();//a capo
                    }
                }
            }
            int hcart1()//funzione di evidenziazione dei numeri estratti presenti nella cartella 1 e segnalazione di eventuale vincitore
            {
                x = 0;//assegnazione del valore 0 a x
                y = 14;//assegnazione del valore 14 a y
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    for (int j = 0; j < 9; j++)//ciclo che identifica ogni numero presente/assente nella riga
                    {
                        if (cart1[j, k] == num)//condizione che verifica la presenza del numero estratto
                        {
                            if (j == 0)//condizione che verifica se il numero estratto ha decina == 0
                            {
                                x = 0;//assegnazione del valore 0 a x nel caso la condizione sia verificata (decina == 0)
                            }
                            else//istruzioni da eseguire se la condizione non è verificata
                            {
                                x += j * 3 - 1;//calcolo della x in base alla decina  del numero
                            }
                            y += k * 2;//calcolo della y in base alla riga presa in considerazione
                            car1v++;//incremento del contatore che segnala la tombola
                            Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                            Console.BackgroundColor = ConsoleColor.Magenta;//impostare il colore dello sfondo a magenta
                            Console.Write(num);//output del numero con sfondo magenta
                            Console.BackgroundColor = ConsoleColor.Black;//impostare il colore dello sfondo a nero
                            if (car1v == 15)//condizione che verifica l'eventuale tombola
                            {
                                Console.SetCursorPosition(0, 20);//impostare la posizione a 0, 20
                                Console.Write("Il giocatore 1 ha fatto tombola");//output del messaggio "Il giocatore 1 ha fatto tombola"
                                Console.SetCursorPosition(1, 1);//impostare la posizione a 1, 1
                                Environment.Exit(1);//chiusura del programma
                            }
                        }
                    }
                }
                return car1v;//ritorna il valore aggiornato del contatore per eventuale tombola
            }
            int hcart2()//funzione di evidenziazione dei numeri estratti presenti nella cartella 1 e segnalazione di eventuale vincitore
            {
                x = 30;//assegnazione del valore 30 a x
                y = 14;//assegnazione del valore 14 a y
                for (int k = 0; k < 3; k++)//ciclo che identifica le righe della cartella
                {
                    for (int j = 0; j < 9; j++)//ciclo che identifica ogni numero presente/assente nella riga
                    {
                        if (cart2[j, k] == num)//condizione che verifica la presenza del numero estratto
                        {
                            if (j == 0)//condizione che verifica se il numero estratto ha decina == 0
                            {
                                x = 30;//assegnazione del valore 30 a x nel caso la condizione sia verificata (decina == 0)
                            }
                            else//istruzioni da eseguire se la condizione non è verificata
                            {
                                x += j * 3 - 1;//calcolo della x in base alla decina  del numero
                            }
                            y += k * 2;//calcolo della y in base alla riga presa in considerazione
                            car2v++;//incremento del contatore che segnala la tombola
                            Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                            Console.BackgroundColor = ConsoleColor.Blue;//impostare il colore dello sfondo a blu
                            Console.Write(num);//output del numero con sfondo blu
                            Console.BackgroundColor = ConsoleColor.Black;//impostare il colore dello sfondo a nero
                            if (car2v == 15)
                            {
                                Console.SetCursorPosition(30, 20);//impostare la posizione a 30, 20
                                Console.Write("Il giocatore 2 ha fatto tombola");//output del messaggio "Il giocatore 2 ha fatto tombola"
                                Console.SetCursorPosition(1, 1);//impostare la posizione a 1, 1
                                Environment.Exit(1);//chiusura del programma
                            }
                        }
                    }
                }
                return car2v;//ritorna il valore aggiornato del contatore per eventuale tombola
            }
        }
    }
}