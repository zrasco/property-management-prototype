using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMgmt.Utilities
{
    public struct EntityChangeTracker
    {
        public string PropertyName;
        public string OriginalValue;
        public string NewValue;
    }

    public static class Clone
    {
        /// <summary>
        /// Makes a shallow copy of an entity object. This works much like a MemberwiseClone
        /// but directly instantiates a new object and copies only properties that work with
        /// EF and don't have the NotMappedAttribute.
        /// 
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="source">The source entity.</param>
        public static TEntity ShallowCopyEntity<TEntity>(TEntity source) where TEntity : class, new()
        {

            // Get properties from EF that are read/write and not marked with the NotMappedAttribute
            var sourceProperties = typeof(TEntity)
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite &&
                                                p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);
            var newObj = new TEntity();

            foreach (var property in sourceProperties)
            {

                // Copy value
                property.SetValue(newObj, property.GetValue(source, null), null);
            }

            return newObj;

        }

        public static List<EntityChangeTracker> CompareEntities<TEntity>(TEntity originalEntity, TEntity newEntity) where TEntity : class, new()
        {

            // Get properties from EF that are read/write and not marked with the NotMappedAttribute
            List<EntityChangeTracker> comparisonList = new List<EntityChangeTracker>();

            var sourceProperties = typeof(TEntity)
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite &&
                                                p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);
            string propertyName = null;
            object originalValue = null;
            object newValue = null;

            foreach (var property in sourceProperties)
            {
                // Copy value
                propertyName = property.Name;
                originalValue = property.GetValue(originalEntity);
                newValue = newEntity.GetType().GetProperty(propertyName).GetValue(newEntity);

                if (originalValue != null && newValue != null &&
                    originalValue.ToString() != newValue.ToString())
                {
                    EntityChangeTracker ect = new EntityChangeTracker();

                    ect.OriginalValue = originalValue.ToString();
                    ect.NewValue = newValue.ToString();
                    ect.PropertyName = propertyName;

                    comparisonList.Add(ect);
                }
            }

            return comparisonList;

        }
        public static List<EntityChangeTracker> GetChangesMade<TEntity>(DbContext _db, TEntity theEntity) where TEntity : class, new()
        {
            List<EntityChangeTracker> comparisonList = new List<EntityChangeTracker>();

            // Get list of entities that are marked as modified
            List<DbEntityEntry> modifiedEntityList =
                _db.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();

            foreach (DbEntityEntry entity in modifiedEntityList)
            {
                if (entity.Entity == theEntity)
                {
                    DbPropertyValues propertyValues = entity.OriginalValues;


                    foreach (String propertyName in propertyValues.PropertyNames)
                    {
                        object objOriginal = propertyValues[propertyName];
                        string originalValue = (objOriginal != null ? objOriginal.ToString() : null);
                        object objNew = entity.Entity.GetType().GetProperty(propertyName).GetValue(entity.Entity);
                        string newValue = (objNew != null ? objNew.ToString() : null);

                        if (originalValue != newValue)
                        {
                            EntityChangeTracker ect = new EntityChangeTracker();
                            ect.OriginalValue = originalValue;
                            ect.NewValue = newValue;
                            ect.PropertyName = propertyName;

                            comparisonList.Add(ect);
                        }
                        


                    }
                }

            }

            return comparisonList;
        }
    }
}
