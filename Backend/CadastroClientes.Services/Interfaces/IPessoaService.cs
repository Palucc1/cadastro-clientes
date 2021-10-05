using CadastroClientes.Domain.Entitites;
using System.Collections.Generic;

namespace CadastroClientes.Services.Interfaces
{
    public interface IPessoaService : IBaseService<Pessoa>
    {
        public IList<Pessoa> GetByTelefones(string query);
    }
}
