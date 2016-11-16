using GalaSoft.MvvmLight.Messaging;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        ListagemViewModel viewModel;

        public ListagemView()
        {
            viewModel = new ListagemViewModel();
            BindingContext = viewModel;

            InitializeComponent();

            Messenger.Default.Register<VeiculoSelecionadoMessage>(this, (msg) =>
            {
                Navigation.PushAsync(new DetalheView(msg.Modelo, msg.Preco));
            });
        }
    }
}
