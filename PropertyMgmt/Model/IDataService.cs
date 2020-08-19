using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyMgmt.Model
{
    public interface IDataService
    {
        int SaveChanges();
        void UpdateDepositTypes(List<DepositType> DepositTypeList);
        void UpdateUtilityTypes(List<UtilitiesType> UtilityTypeList);
        void UpdateBusinessTypes(List<BusinessType> BusinessTypeList);
        void UpdatePaymentTypes(List<PaymentType> PaymentTypeList);
        void UpdateChargeTypes(List<ChargeType> ChargeTypeList);
        IQueryable<Property> GetPropertyList();
        IQueryable<Tenant> GetTenantList();
        IQueryable<Owner> GetOwnerList();
        IQueryable<HOA> GetHOAList();
        IQueryable<Vendor> GetVendorList();
        IQueryable<PropertyManager> GetPropertyMgmtList();
        IQueryable<ServiceCall> GetServiceCallList();
        IQueryable<DepositType> GetDepositTypeList();
        IQueryable<UtilitiesType> GetUtilityTypeList();
        IQueryable<BusinessType> GetBusinessTypeList();
        IQueryable<PaymentType> GetPaymentTypeList();
        IQueryable<ChargeType> GetChargeTypeList();
        DepositType GetDepositTypeFromString(string category);
        PaymentType GetPaymentTypeFromString(string category);
        ChargeType GetChargeTypeFromString(string category);
        void RemoveServiceCall(ServiceCall WorkingServiceCall);
        void RemoveServiceCallFromContainer<T>(T theContainer, ServiceCall WorkingServiceCall);
        void RemoveContact(Contact WorkingContact);
        void RemoveCorrespondence(Correspondence WorkingCorrespondence);
        void RemoveLedgerRecord(LedgerRecord WorkingLedgerRecord);
        void RemoveFile(File WorkingFile);
        void RemoveFileContainer(FileContainer WorkingFileContainer);
        void SaveProperty(Property WorkingProperty);
        void SaveOwner(Owner WorkingOwner);
        void SaveTenant(Tenant WorkingTenant);
        void SaveHOA(HOA WorkingHOA);
        void SaveVendor(Vendor WorkingVendor);
        void SavePropertyMgmtCompany(PropertyManager WorkingPropertyMgmtCompany);
        void SaveServiceCall(ServiceCall WorkingServiceCall);

        object GetOriginalProperty(object theEntity, string propertyName);
        object GetModifiedProperty(object theEntity, string propertyName);

        void UndoAllChanges();
    }
}
