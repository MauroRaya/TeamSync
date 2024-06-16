using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    static class CadastroBLL
    {
        public static void validarCampos(Usuario usuario, String senha, String confSenha)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(usuario.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }
            if (usuario.getNome().Length > 15)
            {
                Erro.setMsgErro("Nome de usuário não pode ultrapassar 15 caracteres. ");
                return;
            }

            if (String.IsNullOrEmpty(senha))
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }
            if (senha.Length > 15)
            {
                Erro.setMsgErro("Senha não pode ultrapassar 15 caracteres. ");
                return;
            }

            if (senha != confSenha)
            {
                Erro.setMsgErro("Senhas precisam ter o mesmo valor. ");
                return;
            }

            byte[] salt = gerarSalt();
            byte[] hash = gerarHash(senha, salt);

            string saltBase64 = Convert.ToBase64String(salt);
            string hashBase64 = Convert.ToBase64String(hash);

            usuario.setSalt(saltBase64);
            usuario.setHash(hashBase64);

            CadastroDAL.criarUsuario(usuario);
        }

        public static byte[] gerarSalt(int tamanho = 16)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[tamanho];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static byte[] gerarHash(String senha, byte[] salt, int iterations = 10000, int hashByteSize = 20)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, iterations))
            {
                return pbkdf2.GetBytes(hashByteSize);
            }
        }
    }
}
