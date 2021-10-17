// Created By: Ricardo Xavier
// Student ID: 2112018

using System;
using System.Collections.Generic;

namespace ChallengeWeek4_2112018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using a list allows for the user to enter as many team members as they have to,
            // since a list has a dynamic size
            List<TeamMember> teamMembers = new List<TeamMember>();

            // Turn all the possible values in the enum Profession into a string array for easier display to the user
            string[] professions = Enum.GetNames(typeof(Profession));

            while (true)
            {
                TeamMember teamMember = new TeamMember();

                while (string.IsNullOrEmpty(teamMember.Name))
                {
                    string name = GetInput("Please enter the member's name!");
                    if (GetConfirmation($"The member's name is \"{name}\"?"))
                    {
                        teamMember.Name = name;
                    }
                }

                while (teamMember.Age < 18)
                {
                    if (!int.TryParse(GetInput($"Please enter the {teamMember.Name}'s age!"), out int age))
                    {
                        Console.WriteLine("Please enter a valid age!");
                        continue;
                    }

                    if (age < 18)
                    {
                        Console.WriteLine("The member must be over 18!");
                        continue;
                    }

                    if (GetConfirmation($"Is the member {age} years old?"))
                    {
                        teamMember.Age = age;
                    }
                }

                while (true)
                {
                    Console.WriteLine("Please select a profession!");
                    Profession profession = (Profession)GetSelection(professions);

                    if (GetConfirmation($"The member will work as a {profession}?"))
                    {
                        teamMember.Profession = profession;
                        break;
                    }
                }

                while (true)
                {
                    bool workInPerson = GetConfirmation($"Is {teamMember.Name} available to work in person?");
                    string work = workInPerson ? "ABLE" : "NOT ABLE";

                    if (GetConfirmation($"So the member is {work} to work in person?"))
                    {
                        teamMember.WorkInPerson = workInPerson;
                        break;
                    }
                }

                if (!GetConfirmation($"Member Details: \n{teamMember}\nAre the details correct?"))
                {
                    Console.WriteLine("Please re-enter the member's details!");
                    continue;
                }

                teamMembers.Add(teamMember);

                Console.WriteLine("Thank you for your time!");
                Console.WriteLine($"You have {teamMembers.Count} member(s)");
                bool addMember = false;
                while (true)
                {
                    addMember = GetConfirmation("Want to add another member?");
                    if (!addMember && teamMembers.Count < 3)
                    {
                        Console.WriteLine("You need to have at least 3 team members to be able to complete a team!");
                        continue;
                    }
                    break;
                }

                if (addMember)
                {
                    continue;
                }

                break;
            }

            Console.WriteLine();
            Console.WriteLine("Here is your team:");
            Console.WriteLine(string.Join("\n\n", teamMembers));
        }

        static string GetInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        static bool GetConfirmation(string text)
        {
            // ToLower allows to have as minimal checks as possible, as the text the user inputs will be all lower case
            // no matter how the user typed it in
            string confirmation = GetInput($"{text} (y/n)").ToLower();
            // Checks if they have not input a correct option
            if (confirmation != "y" && confirmation != "n")
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                return GetConfirmation(text);
            }
            return confirmation == "y";
        }

        static int GetSelection(params string[] options)
        {
            // Put a number in front of the option to allow the user to easily chose an option
            // as opposed to them typing in the option and potentially mistyping
            string[] texts = new string[options.Length];
            for (int i = 0; i < options.Length; i++)
            {
                texts[i] = $"{i + 1}. {options[i]}";
            }
            Console.WriteLine(string.Join("\n", texts));

            while (true)
            {
                string input = Console.ReadLine();

                // Try to parse what the user inputted into an int
                if (!int.TryParse(input, out int option))
                {
                    // If it fails, they have not entered a valid option
                    Console.WriteLine("Please enter a valid option!");
                    continue;
                }
                // Turn whichever number the user entered into 0-indexed number to be easily used in lists/arrays
                option -= 1;

                if (option < 0 || option >= options.Length)
                {
                    Console.WriteLine("Please enter a valid option!");
                    continue;
                }
                return option;
            }
        }
    }
}
