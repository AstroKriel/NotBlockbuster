using System;

namespace NotBlockbuster {
    public class Member {
        // Member object constructor
        public Member(string first_name, string last_name, string address, string contact_number) {
            Username       = last_name + first_name;
            FirstName      = first_name;
            LastName       = last_name;
            Address        = address;
            ContactNumber  = contact_number;
        }

        // Get and Set movie properties
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        // Print member information
        public override string ToString() {
            return $@"Member Details:
                Name: {FirstName} {LastName}
                Address: {Address}
                Contact Number: {ContactNumber}
                ";
        }

        // Define member comparitor (case insensitive)
        // Returns (-1) if prior is smaller, (+1) if prior is larger, (0) if equal.
        public int CompareTo(string other_username) { return string.Compare(this.Username.ToString().ToLower(), other_username.ToLower()); }
    }
}
