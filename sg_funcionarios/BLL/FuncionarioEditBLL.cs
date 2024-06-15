using sg_funcionarios.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.BLL
{
    static class FuncionarioEditBLL
    {
        public static void validarCampos(Funcionario funcionario)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(funcionario.getCodigo()))
            {
                Erro.setMsgErro("Código é de preenchimento obrigatório. ");
                return;
            }
            else
            {
                if (!int.TryParse(funcionario.getCodigo(), out int codigo))
                {
                    Erro.setMsgErro("Código precisa ser um valor numérico. ");
                    return;
                }
            }

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
                if (!long.TryParse(funcionario.getTelefone(), out long telefone))
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
                if (!float.TryParse(funcionario.getSalario(), out float salario))
                {
                    Erro.setMsgErro("Salário precisa ser um valor numérico. ");
                    return;
                }
            }

            FuncionarioEditDAL.editarFuncionario(funcionario);
        }
    }
}
