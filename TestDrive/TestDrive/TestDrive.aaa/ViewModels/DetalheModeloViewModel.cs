using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TestDrive.ViewModels
{
    public class DetalheModeloViewModel : BaseViewModel
    {
        public DetalheModeloViewModel()
        {
        }

        public DetalheModeloViewModel(string modelo, decimal preco)
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
                return string.Format(new CultureInfo("pt-BR"), "{0:C}", Preco);
            }
        }
        public decimal PrecoTotal
        {
            get
            {
                return Preco + Acessorios.Sum(a => a.Preco);
            }
        }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format(new CultureInfo("pt-BR"), "{0:C}", Preco);
            }
        }

        public ObservableCollection<Acessorio> Acessorios { get; set; }
    }
}
