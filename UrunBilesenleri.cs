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
    
    public partial class UrunBilesenleri
    {
        public int UrunBilesenleriID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public Nullable<int> BilesenID { get; set; }
        public Nullable<int> UrunBilesenleriAdet { get; set; }
        public Nullable<decimal> UrunBilesenleriAdetAgirlik { get; set; }
        public Nullable<decimal> UrunBilesenleriAdetTutari { get; set; }
    
        public virtual Bilesenler Bilesenler { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
