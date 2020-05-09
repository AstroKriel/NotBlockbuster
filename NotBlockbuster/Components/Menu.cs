using System;

namespace NotBlockbuster.Components {
    public class Menu {
        ////////////////////////////////////////////////////////////////////////
        /// MAIN MENU
        ////////////////////////////////////////////////////////////////////////

        /* Main Menu
             * Returns the users option:
             * 1: Staff Login
             * 2: Member Login
             * 0: Exit
             */
        static public void MainMenu() {
            // Initialise important varbiales
            string user_input = "NA";
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("Welcome to Blockbuster's Community Library");
                Console.WriteLine("================ Main Menu ===============");
                Console.WriteLine("\t 1. Staff Login");
                Console.WriteLine("\t 2. Member Login");
                Console.WriteLine("\t 0. Exit");
                Console.WriteLine("==========================================\n");
                // Display that the previous input was not correct
                if (!bool_first_entry) { Console.WriteLine("Your choice of {0} was not a valid option.", user_input); }
                // Receive user input
                Console.Write("Please choose from (1-2, or '0' to exit): ");
                user_input = Console.ReadLine();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
            } while (!( user_input.Equals("0") || user_input.Equals("1") || user_input.Equals("2") ));
            if (user_input.Equals("0")) {
                // If user chose to exit
                Console.WriteLine("Shutting down...");
                MainProgram.program_finished = true;
                return;
            } else if (user_input.Equals("1")) {
                // To use the staff menu, verify the user is a staff member
                StaffMenus.StaffLogin();
            } else {
                // To use the member menu, verify the user is a valid member
                MemberMenus.MemberLogin();
            }
        }
    }
}
