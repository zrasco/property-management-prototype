using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using PropertyChanged;
using PropertyMgmt.Model;
using PropertyMgmt.Utilities;
using PropertyMgmt.ViewModel;
using PropertyMgmt.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PropertyMgmt.Model
{
    [ImplementPropertyChanged]
    public partial class Owner : ObservableObject
    {
        public void Properties_RaisePropertiesChanged() { RaisePropertyChanged("Properties"); }
        public Contact FirstContact { get { return Contacts.FirstOrDefault(); } }
        public void Contacts_RaisePropertiesChanged() { RaisePropertyChanged("ContactsList"); }
        public List<Contact> ContactsList { get { return Contacts.ToList(); } }

        /// <summary>
        /// The <see cref="WorkingOwnerProperty" /> property's name.
        /// </summary>
        public const string WorkingOwnerPropertyPropertyName = "WorkingOwnerProperty";
        private Property _workingOwnerProperty = null;
        /// <summary>
        /// Sets and gets the SelectedProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Property WorkingOwnerProperty
        {
            get
            {
                return _workingOwnerProperty;
            }
            set
            {
                Set(() => WorkingOwnerProperty, ref _workingOwnerProperty, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingContact" /> property's name.
        /// </summary>
        public const string WorkingContactPropertyName = "WorkingContact";
        private Contact _workingContact = null;
        /// <summary>
        /// Sets and gets the WorkingContact property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Contact WorkingContact
        {
            get
            {
                return _workingContact;
            }
            set
            {
                Set(() => WorkingContact, ref _workingContact, value);
            }
        }

    }
    [ImplementPropertyChanged]
    public partial class Property : ObservableObject
    {
        public void ServiceCalls_RaisePropertiesChanged() { RaisePropertyChanged("ServiceCallList"); }
        public List<ServiceCall> ServiceCallList { get { return ServiceCalls.ToList(); } }

        public void GateCodes_RaisePropertiesChanged() { RaisePropertyChanged("GateCodeList"); }
        public List<GateCode> GateCodeList { get { return GateCodes.ToList(); } }

        public void ParkingStalls_RaisePropertiesChanged() { RaisePropertyChanged("ParkingStallList"); }
        public List<ParkingStall> ParkingStallList { get { return ParkingStalls.ToList(); } }

        /// <summary>
        /// The <see cref="City" /> property's name.
        /// </summary>
        public const string CityPropertyName = "City";

        /// <summary>
        /// Sets and gets the City property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                RaisePropertyChanged(CityPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="WorkingTenant" /> property's name.
        /// </summary>
        public const string WorkingTenantPropertyName = "WorkingTenant";

        private Tenant _workingTenant = null;
        /// <summary>
        /// Sets and gets the WorkingTenant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Tenant WorkingTenant
        {
            get
            {
                return _workingTenant;
            }
            set
            {
                if (_workingTenant != value)
                {
                    _workingTenant = value;
                    RaisePropertyChanged(WorkingTenantPropertyName);
                }
            }
        }

        /// <summary>
        /// The <see cref="WorkingServiceCall" /> property's name.
        /// </summary>
        public const string WorkingServiceCallPropertyName = "WorkingServiceCall";

        private ServiceCall _workingServiceCall = null;

        /// <summary>
        /// Sets and gets the WorkingServiceCall property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ServiceCall WorkingServiceCall
        {
            get
            {
                return _workingServiceCall;
            }
            set
            {
                Set(() => WorkingServiceCall, ref _workingServiceCall, value);
            }
        }

        public string FullAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(address2))
                    return address1 + ", " + address2;
                else
                    return address1;
            }
        }
        /// <summary>
        /// The <see cref="WorkingGateCode" /> property's name.
        /// </summary>
        public const string WorkingGateCodePropertyName = "WorkingGateCode";

        private GateCode _workingGateCode = null;

        /// <summary>
        /// Sets and gets the WorkingGateCode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public GateCode WorkingGateCode
        {
            get
            {
                return _workingGateCode;
            }
            set
            {
                Set(() => WorkingGateCode, ref _workingGateCode, value);
            }
        }

        private RelayCommand _addGateCodeCommand;

        /// <summary>
        /// Gets the AddGateCodeCommand.
        /// </summary>
        public RelayCommand AddGateCodeCommand
        {
            get
            {
                return _addGateCodeCommand
                    ?? (_addGateCodeCommand = new RelayCommand(
                    () =>
                    {
                        if (AddGateCodeCommand.CanExecute(null))
                        {
                            GateCode newCode = new GateCode();

                            newCode.Property = this;
                            newCode.code = "Enter code";
                            GateCodes.Add(newCode);
                            GateCodes_RaisePropertiesChanged();
                        }
                        
                    },
                    () => true));
            }
        }

        private RelayCommand _removeGateCodeCommand;

        /// <summary>
        /// Gets the RemoveGateCodeCommand.
        /// </summary>
        public RelayCommand RemoveGateCodeCommand
        {
            get
            {
                return _removeGateCodeCommand
                    ?? (_removeGateCodeCommand = new RelayCommand(
                    () =>
                    {
                        if (RemoveGateCodeCommand.CanExecute(null))
                        {
                            GateCodes.Remove(WorkingGateCode);
                            GateCodes_RaisePropertiesChanged();
                        }
                    },
                    () => true));
            }
        }

        /// <summary>
        /// The <see cref="WorkingParkingStall" /> property's name.
        /// </summary>
        public const string WorkingParkingStallPropertyName = "WorkingParkingStall";

        private ParkingStall _workingParkingStall = null;

        /// <summary>
        /// Sets and gets the WorkingParkingStall property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ParkingStall WorkingParkingStall
        {
            get
            {
                return _workingParkingStall;
            }
            set
            {
                Set(() => WorkingParkingStall, ref _workingParkingStall, value);
            }
        }

        private RelayCommand _addParkingStallCommand;

        /// <summary>
        /// Gets the AddParkingStallCommand.
        /// </summary>
        public RelayCommand AddParkingStallCommand
        {
            get
            {
                return _addParkingStallCommand
                    ?? (_addParkingStallCommand = new RelayCommand(
                    () =>
                    {
                        if (AddParkingStallCommand.CanExecute(null))
                        {
                            ParkingStall newStall = new ParkingStall();

                            newStall.Property = this;
                            newStall.stall = "Enter stall";
                            ParkingStalls.Add(newStall);
                            ParkingStalls_RaisePropertiesChanged();
                        }

                    },
                    () => true));
            }
        }

        private RelayCommand _removeParkingStallCommand;

        /// <summary>
        /// Gets the RemoveParkingStallCommand.
        /// </summary>
        public RelayCommand RemoveParkingStallCommand
        {
            get
            {
                return _removeParkingStallCommand
                    ?? (_removeParkingStallCommand = new RelayCommand(
                    () =>
                    {
                        if (RemoveParkingStallCommand.CanExecute(null))
                        {
                            ParkingStalls.Remove(WorkingParkingStall);
                            ParkingStalls_RaisePropertiesChanged();
                        }
                    },
                    () => true));
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class Tenant : ObservableObject
    {
        public void LedgerRecords_RaisePropertiesChanged() { RaisePropertyChanged("LedgerRecordsList"); }
        public List<LedgerRecord> LedgerRecordsList { get { return LedgerRecords.ToList(); } }
        public void ServiceCalls_RaisePropertiesChanged() { RaisePropertyChanged("ServiceCallList"); }
        public List<ServiceCall> ServiceCallList { get { return Property.ServiceCalls.ToList(); } }
        public void Correspondences_RaisePropertiesChanged() { RaisePropertyChanged("CorrespondencesList"); }
        public List<Correspondence> CorrespondencesList { get { return Correspondences.ToList(); } }
        public string NameAndProperty { get { return Contact.FullName + " (" + Property.FullAddress + ")"; } }

        /// <summary>
        /// The <see cref="WorkingLedgerRecord" /> property's name.
        /// </summary>
        public const string WorkingLedgerRecordPropertyName = "WorkingLedgerRecord";
        private LedgerRecord _workingLedgerRecord = null;
        /// <summary>
        /// Sets and gets the WorkingLedgerRecord property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LedgerRecord WorkingLedgerRecord
        {
            get
            {
                return _workingLedgerRecord;
            }
            set
            {
                Set(() => WorkingLedgerRecord, ref _workingLedgerRecord, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingCorrespondence" /> property's name.
        /// </summary>
        public const string WorkingCorrespondencePropertyName = "WorkingCorrespondence";
        private Correspondence _WorkingCorrespondence = null;
        /// <summary>
        /// Sets and gets the SelectedProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Correspondence WorkingCorrespondence
        {
            get
            {
                return _WorkingCorrespondence;
            }
            set
            {
                Set(() => WorkingCorrespondence, ref _WorkingCorrespondence, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingServiceCall" /> property's name.
        /// </summary>
        public const string WorkingServiceCallPropertyName = "WorkingServiceCall";

        /// <summary>
        /// Sets and gets the WorkingServiceCall property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ServiceCall WorkingServiceCall
        {
            get
            {
                if (Property != null)
                    return Property.WorkingServiceCall;
                else
                    return null;
            }
            set
            {
                if (Property.WorkingServiceCall != value)
                {
                    Property.WorkingServiceCall = value;
                    RaisePropertyChanged(WorkingServiceCallPropertyName);
                }
            }
        }

        /// <summary>
        /// The <see cref="PropertyListed" /> property's name.
        /// </summary>
        public const string PropertyInGridPropertyName = "PropertyInGrid";

        public Property PropertyListed
        {
            get { return Property; }

            set
            {
                if (Property != value)
                    Property = value;

                RaisePropertyChanged(PropertyInGridPropertyName);
            }
        }
        /// <summary>
        /// Wrapper w/INPC for Property property
        /// </summary>
        public List<Property> PropertyInGrid
        {
            get
            {
                List<Property> retval = new List<Property>();
                
                if (PropertyListed != null)
                    retval.Add(PropertyListed);
                else
                {
                    Property dummyProperty = new Property();

                    dummyProperty.Owner = new Owner();
                    dummyProperty.Owner.company_name = "(None)";
                    dummyProperty.address1 = "(None)";
                    dummyProperty.city = "(None)";
                    dummyProperty.state = "(None)";
                    dummyProperty.zip = "(None)";

                    retval.Add(dummyProperty);
                }

                return retval;
            }
        }

        public void Contacts_RaisePropertiesChanged() { RaisePropertyChanged("ContactListed"); RaisePropertyChanged(ContactInGridContactName); }

        /// <summary>
        /// The <see cref="ContactListed" /> Contact's name.
        /// </summary>
        public const string ContactInGridContactName = "ContactInGrid";

        public Contact ContactListed
        {
            get { return Contact; }

            set
            {
                if (Contact != value)
                    Contact = value;

                RaisePropertyChanged(ContactInGridContactName);
            }
        }
        /// <summary>
        /// Wrapper w/INPC for Contact Contact
        /// </summary>
        public List<Contact> ContactInGrid
        {
            get
            {
                List<Contact> retval = new List<Contact>();

                if (ContactListed != null)
                    retval.Add(ContactListed);

                return retval;
            }
        }

        /// <summary>
        /// The <see cref="RentHistoryList" /> property's name.
        /// </summary>
        public const string RentHistoryListPropertyName = "RentHistoryList";

        /// <summary>
        /// Sets and gets the RentHistoryList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<object> RentHistoryList
        {
            get
            {
                List<object> retval = new List<object>();

                var rentsDue = (from ldg in LedgerRecords
                                where ldg.ChargeType != null && ldg.ChargeType.type == "Rent"
                                select ldg.due_date);

                foreach (Nullable<DateTime> due_date in rentsDue)
                {
                    if (due_date != null)
                    {
                        var toAdd = new { due_date = due_date, 
                                            balance = (double)Balance((DateTime)due_date), 
                                            balance_color = (Balance((DateTime)due_date) > 0 ? "Red" : "Green" ) };

                        retval.Add(toAdd);
                    }
                }

                return retval;
            }
        }

        public void CurrentBalance_RaisePropertiesChanged() { RaisePropertyChanged("CurrentBalance"); }

        public decimal CurrentBalance
        {
            get
            {
                return Balance(DateTime.Now.Date);
            }
        }

        public string CurrentBalanceColor
        {
            get
            {
                return (Balance(DateTime.Now.Date) > 0 ? "Red" : "Green");
            }
        }

        public decimal Balance(DateTime date)
        {
            // Add up all charges up until target date
            // Add up all payments up until and including target date
            // Return result
            decimal retval = 0;

            if (LedgerRecords.Count > 0)
            {
                decimal charges = (from ch in LedgerRecords
                                   where ch.ChargeType != null && ch.transaction_date <= date.Date
                                   select ch.amount).Sum();

                decimal payments = (from py in LedgerRecords
                                    where py.PaymentType != null && py.transaction_date <= date.Date
                                    select py.amount).Sum();
                retval = (charges - payments);
            }
            return retval;
        }
    }
    [ImplementPropertyChanged]
    public partial class HOA : ObservableObject
    {
        public void Contacts_RaisePropertiesChanged() { RaisePropertyChanged("ContactsList"); }
        public List<Contact> ContactsList { get { return Contacts.ToList(); } }

        public string FullAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(address2))
                    return address1 + ", " + address2;
                else
                    return address1;
            }
        }

        /// <summary>
        /// The <see cref="CurrentPropertyMgmtCompany" /> property's name.
        /// </summary>
        public const string CurrentPropertyMgmtCompanyPropertyName = "CurrentPropertyMgmtCompany";
        /// <summary>
        /// Sets and gets the CurrentPropertyMgmtCompany property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PropertyManager CurrentPropertyMgmtCompany
        {
            get
            {
                if (HOA_PropertyManagerHistory.Count() > 0)
                {
                    HOA_PropertyManagerHistory intermediate = null;

                    intermediate = (from pmh in HOA_PropertyManagerHistory
                            where pmh.date_end == null
                            select pmh).FirstOrDefault();

                    if (intermediate != null)
                    {
                        //RaisePropertyChanged(CurrentPropertyMgmtCompanyPropertyName);
                        return intermediate.PropertyManager;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            set
            {
                // Find current property mgmt company
                // Place current timestamp in date_end
                // Create new entry with null timestamp. this will be the new current one

                HOA_PropertyManagerHistory intermediate = null;
                HOA_PropertyManagerHistory newPMH = new HOA_PropertyManagerHistory();

                if (HOA_PropertyManagerHistory.Count() > 0)
                {
                    intermediate = (from pmh in HOA_PropertyManagerHistory
                                    where pmh.date_end == null && (pmh.PropertyManager.id != value.id)
                                    select pmh).FirstOrDefault();

                    if (intermediate != null)
                    {
                        // Found current PM company. Cap with current timestamp
                        intermediate.date_end = DateTime.Now;

                        // Create new entry with null timestamp. Will be new current one
                        newPMH.HOA = this;
                        newPMH.PropertyManager = value;
                        newPMH.date_start = DateTime.Now;
                        HOA_PropertyManagerHistory.Add(newPMH);
                    }
                    else
                    {
                        // Existing PM id matches one trying to be set, no changes required
                    }
                }
                else
                {
                    newPMH.HOA = this;
                    newPMH.PropertyManager = value;
                    newPMH.date_start = DateTime.Now;
                    HOA_PropertyManagerHistory.Add(newPMH);
                }
            }
        }
        /// <summary>
        /// The <see cref="WorkingPropertyMgmtCompany" /> property's name.
        /// </summary>
        public const string WorkingPropertyMgmtCompanyPropertyName = "WorkingPropertyMgmtCompany";
        private PropertyManager _workingPropertyMgmtCompany = null;
        /// <summary>
        /// Sets and gets the WorkingPropertyMgmtCompany property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PropertyManager WorkingPropertyMgmtCompany
        {
            get
            {
                return _workingPropertyMgmtCompany;
            }
            set
            {
                Set(() => WorkingPropertyMgmtCompany, ref _workingPropertyMgmtCompany, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingContact" /> property's name.
        /// </summary>
        public const string WorkingContactPropertyName = "WorkingContact";
        private Contact _workingContact = null;
        /// <summary>
        /// Sets and gets the WorkingContact property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Contact WorkingContact
        {
            get
            {
                return _workingContact;
            }
            set
            {
                Set(() => WorkingContact, ref _workingContact, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingProperty" /> property's name.
        /// </summary>
        public const string WorkingPropertyPropertyName = "WorkingProperty";
        private Property _WorkingProperty = null;
        /// <summary>
        /// Sets and gets the SelectedProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Property WorkingProperty
        {
            get
            {
                return _WorkingProperty;
            }
            set
            {
                Set(() => WorkingProperty, ref _WorkingProperty, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class Vendor: ObservableObject
    {
        public void ServiceCalls_RaisePropertiesChanged() { RaisePropertyChanged("ServiceCallList"); }
        public List<ServiceCall> ServiceCallList { get { return ServiceCalls.ToList(); } }
        public void Contacts_RaisePropertiesChanged() { RaisePropertyChanged("ContactsList"); }
        public List<Contact> ContactsList { get { return Contacts.ToList(); } }

        /// <summary>
        /// The <see cref="WorkingServiceCall" /> property's name.
        /// </summary>
        public const string WorkingServiceCallPropertyName = "WorkingServiceCall";

        private ServiceCall _workingServiceCall = null;

        /// <summary>
        /// Sets and gets the WorkingServiceCall property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ServiceCall WorkingServiceCall
        {
            get
            {
                return _workingServiceCall;
            }
            set
            {
                Set(() => WorkingServiceCall, ref _workingServiceCall, value);
            }
        }

        public string FullAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(address2))
                    return address1 + ", " + address2;
                else
                    return address1;
            }
        }
        /// <summary>
        /// The <see cref="WorkingContact" /> property's name.
        /// </summary>
        public const string WorkingContactPropertyName = "WorkingContact";
        private Contact _workingContact = null;
        /// <summary>
        /// Sets and gets the WorkingContact property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Contact WorkingContact
        {
            get
            {
                return _workingContact;
            }
            set
            {
                Set(() => WorkingContact, ref _workingContact, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class PropertyManager : ObservableObject
    {
        public void Contacts_RaisePropertiesChanged() { RaisePropertyChanged("ContactsList"); }
        public List<Contact> ContactsList { get { return Contacts.ToList(); } }

        /// <summary>
        /// The <see cref="CurrentHOAList" /> property's name.
        /// </summary>
        public const string CurrentHOAListPropertyName = "CurrentHOAList";
        /// <summary>
        /// Sets and gets the CurrentHOAList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<HOA> CurrentHOAList
        {
            get
            {
                return (from hoa in HOA_PropertyManagerHistory
                        where hoa.date_end == null
                        select hoa.HOA).ToList();
            }
        }
        public string FullAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(address2))
                    return address1 + ", " + address2;
                else
                    return address1;
            }
        }
        /// <summary>
        /// The <see cref="WorkingHOA" /> property's name.
        /// </summary>
        public const string WorkingHOAPropertyName = "WorkingHOA";
        private HOA _WorkingHOA = null;
        /// <summary>
        /// Sets and gets the SelectedProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public HOA WorkingHOA
        {
            get
            {
                return _WorkingHOA;
            }
            set
            {
                Set(() => WorkingHOA, ref _WorkingHOA, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingContact" /> property's name.
        /// </summary>
        public const string WorkingContactPropertyName = "WorkingContact";
        private Contact _workingContact = null;
        /// <summary>
        /// Sets and gets the WorkingContact property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Contact WorkingContact
        {
            get
            {
                return _workingContact;
            }
            set
            {
                Set(() => WorkingContact, ref _workingContact, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class Contact : ObservableObject
    {
        public string FullName { get { return last_name + ", " + first_name + (!string.IsNullOrEmpty(middle_initial) ? " " + middle_initial : ""); } }
        
        public string FullAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(address2))
                    return address1 + ", " + address2;
                else
                    return address1;
            }
        }

        /// <summary>
        /// The <see cref="Visible" /> property's name.
        /// </summary>
        public const string VisiblePropertyName = "Visible";

        private Visibility _visible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the Visible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                Set(() => Visible, ref _visible, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class ServiceCall : ObservableObject
    {
        /// <summary>
        /// The <see cref="Visible" /> property's name.
        /// </summary>
        public const string VisiblePropertyName = "Visible";

        private Visibility _visible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the Visible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                Set(() => Visible, ref _visible, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class Correspondence : ObservableObject
    {
        /// <summary>
        /// The <see cref="Visible" /> property's name.
        /// </summary>
        public const string VisiblePropertyName = "Visible";

        private Visibility _visible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the Visible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                Set(() => Visible, ref _visible, value);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class LedgerRecord : ObservableObject
    {
        public static string LEDGERTYPE_DEPOSIT = "Deposit";
        public static string LEDGERTYPE_PAYMENT = "Payment";
        public static string LEDGERTYPE_CHARGE = "Charge";

        public List<string> GetCategoryList(IDataService _repo, string typeName)
        {
            List<string> retval = null;

            if (typeName == LEDGERTYPE_DEPOSIT)
            {
                retval = (from theItem in _repo.GetDepositTypeList()
                          select theItem.type).ToList();
            }
            else if (typeName == LEDGERTYPE_PAYMENT)
            {
                retval = (from theItem in _repo.GetPaymentTypeList()
                          select theItem.type).ToList();
            }
            else if (typeName == LEDGERTYPE_CHARGE)
            {
                retval = (from theItem in _repo.GetChargeTypeList()
                          select theItem.type).ToList();
            }

            return retval;
        }
        public string LedgerType
        {
            get
            {
                if (DepositType != null)
                    return LEDGERTYPE_DEPOSIT;
                else if (PaymentType != null)
                    return LEDGERTYPE_PAYMENT;
                else if (ChargeType != null)
                    return LEDGERTYPE_CHARGE;
                else
                    return null;
            }
        }
        public string Category
        {
            get
            {
                if (DepositType != null)
                    return DepositType.type;
                else if (PaymentType != null)
                    return PaymentType.type;
                else if (ChargeType != null)
                    return ChargeType.type;
                else
                    return null;
            }
        }

        /// <summary>
        /// The <see cref="Visible" /> property's name.
        /// </summary>
        public const string VisiblePropertyName = "Visible";

        private Visibility _visible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the Visible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                Set(() => Visible, ref _visible, value);
            }
        }

        /// <summary>
        /// The <see cref="TypeList" /> property's name.
        /// </summary>
        public const string TypeListPropertyName = "TypeList";

        private List<string> _typeList = new List<string>(new string[] { LEDGERTYPE_DEPOSIT, LEDGERTYPE_PAYMENT, LEDGERTYPE_CHARGE });

        /// <summary>
        /// Sets and gets the TypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<string> TypeList
        {
            get
            {
                return _typeList;
            }
            set
            {
                Set(() => TypeList, ref _typeList, value);
            }
        }

        /// <summary>
        /// The <see cref="CategoryList" /> property's name.
        /// </summary>
        public const string CategoryListPropertyName = "CategoryList";

        private List<string> _categoryList = null;

        /// <summary>
        /// Sets and gets the CategoryList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<string> CategoryList
        {
            get
            {
                List<string> retval = GetCategoryList(ViewModelLocator.Instance.Repository, WorkingType);

                return retval;
            }
            set
            {
                Set(() => CategoryList, ref _categoryList, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingType" /> property's name.
        /// </summary>
        public const string WorkingTypePropertyName = "WorkingType";

        private string _workingType = null;

        /// <summary>
        /// Sets and gets the WorkingType property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WorkingType
        {
            get
            {
                return _workingType;
            }
            set
            {
                Set(() => WorkingType, ref _workingType, value);
                RaisePropertyChanged(CategoryListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="WorkingCategory" /> property's name.
        /// </summary>
        public const string WorkingCategoryPropertyName = "WorkingCategory";

        private string _workingCategory = null;

        /// <summary>
        /// Sets and gets the WorkingCategory property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WorkingCategory
        {
            get
            {
                return _workingCategory;
            }
            set
            {
                Set(() => WorkingCategory, ref _workingCategory, value);
                //RaisePropertyChanged(CategoryListPropertyName);
            }
        }
    }
    [ImplementPropertyChanged]
    public partial class FileContainer : ObservableObject
    {
        /// <summary>
        /// The <see cref="Visible" /> property's name.
        /// </summary>
        public const string VisiblePropertyName = "Visible";

        private Visibility _visible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the Visible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                Set(() => Visible, ref _visible, value);
            }
        }
    }
}

namespace PropertyMgmt.ViewModel
{
    public enum ItemType
    {
        // NOTE: Enum values coupled with array indexes!
        // CHANGING THE INITIAL PROPERTY = 0 WILL BREAK THE PROGRAM!!!!! YOU'VE BEEN WARNED!!!!!
        Property = 0,
        Tenant,
        Owner,
        HOA,
        Vendor,
        PropertyMgmtCompany,
        ServiceCall,
        Contact,
        Correspondence,
        LedgerRecord
    }

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private const string DEFAULT_STATE = "NV";

        private readonly IDataService _repo;
        private State _state = new State();
        public List<State> StateList { get { return _state.ListOfStates() as List<State>; } }

        public event Action<ItemType> EventItemSaved = delegate { };
        public event Action<ItemType> EventNewItemDialog = delegate { };
        public event Action<ItemType> EventOpenItemDialog = delegate { };

        public event Action EventGateCodeAdded = delegate { };
        public event Action EventParkingStallAdded = delegate { };

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _repo = dataService;

            // TODO: Start loading these when tabs are actually clicked
            PropertyList = new ObservableCollection<Property>(_repo.GetPropertyList().ToList());
            TenantList = new ObservableCollection<Tenant>(_repo.GetTenantList().ToList());
            OwnerList = new ObservableCollection<Owner>(_repo.GetOwnerList().ToList());
            HOAList = new ObservableCollection<HOA>(_repo.GetHOAList().ToList());
            VendorList = new ObservableCollection<Vendor>(_repo.GetVendorList().ToList());
            PropertyMgmtList = new ObservableCollection<PropertyManager>(_repo.GetPropertyMgmtList().ToList());
            ServiceCallList = new ObservableCollection<ServiceCall>(_repo.GetServiceCallList().ToList());
        }

        #region RelayCommands
        private RelayCommand<Property> _addGateCodeCommand;
        public RelayCommand<Property> AddGateCodeCommand
        {
            get
            {
                return _addGateCodeCommand
                    ?? (_addGateCodeCommand = new RelayCommand<Property>(
                    theProperty =>
                    {
                        if (AddGateCodeCommand.CanExecute(theProperty))
                        {
                            theProperty.AddGateCodeCommand.Execute(null);
                            EventGateCodeAdded();
                        }
                    },
                    theProperty => true));
            }
        }
        private RelayCommand<Property> _addParkingStallCommand;
        public RelayCommand<Property> AddParkingStallCommand
        {
            get
            {
                return _addParkingStallCommand
                    ?? (_addParkingStallCommand = new RelayCommand<Property>(
                    theProperty =>
                    {
                        if (AddParkingStallCommand.CanExecute(theProperty))
                        {
                            theProperty.AddParkingStallCommand.Execute(null);
                            EventParkingStallAdded();
                        }
                    },
                    theProperty => true));
            }
        }
        private RelayCommand<ItemType> _saveItemCommand;
        public RelayCommand<ItemType> SaveItemCommand
        {
            get
            {
                return _saveItemCommand
                    ?? (_saveItemCommand = new RelayCommand<ItemType>(
                    (ItemType itemType) =>
                    {
                        if (SaveItemCommand.CanExecute(itemType))
                        {
                            List<EntityChangeTracker> changedItems = null;

                            var invokeMethods = new Action[] {
                                                   delegate
                                                   {
                                                       int originalOwnerId = (int)_repo.GetModifiedProperty(WorkingProperty,"owner_id");

                                                       if (WorkingProperty.id == 0)
                                                       {
                                                           PropertyList.Add(WorkingProperty);
                                                           AddAuditEntry(WorkingProperty, "Created property '" + WorkingProperty.FullAddress + "'");
                                                       }

                                                       //WorkingProperty.ServiceCalls_RaisePropertiesChanged();
                                                       if (originalOwnerId != WorkingProperty.owner_id)
                                                       {
                                                           // Owner changed
                                                           //Owner oldOwner = _repo.GetOriginalProperty(WorkingProperty, "Owner") as Owner;

                                                           // TODO: Need func to return owner using owner_id
                                                           Owner oldOwner = null;
                                                           oldOwner.Properties_RaisePropertiesChanged();
                                                           WorkingProperty.Owner.Properties_RaisePropertiesChanged();
                                                       }

                                                       _repo.SaveProperty(WorkingProperty);
                                                   },
                                                   delegate {
                                                       if (WorkingTenant.id == 0)
                                                       {
                                                           TenantList.Add(WorkingTenant);
                                                           AddAuditEntry(WorkingTenant, "Created tenant '" + WorkingTenant.NameAndProperty + "'");
                                                       }

                                                       _repo.SaveTenant(WorkingTenant);
                                                   },
                                                   delegate {
                                                       if (WorkingOwner.id == 0)
                                                       {
                                                           OwnerList.Add(WorkingOwner);
                                                           AddAuditEntry(WorkingOwner, "Created owner '" + WorkingOwner.company_name + "'");
                                                       }

                                                       _repo.SaveOwner(WorkingOwner);
                                                   },
                                                   delegate {
                                                       if (WorkingHOA.id == 0)
                                                       {
                                                           HOAList.Add(WorkingHOA);
                                                           AddAuditEntry(WorkingHOA, "Created HOA '" + WorkingHOA.company_name + "'");
                                                       }

                                                       _repo.SaveHOA(WorkingHOA);
                                                   },
                                                   delegate {
                                                       if (WorkingVendor.id == 0)
                                                       {
                                                           VendorList.Add(WorkingVendor);
                                                           AddAuditEntry(WorkingVendor, "Created vendor '" + WorkingVendor.company_name + "'");
                                                       }

                                                       _repo.SaveVendor(WorkingVendor);
                                                   },
                                                   delegate {
                                                       if (WorkingPropertyMgmtCompany.id == 0)
                                                       {
                                                           PropertyMgmtList.Add(WorkingPropertyMgmtCompany);
                                                           AddAuditEntry(WorkingPropertyMgmtCompany, "Created property management company '" + WorkingPropertyMgmtCompany.company_name + "'");
                                                       }

                                                       _repo.SavePropertyMgmtCompany(WorkingPropertyMgmtCompany);
                                                   },
                                                   delegate {
                                                       if (WorkingServiceCall.id == 0)
                                                       {
                                                           ServiceCallList.Add(WorkingServiceCall);
                                                           WorkingServiceCall.Property.ServiceCalls.Add(WorkingServiceCall);
                                                           WorkingServiceCall.Property.ServiceCallList.Add(WorkingServiceCall);
                                                           AddAuditEntry(WorkingContainer, "Created service call '" + WorkingServiceCall.summary + "'");
                                                       }

                                                       if (WorkingContainer == null)
                                                           // Save to list right away since called from main screen
                                                           _repo.SaveServiceCall(WorkingServiceCall);
                                                       else if (!(WorkingContainer is Property) && !(WorkingContainer is Tenant))
                                                       {
                                                           ICollection<ServiceCall> ContainedServiceCallList = 
                                                               WorkingContainer.GetType().GetProperty("ServiceCalls").GetValue(WorkingContainer) as ICollection<ServiceCall>;
                                                           ContainedServiceCallList.Add(WorkingServiceCall);

                                                       }

                                                       //WorkingContainer.GetType().GetMethod("ServiceCalls_RaisePropertiesChanged").Invoke(WorkingContainer, null);

                                                       //if (WorkingServiceCall.id == 0)
                                                       //    ServiceCallList.Add(WorkingServiceCall);

                                                       //_repo.SaveServiceCall(WorkingServiceCall);
                                                   },
                                                   delegate {
                                                       // Show on display list
                                                       if (WorkingContact.id == 0 && !(WorkingContainer is Tenant))
                                                       {
                                                           ICollection<Contact> ContactList = WorkingContainer.GetType().GetProperty("Contacts").GetValue(WorkingContainer) as ICollection<Contact>;
                                                           ContactList.Add(WorkingContact);
                                                           AddAuditEntry(WorkingContainer, "Created contact info for '" + WorkingContact.FullName + "'");
                                                       }

                                                       WorkingContainer.GetType().GetMethod("Contacts_RaisePropertiesChanged").Invoke(WorkingContainer, null);
                                                    },
                                                    delegate {
                                                        // Correspondence
                                                        if (WorkingContainer != null)
                                                        {
                                                            ICollection<Correspondence> CorrespondencesList = WorkingContainer.GetType().GetProperty("Correspondences").GetValue(WorkingContainer) as ICollection<Correspondence>;

                                                            if ((WorkingContainer as Tenant).WorkingCorrespondence.id == 0)
                                                            {
                                                                CorrespondencesList.Add((WorkingContainer as Tenant).WorkingCorrespondence);
                                                                AddAuditEntry(WorkingContainer, "Created correspondence info for '" + (WorkingContainer as Tenant).WorkingCorrespondence.summary + "'");
                                                            }

                                                            WorkingContainer.GetType().GetMethod("Correspondences_RaisePropertiesChanged").Invoke(WorkingContainer, null);
                                                        } 
                                                    },
                                                    delegate {
                                                        // Ledger
                                                        if (WorkingContainer != null)
                                                        {
                                                            ICollection<LedgerRecord> LedgerRecordsList = WorkingContainer.GetType().GetProperty("LedgerRecords").GetValue(WorkingContainer) as ICollection<LedgerRecord>;

                                                            // Make some modifications to ledger record baed on dropdowns
                                                            WorkingLedgerRecord.ChargeType = null;
                                                            WorkingLedgerRecord.DepositType = null;
                                                            WorkingLedgerRecord.PaymentType = null;

                                                            if (WorkingLedgerRecord.WorkingType == LedgerRecord.LEDGERTYPE_CHARGE)
                                                            {
                                                                WorkingLedgerRecord.ChargeType = _repo.GetChargeTypeFromString(WorkingLedgerRecord.WorkingCategory);
                                                            }
                                                            else if (WorkingLedgerRecord.WorkingType == LedgerRecord.LEDGERTYPE_DEPOSIT)
                                                            {
                                                                WorkingLedgerRecord.DepositType = _repo.GetDepositTypeFromString(WorkingLedgerRecord.WorkingCategory);
                                                            }
                                                            else if (WorkingLedgerRecord.WorkingType == LedgerRecord.LEDGERTYPE_PAYMENT)
                                                            {
                                                                WorkingLedgerRecord.PaymentType = _repo.GetPaymentTypeFromString(WorkingLedgerRecord.WorkingCategory);
                                                            }

                                                            if (WorkingLedgerRecord.id == 0)
                                                            {
                                                                LedgerRecordsList.Add(WorkingLedgerRecord);
                                                                AddAuditEntry(WorkingContainer, "Created ledger record for '" + WorkingLedgerRecord.amount.ToString("C") + " " +
                                                                    WorkingLedgerRecord.Category + " " + WorkingLedgerRecord.LedgerType + " - " + ((DateTime)(WorkingLedgerRecord).transaction_date).ToString("MM/dd/yy"));
                                                            }
                                                            
                                                            WorkingContainer.GetType().GetMethod("LedgerRecords_RaisePropertiesChanged").Invoke(WorkingContainer, null);
                                                        }
                                                    }
                                                };

                            invokeMethods[(int)itemType].Invoke();

                            // Remove any deleted service calls, contacts, correspondences, and ledgers
                            if (WorkingContainer != null &&
                                itemType != ItemType.ServiceCall &&
                                itemType != ItemType.Contact &&
                                itemType != ItemType.Correspondence &&
                                itemType != ItemType.LedgerRecord)
                            {
                                RemoveInvisibleItems<ServiceCall>(WorkingContainer, "ServiceCalls");
                                RemoveInvisibleItems<Contact>(WorkingContainer, "Contacts");
                                RemoveInvisibleItems<Correspondence>(WorkingContainer, "Correspondences");
                                RemoveInvisibleItems<LedgerRecord>(WorkingContainer, "LedgerRecords");
                                RemoveInvisibleItems<FileContainer>(WorkingContainer, "FileContainers");

                                _repo.SaveChanges();
                            }

                            EventItemSaved(itemType);

                        }
                    },
                    (ItemType itemType) => true));
            }
        }
        private RelayCommand<ItemType> _newItemCommand;
        public RelayCommand<ItemType> NewItemCommand
        {
            get
            {
                return _newItemCommand
                    ?? (_newItemCommand = new RelayCommand<ItemType>(
                    (ItemType itemType) =>
                    {
                        if (NewItemCommand.CanExecute(null))
                        {
                            // NOTE: Indexes coupled with enum values!
                            var invokeMethods = new Action[] {
                                                   delegate { WorkingContainer = WorkingProperty = new PropertyMgmt.Model.Property(); WorkingProperty.state = DEFAULT_STATE; },
                                                   delegate {
                                                       DateTime firstOfNextMonth = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
                                                       WorkingContainer = WorkingTenant = new Tenant();
                                                       WorkingTenant.Contact = new Contact();

                                                       // Set lease start date to beginning day of next month
                                                       firstOfNextMonth = firstOfNextMonth.AddMonths(1);
                                                       WorkingTenant.lease_start = firstOfNextMonth;
                                                       WorkingTenant.lease_end = firstOfNextMonth.AddYears(1);

                                                       // Default contact info
                                                       WorkingTenant.Contact.first_name = "(None)";
                                                       WorkingTenant.Contact.last_name = "(None)";
                                                       WorkingTenant.Contact.phone1 = "(None)";
                                                       WorkingTenant.Contact.email = "(None)";

                                                   },
                                                   delegate { WorkingContainer = WorkingOwner = new Owner(); },
                                                   delegate { WorkingContainer = WorkingHOA = new HOA(); WorkingHOA.state = DEFAULT_STATE; },
                                                   delegate { WorkingContainer = WorkingVendor = new Vendor(); WorkingVendor.state = DEFAULT_STATE; },
                                                   delegate { WorkingContainer = WorkingPropertyMgmtCompany = new PropertyManager(); WorkingPropertyMgmtCompany.state = DEFAULT_STATE; },
                                                   
                                                   // Don't set working containers for anything below. They'll use one of the previously assigned containers above
                                                   delegate {
                                                       WorkingServiceCall = new ServiceCall();

                                                       WorkingServiceCall.time_placed = DateTime.Now;

                                                       if (WorkingContainer is Property)
                                                           WorkingServiceCall.Property = WorkingContainer as Property;
                                                       else if (WorkingContainer is Tenant)
                                                           WorkingServiceCall.Property = (WorkingContainer as Tenant).Property;
                                                       else if (WorkingContainer is Vendor)
                                                           WorkingServiceCall.Vendor = WorkingContainer as Vendor;
                                                   },
                                                   delegate { WorkingContact = new Contact(); WorkingContact.state = DEFAULT_STATE; },
                                                   delegate {
                                                        if (WorkingContainer is Tenant)
                                                        {
                                                            (WorkingContainer as Tenant).WorkingCorrespondence = new Correspondence();

                                                            (WorkingContainer as Tenant).WorkingCorrespondence.time_placed = DateTime.Now;
                                                            (WorkingContainer as Tenant).WorkingCorrespondence.Tenant = (WorkingContainer as Tenant);
                                                        }
                                                   },
                                                   delegate {
                                                       WorkingLedgerRecord = new LedgerRecord();

                                                   }
                                                };

                            invokeMethods[(int)itemType].Invoke();
                            EventNewItemDialog(itemType);
                        }
                    },
                    (ItemType itemType) => true));
            }
        }
        private RelayCommand<ItemType> _openItemCommand;
        public RelayCommand<ItemType> OpenItemCommand
        {
            get
            {
                return _openItemCommand
                    ?? (_openItemCommand = new RelayCommand<ItemType>(
                    (ItemType itemType) =>
                    {
                        if (OpenItemCommand.CanExecute(null))
                        {
                            bool execEvent = true;

                            // NOTE: Indexes coupled with enum values!
                            var invokeMethods = new Action[] {
                                                   delegate {
                                                       // Property opened
                                                       WorkingContainer = WorkingProperty;
                                                   },
                                                   delegate {
                                                       // Tenant opened
                                                       WorkingContainer = WorkingTenant;
                                                   },
                                                   delegate {
                                                       // Owner opened
                                                       WorkingContainer = WorkingOwner;
                                                   },
                                                   delegate {
                                                       // HOA opened
                                                       WorkingContainer = WorkingHOA;
                                                   },
                                                   delegate {
                                                       // Vendor opened
                                                       WorkingContainer = WorkingVendor;
                                                   },
                                                   delegate {
                                                       // Property mgmt company opened
                                                       WorkingContainer = WorkingPropertyMgmtCompany;
                                                   },
                                                   
                                                   // Don't set working containers for anything below. They'll use one of the previously assigned containers above
                                                   delegate {
                                                       // Service call opened

                                                       // If a service call is selected from the main screen, working container is purposely set to null. This allows the service call
                                                       // to be opened directly from the main ServiceCallList (instead of from a container)
                                                       PropertyInfo reflectionResult = null;

                                                       if (WorkingContainer != null)
                                                           reflectionResult = WorkingContainer.GetType().GetProperty("WorkingServiceCall");

                                                       if (reflectionResult != null)
                                                       {
                                                           WorkingServiceCall = reflectionResult.GetValue(WorkingContainer) as ServiceCall;

                                                           if (WorkingServiceCall == null)
                                                               execEvent = false;
                                                       }
                                                   },
                                                   delegate { 
                                                       // Contact opened
                                                       PropertyInfo reflectionResult = null;

                                                       if (WorkingContainer != null)
                                                           reflectionResult = WorkingContainer.GetType().GetProperty("WorkingContact");

                                                       if (reflectionResult != null)
                                                       {
                                                           WorkingContact = reflectionResult.GetValue(WorkingContainer) as Contact;

                                                           if (WorkingContact == null)
                                                               execEvent = false;
                                                       }
                                                   },
                                                   delegate {
                                                       // Correspondence opened
                                                       PropertyInfo reflectionResult = null;

                                                       if (WorkingContainer != null)
                                                           reflectionResult = WorkingContainer.GetType().GetProperty("WorkingCorrespondence");

                                                       if (reflectionResult != null)
                                                       {
                                                           WorkingCorrespondence = reflectionResult.GetValue(WorkingContainer) as Correspondence;

                                                           if (WorkingCorrespondence == null)
                                                               execEvent = false;
                                                       }
                                                   },
                                                   delegate {
                                                       // Ledger record opened
                                                       PropertyInfo reflectionResult = null;

                                                       if (WorkingContainer != null)
                                                           reflectionResult = WorkingContainer.GetType().GetProperty("WorkingLedgerRecord");

                                                       if (reflectionResult != null)
                                                       {
                                                           WorkingLedgerRecord = reflectionResult.GetValue(WorkingContainer) as LedgerRecord;

                                                           if (WorkingLedgerRecord == null)
                                                               execEvent = false;
                                                           else
                                                           {
                                                               WorkingLedgerRecord.WorkingType = WorkingLedgerRecord.LedgerType;
                                                               WorkingLedgerRecord.WorkingCategory = WorkingLedgerRecord.Category;
                                                           }
                                                       }
                                                   }
                                                };

                            invokeMethods[(int)itemType].Invoke();

                            if (itemType != ItemType.ServiceCall &&
                                itemType != ItemType.Contact &&
                                itemType != ItemType.Correspondence &&
                                itemType != ItemType.LedgerRecord)
                            {
                                // Clear working service call, contact, correspondence, and ledger record
                                PropertyInfo reflectionResult = null;

                                if ((reflectionResult = WorkingContainer.GetType().GetProperty("WorkingServiceCall")) != null)
                                    reflectionResult.SetValue(WorkingContainer, null);

                                if ((reflectionResult = WorkingContainer.GetType().GetProperty("WorkingContact")) != null)
                                    reflectionResult.SetValue(WorkingContainer, null);

                                if ((reflectionResult = WorkingContainer.GetType().GetProperty("WorkingCorrespondence")) != null)
                                    reflectionResult.SetValue(WorkingContainer, null);

                                if ((reflectionResult = WorkingContainer.GetType().GetProperty("WorkingLedgerRecord")) != null)
                                    reflectionResult.SetValue(WorkingContainer, null);
                            }

                            if (execEvent)
                                EventOpenItemDialog(itemType);
                        }
                    },
                    (ItemType itemType) => true));
            }
        }
        private RelayCommand<ItemType> _removeItemCommand;
        public RelayCommand<ItemType> RemoveItemCommand
        {
            get
            {
                return _removeItemCommand
                    ?? (_removeItemCommand = new RelayCommand<ItemType>(
                    (ItemType itemType) =>
                    {
                        if (RemoveItemCommand.CanExecute(null))
                        {
                            // NOTE: Indexes coupled with enum values!
                            var invokeMethods = new Action[] {
                                                   delegate {
                                                       // Property removed
                                                   },
                                                   delegate {
                                                       // Tenant removed
                                                   },
                                                   delegate {
                                                       // Owner removed
                                                   },
                                                   delegate {
                                                       // HOA removed
                                                   },
                                                   delegate {
                                                       // Vendor removed
                                                   },
                                                   delegate { 
                                                       // Property mgmt company removed
                                                   },
                                                   delegate {
                                                       // Service call removed

                                                       // If a service call is selected from the main screen, working container is purposely set to null. This allows the service call
                                                       // to be removed directly from the main ServiceCallList (instead of from a container)
                                                        if (WorkingContainer == null)
                                                            // Called from main screen
                                                        {
                                                            _repo.RemoveServiceCall(WorkingServiceCall);
                                                            ServiceCallList.Remove(WorkingServiceCall);
                                                            _repo.SaveChanges();
                                                        }
                                                        else
                                                        {
                                                            PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty("WorkingServiceCall");

                                                            if (reflectionResult != null)
                                                            {
                                                                ServiceCall svcCallRef = reflectionResult.GetValue(WorkingContainer) as ServiceCall;

                                                                if (svcCallRef != null)
                                                                    svcCallRef.Visible = Visibility.Collapsed;

                                                                // Clear working call
                                                                reflectionResult.SetValue(WorkingContainer, null);
                                                            }
                                                       }
                                                   },
                                                   delegate {
                                                       PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty("WorkingContact");

                                                       if (reflectionResult != null)
                                                       {
                                                           Contact contactRef = reflectionResult.GetValue(WorkingContainer) as Contact;

                                                           if (contactRef != null)
                                                               contactRef.Visible = Visibility.Collapsed;

                                                           // Clear working contact
                                                           reflectionResult.SetValue(WorkingContainer, null);
                                                        }
                                                   },
                                                   delegate {
                                                       PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty("WorkingCorrespondence");

                                                       if (reflectionResult != null)
                                                       {
                                                           Correspondence correspondenceRef = reflectionResult.GetValue(WorkingContainer) as Correspondence;

                                                           if (correspondenceRef != null)
                                                               correspondenceRef.Visible = Visibility.Collapsed;

                                                           // Clear working correspondence
                                                           reflectionResult.SetValue(WorkingContainer, null);
                                                        }
                                                   },
                                                   delegate {
                                                       PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty("WorkingLedgerRecord");

                                                       if (reflectionResult != null)
                                                       {
                                                           LedgerRecord ledgerRecordRef = reflectionResult.GetValue(WorkingContainer) as LedgerRecord;

                                                           if (ledgerRecordRef != null)
                                                               ledgerRecordRef.Visible = Visibility.Collapsed;

                                                           // Clear working ledger
                                                           reflectionResult.SetValue(WorkingContainer, null);
                                                        }
                                                   }
                                                };

                            invokeMethods[(int)itemType].Invoke();
                        }
                    },
                    (ItemType itemType) => true));
            }
        }
        private RelayCommand<ItemType> _cancelItemCommand;
        public RelayCommand<ItemType> CancelItemCommand
        {
            get
            {
                return _cancelItemCommand
                    ?? (_cancelItemCommand = new RelayCommand<ItemType>(
                    itemType =>
                    {
                        if (CancelItemCommand.CanExecute(itemType))
                        {
                            List<EntityChangeTracker> changedItems = null;

                            // NOTE: Indexes coupled with enum values!
                            var invokeMethods = new Action[] {
                                                   delegate {
                                                       changedItems = Clone.GetChangesMade<Property>((_repo as DataService)._db, WorkingProperty);
                                                       // Property cancelled
                                                   },
                                                   delegate {
                                                       // Tenant cancelled
                                                   },
                                                   delegate {
                                                       // Owner cancelled
                                                   },
                                                   delegate {
                                                       // HOA cancelled
                                                   },
                                                   delegate {
                                                       // Vendor cancelled
                                                   },
                                                   delegate { 
                                                       // Property mgmt company cancelled
                                                   },
                                                   delegate {
                                                       // Service call cancelled
                                                   },
                                                   delegate {
                                                       // Contact cancelled
                                                   },
                                                   delegate {
                                                       // Correspondence cancelled
                                                   },
                                                   delegate {
                                                       // Ledger record cancelled
                                                }
                            };

                            invokeMethods[(int)itemType].Invoke();

                            // Reset visibility on all items
                            if (WorkingContainer != null)
                            {
                                RemoveInvisibility<ServiceCall>(WorkingContainer, "ServiceCalls");
                                RemoveInvisibility<Contact>(WorkingContainer, "Contacts");
                                RemoveInvisibility<Correspondence>(WorkingContainer, "Correspondences");
                                RemoveInvisibility<LedgerRecord>(WorkingContainer, "LedgerRecords");
                                RemoveInvisibility<FileContainer>(WorkingContainer, "FileContainers");
                            }

                            _repo.UndoAllChanges();

                            if (WorkingContainer != null)
                            {
                                MethodInfo reflectionResult = null;

                                if ((reflectionResult = WorkingContainer.GetType().GetMethod("ServiceCalls_RaisePropertiesChanged")) != null)
                                    reflectionResult.Invoke(WorkingContainer, null);

                                if ((reflectionResult = WorkingContainer.GetType().GetMethod("CurrentBalance_RaisePropertiesChanged")) != null)
                                    reflectionResult.Invoke(WorkingContainer, null);
                            }

                            
                        }                        
                    },
                    itemType => true));
            }
        }
        #endregion
        #region Working variables

        /// <summary>
        /// The <see cref="WorkingContainer" /> property's name.
        /// </summary>
        public const string WorkingContainerPropertyName = "WorkingContainer";
        private object _workingContainer = null;
        /// <summary>
        /// Sets and gets the WorkingContainer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object WorkingContainer
        {
            get
            {
                return _workingContainer;
            }
            set
            {
                Set(() => WorkingContainer, ref _workingContainer, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingDocument" /> property's name.
        /// </summary>
        public const string WorkingDocumentPropertyName = "WorkingDocument";
        private FileContainer _workingDocument = null;
        /// <summary>
        /// Sets and gets the WorkingDocument property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public FileContainer WorkingDocument
        {
            get
            {
                return _workingDocument;
            }
            set
            {
                Set(() => WorkingDocument, ref _workingDocument, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingLedgerRecord" /> property's name.
        /// </summary>
        public const string WorkingLedgerRecordPropertyName = "WorkingLedgerRecord";
        private LedgerRecord _workingLedgerRecord = null;
        /// <summary>
        /// Sets and gets the WorkingLedgerRecord property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LedgerRecord WorkingLedgerRecord
        {
            get
            {
                return _workingLedgerRecord;
            }
            set
            {
                Set(() => WorkingLedgerRecord, ref _workingLedgerRecord, value);
            }
        }

        /// <summary>
        /// The <see cref="WorkingCorrespondence" /> property's name.
        /// </summary>
        public const string WorkingCorrespondencePropertyName = "WorkingCorrespondence";
        private Correspondence _workingCorrespondence = null;
        /// <summary>
        /// Sets and gets the WorkingCorrespondence property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Correspondence WorkingCorrespondence
        {
            get
            {
                return _workingCorrespondence;
            }
            set
            {
                Set(() => WorkingCorrespondence, ref _workingCorrespondence, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingContact" /> property's name.
        /// </summary>
        public const string WorkingContactPropertyName = "WorkingContact";
        private Contact _workingContact = null;
        /// <summary>
        /// Sets and gets the WorkingContact property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Contact WorkingContact
        {
            get
            {
                return _workingContact;
            }
            set
            {
                Set(() => WorkingContact, ref _workingContact, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingServiceCall" /> property's name.
        /// </summary>
        public const string WorkingServiceCallPropertyName = "WorkingServiceCall";
        private ServiceCall _workingServiceCall = null;
        /// <summary>
        /// Sets and gets the WorkingServiceCall property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ServiceCall WorkingServiceCall
        {
            get
            {
                return _workingServiceCall;
            }
            set
            {
                Set(() => WorkingServiceCall, ref _workingServiceCall, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingProperty" /> property's name.
        /// </summary>
        public const string WorkingPropertyPropertyName = "WorkingProperty";
        private Property _workingProperty = null;
        /// <summary>
        /// Sets and gets the SelectedProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Property WorkingProperty
        {
            get
            {
                return _workingProperty;
            }
            set
            {
                Set(() => WorkingProperty, ref _workingProperty, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingTenant" /> property's name.
        /// </summary>
        public const string WorkingTenantPropertyName = "WorkingTenant";
        private Tenant _workingTenant = null;
        /// <summary>
        /// Sets and gets the WorkingTenant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Tenant WorkingTenant
        {
            get
            {
                return _workingTenant;
            }
            set
            {
                Set(() => WorkingTenant, ref _workingTenant, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingOwner" /> property's name.
        /// </summary>
        public const string WorkingOwnerPropertyName = "WorkingOwner";
        private Owner _workingOwner = null;
        /// <summary>
        /// Sets and gets the WorkingOwner property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Owner WorkingOwner
        {
            get
            {
                return _workingOwner;
            }
            set
            {
                Set(() => WorkingOwner, ref _workingOwner, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingHOA" /> property's name.
        /// </summary>
        public const string WorkingHOAPropertyName = "WorkingHOA";
        private HOA _workingHOA = null;
        /// <summary>
        /// Sets and gets the WorkingHOA property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public HOA WorkingHOA
        {
            get
            {
                return _workingHOA;
            }
            set
            {
                Set(() => WorkingHOA, ref _workingHOA, value);
            }
        }
        /// <summary>
        /// The <see cref="WorkingVendor" /> property's name.
        /// </summary>
        public const string WorkingVendorPropertyName = "WorkingVendor";
        private Vendor _workingVendor = null;
        /// <summary>
        /// Sets and gets the WorkingVendor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Vendor WorkingVendor
        {
            get
            {
                return _workingVendor;
            }

            set
            {
                if (_workingVendor == value)
                {
                    return;
                }

                _workingVendor = value;
                RaisePropertyChanged(WorkingVendorPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="WorkingPropertyMgmtCompany" /> property's name.
        /// </summary>
        public const string WorkingPropertyMgmtCompanyPropertyName = "WorkingPropertyMgmtCompany";
        private PropertyManager _workingPropertyMgmtCompany = null;
        /// <summary>
        /// Sets and gets the WorkingPropertyMgmtCompany property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PropertyManager WorkingPropertyMgmtCompany
        {
            get
            {
                return _workingPropertyMgmtCompany;
            }
            set
            {
                Set(() => WorkingPropertyMgmtCompany, ref _workingPropertyMgmtCompany, value);
            }
        }
        #endregion
        #region Type lists
        // Redirect to Admin VM
        public AdministrationViewModel AdminVM = ViewModelLocator.Instance.AdministrationVM;
        public List<BusinessType> BusinessTypeList { get { return AdminVM.BusinessTypeList; } }
        public List<UtilitiesType> UtilityTypeList { get { return AdminVM.UtilityTypeList; } }
        public List<DepositType> DepositTypeList { get { return AdminVM.DepositTypeList; } }
        public List<PaymentType> PaymentTypeList { get { return AdminVM.PaymentTypeList; } }
        public List<ChargeType> ChargeTypeList { get { return AdminVM.ChargeTypeList; } }
        #endregion
        #region DataGrid lists
        /// <summary>
        /// The <see cref="PropertyList" /> property's name.
        /// </summary>
        public const string PropertyListPropertyName = "PropertyList";
        private ObservableCollection<Property> _propertyList = null;
        /// <summary>
        /// Sets and gets the PropertyList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Property> PropertyList
        {
            get
            {
                return _propertyList;
            }
            set
            {
                Set(() => PropertyList, ref _propertyList, value);
            }
        }
        /// <summary>
        /// The <see cref="TenantList" /> property's name.
        /// </summary>
        public const string TenantListPropertyName = "TenantList";
        private ObservableCollection<Tenant> _tenantList = null;
        /// <summary>
        /// Sets and gets the TenantList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Tenant> TenantList
        {
            get
            {
                return _tenantList;
            }
            set
            {
                Set(() => TenantList, ref _tenantList, value);
            }
        }
        /// <summary>
        /// The <see cref="OwnerList" /> property's name.
        /// </summary>
        public const string OwnerListPropertyName = "OwnerList";
        private ObservableCollection<Owner> _ownerList = null;
        /// <summary>
        /// Sets and gets the OwnerList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Owner> OwnerList
        {
            get
            {
                return _ownerList;
            }
            set
            {
                Set(() => OwnerList, ref _ownerList, value);
            }
        }
        /// <summary>
        /// The <see cref="HOAList" /> property's name.
        /// </summary>
        public const string HOAListPropertyName = "HOAList";
        private ObservableCollection<HOA> _HOAList = null;
        /// <summary>
        /// Sets and gets the HOAList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<HOA> HOAList
        {
            get
            {
                return _HOAList;
            }
            set
            {
                Set(() => HOAList, ref _HOAList, value);
            }
        }
        /// <summary>
        /// The <see cref="VendorList" /> property's name.
        /// </summary>
        public const string VendorListPropertyName = "VendorList";
        private ObservableCollection<Vendor> _vendorList = null;
        /// <summary>
        /// Sets and gets the VendorList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Vendor> VendorList
        {
            get
            {
                return _vendorList;
            }
            set
            {
                Set(() => VendorList, ref _vendorList, value);
            }
        }
        /// <summary>
        /// The <see cref="PropertyMgmtList" /> property's name.
        /// </summary>
        public const string PropertyMgmtListPropertyName = "PropertyMgmtList";
        private ObservableCollection<PropertyManager> _propertyMgmtList = null;
        /// <summary>
        /// Sets and gets the PropertyMgmtList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<PropertyManager> PropertyMgmtList
        {
            get
            {
                return _propertyMgmtList;
            }
            set
            {
                Set(() => PropertyMgmtList, ref _propertyMgmtList, value);
            }
        }
        /// <summary>
        /// The <see cref="ServiceCallList" /> property's name.
        /// </summary>
        public const string ServiceCallListPropertyName = "ServiceCallList";
        private ObservableCollection<ServiceCall> _serviceCallList = null;
        /// <summary>
        /// Sets and gets the ServiceCallList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ServiceCall> ServiceCallList
        {
            get
            {
                return _serviceCallList;
            }
            set
            {
                Set(() => ServiceCallList, ref _serviceCallList, value);
            }
        }
        #endregion

        #region Support functions
        private void RemoveInvisibility<T>(object WorkingContainer, string propertyName) where T: class
        {
            PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty(propertyName);
            Type itemType = typeof(T);

            if (reflectionResult != null)
            {
                ICollection<T> itemListRef = reflectionResult.GetValue(WorkingContainer) as ICollection<T>;

                foreach (T aItem in itemListRef)
                {
                    aItem.GetType().GetProperty("Visible").SetValue(aItem, Visibility.Visible);
                }
            }
        }

        private void RemoveInvisibleItems<T>(object WorkingContainer, string propertyName) where T : class
        {
            PropertyInfo reflectionResult = WorkingContainer.GetType().GetProperty(propertyName);
            Type itemType = typeof(T);

            if (reflectionResult != null)
            {
                ICollection<T> itemListRef = reflectionResult.GetValue(WorkingContainer) as ICollection<T>;
                Collection<T> itemsToRemove = new Collection<T>();

                object[] methodInvokeParams = new object[] { null, null };

                foreach (T aItem in itemListRef)
                {
                    if ((Visibility)(aItem.GetType().GetProperty("Visible").GetValue(aItem)) != Visibility.Visible)
                        itemsToRemove.Add(aItem);
                }

                foreach (T aItem in itemsToRemove)
                {
                    itemListRef.Remove(aItem);

                    if (itemType == typeof(ServiceCall))
                    {
                        AddAuditEntry(WorkingContainer, "Removed service call '" + (aItem as ServiceCall).summary + "'");
                        _repo.RemoveServiceCall(aItem as ServiceCall);
                        ServiceCallList.Remove(aItem as ServiceCall);
                    }
                    else if (itemType == typeof(Contact))
                    {
                        AddAuditEntry(WorkingContainer, "Removed contact info for '" + (aItem as Contact).FullName + "'");
                        _repo.RemoveContact(aItem as Contact);
                    }
                    else if (itemType == typeof(Correspondence))
                    {
                        AddAuditEntry(WorkingContainer, "Removed correspondence info for '" + (aItem as Correspondence).summary + "'");
                        _repo.RemoveCorrespondence(aItem as Correspondence);
                    }
                    else if (itemType == typeof(LedgerRecord))
                    {
                        AddAuditEntry(WorkingContainer, "Removed ledger record for '" + (aItem as LedgerRecord).amount.ToString("C") + " " +
                            (aItem as LedgerRecord).Category + " " + (aItem as LedgerRecord).LedgerType + " - " + ((DateTime)(aItem as LedgerRecord).transaction_date).ToString("MM/dd/yy"));
                        _repo.RemoveLedgerRecord(aItem as LedgerRecord);
                    }
                    else if (itemType == typeof(FileContainer))
                    {
                        AddAuditEntry(WorkingContainer, "Removed file '" + (aItem as FileContainer).file_name + "'");
                        _repo.RemoveFile((aItem as FileContainer).File);
                        _repo.RemoveFileContainer(aItem as FileContainer);
                    }
                }
            }
        }

        public void AddAuditEntry(object WorkingContainer, string info)
        {
            ICollection<AuditEntry> auditList = WorkingContainer.GetType().GetProperty("AuditEntries").GetValue(WorkingContainer) as ICollection<AuditEntry>;
            AuditEntry ae = new AuditEntry();

            ae.date_entered = DateTime.Now;
            ae.username = Environment.UserName;
            ae.info = info;

            auditList.Add(ae);
        }


        //private Tenant MakeCopy(Tenant sourceTenant)
        //{
        //    Tenant outputTenant = Clone.ShallowCopyEntity<Tenant>(sourceTenant);

        //    outputTenant.AuditEntries = null;
        //    outputTenant.AuditEntries = new HashSet<AuditEntry>();
        //    foreach (AuditEntry anEntry in sourceTenant.AuditEntries)
        //            outputTenant.AuditEntries.Add(anEntry);

        //    outputTenant.Contact = Clone.ShallowCopyEntity<Contact>(sourceTenant.Contact);

        //    outputTenant.Correspondences = new HashSet<Correspondence>();
        //    foreach (Correspondence aCorrespondence in sourceTenant.Correspondences)
        //        outputTenant.Correspondences.Add(aCorrespondence);

        //    outputTenant.FileContainers = new HashSet<FileContainer>();
        //    foreach (FileContainer aFileContainer in sourceTenant.FileContainers)
        //        outputTenant.FileContainers.Add(aFileContainer);

        //    outputTenant.LedgerRecords = new HashSet<LedgerRecord>();
        //    foreach (LedgerRecord aLedgerRecord in sourceTenant.LedgerRecords)
        //        outputTenant.LedgerRecords.Add(aLedgerRecord);

        //    outputTenant.Vehicles = new HashSet<Vehicle>();
        //    foreach (Vehicle aVehicle in sourceTenant.Vehicles)
        //        outputTenant.Vehicles.Add(aVehicle);

        //    return outputTenant;
        //}

        #endregion

        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}