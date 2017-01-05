﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async Task<HttpResponseMessage> DoLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.Usuario),
                        new KeyValuePair<string, string>("senha", login.Senha)
                    });
                var resultado = await cliente.PostAsync("/login", camposFormulario);

                return resultado;
            }
        }
    }
}
