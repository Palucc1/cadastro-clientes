using CadastroClientes.Domain.Entitites;
using System.Collections.Generic;

namespace CadastroClientes.Repository.Repositories.Interfaces
{
    public interface IPessoaTelefoneRepository: IBaseRepository<PessoaTelefone>
    {
        public IList<PessoaTelefone> ListByPessoa(long id);
    }
}
