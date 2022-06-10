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
}
