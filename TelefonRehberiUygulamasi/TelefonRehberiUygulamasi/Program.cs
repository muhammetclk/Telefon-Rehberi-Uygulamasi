using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BasePerson> basePeople = new List<BasePerson> {//BasePerson tipinde isim,soyisim,numara tutan liste. 
                new BasePerson() { FirstName = "Burak", LastName = "Yilmaz", TelNumber ="12345678900"},//ilk deger atamalari yapildi.
                new BasePerson() { FirstName = "Emre", LastName = "Belozoglu", TelNumber ="12345678911"},
                new BasePerson() { FirstName = "Hakan", LastName = "Calhanoglu", TelNumber ="12345678922"},
                new BasePerson() { FirstName = "Mesut", LastName = "Ozil", TelNumber ="12345678933"},
                new BasePerson() { FirstName = "Ferdi", LastName = "Kadioglu", TelNumber ="12345678944"}
            };
            Action action = new Action();//yeni numara ekleme,silme,guncelleme,rehberi listeleme,rehberde arama yapma islmelerini yapacagimiz nesne.
            bool Control = true;//false olmasi durumunda, programi bitiricek degisken tanimi.
            try//programda hata olmasi durumunda calisacak try catch yapisi.
            {
                do//do while yapisinin baslangici.
                {
                    Console.WriteLine("Please select the process to you want to do:");//yapilacak islemler
                    Console.WriteLine("1-Saving a new number");
                    Console.WriteLine("2-Delete exiting number");
                    Console.WriteLine("3-Update exiting number");
                    Console.WriteLine("4-List the directory");
                    Console.WriteLine("5-Search the directory");
                    Console.WriteLine("6-Exit");
                    Console.Write("Process:");
                    string Process = Console.ReadLine();//hangi islemi yapacaginin girisi
                    switch (Process)
                    {
                        case "1":
                            action.SaveNumber(basePeople);//numara kaydetme islemi yapacak metodun cagrilmasi(BasePeople tipinde parametre istiyor.)
                            break;
                        case "2":
                            action.DeleteNumber(basePeople);//numara silme islemi yapacak metodun cagrilmasi.
                            break;
                        case "3":
                            action.UpdateNumber(basePeople);//numara guncellemesi yapacak metodun cagrilmasi.
                            break;
                        case "4":
                            action.TelDirectory(basePeople);//rehberi listeleyecek metodun cagrilmasi.
                            break;
                        case "5":
                            action.TelDirectorySearch(basePeople);//rehberde arama yapilacak ve aranan isim en ustte olacak sekilde diger numaralarinda gozuktugu metodun cagrilmasi.
                            break;
                        case "6":
                            Control = false;//islem icin 6 girisi olmasi durumunda kontrol degiskeni false olacak ve programi bitirecek. 
                            Console.Write("press any key to exit:");
                            break;
                        default://1-6 disinda bir karakter girilmesi durumunda calisacak kisim.
                            Console.WriteLine("Wrong character...Try again");
                            break;
                    }
                } while (Control == true);//Control degiskenini kontrol eden while yapisi.
            }
            catch (Exception exception)//hatali karakterler girisi olmasi durumunda hatayi yakalayacak olan ve mesaj yazdiracak olan catch yapisi.
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
    class BasePerson//base clasimiz.Icinde isim,soyisim,numara propertylerini tutuyor.
    {
        string _FirstName { get; set; }
        string _LastName { get; set; }
        string _TelNumber { get; set; }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string TelNumber
        {
            get { return _TelNumber; }
            set { _TelNumber = value; }
        }
    }
    class Action : BasePerson//Islemleri yapacak olan metodlari tutan ve Base clasindaki propertyleri kullanabilmek icin miras alan classimiz.
    {
        /* public int Control(List<BasePerson> basePeople)//isim,soyisim,numaraya gore arama yapan ve kisi bulunursa indexini donduren yoksa -1 donduren metodumuz.
         { }*/

        public void SaveNumber(List<BasePerson> basePeople)//yeni numara kaydetme islemi yapan metod.
        {
        }
        public void DeleteNumber(List<BasePerson> basePeople)//numara silme islemi yapacak olan metod
        {
        }
        public void UpdateNumber(List<BasePerson> basePeople)//numara guncelleme yapacak olan metod.
        {
        }
        public void TelDirectory(List<BasePerson> basePeople)//rehberi listeleyecek olan metod.
        {
        }
        public void TelDirectorySearch(List<BasePerson> basePeople)//rehberde arama yapan metod.
        {
        }
    }
}
