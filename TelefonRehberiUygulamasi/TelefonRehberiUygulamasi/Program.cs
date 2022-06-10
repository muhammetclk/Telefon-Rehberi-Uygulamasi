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
        public int Control(List<BasePerson> basePeople)//isim,soyisim,numaraya gore arama yapan ve kisi bulunursa indexini donduren yoksa -1 donduren metodumuz.
        {
            Console.Write("FirstNameOrLastNameOrTelnumber:");
            string NameOrSurnameOrTelnumber = Console.ReadLine();//aranacak kisi bilgisi.
            bool IsThere = true;//aranacak kisinin varligini gosteren kontrol ifadesi.
            int count = 0;//aranacak kisinin indexini dondurecek degisken.
            foreach (var basePerson in basePeople)
            {
                if (NameOrSurnameOrTelnumber.ToLower() == basePerson.FirstName.ToLower() || NameOrSurnameOrTelnumber.ToLower() == basePerson.LastName.ToLower() || NameOrSurnameOrTelnumber.ToLower() == basePerson.TelNumber.ToLower())
                {
                    IsThere = true;//eger aranacak kisi eslesirse true olup donguyu bitirecek.
                    break;
                }
                else
                {
                    IsThere = false;//eger aranan kisi eslesmediyse false olup listenin sonuna kadar kontrol  edilecek.
                    count++;//eslesme yoksa degiskenin degerini arttiracak ve indexini bulmamizi saglayacak.
                }
            }
            int Result;
            Result = IsThere == true ? count : -1;//aranan bulunursa indexini, bulunmassa -1 dondurucek yapi. 
            return Result;
        }

        public void SaveNumber(List<BasePerson> basePeople)//yeni numara kaydetme islemi yapan metod.
        {
            Console.Write("Please Enter FirstName:");
            FirstName = Console.ReadLine();//isim atamasi.
            Console.Write("Please Enter LastName:");
            LastName = Console.ReadLine();//soyisim atamasi.
            Console.Write("Please Enter Phone Number:");
            TelNumber = Console.ReadLine();//numara atamasi.
            basePeople.Add(new BasePerson { FirstName = FirstName, LastName = LastName, TelNumber = TelNumber });//yeni kisiyi listeye akleme islemi.
            Console.WriteLine("Saved...");
            Console.WriteLine("Returns to main menu");
        }
        public void DeleteNumber(List<BasePerson> basePeople)//numara silme islemi yapacak olan metod
        {
            while (true)
            {
                Console.WriteLine("Please enter the name or last name or Telnumber of the person whose number you want to delete:");
                int inComingValue = Control(basePeople);//silinecek ismin kontrolu yapilacak ve indexini getirecek Control metod cagrimi.
                if (inComingValue != -1)//gelen deger -1 degilse kisi bulunmustur ve burasi calisir.
                {
                    Console.WriteLine("Do you approve " + basePeople[inComingValue].FirstName + " " + basePeople[inComingValue].LastName + " " + "to be deleted from the directory? (y / n)");
                    Console.Write("Process:");//bulunan kisinin silinmesinin onay islemi.
                    char Process = Convert.ToChar(Console.ReadLine());
                    if (Process == 'y' || Process == 'Y')//eger y girilirse silinme islemi gerceklesir ve ana menuye doner.
                    {
                        basePeople.Remove(basePeople[inComingValue]);//kisi listeden silindi.
                        Console.WriteLine("Deleted...");
                        Console.WriteLine("Returns to main menu");
                        break;
                    }
                    else if (Process == 'n' || Process == 'N')//eger n girilirse silme iptal olur ve ana menuye doner.
                    {
                        Console.WriteLine("Returns to main menu ");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Wrong character..." + "\nReturns to main menu");//eger Y ve N disinda bir karakter girilirse karakter hatasi verir ve ana menuye donulur.
                        break;
                    }
                }
                else  //eger gelen deger -1 ise bu kisma girer.
                {
                    Console.WriteLine("The person you are  looking for was not found");//aranan kisini olmadigini soyler.
                    Console.WriteLine("Please select an operation");//secim yapmamizi ister 1 icin silmeyi bitir,2 icin tekrar dene.
                    Console.WriteLine("1-End Deletion...");
                    Console.WriteLine("2-Try Again...");
                    Console.Write("Process:");
                    int Process = Convert.ToInt32(Console.ReadLine());
                    if (Process == 1)//1 basilirsa ana menue doner.
                    {
                        Console.WriteLine("Returns to main menu");
                        break;
                    }
                    else if (Process == 2)//2 basilirsa silme adimi tekrar calisir ve tekrar kisi bilgisi ister.
                        continue;
                    else//yanlis karakter girilmesi durumunda hata verir ve ana menuye doner.
                    {
                        Console.WriteLine("Wrong character..." + "\nReturns to main menu");
                        break;
                    }
                }
            }
        }
        public void UpdateNumber(List<BasePerson> basePeople)//numara guncelleme yapacak olan metod.
        {
            while (true)//islemi donguye sokacak olan while yapisi
            {
                Console.WriteLine("Please enter the name or last name or Telnumber of the person whose number you want to update:");
                int inComingValue = Control(basePeople);//guncellenecek ismin kontrolu yapilacak ve indexini getirecek Control metod cagrimi.
                if (inComingValue != -1)//gelen deger -1 degilse kisi bulunmustur ve burasi calisir.
                {
                    Console.WriteLine("Do you approve " + basePeople[inComingValue].FirstName + basePeople[inComingValue].LastName + " to be updated from the directory?(y/n)");
                    Console.Write("Process:");//bulunan kisinin guncellenmesinin onay islemi.
                    char Process = Convert.ToChar(Console.ReadLine());
                    if (Process == 'y' || Process == 'Y')//eger y girilirse guncelleme islemi gerceklesir ve ana menuye doner.
                    {
                        Console.Write("Enter the new number:");
                        basePeople[inComingValue].TelNumber = Console.ReadLine();//kisinin yeni numarasi girilecek.
                        Console.WriteLine("Updated...");
                        break;
                    }
                    else if (Process == 'n' || Process == 'N')//eger n girilise guncelleme iptal olur ve ana menuye doner.
                    {
                        Console.WriteLine("Returns to main menu ");
                        continue;
                    }
                    else//eger yanlis karakter girilirse hata verir ve ana menuye doner.
                    {
                        Console.WriteLine("Wrong character..." + "\nReturns to main menu");
                        break;
                    }
                }
                else//gelen deger -1 ise burasi calisir.
                {
                    Console.WriteLine("Data not found.Please select the process to you want to do");//kisi bulunamadi.
                    Console.WriteLine("End the update:(1)\n" + "Try again:(2)");
                    Console.Write("Process:");//islem secimi yap.
                    int Process = Convert.ToInt32(Console.ReadLine());
                    if (Process == 1)//1 icin guncelleme islemi iptal olur ve ana menuye doner.
                    {
                        Console.WriteLine("Returns to main menu...");
                        break;
                    }
                    else if (Process == 2)//2 icin guncelleme tekrar denenir.
                        continue;
                    else//1 veya 2 disinda bir karakter girilmesi durumunda hata verir ve ana menuye doner.
                    {
                        Console.WriteLine("Wrong character..." + "\nReturns to main menu");
                        break;
                    }
                }
            }
        }
        public void TelDirectory(List<BasePerson> basePeople)//rehberi listeleyecek olan metod.
        {
            Console.WriteLine("Phone Directory");
            foreach (var basePerson in basePeople)//rehberi kerana bastiriir.
            {
                Console.WriteLine("FirstName:" + basePerson.FirstName);
                Console.WriteLine("LastName:" + basePerson.LastName);
                Console.WriteLine("TelNumber:" + basePerson.TelNumber);
            }
        }
        public void TelDirectorySearch(List<BasePerson> basePeople)//rehberde arama yapan metod.
        {
            Console.WriteLine("Enter a first name or last name or number to search in the directory:");
            int inComingValue = Control(basePeople);//aranan kisinin indexini dondurur .
            if (inComingValue != -1)//gelen deger -1 degilse kisi bulunmustur.
            {
                for (; inComingValue < basePeople.Count; inComingValue++)//aranan kisinin en ustte oldugu ve sonrasinda diger numaralarin geldigi dongu yapisi.
                    Console.WriteLine("FirstName: " + basePeople[inComingValue].FirstName + "\nLastName:" + basePeople[inComingValue].LastName + "\nTelNumber:" + basePeople[inComingValue].TelNumber);
            }
            else//kisi bulunmassa burasi calisir ve ana menuye doner.
                Console.WriteLine("Number not found");
        }
    }
}
