using SportsBetting.Data.Repositories;
using SportsBetting.Models;

namespace SportsBetting.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Bet> BetRepository { get; }
        GenericRepository<Match> MatchRepository { get; }
        GenericRepository<Odd> OddRepository { get; }
        GenericRepository<SportEvent> SportEventRepository { get; }
        GenericRepository<Sport> SportRepository { get; }

        void Dispose();
        void Save();
    }
}