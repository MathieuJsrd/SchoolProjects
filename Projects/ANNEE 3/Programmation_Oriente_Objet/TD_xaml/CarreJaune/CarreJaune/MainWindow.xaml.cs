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

namespace CarreJaune
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
        void ClickBouger(object sender, RoutedEventArgs e)
        {
            //Le carré rouge doit toujours etre dans le rectangle jaune
            //Donc Le milieu du rouge doit toujours etre éloigné de 40 en haut et en bas
            //Sachant que le rectangle jaune fait 420x330 (en prenant en compte les deux marges de 10 sur 350 de largeur)
            //Le terrain disponible pour le rouge est donc : (en terme de coordonnées)
            //Canvas.Left compris entre 0 et 380
            //Canvas.Top compris entre 0 et 259
            
            //Il nous faut donc deux valeurs tirer au hasard
            Random valeurLeft = new Random();
            valeurLeft.Next(0, 380);
            Random valeurTop = new Random();
            valeurTop.Next(0, 259);

            
        }
    }
}
