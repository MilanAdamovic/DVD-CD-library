//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DvdClubFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Iznajmljivanje
    {
        public int IznajmljivanjeID { get; set; }
        public int ClanID { get; set; }
        public int FilmID { get; set; }
        public System.DateTime DatumIznajmljivanja { get; set; }
        public System.DateTime DatumVracanja { get; set; }
        public double Cena { get; set; }
    
        public virtual Clan Clan { get; set; }
        public virtual Film Film { get; set; }
    }
}
