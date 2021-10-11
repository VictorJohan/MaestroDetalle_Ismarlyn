using MaestroDetalle.BLL;
using MaestroDetalle.Modelos;
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

namespace MaestroDetalle.UI.rArmario
{
    /// <summary>
    /// Interaction logic for rArmario.xaml
    /// </summary>
    public partial class rArmario : Window
    {
        private Armarios Armario;
        private Zapatos Zapatos;
        public rArmario()
        {
            InitializeComponent();
            Armario = new Armarios();
            this.DataContext = Armario;
            //Llenamos el combobox
            ZapatoIdComboBox.ItemsSource = ZapatosBLL.GetList(X => true);
            ZapatoIdComboBox.SelectedValue = "ZapatoId";
            ZapatoIdComboBox.DisplayMemberPath = "Marca";
        }

        private void BuscarButto_Click(object sender, RoutedEventArgs e)
        {
            var registro = ArmariosBLL.Buscar(Armario.ArmarioId);
            if (registro != null)
            {
                Armario = registro;
                this.DataContext = Armario;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArmariosBLL.Guardar(Armario))
            {
                MessageBox.Show("Guardado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArmariosBLL.Eliminar(Armario.ArmarioId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Limpiar()
        {
            Armario = new Armarios();
            this.DataContext = Armario;
        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ArmarioDetalle
            {
                Zapato = Zapatos,
                ArmarioId = Armario.ArmarioId
            };

            Armario.ArmarioDetalle.Add(detalle);
            Cargar();
            ZapatoIdComboBox.SelectedIndex = -1;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.SelectedIndex != -1)
            {
                Armario.ArmarioDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Armario;
        }

        private void ZapatoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ZapatoIdComboBox.SelectedIndex != -1)
            {
                Zapatos = (Zapatos)ZapatoIdComboBox.SelectedItem;
                Zapatos.ZapatoId = 0;
            }
        }
    }
}
