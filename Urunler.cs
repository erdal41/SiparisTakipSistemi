//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiparisTakipSistemi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.MaliyetDetayi = new HashSet<MaliyetDetayi>();
            this.UrunBilesenleri = new HashSet<UrunBilesenleri>();
            this.UrunEkBilesenleri = new HashSet<UrunEkBilesenleri>();
            this.UrunEkIslemMaliyetleri = new HashSet<UrunEkIslemMaliyetleri>();
        }
    
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<int> UrunAdet { get; set; }
        public string UrunBirimi { get; set; }
        public Nullable<decimal> UrunAgirlik { get; set; }
        public Nullable<decimal> UrunBirimFiyati { get; set; }
        public Nullable<int> KaydedenID { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaliyetDetayi> MaliyetDetayi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunBilesenleri> UrunBilesenleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunEkBilesenleri> UrunEkBilesenleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunEkIslemMaliyetleri> UrunEkIslemMaliyetleri { get; set; }
    }
}
