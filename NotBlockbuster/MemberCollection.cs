using System;

namespace NotBlockbuster {
    public class MemberCollection {
        public Member[] members;
        public int counter;

        public MemberCollection() {
            members = new Member[10];
            counter = 0;
        }

        public void AddMember(Member member) {
            this.members[counter++] = member;
        }
    }
}
