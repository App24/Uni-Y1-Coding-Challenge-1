using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeWeek4_2112018
{
    struct TeamMember
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Profession Profession { get; set; }
        public bool WorkInPerson { get; set; }

        // Override ToString allows for clean output of the struct without having to access each variable individually
        // whenever it is needed to print out the struct
        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nProfession: {Profession}\nCan Work In Person: {(WorkInPerson ? "Yes":"No")}";
        }
    }

    enum Profession
    {
        Programmer,
        Designer,
        Artist,
        Audio
    }
}
