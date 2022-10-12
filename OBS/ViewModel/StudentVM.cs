using Odev.Models;

namespace Odev.ViewModel
{
    public class StudentVM
    {
        public StudentVM()
        {
            İllers = new List<iller>();
            İlcelers = new List<ilceler>();
            Ogrencis = new List<Student>();
            Ogretmens = new List<Ogretmen>();
        }
        public List<iller> İllers { get; set; }
        public List<ilceler> İlcelers { get; set; }
        public List<Student> Ogrencis { get; set; }
        public List<Ogretmen> Ogretmens { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
}
