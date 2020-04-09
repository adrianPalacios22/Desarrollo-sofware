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
            MessageBoxResult resultado = MessageBox.Show("¿Desea Cerrar?", "Cerrar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes) {
                this.Close();
            }

        }

        private void btningresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidarCampos() == true)
                {
                    string rut = string.Format("{0}-{1}", txtrut_Copy.Text.Trim(), txtdvr.Text.Trim());
                    int telefono = 0;
                    if (NoExisteCliente(rut))
                    { 

                        Cliente cliente = new Cliente();
                        cliente.Rut = rut;
                        cliente.RazonSocial = txtrazon_social.Text.Trim();

                        bool esUnNumero = int.TryParse(txttelefono.Text, out telefono);
                        if (esUnNumero)
                        {
                            cliente.Telefono = telefono;
                        }
                        else
                        {
                            MessageBox.Show("El telefono debe ser de tipo numerico.", "Validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }

                        cliente.Direccion = txtdireccion.Text.Trim();
                        cliente.tipo = (tipoEmpresa)cmbtipo.SelectedItem;
                        cliente.actividad = (actividadEmpresa)cmbactividad.SelectedItem;

                        clientes.Add(cliente);
                        CargarGrilla();
                        LimpiarControles();
                    }

                }
                else {
                    MessageBox.Show("Debe Ingresar los datos Solicitados", "Validacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..\n" + ex.Message, "Excepcion", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarControles();
        }

        private void TxtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            string rut = txtrut_Copy.Text;
            Cliente cliente = clientes.FirstOrDefault(c => c.Rut.Split('-')[0] == rut);
            if (cliente != null)
            {
                txtrut_Copy.IsEnabled = false;
                txtdvr.IsEnabled = false;

                txtdvr.Text = cliente.Rut.Split('-')[1];
                txtrazon_social.Text = cliente.RazonSocial;
                txtdireccion.Text = cliente.Direccion;
                txttelefono.Text = cliente.Telefono.ToString();
                cmbtipo.SelectedItem = cliente.tipo;
                cmbactividad.SelectedItem = cliente.actividad;
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtrut_Copy.Text;
            Cliente cliente = clientes.FirstOrDefault(c => c.Rut.Split('-')[0] == rut);
            if (cliente != null)
            {
                cliente.RazonSocial = txtrazon_social.Text;
                cliente.Direccion = txtdireccion.Text;
                cliente.Telefono = int.Parse(txttelefono.Text);
                cliente.tipo = (tipoEmpresa)cmbtipo.SelectedItem;
                cliente.actividad = (actividadEmpresa)cmbactividad.SelectedItem;

                CargarGrilla();
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El cliente ingresado no existe.", "Validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtrut_Copy.Text;
            Cliente cliente = clientes.FirstOrDefault(c => c.Rut.Split('-')[0] == rut);
            if (cliente != null)
            {
                MessageBoxResult resultado = MessageBox.Show("¿Estas seguro que deseas eliminar?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultado == MessageBoxResult.Yes)
                {
                    clientes.Remove(cliente);
                    CargarGrilla();
                }

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El cliente ingresado no existe.", "Validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private bool NoExisteCliente(string rut)
        {
            //return clientes.FirstOrDefault(c => c.Rut == rut.Trim()) == null;
            bool noExiste = true;

            foreach (var cliente in clientes)
            {
                if (cliente.Rut == rut)
                {
                    noExiste = false;
                    break;
                }
            }

            return noExiste;
        }

        private bool ValidarCampos()
        {
            bool validar = true;

            if (txtrut_Copy.Text.Trim().Length == 0 && txtdvr.Text.Trim().Length == 0)
            {
                validar = false;
                txtrut_Copy.BorderBrush = Brushes.Red;
                txtdvr.BorderBrush = Brushes.Red;
            }
            else {
                txtrut_Copy.BorderBrush = Brushes.Gray;
                txtdvr.BorderBrush = Brushes.Gray;

            }

            if (txtdireccion.Text.Trim().Length == 0)
            {
                validar = false;
                txtdireccion.BorderBrush = Brushes.Red;
            }
            else
            {
                txtdireccion.BorderBrush = Brushes.Gray;

            }

            if (txtrazon_social.Text.Trim().Length == 0)
            {
                validar = false; 
                txtrazon_social.BorderBrush = Brushes.Red;
            }
            else
            {
                txtrazon_social.BorderBrush = Brushes.Gray;

            }

            if (txttelefono.Text.Trim().Length == 0)
            {
                validar = false;
                txttelefono.BorderBrush = Brushes.Red;
            }
            else
            {
                txttelefono.BorderBrush = Brushes.Gray;

            }

            if (cmbtipo.SelectedIndex == -1)
            {
                validar = false;
                cmbtipo.BorderBrush = Brushes.Red;

            }
            else
            {
                cmbtipo.BorderBrush = Brushes.Gray;

            }

            if (cmbactividad.SelectedIndex == -1)
            {
                validar = false;
                cmbactividad.BorderBrush = Brushes.Red;

            }
            else
            {
                cmbactividad.BorderBrush = Brushes.Gray;

            }
            return validar;
        }

        private void LimpiarControles()
        {
            txtdireccion.Text = string.Empty;
            txtrut_Copy.Text = string.Empty;
            txtdvr.Text = string.Empty;
            txttelefono.Text = string.Empty;
            txtrazon_social.Text = string.Empty;
            cmbtipo.SelectedIndex = -1;
            cmbactividad.SelectedIndex = -1;
        }
    }
}
