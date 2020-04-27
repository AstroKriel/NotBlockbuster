using System;

namespace NotBlockbuster {
    public class Member {
        public Member(string name, string address, string contact_number) {
            this.name           = name;
            this.address        = address;
            this.contactNumber  = contact_number;
        }

        public string name { get; set; }
        public string address { get; set; }
        public string contactNumber { get; set; }

        public override string ToString() {
            return $@"Member Details:
                Name: {name}
                Address: {address}
                Contact Number: {contactNumber}
                ";
        }
    }
}
