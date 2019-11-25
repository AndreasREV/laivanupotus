using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laivanupotusali
{
    class Program
    {
       static string head;
       static int x, y;
       static int[,] grid = new int[10, 10];
       static int[,] pcgrid = new int[10, 10];
       static Random rdm = new Random();
        private static int Maksalaatikko()
        {    
            int zx = rdm.Next(1, 8);
            int vz = rdm.Next(1, 8);
            pcgrid[zx, vz] = 1;
            int kek = rdm.Next(1,5);
            //int derp;
            //arvotaan tietokoneen laivojen paikka
            if (kek == 1)
            {
                pcgrid[zx + 1, vz] = 1;
                Console.WriteLine("tietsikan laiva on :" + (zx+1) + "," + vz);               
            }
            else if (kek == 2)
            {
                pcgrid[zx, vz + 1] = 1;
                Console.WriteLine("tietsikan laiva on :" + zx + "," + (vz+1));              
            }
            else if (kek == 3)    
            {
                pcgrid[zx - 1, vz] = 1;
                Console.WriteLine("tietsikan laiva on :" + (zx-1) + "," + vz);                
            }
            else if (kek == 4)
            {
                pcgrid[zx, vz - 1] = 1;
                Console.WriteLine("tietsikan laiva on :" + zx + "," + (vz-1));   
            }
            Console.WriteLine("tietsikan laiva on :" + zx + "," + vz);
            //laitetaan pelaajan laivat ja niiden suunta
            Console.WriteLine("mihin haluat laitta shippis anna x koordi");
            x = int.Parse(Console.ReadLine());                                 
            Console.WriteLine("mihin haluat laitta shippis anna y koordi");
            y = int.Parse(Console.ReadLine());
            //grid[x, y] = 1;
            Console.WriteLine("mihin suuntaan laiva laitetaan");
            head = Console.ReadLine(); 
            if (head == "up")
            {
                grid[x, y + 1] = 1;
                Console.WriteLine("laivasi on koordinaateissa:" + x + "," + (y+1));
            }
            else if (head == "down")
            {
                grid[x, y - 1] = 1;
                Console.WriteLine("laivasi on koordinaateissa:" + x + "," + (y - 1));
            }
            else if (head == "right")
            {
                grid[x + 1, y] = 1;
                Console.WriteLine("laivasi on koordinaateissa:" +(x+1) + "," +y);
            }
            else if (head == "left")
            {
                grid[x - 1, y] = 1;
                Console.WriteLine("laivasi on koordinaateissa:" + (x-1) + "," +y);
            }
            //grid[x +1, y] = 1;
            ////grid[x , y+1] = 1;
            //grid[x-1 , y] = 1;
            //grid[x , y-1] = 1; 
            Console.WriteLine("laivasi on koordinaateissa:" + x + "," + y);
            return kek;
        }
        static void Main(string[] args)
        {
            //muuuttujat ja taulukko
            int kek = 0;
            bool peli = true;
          //  int x = 0, y = 0;
          //  int[,] grid = new int[10, 10];
            int pshotv, pshotz, pcshotx, pcshotz;
          //  int[,] pcgrid = new int[10, 10];
            kek = Maksalaatikko();
            //ammuskellaan laivoja  
            //peli pyörii niin kauan kunnes jompikumpi osuu
            while (peli)
            {
                //pelaaja ampuu kaksi kertaa , kahdella osumalla laiva posahtaa
                Console.WriteLine("Ammu laivaa!");
                Console.WriteLine("mihin haluat ampua. Anna v koordinaatti:");
                pshotv = int.Parse(Console.ReadLine());
                Console.WriteLine("mihin haluat ampua. Anna z koordinaatti:");
                pshotz = int.Parse(Console.ReadLine());
                Console.WriteLine("ammuit koordinaattehin:  " + pshotv + "," + pshotz);
                if (pcgrid[pshotv, pshotz] == 1)
                {
                    Console.WriteLine("osuit ekan kerran");
                    
                    //tarkistetaan toisen osuma
                }
                else
                {
                   pcgrid[pshotv, pshotz] = 2;
                   Console.WriteLine("ei osunut");
                }
                Console.WriteLine("ammu toisen kerran!");
                Console.WriteLine("mihin haluat ampua. Anna v koordinaatti:");
                pshotv = int.Parse(Console.ReadLine());
                Console.WriteLine("mihin haluat ampua. Anna z koordinaatti:");
                pshotz = int.Parse(Console.ReadLine());
                Console.WriteLine("ammuit kooordinaattehin:  " + pshotv + "," + pshotz);
                if (pcgrid[pshotv, pshotz] == 1)
                {
                    Console.WriteLine("osuit viimeisen kerran bang bang laiva upposi");
                    break;                    
                }
                else
                {
                    pcgrid[pshotv, pshotz] = 2;
                    Console.WriteLine("ei osunut");
                }
                //tietokone ampuu kaksi kertaa
                pcshotx = rdm.Next(0, 10);
                pcshotz = rdm.Next(0, 10);
                if (pcshotx == x && pcshotz == y)
                {
                    Console.WriteLine("tietokone osui \a \a");
                    //peli = false;
                    break;
                }
                else
                {
                    Console.WriteLine("tietsikka ampui ohi koordinatteihin: " + pcshotx + "," + pshotz);
                    grid[x, y] = 2;
                }
            }
            Console.WriteLine("paina jotai että peli sammuu");
            Console.ReadKey();
        }
    }
}
