using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Metadata.Edm;

namespace PropertyMgmt.Model
{
    public class DataService : IDataService
    {
        public PropMgmtDBContainer _db = new PropMgmtDBContainer();

        public void UpdateDepositTypes(List<DepositType> DepositTypeList) { UpdateTypes<DepositType>(DepositTypeList, _db.DepositTypes); }
        public void UpdateUtilityTypes(List<UtilitiesType> UtilityTypeList) { UpdateTypes<UtilitiesType>(UtilityTypeList, _db.UtilitiesTypes); }
        public void UpdateBusinessTypes(List<BusinessType> BusinessTypeList) { UpdateTypes<BusinessType>(BusinessTypeList, _db.BusinessTypes); }
        public void UpdatePaymentTypes(List<PaymentType> PaymentTypeList) { UpdateTypes<PaymentType>(PaymentTypeList, _db.PaymentTypes); }
        public void UpdateChargeTypes(List<ChargeType> ChargeTypeList) { UpdateTypes<ChargeType>(ChargeTypeList, _db.ChargeTypes); }

        private void UpdateTypes<theType>(List<theType> theList, DbSet<theType> entityToUpdate) where theType : class
        {
            foreach (theType ti in theList)
            {
                bool foundExisting = false;

                foreach (theType anotherTI in entityToUpdate)
                {
                    if ((anotherTI.GetType().GetProperty("id").GetValue(anotherTI) as Nullable<int>) == (ti.GetType().GetProperty("id").GetValue(ti) as Nullable<int>))
                    {
                        anotherTI.GetType().GetProperty("type").SetValue(anotherTI,ti.GetType().GetProperty("type").GetValue(ti));
                        foundExisting = true;
                        break;
                    }
                }

                if (!foundExisting)
                    entityToUpdate.Add(ti);                    
            }
        }

        public IQueryable<Tenant> GetTenantList() { return _db.Tenants; }
        public IQueryable<Owner> GetOwnerList() { return _db.Owners; }
        public IQueryable<Vendor> GetVendorList() { return _db.Vendors; }
        public IQueryable<PropertyManager> GetPropertyMgmtList() { return _db.PropertyManagers; }
        public IQueryable<HOA> GetHOAList() { return _db.HOAs; }
        public IQueryable<ServiceCall> GetServiceCallList() { return _db.ServiceCalls; }
        public IQueryable<BusinessType> GetBusinessTypeList() { return _db.BusinessTypes; }
        public IQueryable<PaymentType> GetPaymentTypeList() { return _db.PaymentTypes; }
        public IQueryable<ChargeType> GetChargeTypeList() { return _db.ChargeTypes; }
        public IQueryable<Property> GetPropertyList() { return _db.Properties; }
        public IQueryable<DepositType> GetDepositTypeList() { return _db.DepositTypes; }
        public IQueryable<UtilitiesType> GetUtilityTypeList() { return _db.UtilitiesTypes; }

        public void RemoveServiceCall(ServiceCall WorkingServiceCall) { _db.ServiceCalls.Remove(WorkingServiceCall); }
        public void RemoveContact(Contact WorkingContact) { _db.Contacts.Remove(WorkingContact); }
        public void RemoveCorrespondence(Correspondence WorkingCorrespondence) { _db.Correspondences.Remove(WorkingCorrespondence); }
        public void RemoveLedgerRecord(LedgerRecord WorkingLedgerRecord) { _db.LedgerRecords.Remove(WorkingLedgerRecord); }
        public void RemoveFile(File WorkingFile) { _db.Files.Remove(WorkingFile); }
        public void RemoveFileContainer(FileContainer WorkingFileContainer) { _db.FileContainers.Remove(WorkingFileContainer); }
        public void SaveProperty(Property WorkingProperty) { SaveItem<Property>(WorkingProperty,_db.Properties); }
        public void SaveOwner(Owner WorkingOwner) { SaveItem<Owner>(WorkingOwner, _db.Owners); }
        public void SaveTenant(Tenant WorkingTenant) { SaveItem<Tenant>(WorkingTenant, _db.Tenants); }
        public void SaveHOA(HOA WorkingHOA) { SaveItem<HOA>(WorkingHOA, _db.HOAs); }
        public void SaveVendor(Vendor WorkingVendor) { SaveItem<Vendor>(WorkingVendor,_db.Vendors); }
        public void SavePropertyMgmtCompany(PropertyManager WorkingPropertyMgmtCompany) { SaveItem<PropertyManager>(WorkingPropertyMgmtCompany, _db.PropertyManagers); }
        public void SaveContact(Contact WorkingContact) { SaveItem<Contact>(WorkingContact, _db.Contacts); }
        public void SaveServiceCall(ServiceCall WorkingServiceCall) { SaveItem<ServiceCall>(WorkingServiceCall, _db.ServiceCalls); }
        public int SaveChanges() { return _db.SaveChanges(); }

        private void SaveItem<theType>(theType theWorkingItem, DbSet<theType> entityToUpdate) where theType : class
        {
            if ((theWorkingItem.GetType().GetProperty("id").GetValue(theWorkingItem) as Nullable<int>) == 0 ||
                (theWorkingItem.GetType().GetProperty("id").GetValue(theWorkingItem) as Nullable<int>) == null)
            {
                entityToUpdate.Add(theWorkingItem);
            }

            _db.SaveChanges();
        }

        public void UndoAllChanges()
        {
            // Undo the changes of the all entries.
            foreach (DbEntityEntry entry in _db.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    // Under the covers, changing the state of an entity from  
                    // Modified to Unchanged first sets the values of all  
                    // properties to the original values that were read from  
                    // the database when it was queried, and then marks the  
                    // entity as Unchanged. This will also reject changes to  
                    // FK relationships since the original value of the FK  
                    // will be restored.
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is Deleted, reload the date from the database.
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }


            //// Get list of entities that are marked as modified
            //List<DbEntityEntry> modifiedEntityList =
            //    _db.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();
            //DbEntityEntry test = _db.Entry(ViewModel.ViewModelLocator.Instance.Main.PropertyList[0]);

            //foreach (DbEntityEntry entity in modifiedEntityList)
            //{
            //    DbPropertyValues propertyValues = entity.OriginalValues;
            //    foreach (String propertyName in propertyValues.PropertyNames)
            //    {
            //        //Replace current values with original values
            //        PropertyInfo property = entity.Entity.GetType().GetProperty(propertyName);
            //        property.SetValue(entity.Entity, propertyValues[propertyName]);
            //    }
            //}
            
            //// Get all added entities
            //modifiedEntityList =
            //    _db.ChangeTracker.Entries().Where(x => x.State == EntityState.Added).ToList();

            //foreach (DbEntityEntry entity in modifiedEntityList)
            //{
            //    DbPropertyValues propertyValues = entity.OriginalValues;
            //}
        }

        public void RemoveServiceCallFromContainer<T>(T theContainer, ServiceCall WorkingServiceCall)
        {
            MethodInfo reflectionResult = theContainer.GetType().GetMethod("Remove");
            object [] reflectionParams = new object [] { WorkingServiceCall, null };

            if (reflectionResult != null)
            {
                reflectionResult.Invoke(theContainer,reflectionParams);
            }
        }


        public DepositType GetDepositTypeFromString(string category)
        {
            return (from someType in _db.DepositTypes
                    where someType.type == category
                    select someType).FirstOrDefault();
        }

        public PaymentType GetPaymentTypeFromString(string category)
        {
            return (from someType in _db.PaymentTypes
                    where someType.type == category
                    select someType).FirstOrDefault();
        }

        public ChargeType GetChargeTypeFromString(string category)
        {
            return (from someType in _db.ChargeTypes
                    where someType.type == category
                    select someType).FirstOrDefault();
        }


        public object GetOriginalProperty(object theEntity, string propertyName)
        {
            DbEntityEntry target = null;
            object retval = null;
            target = (from entry in _db.ChangeTracker.Entries()
                      where entry.Entity == theEntity
                      select entry).FirstOrDefault();

            ObjectStateEntry objectStateEntry = ((IObjectContextAdapter)_db).ObjectContext.ObjectStateManager.GetObjectStateEntry(theEntity);

            foreach (EdmMember member in ((IObjectContextAdapter)_db).ObjectContext.ObjectStateManager.GetObjectStateEntry(theEntity).EntitySet.ElementType.Members)
            {
                var dbMemberEntry = target.Member(member.Name) as DbMemberEntry;

                if (member.Name == propertyName)
                {
                    if (dbMemberEntry == null)
                    {
                        // Member entry isn't a property entry
                        continue;
                    }

                    if (dbMemberEntry is DbComplexPropertyEntry)
                    {
                        // Bit a bit lazy here and just serialise the complex property to JSON rather than detect which inner properties have changed.
                        var complexProperty = (DbComplexPropertyEntry)dbMemberEntry;
                        retval = complexProperty.OriginalValue;
                        break;
                    }
                    else if (dbMemberEntry is DbReferenceEntry)
                    {
                        var refProperty = (DbReferenceEntry)dbMemberEntry;
                    }
                    else
                    {
                        // It's just a plain property, get the old and new values.
                        var property = dbMemberEntry as DbPropertyEntry;
                        retval = property.OriginalValue;
                    }
                }

            }

            //target = (from entry in _db.ChangeTracker.Entries()
            //          where entry.Entity == theEntity
            //          select entry).FirstOrDefault();

            //if (target != null)
            //{
            //    retval = target.OriginalValues[propertyName];
            //}

            return retval;
        }

        public object GetModifiedProperty(object theEntity, string propertyName)
        {
            DbEntityEntry target = null;
            object retval = null;

            target = (from entry in _db.ChangeTracker.Entries()
                      where entry.Entity == theEntity
                      select entry).FirstOrDefault();

            if (target != null)
            {
                retval = target.CurrentValues[propertyName];
            }

            return retval;
        }
    }
}