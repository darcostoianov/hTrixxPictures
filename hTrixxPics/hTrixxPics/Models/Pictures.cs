//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hTrixxPics.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class Pictures
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FileLocation { get; set; }
        public string Title { get; set; }
        public string Descriptinon { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
