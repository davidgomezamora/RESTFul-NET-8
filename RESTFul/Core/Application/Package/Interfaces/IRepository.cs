﻿using Ardalis.Specification;

namespace Core.Application.Package.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
        TId? GetKeyValue<TId>(T entity);
        string? GetKeyName();
    }
}
