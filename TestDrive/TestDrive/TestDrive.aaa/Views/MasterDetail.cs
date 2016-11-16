using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            Master = new MenuPage();
            Detail = new NavigationPage(new ListagemModelos());
        }
    }

}
