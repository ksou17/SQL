using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }
        void AddBowler(Bowler temp);
        void SaveChanges(Bowler temp);
        void UpdateBowler(Bowler temp);
        void DeleteBowler(int temp);
    }
}
