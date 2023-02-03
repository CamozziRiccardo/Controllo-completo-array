using System;
using System.Collections.Generic;
using System.Linq;
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
        int a, b;

        //variabile temporanea
        string temp;

        //grandezza array
        Console.Write("Inserire quante celle dell'array si vogliono utilizzare (massimo 100): ");
        dim = int.Parse(Console.ReadLine());                        //inserimento dei valori che si vogliono utilizzare

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
            Console.Write("1 - aggiunta stringa \n2 - cancellazione di una stringa \n3 - ordinamento array \n4 - ricerca sequenziale di una stringa \n5 - Visualizzazione degli animali ripetuti \n6 - modifica di una stringa \n7 - visualizzazione dell'array \n8 - ricerca del nome più lungo e più corto \n9 - cancellazione delle copie \n10 - Uscità dal menù \n");
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
                    if (agg(ref array, temp, ref dim))
                    {
                        Console.WriteLine("Elemento inserito");
                    }

                    else
                    {
                        Console.WriteLine("Array pieno");
                    }

                    break;

                //cancellazione di una stringa
                case 2:

                    Console.Write("Inserire la stringa da eliminare: ");
                    temp = Console.ReadLine();

                    //chiamata alla funzione di cancellazione e controllo se l'elemento esiste nell'array o meno
                    if (canc(ref array, temp, ref dim))
                    {
                        Console.WriteLine("L'elemento è stato cancellato correttamente");
                    }
                    else
                    {
                        Console.WriteLine("L'elemento non esisteva nell'array, non è stato peciò cancellato");
                    }

                    break;

                //ordinamento array in ordine alfabetico
                case 3:

                    //richiamo funzione di ordinamento
                    bubblesort(dim, ref array);

                    break;

                //ricerca di una stringa
                case 4:

                    //acquisizione della stringa da ricercare
                    Console.Write("Inserisci la stringa che si vuole ricercare: ");
                    temp = Console.ReadLine();

                    //variabile posizione ricercata
                    int pos;

                    if (search(ref pos, temp, array, dim))
                    {
                        Console.WriteLine($"L'elemento si trovava in posizione {pos + 1}");
                    }
                    else
                    {
                        Console.WriteLine("La stringa inserita non esiste, non è stato perciò possibile individuarla");
                    }

                    break;

                //visualizzazione delle stringhe ripetute
                case 5:

                    break;

                //modifica di una stringa
                case 6:

                    break;

                //visualizzazione dell'array
                case 7:

                    //richiamo alla funzione di visualizzazione
                    visualizza(dim, array);
                    break;

                //ricerca del nome più lungo e corto
                case 8:

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
    static bool agg (ref string[] array, string temp, ref int index)
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
    static bool canc (ref string[] array, string temp, ref int index)
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
    static int bubblesort (int dim, ref string[] array)
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

                Console.WriteLine(first2);
                Console.WriteLine(first1);
                Thread.Sleep(1000);

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
    static bool search(ref int pos, string temp, string[] array, int dim )
    {
        //variabile che dichiara l'esistenza della stringa inserita
        bool esistenza = true;

        for (int i = 0; i < dim; i++)
        {
            //controllo se le stringhe sono uguali
            if (String.Compare(temp, array[i]) == 0)
            {
                //nel caso fosse vero trasferisco il valore di i nella variabile pos e ritorno il valore di esistenza per il controllo dell'esistenza della stringa inserita
                pos = i;
                return esistenza;
            }
        }

        //nel caso non viene trovata la stringa inserita cambierò in falso il valore della variabile booleana e ritorno il valore di esistenza per il controllo dell'esistenza della stringa inserita
        esistenza = false;
        return esistenza;
    }

    //funzione di visualizzazione
    static int visualizza(int dim, string[] array)
    {
        for (int i = 0; i < dim; i++)
        {
            Console.Write($"    {array[i]}");
        }

        Thread.Sleep(2500);
        return 0;
    }
}
