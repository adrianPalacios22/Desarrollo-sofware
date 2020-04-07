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
using OnBreaker.Biblioteca;

namespace Wpf2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clientes;
        public MainWindow()
        {
            clientes = new List<Cliente>();
            InitializeComponent();
            cmbtipo.ItemsSource = Enum.GetValues(typeof(tipoEmpresa));
            cmbactividad.ItemsSource = Enum.GetValues(typeof(actividadEmpresa));

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

        private void btncerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Desea Cerrar?","Cerrar",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes) {
                this.Close();
            }
            
        }

        private void btningresar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Rut = string.Format("{0}-{1}",txtrut_Copy.Text.Trim(),txtdvr.Text.Trim());
            cliente.RazonSocial = txtrazon_social.Text.Trim();
            cliente.Telefono = int.Parse(txttelefono.Text);
            cliente.Direccion = txtdireccion.Text.Trim();
            cliente.tipo = (tipoEmpresa)cmbtipo.SelectedItem;
            cliente.actividad = (actividadEmpresa)cmbactividad.SelectedItem;

            clientes.Add(cliente);

            CargarGrilla();



        }
    }
}
