using System.Linq;
using akabutbetter.Models;

namespace akabutbetter.Helpers
{
    public class AkaHelper
    {
        public static Shortlink GetShortlinkFromDb(AkaContext _context, int id)
        {
            return _context.Shortlinks.Find(id);
        }

        /// <summary>
        /// Get shortlink if only 1 reference to the requested short/pretty name exists.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="prettyname">The short name or pretty name used for the shortlink.</param>
        /// <returns>Returns null if no results or too many results found.</returns>
        public static Shortlink GetShortlinkFromDb(AkaContext context, string prettyname)
        {
            var rows = context.Shortlinks.Where(s => s.PrettyName.Equals(prettyname));

            return (rows.Count() == 1) ?  rows.FirstOrDefault() : null;
        }

        public static int GetNextAvailableIDFrom(AkaContext context)
        {
            return 1;
        }
    }
}