using CadastroClientes.Application.Interfaces;
using CadastroClientes.Domain.Interfaces;
using CadastroClientes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Application
{
    public class BaseApplication<T> : IBaseApplication<T> where T : class, IBaseEntity
    {
        private readonly IBaseService<T> _service;
        public BaseApplication(IBaseService<T> service) => _service = service;

        public virtual void AddOrUpdate(T obj)
        {
            try
            {
                if (obj.Id == 0)
                    _service.Add(obj);
                else
                    _service.Update(obj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> GetAll(string query) => _service.GetAll(query);

        public virtual T GetById(long id) => _service.GetById(id);

        public virtual void Remove(long id)
        {
            var obj = GetById(id);

            if (obj == null)
                throw new Exception("Esse registro não existe");

            _service.Remove(obj);
        }
    }
}
