using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    static class LoginBLL
    {
        public static void validarCampos(Usuario usuario, String senha)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(usuario.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }
            if (usuario.getNome().Length > 15)
            {
                Erro.setMsgErro("Nome de usuario não pode ultrapassar 15 caracteres. ");
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
        }

        public static int getCodigoUsuario(Usuario usuario)
        {
            return LoginDAL.getCodigoUsuario(usuario);
        }

        public static void validarSenha(String senha) //usando hash e salt
        {
            byte[] salt = Convert.FromBase64String(getSalt());
            byte[] hash = gerarHash(senha, salt);

            String hashBase64 = Convert.ToBase64String(hash);
            String hashDB = getHash();

            if (hashBase64 != hashDB)
            {
                Erro.setMsgErro("Senha está incorreta. ");
                return;
            }
        }

        public static String getSalt()
        {
            return LoginDAL.getSalt();
        }

        public static byte[] gerarHash(String senha, byte[] salt, int iterations = 10000, int hashByteSize = 20)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, iterations))
            {
                return pbkdf2.GetBytes(hashByteSize);
            }
        }

        public static String getHash()
        {
            return LoginDAL.getHash();
        }
    }
}
