using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive
{
    public partial class DetalheModelo : ContentPage
	{
        public DetalheModeloViewModel Veiculo { get; set; }

        public DetalheModelo ()
		{
            Veiculo = new DetalheModeloViewModel
            {
                Modelo = "Azera V6",
                Preco = 85000,
                Acessorios = new ObservableCollection<Acessorio>(new List<Acessorio>
                {
                    new Acessorio("Freio ABS", 800),
                    new Acessorio("Ar Condicionado", 1000, true),
                    new Acessorio("MP3 Layer", 500)
                })
            };

            InitializeComponent();

            this.BindingContext = Veiculo;
        }
    }
}
