using CadastroClientes.Domain.Entitites;
using System.Collections.Generic;

namespace CadastroClientes.Application.Interfaces
{
    public interface IPessoaApplication : IBaseApplication<Pessoa>
    {
        public IList<Pessoa> GetByTelefones(string query);
    }
}
