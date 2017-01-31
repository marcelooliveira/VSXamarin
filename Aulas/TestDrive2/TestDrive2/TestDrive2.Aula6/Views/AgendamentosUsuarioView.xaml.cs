using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class AgendamentosUsuarioView : ContentPage
    {
        readonly AgendamentosUsuarioViewModel viewModel;
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this.viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this.viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinaturas();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado",
                async (agendamentoSelecionado) =>
                {
                    var reenviar = await DisplayAlert("Reenviar", "Confirma o reenvio do agendamento?", "Sim", "Não");

                    if (reenviar)
                    {
                        //this.viewModel.Aguarde = true;
                        var agendamentoService = new AgendamentoService();
                        agendamentoService.Post(agendamentoSelecionado);
                        //this.viewModel.Aguarde = false;
                    }
                });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
            (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "ok");
                this.viewModel.AtualizarLista();
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
            (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente mais tarde!", "ok");
            });
        }

        private void CancelarAssinaturas()
        {
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}
