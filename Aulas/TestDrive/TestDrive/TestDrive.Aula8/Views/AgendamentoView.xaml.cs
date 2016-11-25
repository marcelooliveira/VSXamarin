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
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            this.ViewModel = new AgendamentoViewModel
            {
                 Veiculo = veiculo
            };

            InitializeComponent();
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            Messenger.Default.Register<AgendamentoMessage>(this, async (msg) =>
            {
                var resposta = await DisplayAlert("Salvar Agendamento",
                    "Deseja mesmo salvar o agendamento?", "Sim", "Não");
                if (resposta)
                    this.ViewModel.SalvarAgendamento();
            });
            base.OnAppearing(); 
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Messenger.Default.Unregister(this);
        }
    }
}