using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public DetalheViewModel ViewModel { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            this.ViewModel = new DetalheViewModel
            {
                Veiculo = veiculo
            };

            InitializeComponent();
            this.BindingContext = this.ViewModel;

            Messenger.Default.Register<ProximoMessage>(this,
                (msg) =>
                {
                    Navigation.PushAsync(new AgendamentoView(this.ViewModel.Veiculo));
                });
        }
    }
}


