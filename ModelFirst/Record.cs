//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public int Record_number { get; set; }
        public System.DateTime Date { get; set; }
        public double Bottom_line { get; set; }
        public int Game_code { get; set; }
        public int Card_number { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Game_type Game_type { get; set; }
    }
}
