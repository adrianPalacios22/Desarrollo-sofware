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
using System.Windows.Shapes;

namespace Wpf2._0
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnAdministracion_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ListadoClientes = new MainWindow();
            ListadoClientes.Owner = this;
            ListadoClientes.ShowDialog();
        }
    }
}
