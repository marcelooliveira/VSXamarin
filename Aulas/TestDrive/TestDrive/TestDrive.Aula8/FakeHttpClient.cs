using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrive
{
    public class HttpClient
    {
        public Task<System.Net.Http.HttpResponseMessage> PostAsync(string requestUri, System.Net.Http.HttpContent content)
        {
            var str = content.ReadAsStringAsync().Result;
            var agendamento = JsonConvert.DeserializeObject<JsonAgendamento>(str);
            
            if (string.IsNullOrEmpty(agendamento.nome))
                return Task.FromResult<System.Net.Http.HttpResponseMessage>(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = content
                });
            else
                return Task.FromResult<System.Net.Http.HttpResponseMessage>(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = content
                });
        }
    }

    public class JsonAgendamento
    {
        public string carro { get; set; }
        public string email { get; set; }
        public string fone { get; set; }
        public string nome { get; set; }
        public string preco { get; set; }
        public string dataAgendamento { get; set; }
    }
}
