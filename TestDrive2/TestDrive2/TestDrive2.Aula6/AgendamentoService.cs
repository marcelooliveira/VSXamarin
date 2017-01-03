using AluraNutricao.Data;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class AgendamentoService
    {
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

        public async void Post(Agendamento agendamento)
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                agendamento.DataAgendamento.Year, agendamento.DataAgendamento.Month, agendamento.DataAgendamento.Day,
                agendamento.HoraAgendamento.Hours, agendamento.HoraAgendamento.Minutes, agendamento.HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = agendamento.Nome,
                fone = agendamento.Fone,
                email = agendamento.Email,
                carro = agendamento.Modelo,
                preco = agendamento.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);
            agendamento.Confirmado = resposta.IsSuccessStatusCode;

            SalvarAgendamento(resposta, agendamento);

            if (agendamento.Confirmado)
                MessagingCenter.Send<Agendamento>(agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
        }

        private void SalvarAgendamento(HttpResponseMessage resposta, Agendamento agendamento)
        {
            using (SQLiteConnection con = DependencyService.Get<ISQLite>().GetConnection())
            {
                AgendamentoDAO dao = new AgendamentoDAO(con);
                dao.Salvar(agendamento);
            }
        }
    }
}
