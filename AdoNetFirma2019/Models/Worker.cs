namespace AdoNetFirma2019.Models {
    public class Worker {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public decimal Pensja { get; set; }
        public Stanowisko Stanowisko { get; set; }
    }
}