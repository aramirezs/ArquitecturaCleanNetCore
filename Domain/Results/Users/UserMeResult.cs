using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Domain.Results.Users
{
    [DataContract]
    public class UserMeResult
    {
        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "migration_admin")]
        public string MigrationAdmin { get; set; }


        [DataMember(Name = "full_name")]
        public string FullName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "cell_mobil")]
        public string CellMobil { get; set; }
        [DataMember(Name = "tele_house")]
        public string TeleHouse { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "dni")]
        public string Dni { get; set; }



        [DataMember(Name = "sex_user")]
        public string SexUser { get; set; }

        [DataMember(Name = "profile")]
        public string Profile { get; set; }


        [DataMember(Name = "permitions")]
        public List<RollType> Permitions
        {
            get
            {
                var result = new List<RollType>();            

                if (MigrationAdmin == "True")
                {
                    result.Add(RollType.MigrationAdmin);
                }

                return result;
            }
        }

        public UserMeResult(string user, string sexUser, string profile,
                            string migrationAdmin, string fullName, string lastName, string cellMobil, string teleHouse, string email, string address, string dni)
        {
            User = user;
            SexUser = sexUser;
            Profile = profile;           
            MigrationAdmin = migrationAdmin;
            FullName = fullName;
            LastName = lastName;
            CellMobil = cellMobil;
            TeleHouse = teleHouse;
            Email = email;
            Address = address;
            Dni = dni;
        }
    }
}
