using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class AgendamentosUsuarioViewModel : BaseViewModel 
    {
        public ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionado;
        public Agendamento AgendamentoSelecionado
        {
            get { return agendamentoSelecionado; }
            set
            {
                agendamentoSelecionado = value;

                if (agendamentoSelecionado?.Confirmado == false)
                {
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionado, "AgendamentoSelecionado");
                }

                OnPropertyChanged(nameof(AgendamentoSelecionado));
            }
        }

        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            Lista.Clear();
            using (SQLiteConnection con = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(con);
                var query = dao
                    .Lista
                    .OrderBy(a => a.DataAgendamento)
                    .ThenBy(a => a.HoraAgendamento);

                foreach (var agendamento in dao.Lista)
                {
                    Lista.Add(agendamento);
                }
            }
        }
    }
}
