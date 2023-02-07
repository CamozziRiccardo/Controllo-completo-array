using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        //dichiarazione array di stringhe
        string[] array = new string[100];

        //variabile di scelta
        int scelta = 0;

        //dichiarazione variabili
        int dim = 0;

        //variabile temporanea
        string temp;

        //grandezza array e verifica che sia minore di 100
        do
        {
            Console.Write("Inserire quante celle dell'array si vogliono utilizzare: ");
            dim = int.Parse(Console.ReadLine());                        //inserimento dei valori che si vogliono utilizzare
        } while (dim > array.Length);


        //inserimento animali
        for (int i = 0; i < dim; i++)
        {
            Console.Clear();                                        //cancellamento della console
            Console.WriteLine("Inserisci il nome di un animale: ");
            array[i] = Console.ReadLine();
        }

        //cancellamento della console
        Console.Clear();

        //Ciclo del Menà
        do
        {
            //inserimento scelta per il menù
            Console.WriteLine("Premere uno dei seguenti tasti per selezionare l'operazione desiderata:");
            Console.Write("1 - aggiunta stringa \n2 - cancellazione della prima stringa di un nome di animale \n3 - ordinamento array \n4 - ricerca sequenziale di una stringa \n5 - Visualizzazione degli animali ripetuti \n6 - modifica di una stringa \n7 - visualizzazione dell'array \n8 - ricerca del nome più lungo e più corto \n9 - cancellazione di tutte le stringhe di un nome di animale \n10 - Uscità dal menù \n");
            scelta = int.Parse(Console.ReadLine());
            Console.Clear();                                        //cancellamento della console

            //Menù principale
            switch(scelta)
            {
                //aggiunta di una stringa
                case 1:

                    Console.Write("Inserire il nome di un animale: ");
                    temp = Console.ReadLine();

                    //chiamata alla funzione di aggiunta e controllo se l'array è pieno
                    if (Agg(ref array, temp, ref dim))
                    {
                        Console.WriteLine("Elemento inserito");
                    }

                    else
                    {
                        Console.WriteLine("Array pieno");
                    }

                    Thread.Sleep(2500);

                    break;

                //cancellazione di una stringa
                case 2:

                    Console.Write("Inserire la stringa da eliminare: ");
                    temp = Console.ReadLine();

                    //chiamata alla funzione di cancellazione e controllo se l'elemento esiste nell'array o meno
                    if (Canc(ref array, temp, ref dim))
                    {
                        Console.WriteLine("L'elemento è stato cancellato correttamente");
                    }
                    else
                    {
                        Console.WriteLine("L'elemento non esisteva nell'array, non è stato peciò cancellato");
                    }

                    Thread.Sleep(2500);

                    break;

                //ordinamento array in ordine alfabetico
                case 3:

                    //richiamo funzione di ordinamento
                    Bubblesort(dim, ref array);

                    break;

                //ricerca di una stringa
                case 4:

                    //acquisizione della stringa da ricercare
                    Console.Write("Inserisci la stringa che si vuole ricercare: ");
                    temp = Console.ReadLine();

                    //variabile posizione ricercata
                    int pos = 0;

                    if (Search(ref pos, temp, array, dim))
                    {
                        Console.WriteLine($"L'elemento si trovava in posizione {pos + 1}");
                    }
                    else
                    {
                        Console.WriteLine("La stringa inserita non esiste, non è stato perciò possibile individuarla");
                    }

                    Thread.Sleep(2500);

                    break;

                //visualizzazione delle stringhe ripetute
                case 5:

                    //variabile che conta il numero di ripetizioni
                    int ripetizioni = 0;

                    //array di stringhe che segna i nomi delle variabili ripetute
                    string[] name = new string[dim];

                    //array che segna il numero di ripetizioni per ogni parola
                    int[] ripet = new int[dim];

                    //controllo che ci siano delle ripetizione all'intenro dell'array
                    if(Rip(array, dim, ref ripetizioni, ref name))
                    {
                        Contarip(array, dim, ref ripetizioni, ref name, ref ripet);
                        Console.Write("I nomi di animali ripetuti sono ");
                        for (int i = 0; i < ripetizioni; i++)
                        {
                            Console.Write($"{name[i]} con {ripet[i]} ripetizioni");
                            if (i + 2 == ripetizioni)
                            {
                                Console.Write("e ");
                            }
                            else if (i + 2 < ripetizioni)
                            {
                                Console.Write(", ");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Non sono state trovate ripetizioni all'interno dell'array");
                    }

                    Thread.Sleep(2500);

                    break;

                //modifica di una stringa
                case 6:

                    //variabile ricerca posizione
                    int posiz = 0;

                    Console.WriteLine("Inserisci la stringa che vuoi che venga modificata: ");
                    temp = Console.ReadLine();

                    if (Search(ref posiz, temp, array, dim))
                    {
                        Console.WriteLine("Modifica la stringa: ");
                        array[posiz] = Console.ReadLine();
                        Console.WriteLine("L'elemento è stato modificato correttamente");
                    }
                    else
                    {
                        Console.WriteLine("La stringa inserita non esiste, non è stato perciò possibile individuarla e modificarla");
                    }

                    Thread.Sleep(2500);

                    break;

                //visualizzazione dell'array
                case 7:

                    //richiamo alla funzione di visualizzazione
                    Visualizza(dim, array);

                    break;

                //ricerca del nome più lungo e corto
                case 8:

                    //dichiarazine variabili che salvano il nome più corto e più lungo
                    string Long = "";
                    string Short = "";

                    //richiamo alla funzione che faccia visualizzare il valore più lungo e più corto
                    Ls(ref Long, ref Short, array, dim);

                    //output del nome più lungo e più corto
                    Console.WriteLine($"La stringa con maggior numero di caratteri è {Long} mentre quella con minor numero di caratteri è {Short}");

                    Thread.Sleep(2500);

                    break;

                //cancellazione di tutte le stringhe uguali
                case 9:

                    break;
            }

            //cancellamento della console
            Console.Clear();

        } while (scelta != 10);
    }

    //funzione di aggiunta
    static bool Agg (ref string[] array, string temp, ref int index)
    {
        //dichiarazione variabile booleana per controllare se l'array è pieno o meno
        bool pienezza = true;

        //controllo riempimento array
        if (index < array.Length)
        {
            array[index] = (temp);
            index++;
        }
        else
        {
            pienezza = false;
        }

        //ritornare il valore della variabile booleana
        return pienezza;
    }

    //funzione di cancellamento
    static bool Canc (ref string[] array, string temp, ref int index)
    {
        //dichiarazione variabile booleana per la conferma dell'esistenza della stringa
        bool esistenza = false;

        //ciclo di controllo e cancellazione
        for (int i = 0; i < index; i++)
        {
            if (array[i] == temp)
            {

                index--;
                //ciclo di spostamento dei valori per la cancellazione
                for (int j = i; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                esistenza = true;

                break;
            }
        }

        //ritornare il valore della variabile booleana
        return esistenza;
    }

    //funzione di ordinamento
    static int Bubblesort (int dim, ref string[] array)
    {
        //dichiarazione variabile temporanea
        string temp;

        //ciclo di ordinamento
        for (int i = 0; i < dim - 1; i++)
        {
            for (int j = 0; j < dim - 1; j++)
            {
                //trasferimento del primo carattere di ogni stringa in una variabile apposita per l'ordinamento
                int first1 = (int)array[j].FirstOrDefault();
                int first2 = (int)array[j+1].FirstOrDefault();
                //controllo per ordinamento alfabetico
                if (first1 > first2)
                {
                    //scambio valori
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        return 0;
    }

    //funzione di ricerca sequenziale
    static bool Search(ref int pos, string temp, string[] array, int dim )
    {
        //variabile che dichiara l'esistenza della stringa inserita
        bool esistenza = true;

        for (int i = 0; i < dim; i++)
        {
            //controllo se le stringhe sono uguali
            if (String.Compare(temp, array[i]) == 0)
            {
                //nel caso fosse vero trasferisco il valore di i nella variabile pos e ne ritorno il valore per il controllo
                pos = i;
                return esistenza;
            }
        }

        //nel caso non viene trovata la stringa inserita cambierò in falso il valore della variabile booleana e ne ritorno il valore per il controllo
        esistenza = false;
        return esistenza;
    }

    //funzione che segna le ripetizioni all'interno dell'array
    static bool Rip(string[] array, int dim, ref int Rip, ref string[] name)
    {
        //variabile che dichiara l'esistenza di ripetizione all'interno dell'array
        bool ripetizioni = true;

        //ciclo di controllo ripetizione
        for (int i = 0; i < dim; i++)
        {
            for (int j = 0; j < dim; j++)
            {
                //nel caso i contatori dei cicli fossero uguali salterò il passaggio di confronto, dato che darebbero come risultato sempre vero
                if (i != j)
                {
                    if (array[i] == array[j])
                    {
                        name[Rip] = array[i];
                        Rip++;
                    }
                }
            }
        }

        //nel caso non ci siano stringhe ripetute cambierò in falso il valore della variabile booleana
        if (Rip == 0)
        {
            ripetizioni = false;
        }

        //e ne ritorno il valore per il controllo
        return ripetizioni;
    }

    //funzione che conta quante ripetizioni di ogni nome di animali ci siano all'interno dell'array
    static int Contarip(string[] array, int dim, ref int Rip, ref string[] name, ref int[] ripet)
    {
        //ciclo che conti le ripetizioni per ogni parola
        for(int i = 0; i < Rip; i++)
        {
            //ciclo che controlli se nell'array che conserva i nomi ci sia lo stesso nome
            for (int j = 0; j < Rip; j++)
            {
                if (i != j)
                {
                    if (name[i] == name[j])
                    {
                        //ciclo per spostamento dei valori
                        for (int k = 0; k < Rip; k++)
                        {
                            name[k] = name[k + 1];
                        }

                        Rip--;
                        ripet[i]++;
                    }
                }
            }
        }

        return 0;
    }

    //funzione di visualizzazione
    static int Visualizza(int dim, string[] array)
    {
        for (int i = 0; i < dim; i++)
        {
            Console.Write($"    {array[i]}");
        }

        Thread.Sleep(2500);
        return 0;
    }

    //funzione che calcoli il valore più lungo e più corto
    static int Ls(ref string Long, ref string Short, string[] array, int dim)
    {
        //creazione di un array ausiliare da ordinare in modo
        string[] copia = array;

        //ciclo che ordini l'array ausiliare in base alla lunghezza
        for (int i = 0; i < dim - 1; i++)
        {
            for (int j = 0; j < dim - 1 - i; j++)
            {
                if (String.Compare(copia[j], copia[j + 1]) < 0)
                {
                    string temp = copia[j];
                    copia[j] = copia[j + 1];
                    copia[j + 1] = temp;
                }
            }
        }

        //inserimento della stringa nell'indice 0 della copia in Short e della stringa nell'indice equivalente a dim in Long
        Short = copia[0];
        Long = copia[dim - 1];

        //ritorno al programma principale
        return 0;
    }
}
