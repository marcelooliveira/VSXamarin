using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        SQLiteConnection conexao;

        private ObservableCollection<Agendamento> lista;

        public ObservableCollection<Agendamento> Lista
        {
            get
            {
                if (lista == null)
                {
                    lista = GetAll();
                }
                return lista;
            }
            private set
            {
                lista = value;
            }
        }

        public AgendamentoDAO(SQLiteConnection con)
        {
            conexao = con;
            conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            if (conexao.Find<Agendamento>(agendamento.ID) == null)
            {
                conexao.Insert(agendamento);
                Lista.Add(agendamento);
            }
            else
            {
                conexao.Update(agendamento);
            }
        }

        public ObservableCollection<Agendamento> GetAll()
        {
            return new ObservableCollection<Agendamento>(conexao.Table<Agendamento>());
        }
    }
}
