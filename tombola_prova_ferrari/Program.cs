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
            for (int i = 0; i < 9; i++)//ciclo di stampa della colonna del tabellone
            {
                x = 4;//assegnazione del valore 4 a x
                for (int j = 0; j < 10; j++)//ciclo di stampa della riga del tabellone
                {
                    Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                    Console.Write("**");//output degli asterischi
                    x += 3;//incremento della variabile x
                }
                y++;//incremento della variabile y
            }
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
                    Thread.Sleep(100);//attesa per lampeggiare
                    Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                    Console.ForegroundColor = ConsoleColor.White;//impostare il colore della scritta a bianco
                    Console.WriteLine(num);//output del numero in bianco
                    Thread.Sleep(100);//attesa per lampeggiare
                }
                hcart1();//verifica della presenza di un numero nella cartella 1, di eventuale tombola e cambio del colore dello sfondo
                hcart2();//verifica della presenza di un numero nella cartella 2, di eventuale tombola e cambio del colore dello sfondo
                Thread.Sleep(100);//attesa tra 2 turni
            }
            int estrazione()
            {
                int nume;
                do
                {
                    nume = ran.Next(1, 91);
                } while (v[nume - 1] == true);
                v[nume - 1] = true;
                return nume;
            }
            int coordx()
            {
                if (num / 10 == 0)
                {
                    x = 2 + (num % 10 * 3);
                }
                else
                {
                    if (num % 10 != 0)
                    {
                        x = 2 + (num % 10 * 3 - 1);
                    }
                    else
                    {
                        x = 2 + num / (num / 10) * 3 - 1;
                    }
                }
                return x;
            }
            int coordy()
            {
                if (num / 10 == 0)
                {
                    y = 2;
                }
                else
                {
                    if (num % 10 != 0)
                    {
                        y = 2 + num / 10;
                    }
                    else
                    {
                        y = 1 + num / 10;
                    }
                }
                return y;
            }
            int ccart1()
            {
                bool[] cartv = new bool[90];
                int numr;
                for (int k = 0; k < 3; k++)
                {
                    bool[] decv = new bool[10];
                    for (int j = 0; j < 5; j++)
                    {
                        do
                        {
                            numr = ran.Next(1, 91);
                            if (numr == 90)
                            {
                                j--;
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)
                        {
                            cart1[8, k] = 90;
                        }
                        else
                        {
                            cart1[numr / 10, k] = numr;
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        decv[i] = false;
                    }
                }
                return 0;
            }
            int ccart2()
            {

                bool[] cartv = new bool[90];
                int numr;
                for (int k = 0; k < 3; k++)
                {
                    bool[] decv = new bool[10];
                    for (int j = 0; j < 5; j++)
                    {
                        do
                        {
                            numr = ran.Next(1, 91);
                            if (numr == 90)
                            {
                                j--;
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)
                        {
                            cart2[8, k] = 90;
                        }
                        else
                        {
                            cart2[numr / 10, k] = numr;
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        decv[i] = false;
                    }
                }
                return 0;
            }
            void pcart1()
            {
                x = 0;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 1: ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 0;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)
                        {
                            if (cart1[j, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{cart1[j, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            void pcart2()
            {
                x = 30;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 2: ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 30;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)
                        {
                            if (cart2[j, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{cart2[j, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            int hcart1()
            {
                x = 0;
                y = 14;
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (cart1[j, k] == num)
                        {
                            if (j == 0)
                            {
                                x = 0;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            car1v++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car1v == 15)
                            {
                                Console.SetCursorPosition(0, 20);
                                Console.Write("Il giocatore 1 ha fatto tombola");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);
                            }
                        }
                    }
                }
                return car1v;
            }
            int hcart2()
            {
                x = 30;
                y = 14;
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (cart2[j, k] == num)
                        {
                            if (j == 0)
                            {
                                x = 30;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            car2v++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car2v == 15)
                            {
                                Console.SetCursorPosition(30, 20);
                                Console.Write("Il giocatore 2 ha fatto tombola");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);
                            }
                        }
                    }
                }
                return car2v;
            }
        }
    }
}