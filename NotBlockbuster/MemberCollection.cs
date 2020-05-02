using System;

namespace NotBlockbuster {
    public class MemberCollection {
        public Member[] ListMembers;
        public int ActiveMembers;

        public MemberCollection() {
            ListMembers = new Member[10]; // assume that there are a max of 10 members (oof, Blockbuster is _struggling_)
            ActiveMembers = 0; // variable to indicate how many customers have been added
        }

        public void AddMember(Member member) {
            if (ActiveMembers < ListMembers.Length) { ListMembers[ActiveMembers++] = member; }
            else { Console.WriteLine("Could not add the member. The maximum number of members have already been reached!\n"); }
        }

        // Check to see if a member already exists
        // Assume that member first and last name combinations are unique (i.e. the usernames are unique)
        public Member SearchMember(string first_name, string last_name) {
            for (int i = 0; i < ActiveMembers; i++) {
                // If the member already exists, then return the member object
                if (ListMembers[i].CompareTo(last_name + first_name) == 0) { return ListMembers[i]; }
            }
            // If the member doesn't already exist, then return nothing
            return null;
        }

        public void PrintActiveMembers() {
            Console.WriteLine("List of active member's usernames:");
            for (int i = 0; i < ActiveMembers; i++) { Console.WriteLine("\t- {0}", ListMembers[i].Username); }
            Console.Write("\n");
        }
    }
}
