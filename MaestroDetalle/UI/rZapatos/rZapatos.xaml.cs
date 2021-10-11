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

namespace MaestroDetalle.UI.rZapatos
{
    /// <summary>
    /// Interaction logic for rZapatos.xaml
    /// </summary>
    public partial class rZapatos : Window
    {
        private Zapatos Zapato;
        public rZapatos()
        {
            InitializeComponent();
            Zapato = new Zapatos();
            this.DataContext = Zapato;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = ZapatosBLL.Buscar(Zapato.ZapatoId);
            if(registro != null)
            {
                Zapato = registro;
                this.DataContext = Zapato;
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
            if (ZapatosBLL.Guardar(Zapato))
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
            if (ZapatosBLL.Eliminar(Zapato.ZapatoId))
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
            Zapato = new Zapatos();
            this.DataContext = Zapato;
        }
    }
}
