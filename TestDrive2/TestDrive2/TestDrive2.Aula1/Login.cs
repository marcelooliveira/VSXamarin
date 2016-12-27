using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrive
{
    public class Login
    {
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        public Login(string usuario, string senha)
        {
            if (string.IsNullOrEmpty(usuario))
                throw new ArgumentException(nameof(usuario));

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException(nameof(senha));

            this.Usuario = usuario;
            this.Senha = senha;
        }
    }
}
