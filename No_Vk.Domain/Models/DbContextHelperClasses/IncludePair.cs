using System;
using System.Linq.Expressions;

namespace No_Vk.Domain.Models.DbContextHelperClasses
{
    public struct IncludePair<T>
    {
        public Expression<Func<T, object>> Include { get; }
        public Expression<Func<T, object>> ThenInclude { get; }

        public IncludePair(Expression<Func<T, object>> include, Expression<Func<T, object>> thenInclude = null)
        {
            Include = include;
            ThenInclude = thenInclude;
        }
    }
}