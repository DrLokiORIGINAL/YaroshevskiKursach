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
    
    public partial class Clothes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clothes()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int IdClothes { get; set; }
        public int IdCollection { get; set; }
        public int IdSeason { get; set; }
        public int IdTypeOfClothing { get; set; }
        public byte[] PhotoClothes { get; set; }
        public int IdGender { get; set; }
    
        public virtual Collection Collection { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Season Season { get; set; }
        public virtual TypeOfClothing TypeOfClothing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
