//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsLenta.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int comments_id { get; set; }
        public int news_id { get; set; }
        public string text_comment { get; set; }
        public Nullable<System.DateTime> date_make { get; set; }
        public Nullable<System.DateTime> date_update { get; set; }
        public int user_id { get; set; }
    
        public virtual News News { get; set; }
        public virtual Users Users { get; set; }
    }
}
