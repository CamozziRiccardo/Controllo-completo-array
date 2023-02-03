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
        int temp;

        //ciclo di ordinamento
        for (int i = 0; i < dim - 1; i++)
        {
            for (int j = 0; j < dim - 1 - i; j++)
            {
                //trasferimento del primo carattere di ogni stringa in una variabile apposita per l'ordinamento
                char first1 = array[j].FirstOrDefault();
                char first2 = array[j+1].FirstOrDefault();

                //conversione del carattere in ASCII per controllo
                int firs1 = (int)first1;
                int firs2 = (int)first2;

                //controllo per ordinamento alfabetico
                if(firs1 > firs2)
                {
                    temp = firs1;
                    firs1 = firs2;
                    firs2 = temp;
                }
            }
        }
        return 0;
    }


}
