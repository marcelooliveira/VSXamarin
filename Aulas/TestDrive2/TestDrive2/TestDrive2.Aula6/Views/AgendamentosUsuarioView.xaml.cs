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
            this.BindingContext = new AgendamentosUsuarioViewModel();
        }
    }
}
