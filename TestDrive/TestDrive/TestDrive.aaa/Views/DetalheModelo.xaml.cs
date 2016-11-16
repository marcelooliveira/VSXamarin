using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
    public abstract class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    var changed = PropertyChanged;
        //    if (changed != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Acessorio : BaseViewModel
    {
        public Acessorio()
        {

        }

        public Acessorio(string descricao, decimal preco) : base()
        {
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Acessorio(string descricao, decimal preco, bool selecionado) : base ()
        {
            this.Descricao = descricao;
            this.Preco = preco;
            this.Selecionado = false;
        }

        string descricao;
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
                OnPropertyChanged("Descricao");
            }
        }

        decimal preco;
        public decimal Preco
        {
            get
            {
                return preco;
            }
            set
            {
                preco = value;
                OnPropertyChanged("Preco");
                OnPropertyChanged("PrecoFormatado");
            }
        }

        public string PrecoFormatado
        {
            get
            {
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Preco);
            }
        }

        bool selecionado;
        public bool Selecionado
        {
            get
            {
                return selecionado;
            }
            set
            {
                selecionado = value;
                OnPropertyChanged("Selecionado");
                Messenger.Default.Send(new AcessorioChangedMessage());
                Preco += 10;
            }
        }
    }

    public class AcessorioChangedMessage { }

    public class DetalheVeiculo : BaseViewModel
    {
        public DetalheVeiculo()
        {
            Messenger.Default.Register<AcessorioChangedMessage>(this, (msg) =>
            {
                OnPropertyChanged("PrecoTotalFormatado");
            });
        }

        public DetalheVeiculo(string modelo, decimal preco) : base()
        {
            this.Modelo = modelo;
            this.Preco = preco;
            this.Acessorios = new ObservableCollection<Acessorio>();
        }

        string modelo;
        public string Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                modelo = value;
                OnPropertyChanged("Modelo");
            }
        }

        decimal preco;
        public decimal Preco
        {
            get
            {
                return preco;
            }
            set
            {
                preco = value;
                OnPropertyChanged("Preco");
                OnPropertyChanged("PrecoFormatado");
                OnPropertyChanged("PrecoTotal");
                OnPropertyChanged("PrecoTotalFormatado");
            }
        }

        public string PrecoFormatado
        {
            get
            {
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Preco);
            }
        }

        public decimal PrecoTotal
        {
            get
            {
                return Preco + Acessorios.Sum(a => a.Selecionado ? a.Preco : 0);
            }
        }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", PrecoTotal);
            }
        }

        public ObservableCollection<Acessorio> Acessorios { get; set; }
    }

    public partial class DetalheModelo : ContentPage
	{
        public DetalheVeiculo Veiculo { get; set; }

        public DetalheModelo ()
		{
            Veiculo = new DetalheVeiculo
            {
                Modelo = "Azera V6",
                Preco = 85000,
                Acessorios = new ObservableCollection<Acessorio>(new List<Acessorio>
                {
                    new Acessorio("Freio ABS", 800),
                    new Acessorio("Ar Condicionado", 1000),
                    new Acessorio("MP3 Layer", 500)
                })
            };

            this.BindingContext = Veiculo;

            InitializeComponent();
		}
    }
}
