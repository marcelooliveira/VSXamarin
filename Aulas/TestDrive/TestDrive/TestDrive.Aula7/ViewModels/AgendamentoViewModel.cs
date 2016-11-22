using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
    }
}
