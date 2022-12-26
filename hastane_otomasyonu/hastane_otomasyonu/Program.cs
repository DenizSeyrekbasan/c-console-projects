using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane_otomasyonu
{
    internal class Program
    {
        public class hastane
        {
            public string adi = "";
            public string adres = "";

            List<hasta> hastalar = new List<hasta>();
            List<doktor> doktorlar = new List<doktor>();
            public void hastaEkle(string adiSoyadi,string tc,string cinsiyet,string dTarihi)
            {
                hasta yeni = new hasta();
                yeni.hastaAdiSoyadi = adiSoyadi;
                yeni.hastaTc = tc;
                yeni.hastaCinsiyet = cinsiyet;
                yeni.hastaDogumTarihi = dTarihi;
                hastalar.Add(yeni);
            }
            public void hastaListele()
            {
                foreach(var item in hastalar)
                {
                    Console.WriteLine("Hasta Adi-Soyadi : {0}\n" + "Hasta TC : {1}\n" + "Hasta Cinsiyet : {2}\n" + "Hasta Dogum Tarihi : {3}", item.hastaAdiSoyadi, item.hastaTc, item.hastaCinsiyet, item.hastaDogumTarihi);
                    Console.WriteLine("**************************");
                }
            }
            public void hastaSil(string TC)
            {
                foreach(var item in hastalar)
                {
                    if (item.hastaTc==TC)
                    {
                        hastalar.Remove(item);
                        break;
                    }
                }
            }
            public void doktorEkle(string adSoyad,string tc,string cins,string d_tarihi)
            {
                doktor yeni = new doktor();
                yeni.doktorAdiSoyadi = adSoyad;
                yeni.doktorTc = tc;
                yeni.doktorCinsiyet = cins;
                yeni.doktorDogumTarihi = d_tarihi;

                doktorlar.Add(yeni);
            }
            public void doktorSil(string tc)
            {
                foreach(var item in doktorlar)
                {
                    if (item.doktorTc==tc)
                    {
                        doktorlar.Remove(item);
                    }
                }
            }
            public void doktorListele()
            {
                foreach(var item in doktorlar)
                {
                    Console.WriteLine("doktor adı-soyadı : {0}\n" + "doktor tc : {1}\n" + "doktor cinsiyet : {2}\n" + "doktor dTarihi : {3}", item.doktorAdiSoyadi, item.doktorTc, item.doktorCinsiyet, item.doktorDogumTarihi);
                    Console.WriteLine("**************************");
                }
            }
        }
        public class hasta
        {
            public string hastaAdiSoyadi = "";
            public string hastaTc = "";
            public string hastaCinsiyet = "";
            public string hastaDogumTarihi = "";
        }
        public class doktor
        {
            public string doktorAdiSoyadi = "";
            public string doktorTc = "";
            public string doktorCinsiyet = "";
            public string doktorDogumTarihi = "";
        }
        static void Main(string[] args)
        {
            hastane yeni = new hastane();
            yeni.adi = "Atatürk Devlet Hastanesi";
            yeni.adres = "Antalya";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hasta eklemek için     : 1");
                Console.WriteLine("Hasta listelemek için  : 2");
                Console.WriteLine("Hasta silmek için      : 3");
                Console.WriteLine("Doktor eklemek için    : 4");
                Console.WriteLine("Doktor listelemek için : 5");
                Console.WriteLine("Doktor silmek için     : 6");
                Console.WriteLine("Çıkış için             : ESC");
                Console.WriteLine("Tuşlarından birine basınız..");
                

                var basilanTus = Console.ReadKey();

                if (basilanTus.Key==ConsoleKey.NumPad1)
                {
                    Console.Write("Adi-Soyadi : ");
                    string adi_soyadi = Console.ReadLine();

                    Console.Write("Tc : ");
                    string tc = Console.ReadLine();

                    Console.Write("Cinsiyet : ");
                    string cinsiyet = Console.ReadLine();

                    Console.Write("Doğum Tarihi : ");
                    string dogum_tarihi = Console.ReadLine();
                    yeni.hastaEkle(adi_soyadi, tc, cinsiyet, dogum_tarihi);

                    Console.WriteLine("Hasta başarıyla eklenmştir..Devam etmek için bir tuşa basın..");
                    Console.ReadLine();
                }
                else if (basilanTus.Key==ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Hasta Listesi");
                    Console.WriteLine("**************************");
                    yeni.hastaListele();
                    Console.ReadLine();
                }
                else if (basilanTus.Key == ConsoleKey.NumPad3)
                {
                    yeni.hastaListele();
                    Console.Write("Lütfen Silmek Istediginiz hasta TC 'sini giriniz : ");
                    string tc = Console.ReadLine();
                    yeni.hastaSil(tc);
                    Console.WriteLine("{0} tc kimlik numaralı kayit basariyla silinmiştir..Devam etmek için bir tuşa basın..",tc);
                    Console.ReadLine();
                }
                else if (basilanTus.Key == ConsoleKey.NumPad4)
                {
                    Console.Write("Doktor ad-soyad : ");
                    string ad = Console.ReadLine();

                    Console.Write("Doktor tc : ");
                    string tc = Console.ReadLine();

                    Console.Write("Doktor cinsiyet : ");
                    string cins = Console.ReadLine();

                    Console.Write("Doktor dogum tarihi : ");
                    string dTarih = Console.ReadLine();

                    yeni.doktorEkle(ad, tc, cins, dTarih);
                    Console.WriteLine("Doktor kaydı oluşturulmuştur..Devam etmek için bir tuşa basın..");
                    Console.ReadLine();

                }
                else if (basilanTus.Key == ConsoleKey.NumPad5)
                {
                    Console.WriteLine("Doktor Listesi");
                    yeni.doktorListele();
                    Console.WriteLine("Devam etmek için bir tuşa basın..");
                    Console.ReadLine();
                }
                else if (basilanTus.Key == ConsoleKey.NumPad6)
                {
                    yeni.doktorListele();
                    Console.Write("Silmek istediğiniz doktorun doktor TC'sini girin : ");
                    string TC = Console.ReadLine();
                    yeni.doktorSil(TC);
                    Console.WriteLine("İşleminiz gerçekleşmiştir..Devam etmek için bir tuşa basın..");
                    Console.ReadLine();
                }
                else if (basilanTus.Key==ConsoleKey.Escape)
                {
                    break;
                }
                
            }
        }
    }
}
