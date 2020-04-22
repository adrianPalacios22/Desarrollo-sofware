using OnBreaker.Biblioteca;
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
    /// Lógica de interacción para ListadoCliente.xaml
    /// </summary>
    public partial class ListadoCliente : Window
    {
        private List<Cliente> clientes;
        public ListadoCliente()
        {
            clientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            InitializeComponent();
            cmbTipoEmpresa.ItemsSource = Enum.GetValues(typeof(tipoEmpresa));
            cmbActividad.ItemsSource = Enum.GetValues(typeof(actividadEmpresa));

            string rut = string.Format("{0}-{1}", 26368820, 1);
            cliente.Rut = rut;
            cliente.RazonSocial = "Adrian Palacios";
            cliente.Telefono = 949178756;
            cliente.Direccion = "Carmen 616";


            clientes.Add(cliente);
            CargarGrilla();

        }

        private void CargarGrilla()
        {
            dgClientes.ItemsSource = clientes;
            dgClientes.Items.Refresh();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Desea Cerrar?", "Cerrar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = TxtRut.Text;
            Cliente cliente = clientes.FirstOrDefault(c => c.Rut.Split('-')[0] == rut);
            if (cliente != null)
            {
             
            }
            else
            {
                MessageBox.Show("No existen datos de busqueda", "Validacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
