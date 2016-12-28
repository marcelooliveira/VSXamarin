using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class MasterView : TabbedPage
    {
        public MasterViewModel ViewModel { get; private set; }

        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario"
                ,(msg) =>
                {
                    this.CurrentPage = this.Children[0];
                });

            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil"
                , (msg) =>
                {
                    this.CurrentPage = this.Children[1];
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarUsuario");
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}
