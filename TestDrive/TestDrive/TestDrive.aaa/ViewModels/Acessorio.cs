using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestDrive.ViewModels
{
    public class Acessorio : BaseViewModel
    {
        public Acessorio()
        {

        }

        public Acessorio(string descricao, decimal preco)
        {
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Acessorio(string descricao, decimal preco, bool selecionado)
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
                return string.Format(new CultureInfo("pt-BR"), "{0:C}", Preco);
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
                Preco += 10M;
            }
        }
    }
}
