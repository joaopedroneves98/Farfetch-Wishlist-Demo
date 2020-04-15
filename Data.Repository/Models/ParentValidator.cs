namespace Data.Repository.Models
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    class ParentValidator
    {
        private static readonly Dictionary<Type, string> ParentAttributes = new Dictionary<Type, string>();

        public static void ValidateEntity(DbContext context, DbEntityEntry entity, Type type)
        {
            if (entity.State == EntityState.Modified)
            {
                if (!ParentAttributes.ContainsKey(type))
                {
                    var properties = (from attributedProperty in type.GetProperties()
                                      select new
                                      {
                                          attributedProperty,
                                          attributes = attributedProperty.GetCustomAttributes(true)
                                              .Where(attribute => attribute is ParentAttribute)
                                      }).Where(p => p.attributes.Any());

                    ParentAttributes.Add(
                                        type,
                                        properties.Any()
                                        ? properties.First().attributedProperty.Name
                                        : string.Empty);
                }

                if (!string.IsNullOrEmpty(ParentAttributes[type]))
                {
                    if (entity.Reference(ParentAttributes[type]).CurrentValue == null)
                    {
                        context.Set(type).Remove(entity.Entity);
                    }
                }
            }
        }
    }
}
