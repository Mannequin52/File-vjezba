using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileVježba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //upis stringa i dohvaćanje putanje
            Console.WriteLine("Upiši svoje ime: ");
            string ime = Console.ReadLine();

            string put = @"C:\aha\Ime.txt";
            //nazivi mape i datoteke
            string mapa = "FileIme";
            string datoteka = "Ime.txt";

            //kreiranje direktorija FileIme
            Directory.CreateDirectory(mapa);

            if (File.Exists(datoteka))
            {
                if (!Directory.Exists("backup"))
                {
                    Directory.CreateDirectory("backup");
                }

                File.Copy(datoteka, @"backup\ime" + DateTime.Now.ToString("ss_mm_HH_dd_MM_yyyy" + ".txt"));
                File.Delete(datoteka);
            }
            //zapisivanje imena u Ime.txt
            Console.WriteLine("\n-- Zapisujemo u datoteku...");
            using (StreamWriter sw = new StreamWriter(put))
            {
                sw.WriteLine(Convert.ToString(ime));
            }
            
            File.WriteAllText(datoteka, ime);
            Console.ReadKey();
        }
    }
}
