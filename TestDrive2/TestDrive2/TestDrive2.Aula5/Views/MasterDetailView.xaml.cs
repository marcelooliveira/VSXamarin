﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();

            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));
        }
    }
}