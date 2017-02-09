using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsBetting.Data.Repositories;
using SportsBetting.Models;

namespace SportsBetting.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private SportsBettingContext context;
        private readonly IDictionary<Type, object> repositories;
        private GenericRepository<Bet> betRepository;
        private GenericRepository<Match> matchRepository;
        private GenericRepository<Odd> oddRepository;
        private GenericRepository<Sport> sportRepository;
        private GenericRepository<SportEvent> sportEventRepository;
        private bool disposed = false;

        public GenericRepository<Bet> BetRepository
        {
            get
            {
                if (this.betRepository == null)
                {
                    this.betRepository = new GenericRepository<Bet>(context);
                }
                return betRepository;
            }
        }

        public GenericRepository<Match> MatchRepository
        {
            get
            {
                if (this.matchRepository == null)
                {
                    this.matchRepository = new GenericRepository<Match>(context);
                }
                return matchRepository;
            }
        }

        public GenericRepository<Odd> OddRepository
        {
            get
            {
                if (this.oddRepository == null)
                {
                    this.oddRepository = new GenericRepository<Odd>(context);
                }
                return oddRepository;
            }
        }

        public GenericRepository<Sport> SportRepository
        {
            get
            {
                if (this.sportRepository == null)
                {
                    this.sportRepository = new GenericRepository<Sport>(context);
                }
                return sportRepository;
            }
        }

        public GenericRepository<SportEvent> SportEventRepository
        {
            get
            {
                if (this.sportEventRepository == null)
                {
                    this.sportEventRepository = new GenericRepository<SportEvent>(context);
                }
                return sportEventRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
