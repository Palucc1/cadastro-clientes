using CadastroClientes.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Domain.Entitites
{
    public class Pessoa : IBaseEntity
    {
        #region Properties
        private string _nome;

        public long Id { get; set; }
        public string Nome { get => _nome; set => SetNome(value); }
        public DateTime DataNascimento { get; set; }
        public IList<PessoaTelefone> Telefones { get; set; }
        #endregion

        #region Constructors
        public Pessoa(string nome)
        {
            Nome = nome;
        }
        #endregion

        #region Methods
        private void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("O nome deve ser preenchido corretamente");

            _nome = nome;
        }
        #endregion
    }
}
