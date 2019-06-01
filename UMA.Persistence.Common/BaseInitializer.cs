using Microsoft.EntityFrameworkCore;
using System;

namespace UMA.Persistence.Identity
{
    public abstract class BaseInitializer<T> where T : DbContext
    {
        public static void Initialize(T context)
        {
            var initializer = Activator.CreateInstance(typeof(BaseInitializer<>)) as BaseInitializer<T>;
            initializer.SeedEverything(context);
        }

        private void SeedEverything(T context)
        {
            context.Database.EnsureCreated();

            if (HasEntries(context))
            {
                return;
            }

            SeedSets(context);
        }

        protected abstract bool HasEntries(T context);

        protected abstract void SeedSets(T context);
    }
}
