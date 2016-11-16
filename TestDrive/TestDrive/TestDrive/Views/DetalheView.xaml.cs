using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public DetalheViewModel Veiculo { get; set; }

        public DetalheView(string modelo, decimal preco)
        {
            Veiculo = new DetalheViewModel
            {
                Modelo = modelo,
                Preco = preco,
                TemArCondicionado = false,
                TemFreioABS = false,
                TemMP3Player = false
            };

            InitializeComponent();

            this.BindingContext = Veiculo;

            Messenger.Default.Register<ProximoMessage>(this, 
                (msg) =>
                {
                    Navigation.PushAsync(new UsuarioView(Veiculo));
                });
        }
    }
}
