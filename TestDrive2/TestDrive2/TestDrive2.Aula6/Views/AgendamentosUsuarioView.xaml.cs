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
        AgendamentosUsuarioViewModel ViewModel;

        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            ViewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = ViewModel;
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
                        this.ViewModel.Aguarde = true;
                        var agendamentoService = new AgendamentoService();
                        agendamentoService.Post(agendamentoSelecionado);
                        this.ViewModel.Aguarde = false;
                    }
                });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "ok");
                    this.ViewModel.AtualizarLista();
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente mais tarde!", "ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}
