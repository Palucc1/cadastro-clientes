using CadastroClientes.Domain.Entitites;
using System.Collections.Generic;

namespace CadastroClientes.Repository.Repositories.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        public IList<Pessoa> GetByTelefones(string query);
    }
}
