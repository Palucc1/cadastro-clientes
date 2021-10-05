using CadastroClientes.Domain.Entitites;
using CadastroClientes.Repository.Repositories.Interfaces;
using CadastroClientes.Services.Interfaces;
using System.Collections.Generic;

namespace CadastroClientes.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _repository;
        public PessoaService(IPessoaRepository repository) : base(repository) => _repository = repository;

        public IList<Pessoa> GetByTelefones(string query) => _repository.GetByTelefones(query);
    }
}
