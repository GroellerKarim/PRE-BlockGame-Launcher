using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseServer.Models
{
    [Serializable]
    public class User
    {
        // Add other User specific date. "Users" are also saved on the DatabaseServer
        public int Id { get; init; }
        public string Name { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(string n, string p)
        {
            this.Name = n;
            this.Password = p;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User u = (User)obj;

            if (u.Name.Equals(this.Name) & u.Password.Equals(this.Password))
            {
                return true;
            }
            return false;
        }

    }

}
