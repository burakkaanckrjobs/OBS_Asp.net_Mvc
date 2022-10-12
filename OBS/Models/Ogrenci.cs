namespace Odev.Models
{
    public class Ogrenci
    {
        public int id { get; set; }
        public string Ogrenci_Adı { get; set; }
        public string Ogrenci_Soyad { get; set; }
        public int Ogrenci_Yas { get; set; }
        public int Sehir { get; set; }
        public int ilce { get; set; }
        public string grup { get; set; }
        public string hobiler { get; set; }
        public int Rehber_Ogretmen { get; set; }
        public int Sınıf_Ogretmeni { get; set; }
    }
}
