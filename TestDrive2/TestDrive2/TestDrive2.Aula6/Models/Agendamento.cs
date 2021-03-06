﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrive.Models
{
    public class Agendamento
    {
        public Agendamento()
        {

        }

        public Agendamento(Veiculo veiculo, Usuario usuario)
        {
            this.Nome = usuario.nome;
            this.Fone = usuario.telefone;
            this.Email = usuario.email;
            this.Modelo = veiculo.Nome;
            this.Preco = veiculo.Preco;
        }

        public Agendamento(string nome, string fone, string email, 
            string modelo, decimal preco, bool confirmado)
        {
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
            this.Confirmado = confirmado;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public bool Confirmado { get; set; }

        [Ignore]
        public bool MostrarReenviar { get; set; }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento { get; set; }

        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
    }
}
