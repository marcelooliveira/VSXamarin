using AluraNutricao.Data;
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
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        public ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                OnPropertyChanged(nameof(Lista));
            }
        }

        private bool mostrarReenviar;
        public bool MostrarReenviar
        {
            get { return mostrarReenviar; }
            set
            {
                mostrarReenviar = value;
                OnPropertyChanged(nameof(MostrarReenviar));
            }
        }

        private Agendamento agendamentoSelecionado;
        public Agendamento AgendamentoSelecionado
        {
            get { return  agendamentoSelecionado; }
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

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            Lista.Clear();
            using (SQLiteConnection con = DependencyService.Get<ISQLite>().GetConnection())
            {
                AgendamentoDAO dao = new AgendamentoDAO(con);
                foreach (var agendamento in dao.Lista)
                {
                    Lista.Add(agendamento);
                }
            }
        }
    }
}
