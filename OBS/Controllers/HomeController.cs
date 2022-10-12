using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Odev.Models;
using Odev.ViewModel;
using System.Diagnostics;

namespace Odev.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudentList()
        {
            StudentVM student = new StudentVM();

            var ogrenciList = _context.Ogrenci_Tbl.ToList();

            foreach (var item in ogrenciList)
            {
                Student students = new Student()
                {
                    group = item.grup,
                    hobiler = item.hobiler,
                    Id = item.id,
                    Ogrenci_adı = item.Ogrenci_Adı,
                    Ogrenci_soyadı = item.Ogrenci_Soyad,
                    Ogrenci_yas = item.Ogrenci_Yas.ToString(),
                    RehberOgretmen = _context.Ogretmen_Tbl.Where(x => x.id == item.Rehber_Ogretmen).FirstOrDefault().Ogretmen_AdıSoyadı,
                    SınıfOgretmeni = _context.Ogretmen_Tbl.Where(x => x.id == item.Sınıf_Ogretmeni).FirstOrDefault().Ogretmen_AdıSoyadı,
                    Sehir = _context.iller.FirstOrDefault(x => x.id == item.Sehir).sehiradi,
                    ilce = _context.ilceler.FirstOrDefault(x => x.id == item.ilce).ilceadi
                };
                student.Ogrencis.Add(students);
            }

            return Json(student);
        }
        public JsonResult UpdateStudent(int id)
        {
            StudentVM student = new StudentVM();
            student.Ogrenci= _context.Ogrenci_Tbl.Where(x => x.id == id).FirstOrDefault();
            student.Ogretmens = _context.Ogretmen_Tbl.ToList();
            student.İllers = _context.iller.ToList();
            student.İlcelers = _context.ilceler.Where(x => x.sehirid == student.Ogrenci.Sehir).ToList();
            return Json(student);
        }
        public IActionResult Teachers()
        {
            return View();
        }
        public JsonResult GetTeacherList()
        {
            var result = _context.Ogretmen_Tbl.ToList();
            return Json(result);
        }
        public JsonResult GetTeacherData(int id)
        {
            var teacher = _context.Ogretmen_Tbl.FirstOrDefault(x => x.id == id);
            return Json(teacher);
        }
        public JsonResult AddOrUpdateTeacher(string name, int id)
        {
            if (id > 0)
            {
                var result = _context.Ogretmen_Tbl.Where(x => x.id == id).FirstOrDefault();
                result.Ogretmen_AdıSoyadı = name;
                _context.SaveChanges();
            }
            else
            {
                Ogretmen ogretmen = new Ogretmen()
                {
                    Ogretmen_AdıSoyadı = name
                };
                _context.Ogretmen_Tbl.Add(ogretmen);
                _context.SaveChanges();
            }
            return Json(1);
        }
        public JsonResult GetCityList()
        {
            var result = _context.iller.ToList();
            return Json(result);
        }
        public JsonResult GetDisctrictList()
        {
            var result = _context.ilceler.ToList();
            return Json(result);
        }
        public JsonResult GetDistrictByCity(int cityId)
        {
            var result = _context.ilceler.Where(x => x.sehirid == cityId).ToList();
            return Json(result);
        }
        public JsonResult AddOrUpdateStudent(Ogrenci ogrenci)
        {
            if (ogrenci.id > 0)
            {
                var result = _context.Ogrenci_Tbl.Where(x => x.id == ogrenci.id).FirstOrDefault();
                result.grup = ogrenci.grup;
                result.Rehber_Ogretmen = ogrenci.Rehber_Ogretmen;
                result.Sınıf_Ogretmeni = ogrenci.Sınıf_Ogretmeni;
                result.Ogrenci_Soyad = ogrenci.Ogrenci_Soyad;
                result.Sehir = ogrenci.Sehir;
                result.hobiler = ogrenci.hobiler;
                result.ilce = ogrenci.ilce;
                result.Ogrenci_Adı = ogrenci.Ogrenci_Adı;
                result.Ogrenci_Yas = ogrenci.Ogrenci_Yas;
                _context.SaveChanges();
            }
            else
            {
                Ogrenci newStudent = new Ogrenci()
                {
                    grup = ogrenci.grup,
                    Ogrenci_Yas = ogrenci.Ogrenci_Yas,
                    hobiler = ogrenci.hobiler,
                    ilce = ogrenci.ilce,
                    Ogrenci_Adı = ogrenci.Ogrenci_Adı,
                    Ogrenci_Soyad = ogrenci.Ogrenci_Soyad,
                    Rehber_Ogretmen = ogrenci.Rehber_Ogretmen,
                    Sehir = ogrenci.Sehir,
                    Sınıf_Ogretmeni = ogrenci.Sınıf_Ogretmeni
                };
                _context.Ogrenci_Tbl.Add(newStudent);
                _context.SaveChanges();
            }
            return Json(1);
        }
    }
}