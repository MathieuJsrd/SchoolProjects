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

namespace Exercice2TD8
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
        public void ClickBoutonHaut(object sender, RoutedEventArgs e)
        {
            if(TextDeGauche.Text != "")
            {
                TextDeDroite.Text = TextDeGauche.Text;
                TextDeGauche.Text = null;
            }
            else
            {
                //Envoie de la nouvelle fenetre "Message erreur"
                MessageBox.Show("Erreur il n'y a pas de message entré");
            }

        }
        public void ClickBoutonBas(object sender, RoutedEventArgs e)
        {
            if(TextDeDroite.Text != "")
            {
                TextDeGauche.Text = TextDeDroite.Text;
                TextDeDroite.Text = null;
            }
            else
            {
                //Envoie de la nouvelle fenetre "Message erreur"
                MessageBox.Show("Erreur il n'y a pas de message entré");
            }
        }
    }
}
