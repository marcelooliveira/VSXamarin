using System;
using Xamarin.Forms;

namespace TestDrive.Views
{
    class MasterDetailPageDemoPage :  MasterDetailPage
	{
		public MasterDetailPageDemoPage (Usuario usuario)
		{
			Label header = new Label {
				Text = "MasterDetailPage",
				FontSize = 30,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};

			this.Master = new ContentPage {
				Title = "Dados do Usuário",
				Content = 
                    new Frame
                    {
                        OutlineColor = Color.Silver,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.Center,
                        Content =
                        new StackLayout
                        {
                            Children = {
                                new Label { Text = usuario.nome, FontSize = 18, HorizontalTextAlignment = TextAlignment.Center },
                                new Label { Text = usuario.email, FontSize = 18, HorizontalTextAlignment = TextAlignment.Center }
                            }
                        }
                    }
            };

            // Create the detail page using NamedColorPage
            var detailPage = new NavigationPage(new ListagemView());
            this.Detail = detailPage;
		}
	}
}
