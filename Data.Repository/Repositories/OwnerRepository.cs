namespace Data.Repository.Repositories
{
    using Data.Repository.Interfaces.Repositories;
    using Data.Repository.Models;
    using Domain.Model;
    using SharpRepository.EfRepository;
    using SharpRepository.Repository.Caching;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class OwnerRepository : EfRepository<Owner, Guid>, IOwnerRepository
    {
        protected WishlistContext Context { get; private set; }

        public OwnerRepository(DbContext dbContext, ICachingStrategy<Owner, Guid> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
            this.Context = (WishlistContext)dbContext;
        }

        public Owner GetOwnerObject(string externalID)
        {
            var owner = this.Context.Owners.Where(o => o.ExternalId.Equals(externalID)).Include(o => o.Wishlists).ToList();

            if (owner.Count == 0)
            {
                return null;
            }

            this.GetWishlistsInOwer(owner);

            return owner.ElementAt(0);
        }

        public void GetWishlistsInOwer(List<Owner> owner)
        {
            foreach (Wishlist wishlist in owner.ElementAt(0).Wishlists)
            {
                wishlist.WishlistItems = this.Context.WishlistItems.Where(i => i.WishlistId == wishlist.Id).ToList();

                foreach (WishlistItem item in wishlist.WishlistItems)
                {
                    item.Attributes = this.Context.WishlistItemAttributes.Where(a => a.WishlistItemId == item.Id).ToList();
                }
            }
        }

        public Owner Add(Owner owner)
        {
            if (owner != null)
            {
                this.Context.Owners.Add(owner);
                this.Context.SaveChanges();
                return owner;
            }
            return null;
        }

        public string DeleteOwner(string ownerID)
        {
            var owner = this.GetOwnerObject(ownerID);
            if (owner != null)
            {
                this.Context.Owners.Remove(owner);
                this.Context.SaveChanges();

                return owner.ExternalId;
            }
            return null;
        }

        public List<Owner> GetAllOwners()
        {
            return this.Context.Owners.ToList();
        }

        public string UpdateOwner(Owner owner)
        {
            if (owner == null)
            {
                return null;
            }

            Owner ownerToUpdate = this.Context.Owners
                .Where(o => o.Id == o.Id).FirstOrDefault();

            if (ownerToUpdate != null)
            {
                this.Context.Entry(ownerToUpdate).CurrentValues.SetValues(owner);
                this.Context.SaveChanges();
                return owner.ExternalId;
            }
            return null;
        }
    }
}
