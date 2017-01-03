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
    public partial class AgendamentosUsuarioView : ContentPage
    {
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado",
                async (agendamentoSelecionado) =>
                {
                    var reenviar = await DisplayAlert("Reenviar", "Confirma o reenvio do agendamento?", "Sim", "Não");

                    if (reenviar)
                    {

                    }
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
        }
    }
}
