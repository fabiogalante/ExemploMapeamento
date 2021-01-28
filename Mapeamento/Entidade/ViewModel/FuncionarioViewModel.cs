using System.Collections.Generic;
using System.Linq;

namespace Mapeamento.Entidade.ViewModel
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public List<TelefoneViewModel> Telefone { get; set; }
        public string CPF { get; set; }
        public string Funcional { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }

        public static implicit operator FuncionarioViewModel(Funcionario obj)
        {

            return new FuncionarioViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                CPF = obj.CPF,
                Departamento = obj.Departamento,
                Endereco = obj.Endereco,
                Telefone = obj.Telefone.Select<Telefone,TelefoneViewModel>(_ => _).ToList(),
                Funcional = obj.Funcional,
                Salario = obj.Salario
            };
        }
    }

    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }

        public static implicit operator EnderecoViewModel(Endereco obj)
        {
            return new EnderecoViewModel
            {
                Logradouro = obj.Logradouro,
                Bairro = obj.Bairro,
                CEP = obj.CEP,
                Numero = obj.Numero
            };
        }
    }

    public class TelefoneViewModel
    {
        public int DDD { get; set; }
        public int Numero { get; set; }

        public static implicit operator TelefoneViewModel(Telefone item)
        {
            return new TelefoneViewModel
            {
                DDD = item.DDD,
                Numero = item.Numero
            };
        }
    }
}
