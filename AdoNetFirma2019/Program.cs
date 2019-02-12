using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetFirma2019.DAL;
using AdoNetFirma2019.Models;

namespace AdoNetFirma2019
{
    class Program
    {
        static void AddWorker() {
            Console.WriteLine("Podaj imie");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj pensje");
            decimal pensja = Convert.ToDecimal(Console.ReadLine());
            IRepository repo = new SQLRepository(MyConnection.GetConnectionString());
            repo.InsertWorker(new Worker(){Imie = imie,Nazwisko = nazwisko,Pensja = pensja});

        }
        static void Main(string[] args)
        {
            IRepository repo = new SQLRepository(MyConnection.GetConnectionString());
            List<Worker> workers = repo.GetWorkers();
            foreach (var worker in workers) {
                Console.WriteLine("{0} {1} {2} zł",worker.Imie,worker.Nazwisko,worker.Pensja);
            }
            AddWorker();
            Console.ReadKey();
        }
    }
}
