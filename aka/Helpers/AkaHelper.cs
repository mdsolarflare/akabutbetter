using System.Collections.Generic;
using System.Linq;
using akabutbetter.Models;

namespace akabutbetter.Helpers
{
    public class AkaHelper
    {
        public static List<Shortlink> GetAllShortlinksFromDb(AkaContext _context)
        {
            return _context.Shortlinks.ToList();
        }

        public static Shortlink GetShortlinkFromDb(AkaContext _context, int id)
        {
            return _context.Shortlinks.Find(id);
        }

        public static Shortlink GetShortlinkFromDb(AkaContext _context, string shortlink)
        {
            var rows = _context.Shortlinks
                .Where(s => s.PrettyName.Equals(shortlink));

            if (rows.Count() == 1)
            {
                return rows.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}