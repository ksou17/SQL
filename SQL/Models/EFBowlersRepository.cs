using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveChanges(Bowler b)
        {
            
            _context.SaveChanges();
        }
       
        public void AddBowler (Bowler b)
        {
            _context.Bowlers.Add(b);
            _context.SaveChanges();
            
        }
        

        public void UpdateBowler(Bowler b)
        {
            
            _context.Bowlers.Update(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(int temp)
        {
            Bowler b = _context.Bowlers.FirstOrDefault(b => temp == b.BowlerID);
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
