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
    public partial class UsuarioView : ContentPage
    {
        public UsuarioView(DetalheViewModel veiculo)
        {
            InitializeComponent();
            this.BindingContext = new UsuarioViewModel(veiculo);

            Messenger.Default.Register<FinalizarMessage>(this, (msg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Sucesso!", "Agendamento do test drive feito com sucesso!", "Ok");
                });
            });

            Messenger.Default.Register<ErroFinalizarMessage>(this, (msg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao finalizar o agendamento", "Ok");
                });
            });
        }
    }
}
