using CadastroClientes.Domain.Entitites;
using CadastroClientes.Repository.Context;
using CadastroClientes.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Repository.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly DbContextOptions<DataContext> _options;
        public PessoaRepository(DbContextOptions<DataContext> options) : base(options) => _options = options;

        public IList<Pessoa> GetByTelefones(string query)
        {
            using(var ctx = new DataContext(_options))
            {
                return ctx.Pessoas
                    .Where(x => x.Telefones.Count > 1)
                    .Include(x => x.Telefones)
                    .ToList();
            }
        }

        public override Pessoa GetById(long id)
        {
            using(var ctx = new DataContext(_options))
            {
                return ctx.Pessoas
                    .Include(x => x.Telefones)
                    .FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
