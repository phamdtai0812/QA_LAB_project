//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QA_LAB_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LAB_HYDRATE_ANALYSIS
    {
        public string HA_ID { get; set; }
        public string HA_TYPE { get; set; }
        public Nullable<System.DateTime> SADATE { get; set; }
        public string CONTAINERID { get; set; }
        public string ADATE { get; set; }
        public Nullable<decimal> REFLECTANCE { get; set; }
        public Nullable<decimal> LEACHSODA { get; set; }
        public Nullable<decimal> MOISTURE { get; set; }
        public int HYDRATE_ID { get; set; }
    }
}
