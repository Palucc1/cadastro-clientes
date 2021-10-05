using CadastroClientes.Domain.Entitites;
using CadastroClientes.Repository.Context;
using CadastroClientes.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Repository.Repositories
{
    public class PessoaTelefoneRepository : BaseRepository<PessoaTelefone>, IPessoaTelefoneRepository
    {
        private readonly DbContextOptions<DataContext> _options;
        public PessoaTelefoneRepository(DbContextOptions<DataContext> options) : base(options) => _options = options;

        public IList<PessoaTelefone> ListByPessoa(long id)
        {
            using(var ctx = new DataContext(_options))
            {
                return ctx.PessoaTelefones
                    .Where(x => x.PessoaId == id)
                    .ToList();
            }
        }
    }
}
