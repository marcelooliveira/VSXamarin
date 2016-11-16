using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using TestDrive.HttpClient;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        private const string URL_GET_MODELOS = @"https://aluracar.herokuapp.com";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                OnPropertyChanged();
                if (veiculoSelecionado != null)
                    Messenger.Default.Send(new VeiculoSelecionadoMessage(veiculoSelecionado.Modelo, veiculoSelecionado.Preco));
            }
        }

        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
            IsRunning = true;

            HttpClient<ResponseObject> client = new HttpClient<ResponseObject>();
            client.RequestCompleted +=
                (s, e) =>
                {
                    PopularVeiculos(e.ResponseObjects);
                    IsRunning = false;
                };

            client.Request(RequestMethod.Get, URL_GET_MODELOS);
        }

        private void PopularVeiculos(ResponseObject[] responseObjects)
        {
            var lista = new List<Veiculo>();
            foreach (var responseObject in responseObjects)
            {
                lista.Add(new Veiculo(responseObject.nome, preco: responseObject.preco));
            }

            lista = lista.OrderBy(item => item.Modelo).ToList();

            foreach (var item in lista)
            {
                Veiculos.Add(new Veiculo(item.Modelo, item.Preco));
            }
        }
    }


    public class Veiculo
    {
        public Veiculo()
        {

        }
        public Veiculo(string modelo, decimal preco)
        {
            this.Modelo = modelo;
            this.Preco = preco;
        }

        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get
            {
                return string.Format("R$ {0}", Preco);
            }
        }

        public FormattedString ItemListagemLabel
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                        new Span { Text = Modelo },
                        new Span { Text = " - " },
                        new Span { Text = PrecoFormatado, FontAttributes = FontAttributes.Bold } }
                };
            }
            set { }
        }
    }

    public class VeiculoSelecionadoMessage
    {
        public VeiculoSelecionadoMessage(string modelo, decimal preco)
        {
            this.Modelo = modelo;
            this.Preco = preco;
        }

        public string Modelo { get; set; }
        public decimal Preco { get; set; }
    }
}


