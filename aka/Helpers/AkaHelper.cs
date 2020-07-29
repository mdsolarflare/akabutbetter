
using akabutbetter.Models;
using Microsoft.EntityFrameworkCore;

namespace akabutbetter.Helpers
{
    public class AkaHelper
    {
        public static Shortlink GetShortlinkFromDb(AkaContext _context, int id)
        {
            return _context.Shortlinks.Find(id);
        }

        /// <summary>
        /// Get shortlink for only the first reference to the requested short/pretty name.
        /// We want to prevent more than one existing on add.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="prettyname">The short name or pretty name used for the shortlink.</param>
        /// <returns>Returns null if no results or too many results found.</returns>
        public static Shortlink GetShortlinkFromDb(AkaContext context, string prettyname)
        {
            Shortlink result;
            DbSet<Shortlink> links = context.Shortlinks;
            
            foreach(Shortlink sl in links)
            {
                if (prettyname.Equals(sl.PrettyName))
                {
                    return sl;
                }
            }
            
            return null;
        }

        public static int GetNextAvailableIDFrom(AkaContext context)
        {
            return 1;
        }

        public static void RedirectToLinkManagement()
        {
            throw new System.NotImplementedException();
        }
    }
}