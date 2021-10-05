using CadastroClientes.Domain.Interfaces;

namespace CadastroClientes.Domain.Entitites
{
    public class PessoaTelefone : IBaseEntity
    {
        #region Properties
        public long Id { get; set; }
        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public long NumeroTelefone { get; set; }
        #endregion

        #region Constructors
        public PessoaTelefone(long numeroTelefone)
        {
            NumeroTelefone = numeroTelefone;
        }
        #endregion
    }
}
