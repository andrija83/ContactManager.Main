//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactManagerDB.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Family
    {
        public int Id { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int RelativeTypes { get; set; }
    
        public virtual Contact Contact { get; set; }
    }
}
