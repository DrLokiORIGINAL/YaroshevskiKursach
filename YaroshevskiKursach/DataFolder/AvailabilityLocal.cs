//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YaroshevskiKursach.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class AvailabilityLocal
    {
        public int IdAvailabilityLocal { get; set; }
        public int IdStore { get; set; }
        public int IdStaff { get; set; }
        public int QuantityAvailabilityLocal { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual Store Store { get; set; }
    }
}