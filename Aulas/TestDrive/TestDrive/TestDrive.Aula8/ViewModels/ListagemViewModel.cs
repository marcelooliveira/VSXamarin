using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; }

        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
        }
            
        public async Task GetVeiculos()
        {
            Aguarde = true;
            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync("https://aluracar.herokuapp.com/");
            var veiculos = JsonConvert.DeserializeObject<Veiculo[]>(resultado);

            foreach (var veiculo in veiculos)
            {
                this.Veiculos.Add(new Veiculo
                {
                   Nome = veiculo.Nome,
                   Preco = veiculo.Preco
                });
            }

            Aguarde = false;
        }

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
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        bool aguarde;
        public bool Aguarde
        {
            get
            {
                return aguarde;
            }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }
    }
}
