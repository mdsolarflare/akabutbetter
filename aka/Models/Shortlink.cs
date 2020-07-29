using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using akabutbetter.Helpers;

namespace akabutbetter.Models
{
    public class Shortlink
    {
        /// <summary>
        /// Creates a new shortlink with all params provided.
        /// </summary>
        /// <param name="linkId">ID of link to be used in DB.</param>
        /// <param name="prettyName">The pretty short name we use.</param>
        /// <param name="destination">The target or destination URI we redirect to.</param>
        /// <param name="owners">The list of owners who can modify this link.</param>
        /// <exception cref="ArgumentException">Thrown if the owners list is too small.</exception>
        public Shortlink(int linkId, string prettyName, Uri destination, List<Owner> owners)
        {
            if (owners.Count < 2)
            {
                throw new ArgumentException("Owners list is too small! Provide at least two owners.");
            }
            
            LinkId = linkId;
            PrettyName = prettyName;
            Destination = destination;
            Owners = owners;
            LastUpdated = DateTime.Now;
        }

        public Shortlink(ShortlinkRequest request, AkaContext context)
        {
            LinkId = AkaHelper.GetNextAvailableIDFrom(context);
            PrettyName = request.PrettyName;
            Destination = new Uri(request.DestinationUri);
            Owners = OwnerHelper.CreateListFrom(request.Owners);
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// The ID for link, for reference in DB and elsewhere.
        /// </summary>
        [Key]
        public int LinkId { get; private set; }

        /// <summary>
        /// The pretty name or short name i.e. https://aka.me/tacobell
        /// </summary>
        public string PrettyName { get; private set; }

        /// <summary>
        /// The destination URI to forward to i.e. https://tacobell.com
        /// </summary>
        public Uri Destination { get; private set; }

        /// <summary>
        /// The list of owners for the link, we want at least two.
        /// we will enforce this on the data object.
        /// </summary>
        public List<Owner> Owners { get; private set; }

        public DateTime LastUpdated { get; private set; }


        /// <summary>
        /// Updates the target/destination URI.
        /// </summary>
        /// <param name="newDestination">The new target/destination URI.</param>
        public void UpdateTarget(Uri newDestination)
        {
            Destination = newDestination;
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Updates the owners of the short link.
        /// </summary>
        /// <param name="newOwners">The list of new owners of the shortlink.</param>
        /// <exception cref="ArgumentException">Thrown if owners list is too small.</exception>
        public void UpdateOwners(List<Owner> newOwners)
        {
            if (newOwners.Count < 2)
            {
                throw new ArgumentException("Owners list is too small! Provide at least two owners.");
            }
            
            Owners = newOwners;
            LastUpdated = DateTime.Now;
        }

        public override string ToString()
        {
            return "{ "
                   + $"LinkId: {LinkId}, PrettyName: {PrettyName}, Destination: {Destination}"
                   + $", Owners: [{string.Join(",", Owners)}], Last Updated: {LastUpdated}"
                   + " }";
        }
    }
}