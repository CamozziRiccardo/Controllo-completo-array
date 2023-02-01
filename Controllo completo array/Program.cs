using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //variabile temporanea per l'aggiunta di un valore
        string temp;

        //grandezza array
        Console.Write("Inserire quante celle dell'array si vogliono utilizzare (massimo 100): ");
        dim = int.Parse(Console.ReadLine());                        //inserimento dei valori che si vogliono utilizzare

        //inserimento animali
        for (int i = 0; i < dim; i++)
        {
            Console.WriteLine("Inserisci il nome di un animale: ");
            array[i] = Console.ReadLine();
            Console.Clear();                                        //cancellamento della console
        }

        //Ciclo del Menà
        do
        {
            //inserimento scelta per il menù
            Console.WriteLine("Premere uno dei seguenti tasti per selezionare l'operazione desiderata:");
            Console.Write("1 - aggiunta stringa \n2 - cancellazione di una stringa \n3 - ordinamento array \n4 - ricerca sequenziale di una stringa \n5 - Visualizzazione degli animali ripetuti \n6 - modifica di una stringa \n7 - visualizzazione dell'array \n8 - ricerca del nome più lungo e più corto \n9 - cancellazione delle copie \n10 - Uscità dal menù");
            scelta = int.Parse(Console.ReadLine());
            Console.Clear();                                        //cancellamento della console

            //Menù principale
            switch(scelta)
            {
                //aggiunta di una stringa
                case 1:

                    break;

                //cancellazione di una stringa
                case 2:

                    break;

                //ordinamento array in ordine alfabetico
                case 3:

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

                    break;

                //ricerca del nome più lungo e corto
                case 8:

                    break;

                //cancellazione di tutte le stringhe uguali
                case 9:

                    break;
            }

        } while (scelta == 10);

    }
}
