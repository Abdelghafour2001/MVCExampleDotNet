using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class Personne
    {
        private string nom;
        private int age;
        private string adresse;

        public string Adresse { get => adresse; set => adresse = value; }
        public int Age { get => age; set => age = value; }
        public string Nom { get => nom; set => nom = value; }

        public Personne() { }
        public Personne(string n,int a,string ad)
        {
            nom = n;
            age = a;
            adresse = ad;
        }

    }
}
