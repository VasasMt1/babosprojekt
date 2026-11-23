using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberclassplojeckt
{
    internal class Program
    {
        public class Monster {

            public int ID { set; get; }
            public string Nev { set; get; }
            public string Képesség { set; get; }
            public int Életerő { set; get; }
            public int Támadás { set; get; }
            public int Védekezés { set; get; }
            public string Ritkaság { set; get; }

            public Monster(int Id, string nev, string képesség, int életerő, int támadás, int védekezés, string ritkaság)
            {
                ID = Id;
                Nev = nev;
                Képesség = képesség;
                Életerő = életerő;
                Támadás = támadás;
                Védekezés = védekezés;
                Ritkaság = ritkaság;
            }
            public void Kiir() 
            {
                Console.WriteLine($"A szörny Id-ja :{ID} , neve:{Nev} , képesség:{Képesség} , életereje:{Életerő} , támadása:{Támadás} , védekezése:{Védekezés} , ritkasága:{Ritkaság}");
            }


        }
        static List<Monster> szornyek = new List<Monster>();
        static string fajlUt = @"C:\Users\Máté\source\repos\VasasMt1\babosplojekt1\monsters.txt"; 
        static void Main(string[] args)
        {

            bool alapKiiras = true;

            while (alapKiiras)
            {
                Console.WriteLine("=======Szörny kollekció========");
                Console.WriteLine("1. Minden szörnykiirasa a txt-bol");
                Console.WriteLine("2. Keresés a szörnyek között");
                Console.WriteLine("3. Adj szörnyet a fájlhoz");
                Console.WriteLine("4. Vége");
                Console.WriteLine("Válaszod: ");

                string választas = Console.ReadLine();

                switch (választas) 
                {
                    case "1":
                        Szörnykiiras();
                        break;
                    case "2":
                        Szörnykereses();
                        break;
                    case "3":
                        SzörnyHozzaadas();
                        break;
                    case "4":
                        alapKiiras = false;
                        Console.WriteLine("Viszlát");
                        break;
                    default:
                        Console.WriteLine("Nincs ilyen opció!");
                        break;
                }

            }

        }



        static void fájl()
        {
            if (!File.Exists(fajlUt))
            { 
                Console.WriteLine("Nem találtam ilyen fájl nevet");
                return;
            }

            string[] sorok = File.ReadAllLines(fajlUt);
            foreach (string sor in sorok)
            {
                string[] Szetvalasztas = sor.Split(' ');
                Monster szorny = new Monster(int.Parse(Szetvalasztas[0]), Szetvalasztas[1], Szetvalasztas[2], int.Parse(Szetvalasztas[3]), int.Parse(Szetvalasztas[4]), int.Parse(Szetvalasztas[5]), Szetvalasztas[6]);
                szornyek.Add(szorny);
            }
            Console.WriteLine("A betoltés sikeres volt.");
        }

        static void Szörnykiiras() 
        {
            foreach (Monster szorny in szornyek) 
            {
                szorny.Kiir();
                
            }
            Console.WriteLine($"Betöltve: {szornyek.Count} szörny");

        }
        static void Szörnykereses() 
        {
            Console.WriteLine("Kérem a szörny nevét: ");
            string nev = Console.ReadLine();

            bool vane = false;
            foreach (Monster szorny in szornyek) 
            {
                if (szorny.Nev.ToLower() == nev.ToLower()) 
                {
                    szorny.Kiir();
                    vane= true;
                }
            }
            if (!vane) 
            {
                Console.WriteLine("Nincs ilyen szörny.");
            }
        }

        static void SzörnyHozzaadas() 
        {
            Console.WriteLine("Neve: ");
            string nev = Console.ReadLine();
            Console.WriteLine("Képessége: ");
            string kepesseg = Console.ReadLine();
            Console.WriteLine("Életereje: ");
            int eletero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Támadása: ");
            int tamadas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Védekezése: ");
            int vedekezes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ritkasága: ");
            string ritkasag = Console.ReadLine();

            int id = szornyek.Count + 1;

            Monster ujSzorny = new Monster(id,nev,kepesseg,eletero,tamadas,vedekezes,ritkasag);
            szornyek.Add(ujSzorny);

            Console.WriteLine("Sikeres volt a szorny importálás.");

        }
    }
}
