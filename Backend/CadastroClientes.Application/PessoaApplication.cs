using CadastroClientes.Application.Interfaces;
using CadastroClientes.Domain.Entitites;
using CadastroClientes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace CadastroClientes.Application
{
    public class PessoaApplication : BaseApplication<Pessoa>, IPessoaApplication
    {
        private readonly IPessoaService _service;
        private readonly IPessoaTelefoneService _telefoneService;
        public PessoaApplication(IPessoaService service, IPessoaTelefoneService telefoneService) : base(service)
        {
            _service = service;
            _telefoneService = telefoneService;
        }

        public override void AddOrUpdate(Pessoa pessoa)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    if (pessoa.Id != 0)
                    {
                        var telefones = pessoa.Telefones;
                        pessoa.Telefones = null;

                        if (telefones.Count == 0)
                            throw new Exception("Ao menos um item deve ser adicionado.");

                        _service.Update(pessoa);

                        // Tratativa para adicionar novos telefones ou atualizar telefones já cadastrados.
                        foreach (var telefone in telefones)
                        {
                            telefone.PessoaId = pessoa.Id;

                            telefone.Pessoa = null;

                            if (telefone.Id == 0)
                                _telefoneService.Add(telefone);
                            else
                                _telefoneService.Update(telefone);
                        }

                        // Tratativa para remover telefones
                        var telefonesDb = _telefoneService.ListByPessoa(pessoa.Id);
                        var telefonesRemover = telefonesDb.Where(x => !telefones.Select(y => y.Id).Contains(x.Id)).ToList();

                        foreach (var telefone in telefonesRemover)
                        {
                            telefone.Pessoa = null;
                            _telefoneService.Remove(telefone);
                        }
                    }
                    else
                    {
                        var telefones = pessoa.Telefones;
                        pessoa.Telefones = null;

                        if (telefones.Count == 0)
                            throw new Exception("Ao menos um telefone para contato deve ser cadastrado.");

                        _service.Add(pessoa);

                        if (telefones.Count > 0)
                        {
                            foreach (var telefone in telefones)
                            {
                                telefone.Pessoa = null;
                                telefone.PessoaId = pessoa.Id;

                                _telefoneService.Add(telefone);
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            catch
            {
                throw new Exception("Não foi possível salvar o usuário.");
            }
        }

        public IList<Pessoa> GetByTelefones(string query) => _service.GetByTelefones(query);
    }
}
