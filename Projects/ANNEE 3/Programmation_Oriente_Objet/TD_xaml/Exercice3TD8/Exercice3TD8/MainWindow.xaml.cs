using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercice3TD8
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) //Si on obtient "la touche de clavier associé à l'élément (ici e.Key) et ici .Return fait allusion à la touche entrée
            {
                //textBlock1.Text = "You Entered: " + textBox1.Text
                txtNom.Text = "Bonjour " + zoneEntree.Text; //Le résultat est contenu dans "la zone de texte bloquée" qui prend en paramètre "la zone de texte d'entrée" par l'utilisateur
            }
        }
    }
}
