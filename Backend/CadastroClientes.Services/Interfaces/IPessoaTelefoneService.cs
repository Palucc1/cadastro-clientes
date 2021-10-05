using CadastroClientes.Domain.Entitites;
using System.Collections.Generic;

namespace CadastroClientes.Services.Interfaces
{
    public interface IPessoaTelefoneService : IBaseService<PessoaTelefone>
    {
        IList<PessoaTelefone> ListByPessoa(long id);
    }
}
