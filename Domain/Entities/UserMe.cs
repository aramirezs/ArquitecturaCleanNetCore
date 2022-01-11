using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserMe
    {
        public string NamerCort { get; set; }
        public string User { get; set; }
        public string SexUser { get; set; }
        //public string CodeProfile { get; set; }
        //public string DescriptionProfile { get; set; }

        public string FullName { get; set; }
        public string LastName { get; set; }
        public string CellMobil { get; set; }
        public string TeleHouse { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Dni { get; set; }


        public string Profile { get; set; }
        public Permit Permit { get; set; }
    }
    public class Permit
    {
/*        public bool MigrationVenta { get; set; }
        public bool MigrationNoteCredit { get; set; }
        public bool MigrationCancellation { get; set; }
        public bool MigrationAnul { get; set; }*/
        public bool MigrationAdmin { get; set; }

    }
}
