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
    
    public partial class KullaniciSonGirisTarihi
    {
        public int KullaniciSonGirisTarihiID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<System.DateTime> SonGirisTarihi { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
