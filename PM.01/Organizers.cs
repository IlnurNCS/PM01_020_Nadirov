//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PM._01
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organizers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otch { get; set; }
        public string Mail { get; set; }
        public System.DateTime Date_birth { get; set; }
        public int Country_ID { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
    
        public virtual Country Country { get; set; }
    }
}
