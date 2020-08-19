using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyMgmt.Model;
using System.Collections.Generic;
using System.Linq;

namespace PropertyMgmt.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AdministrationViewModel : ViewModelBase
    {
        private IDataService _repo;

        private RelayCommand _saveChanges;

        /// <summary>
        /// Gets the SaveChanges.
        /// </summary>
        public RelayCommand SaveChanges
        {
            get
            {
                return _saveChanges
                    ?? (_saveChanges = new RelayCommand(
                    () =>
                    {
                        _repo.UpdateDepositTypes(DepositTypeList);
                        _repo.UpdateUtilityTypes(UtilityTypeList);
                        _repo.UpdateBusinessTypes(BusinessTypeList);
                        _repo.UpdatePaymentTypes(PaymentTypeList);
                        _repo.UpdateChargeTypes(ChargeTypeList);
                        _repo.SaveChanges();
                    }));
            }
        }

        /// <summary>
        /// Initializes a new instance of the AdministrationViewModel class.
        /// </summary>
        public AdministrationViewModel(IDataService repo)
        {
            _repo = repo;

            DepositTypeList = _repo.GetDepositTypeList().ToList();
            UtilityTypeList = _repo.GetUtilityTypeList().ToList();
            BusinessTypeList = _repo.GetBusinessTypeList().ToList();
            PaymentTypeList = _repo.GetPaymentTypeList().ToList();
            ChargeTypeList = _repo.GetChargeTypeList().ToList();
        }

        /// <summary>
        /// The <see cref="DepositTypeList" /> property's name.
        /// </summary>
        public const string DepositTypeListPropertyName = "DepositTypeList";
        
        private List<DepositType> _depositTypeList = null;
        
        /// <summary>
        /// Sets and gets the DepositTypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<DepositType> DepositTypeList
        {
            get
            {
                return _depositTypeList;
            }
            set
            {
                Set(() => DepositTypeList, ref _depositTypeList, value);
            }
        }

        /// <summary>
        /// The <see cref="UtilityTypeList" /> property's name.
        /// </summary>
        public const string UtilityTypeListPropertyName = "UtilityTypeList";

        private List<UtilitiesType> _utilityTypeList = null;

        /// <summary>
        /// Sets and gets the UtilityTypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<UtilitiesType> UtilityTypeList
        {
            get
            {
                return _utilityTypeList;
            }
            set
            {
                Set(() => UtilityTypeList, ref _utilityTypeList, value);
            }
        }

        /// <summary>
        /// The <see cref="BusinessTypeList" /> property's name.
        /// </summary>
        public const string BusinessTypeListPropertyName = "BusinessTypeList";

        private List<BusinessType> _businessTypeList = null;

        /// <summary>
        /// Sets and gets the BusinessTypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<BusinessType> BusinessTypeList
        {
            get
            {
                return _businessTypeList;
            }
            set
            {
                Set(() => BusinessTypeList, ref _businessTypeList, value);
            }
        }

        /// <summary>
        /// The <see cref="PaymentTypeList" /> property's name.
        /// </summary>
        public const string PaymentTypeListPropertyName = "PaymentTypeList";

        private List<PaymentType> _paymentTypeList = null;

        /// <summary>
        /// Sets and gets the PaymentTypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<PaymentType> PaymentTypeList
        {
            get
            {
                return _paymentTypeList;
            }
            set
            {
                Set(() => PaymentTypeList, ref _paymentTypeList, value);
            }
        }

        /// <summary>
        /// The <see cref="ChargeTypeList" /> property's name.
        /// </summary>
        public const string ChargeTypeListPropertyName = "ChargeTypeList";

        private List<ChargeType> _chargeTypeList = null;

        /// <summary>
        /// Sets and gets the ChargeTypeList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ChargeType> ChargeTypeList
        {
            get
            {
                return _chargeTypeList;
            }
            set
            {
                Set(() => ChargeTypeList, ref _chargeTypeList, value);
            }
        }
    }
}