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
    class AgendamentosUsuarioViewModel
    {
        public ObservableCollection<Agendamento> Lista { get; private set; }

        public AgendamentosUsuarioViewModel()
        {
            Lista = new ObservableCollection<Agendamento>();

            using (SQLiteConnection con = DependencyService.Get<ISQLite>().PegarConexao())
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
