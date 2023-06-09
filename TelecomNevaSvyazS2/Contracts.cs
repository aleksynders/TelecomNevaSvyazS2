//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelecomNevaSvyazS2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contracts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contracts()
        {
            this.ConnectedServices = new HashSet<ConnectedServices>();
        }
    
        public int SubscribersID { get; set; }
        public string ContractNumber { get; set; }
        public System.DateTime DateOfCinclusion { get; set; }
        public int TypeContractID { get; set; }
        public int PersonalAccount { get; set; }
        public Nullable<int> ReasonForTerminationID { get; set; }
        public Nullable<System.DateTime> TermibationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectedServices> ConnectedServices { get; set; }
        public virtual ReasonForTerminations ReasonForTerminations { get; set; }
        public virtual TypeContracts TypeContracts { get; set; }
        public virtual Subscribers Subscribers { get; set; }
    }
}
