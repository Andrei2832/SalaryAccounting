//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalaryAccounting.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saiary
    {
        public int idSalary { get; set; }
        public Nullable<int> idUser { get; set; }
        public int SalaryDay { get; set; }
        public int SalaryPay { get; set; }
        public int PaymentHolidaysDay { get; set; }
        public int PaymentHolidaysPay { get; set; }
        public int HolidaySurchargeDay { get; set; }
        public int HolidaySurchargePay { get; set; }
        public int SurchargeWithoutSurchargesDay { get; set; }
        public int SurchargeWithoutSurchargesPay { get; set; }
        public int DifficultyAllowanceDay { get; set; }
        public int DifficultyAllowancePay { get; set; }
        public int PrizeDay { get; set; }
        public int PrizePay { get; set; }
        public int ratioDay { get; set; }
        public int ratioPay { get; set; }
    
        public virtual User User { get; set; }
    }
}