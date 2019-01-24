using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_5_A2
{
    class Article 
    {
        // Les attributs/ propriétés sont les variables que peuvent prendre la Classe Article pour être définie
        // Toujours en majuscule pour les différencier avec le constructeur
        public  long Reference { get; set; } //un numéro qui caractérise l’article de manière unique
        public string Intitule { get; set; } //la description de l’article sous forme de texte
        public float PrixHT { get; set; } //le prix unitaire hors taxe de l’article
        public int QuantiteEnStock { get; set; } //le nombre d’unités de l’article disponibles

        // ICI c'est ce que l'on appelle le constructeur, on donne une valeur a chaque attributs

        public Article(long reference, string intitule, float prixHT, int quantiteEnStock)
        {
            Reference = reference; // les minuscules permettent d'attribuer une valeur à nos attributs
            Intitule = intitule;
            PrixHT = prixHT;
            QuantiteEnStock = quantiteEnStock;
        }

        // ICI on a définit la classe Article avec tous ses attributs et ses fonctions
        //ICI on passe au programme "général" pour utiliser la classe

        public void Approvisionnement (int quantiteAAjouter)
        {
            QuantiteEnStock += quantiteAAjouter;
        }
    }


}
