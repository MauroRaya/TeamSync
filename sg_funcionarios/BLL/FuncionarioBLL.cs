using sg_funcionarios.DAL;
using sg_funcionarios.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.BLL
{
    static class FuncionarioBLL
    {
        public static void validarCampos(FuncionarioVM funcionario)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(funcionario.getNome()))
            {
                Erro.setMsgErro("Nome é de preenchimento obrigatório. ");
                return;
            }

            if (String.IsNullOrEmpty(funcionario.getTelefone()))
            {
                Erro.setMsgErro("Telefone é de preenchimento obrigatório. ");
                return;
            }
            else
            {
                try
                {
                    long.TryParse(funcionario.getTelefone(), out long telefone);
                }
                catch
                {
                    Erro.setMsgErro("Telefone precisa ser um valor numérico. ");
                    return;
                }
            }

            if (String.IsNullOrEmpty(funcionario.getCargo()))
            {
                Erro.setMsgErro("Cargo é de preenchimento obrigatório. ");
                return;
            }

            if (String.IsNullOrEmpty(funcionario.getSalario()))
            {
                Erro.setMsgErro("Salario é de preenchimento obrigatório. ");
                return;
            }
            else
            {
                try
                {
                    float.TryParse(funcionario.getSalario(), out float salario);
                }
                catch
                {
                    Erro.setMsgErro("Salário precisa ser um valor numérico. ");
                    return;
                }
            }

            FuncionarioDAL.criarFuncionario(funcionario);
        }

        public static List<FuncionarioVM> getFuncionarios()
        {
            return FuncionarioDAL.getFuncionarios();
        }
    }
}
