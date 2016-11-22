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

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Salvar Agendamento", "Nome: " + this.ViewModel.Nome, "Ok");
        }
    }
}
