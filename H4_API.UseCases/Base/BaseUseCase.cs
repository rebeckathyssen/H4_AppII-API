using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using H4_API.Application.Base;
using H4_API.Core;

namespace H4_API.UseCases.Base
{
    public class BaseUseCase<TValue, TService> : IBaseUseCase<TValue> where TValue : class, IEntity, new() where TService : IBaseService<TValue>
    {
        private readonly TService service;
        private readonly IUnitOfWork unitOfWork;

        public BaseUseCase(TService service, IUnitOfWork unitOfWork)
        {
            this.service = service;
            this.unitOfWork = unitOfWork;
        }

        public virtual async Task<TValue> Get(Guid id)
        {
            return await service.Get(id);
        }

        public virtual async Task<IEnumerable<TValue>> List()
        {
            return await service.List();
        }

        public virtual TValue Create()
        {
            return new TValue();
        }

        public virtual async Task<TValue> Post(TValue value)
        {
            var ret = await service.Create(value);
            await unitOfWork.Commit();

            return ret;
        }

        public virtual async Task<TValue> Create(TValue value)
        {
            var ret = await service.Create(value);
            await unitOfWork.Commit();
            return ret;
        }

        public virtual async Task<TValue> Update(TValue value)
        {
            var ret = service.Update(value);
            await unitOfWork.Commit();

            return ret;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var ret = await service.Delete(id);
            await unitOfWork.Commit();

            return ret;
        }

    }
}