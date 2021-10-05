using CadastroClientes.Domain.Entitites;
using CadastroClientes.Repository.Repositories.Interfaces;
using CadastroClientes.Services.Interfaces;
using System.Collections.Generic;

namespace CadastroClientes.Services
{
    public class PessoaTelefoneService : BaseService<PessoaTelefone>, IPessoaTelefoneService
    {
        private readonly IPessoaTelefoneRepository _repository;
        public PessoaTelefoneService(IPessoaTelefoneRepository repository) : base(repository) => _repository = repository;

        public IList<PessoaTelefone> ListByPessoa(long id) => _repository.ListByPessoa(id);
    }
}
