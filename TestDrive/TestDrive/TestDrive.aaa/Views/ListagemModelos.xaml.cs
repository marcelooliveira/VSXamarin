using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemModelos : ContentPage
    {
        public string Descricao { get; set; }
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        public class Veiculo
        {
            public Veiculo()
            {

            }

            public Veiculo(string modelo, decimal preco)
            {
                this.Modelo = modelo;
                this.Preco = preco;
            }

            public string Modelo { get; set; }
            public decimal Preco { get; set; }
            public string PrecoFormatado
            {
                get
                {
                    return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Preco);
                }
            }
        }

        public ListagemModelos()
        {
            BindingContext = this;

            Descricao = "alguma Descricao";
            PopularVeiculos();

            InitializeComponent();
        }

        private void PopularVeiculos()
        {
            var lista = new List<Veiculo>();
            lista.Add(new Veiculo("Azera V6", preco: 85000));
            lista.Add(new Veiculo("Onix 1.6", preco: 35000));
            lista.Add(new Veiculo("Fiesta 2.0", preco: 52000));
            lista.Add(new Veiculo("C3 1.0", preco: 22000));
            lista.Add(new Veiculo("Uno Fire", preco: 11000));
            lista.Add(new Veiculo("Sentra 2.0", preco: 53000));
            lista.Add(new Veiculo("Astra Sedan", preco: 39000));
            lista.Add(new Veiculo("Vectra 2.0 Turbo", preco: 37000));
            lista.Add(new Veiculo("Hilux 4x4", preco: 90000));
            lista.Add(new Veiculo("Montana Cabine dupla", preco: 57000));
            lista.Add(new Veiculo("Outlander 2.4", preco: 99000));
            lista.Add(new Veiculo("Brasilia Amarela", preco: 9500));
            lista.Add(new Veiculo("Omega Hatch", preco: 8000));

            lista = lista.OrderBy(item => item.Modelo).ToList();

            Veiculos = new ObservableCollection<Veiculo>(lista);
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetalheModelo());
        }
    }

}
