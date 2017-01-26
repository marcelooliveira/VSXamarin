using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        private readonly SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection con)
        {
            conexao = con;
            conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            conexao.Insert(agendamento);
        }
    }
}
