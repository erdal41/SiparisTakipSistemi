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
    
    public partial class BilesenKProfilleri
    {
        public int BilesenKProfilID { get; set; }
        public Nullable<int> BilesenID { get; set; }
        public Nullable<int> KProfilID { get; set; }
        public Nullable<decimal> UzunlukTutari { get; set; }
        public Nullable<decimal> KProfilAgirlik { get; set; }
        public Nullable<decimal> KProfiUzunluk { get; set; }
    
        public virtual Bilesenler Bilesenler { get; set; }
        public virtual KutuProfiller KutuProfiller { get; set; }
    }
}
