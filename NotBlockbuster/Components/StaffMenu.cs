using System;
using System.Globalization;

namespace NotBlockbuster.Components {
    public class StaffMenus {
        ////////////////////////////////////////////////////////////////////////
        /// STAFF MENU
        ////////////////////////////////////////////////////////////////////////

        /* Staff Login
             * Returns a flag indicating if the staff login was successful.
             * true:  the login was successful
             * false: the login failed, or was canceled
             */
        static public void StaffLogin() {
            // Initialise important variables
            int user_tries = 5;
            string user_id;
            string user_pw;
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the login menu
                Console.WriteLine("Welcome to Blockbuster's Community Library");
                Console.WriteLine("=============== Staff Login ==============");
                Console.WriteLine("\t To cancel login:");
                Console.WriteLine("\t Set username or password to '0'");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("Please enter the staff login details (or '0' to return to the main menu).");
                // Let the user know that their login failed
                if (!bool_first_entry) {
                    Console.WriteLine("\nIncorrect username and password combination.");
                    Console.WriteLine("You have {0} remaining tries.\n", user_tries);
                }
                // Receive the user's username
                Console.Write("Enter Username: ");
                user_id = Console.ReadLine();
                // Receive the user's password
                Console.Write("Enter Password: ");
                user_pw = Console.ReadLine();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // If the user chooses to cancel log in
                if (string.Equals(user_id, "0") || string.Equals(user_pw, "0")) { return; }
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("You entered the wrong login details too many time.");
                    return; // return the user to main menu
                }
            } while (!( user_id.Equals("staff") && user_pw.Equals("today123") ));
            // If the user was able to log in successfully, then use the staff menu
            MainProgram.session_finished = false;
            while (!MainProgram.session_finished) { StaffMenu(); }
        }

        /* Staff Menu
             * Returns the users option:
             * 1: Add a new movie DVD
             * 2: Removie a movie DVD
             * 3: Register a new member
             * 4: Find a registered member's phone number
             * 0: Return to main menu
             */
        static public void StaffMenu() {
            // Initialise important varbiales
            string user_input = "NA";
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("=============== Staff Menu ===============");
                Console.WriteLine("\t 1. Add a new movie DVD");
                Console.WriteLine("\t 2. Remove a movie DVD");
                Console.WriteLine("\t 3. Register a new member");
                Console.WriteLine("\t 4. Find a registered member's phone number");
                Console.WriteLine("\t 5. Display the BST node-structure.");
                Console.WriteLine("\t 0. Return to main menu");
                Console.WriteLine("==========================================\n");
                // Display that the previous input was not correct
                if (!bool_first_entry) { Console.WriteLine("Your choice of {0} was not a valid option.", user_input); }
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Receive user input
                Console.Write("Please choose from (1-5, or '0' to return to the main menu): ");
                user_input = Console.ReadLine();
            } while (!( user_input.Equals("0") || user_input.Equals("1") || user_input.Equals("2") ||
                        user_input.Equals("3") || user_input.Equals("4") || user_input.Equals("5") ));
            if (user_input.Equals("0")) {
                //MainMenu(); // return the user to main menu
                MainProgram.session_finished = true;
                return;
            } else if (user_input.Equals("1")) {
                // Add a new movie
                StaffAddMovie();
            } else if (user_input.Equals("2")) {
                // Remove a movie
                StaffRemoveMovie();
            } else if (user_input.Equals("3")) {
                // Add a new member
                StaffAddMember();
            } else if (user_input.Equals("4")) {
                // Search for a member's contact details
                StaffSearchPhoneNumber();
            } else if (user_input.Equals("5")) {
                // Display the BST node structure
                StaffPrintBST();
            }
        }

        /* Add Movie
             * Returns:
             * 2: Add another movie
             * 1: The movie was successfully deleted
             * 0: Return to main menu
             */
        static public void StaffAddMovie() {
            // Initialise important varbiales
            string user_input;
            string user_title;
            int user_genre;
            int user_class;
            string user_director;
            string user_star;
            int user_length;
            DateTime user_date;
            int user_copies;
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the staff menu options
                Console.WriteLine("============= Add a Movie =============");
                Console.WriteLine("\t Enter movie details.");
                Console.WriteLine("==========================================\n");
                // Ask for the user's input
                if (!bool_first_entry) { Console.WriteLine("Please re-enter the movie's details."); }
                else { Console.WriteLine("Please enter the movie's details."); }
                // Collect all movie details
                // 1. Movie title
                // Perform the loop until the user has input a string
                do { Console.Write("\t Title: ");
                    user_title = Console.ReadLine();
                } while (user_title.Length == 0);
                // 2. Movie genre
                // Perform the loop until the user has chosen a valid option
                Console.WriteLine("\t Genre Options:");
                Console.WriteLine("\t\t 0: Action");
                Console.WriteLine("\t\t 1: Adventure");
                Console.WriteLine("\t\t 2: Animated");
                Console.WriteLine("\t\t 3: Comedy");
                Console.WriteLine("\t\t 4: Drama");
                Console.WriteLine("\t\t 5: Family");
                Console.WriteLine("\t\t 6: Other");
                Console.WriteLine("\t\t 7: SciFi");
                Console.WriteLine("\t\t 8: Thriller");
                do {Console.Write("\t Please choose from (0-8): ");
                    user_input = Console.ReadLine();
                    int.TryParse(user_input, out user_genre);
                } while (   !Enum.IsDefined(typeof(Movie.Genres), user_genre) ||
                            !int.TryParse(user_input, out user_genre) );
                // 3. Movie classification
                // Perform the loop until the user has chosen a valid option
                Console.WriteLine("\t Classification Options:");
                Console.WriteLine("\t\t 0: General (G)");
                Console.WriteLine("\t\t 1: ParentalGuidance");
                Console.WriteLine("\t\t 2: Mature");
                Console.WriteLine("\t\t 3: MatureAccompanied");
                do {Console.Write("\t Please choose from (0-3): ");
                    user_input = Console.ReadLine();
                    int.TryParse(user_input, out user_class);
                } while (   !Enum.IsDefined(typeof(Movie.Classifications), user_class) ||
                            !int.TryParse(user_input, out user_class) );
                // 4. Movie director
                // Perform the loop until the user has input a string
                do { Console.Write("\t Director: ");
                    user_director = Console.ReadLine();
                } while (user_director.Length == 0);
                // 5. Movie star
                // Perform the loop until the user has input a string
                do { Console.Write("\t Starring: ");
                    user_star = Console.ReadLine();
                } while (user_star.Length == 0);
                // 6. Movie duration
                // Perform the loop until the user has input a postive number
                do { Console.Write("\t Duration: ");
                    user_input = Console.ReadLine();
                } while (!int.TryParse(user_input, out user_length) || (Convert.ToInt32(user_length) < 0));
                // 7. Movie release date
                do {Console.Write("\t Release date (dd/mm/yyyy): ");
                } while (   !DateTime.TryParseExact(Console.ReadLine(), new string[] { "d/M/yyyy", "dd/MM/yyyy" },
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out user_date) );
                // 8. Number of movie copies
                // Perform the loop until the user has chosen a positive number
                do { Console.Write("\t Number of copies: ");
                    user_input = Console.ReadLine();
                } while ( !int.TryParse(user_input, out user_copies) || (Convert.ToInt32(user_input) < 0) );
                // Check the details are correct
                Console.WriteLine("\nThe movie details you entered are:");
                Console.WriteLine($@"Movie Details:
                    Title: {user_title}
                    Genre: {(Movie.Genres)user_genre}
                    Classification: {(Movie.Classifications)user_class}
                    Director: {user_director}
                    Stars: {user_star}
                    Duration: {user_length}
                    Release Date: {user_date.ToShortDateString()}
                    Number of copies: {user_copies}
                    ");
                // Perform this loop until the user has chosen a valid option
                do {Console.Write("Are the movie's DETAILS correct? (Y)es / (N)o / (0 to cancel): ");
                    user_input = Console.ReadLine().ToLower();
                } while (!( user_input.Equals("y") || user_input.Equals("n") || user_input.Equals("0") ));
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
            } while (user_input.Equals("n"));
            // If the user has asked to cancel, then return them to the staff menu
            if (user_input.Equals("0")) {
                //StaffMenu();
                return;
            }
            // If the user has confirmed the movie details are correct
            if (user_input.Equals("y")) {
                if (MainProgram.movie_collec.SearchMovie(user_title) == null) {
                    // If the movie doesn't exist
                    MainProgram.movie_collec.InsertMovie(new Movie( user_title,
                                                                    (Movie.Genres)user_genre,
                                                                    (Movie.Classifications)user_class,
                                                                    user_director,
                                                                    user_star,
                                                                    user_length,
                                                                    user_date,
                                                                    user_copies));
                } else {
                    // If the movie exists, check if the user would like to update the movie details
                    Console.WriteLine("\nThe movie already exists. Would you like to update the movie's details?");
                    // Perform this loop until the user has chosen 'yes' or 'no'
                    do {Console.Write("(Y)es / (N)o: ");
                        user_input = Console.ReadLine().ToLower();
                    } while (!( user_input.Equals("y") || user_input.Equals("n") ));
                    if (user_input.Equals("y")) {
                        // If the user would like to update the movie details
                        MainProgram.movie_collec.InsertMovie(new Movie( user_title,
                                                                        (Movie.Genres)user_genre,
                                                                        (Movie.Classifications)user_class,
                                                                        user_director,
                                                                        user_star,
                                                                        user_length,
                                                                        user_date,
                                                                        user_copies));
                    } else { Console.WriteLine("\nThe changes have been discarded.\n"); } // Otherwise, discard movie details
                }
            }
            // Check if the user would like to add another movie
            // Perform this loop until the user has chosen 'yes' or 'no'
            do {Console.Write("Would you like to ADD another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more movies, stay on the ADD MOVIE menu
            if (string.Equals(user_input, "y")) { StaffAddMovie(); }
            // Otherwise, return them to the staff menu
            return;
        }

        /* Delete Movie
             * Returns:
             * 2: Remove another movie
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
        static public void StaffRemoveMovie() { // TODO: remove movie from all users
            // Initialise important variables
            int user_tries = 5;
            string user_input;
            string movie_title = "NA";
            bool bool_first_entry = true;
            Movie movie_to_delete;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("============= Delete a Movie =============");
                Console.WriteLine("\t Enter the movie's title.");
                Console.WriteLine("\t 1. Return to staff menu.");
                Console.WriteLine("\t 0. Return to main menu.");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("Please enter the movie's title (or choose option '1' or '0').");
                // Display that the previous input was not correct
                if (!bool_first_entry) {
                    Console.WriteLine("Could not remove the movie. The movie '{0}' does not exist in the database.\n", movie_title);
                    Console.WriteLine("You have {0} remaining tries.", user_tries);
                }
                Console.Write("\t Title: ");
                // Receive user input
                movie_title = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("The movie are looking for is not in the database.");
                    return;
                }
            } while (   ( !(movie_title.Equals("0") || movie_title.Equals("1") ) &&
                        (MainProgram.movie_collec.SearchMovie(movie_title) == null) ) ||
                        (movie_title.Length == 0));
            // If the user is asking to return to the main menu
            if (movie_title.Equals("0")) { MainProgram.session_finished = true; return; }
            // If the user is asking to return to the staff menu
            else if (movie_title.Equals("1")) { return; }
            // Make the user confirm that they would like to return the movie
            movie_to_delete = MainProgram.movie_collec.SearchMovie(movie_title);
            do {Console.Write("Are you sure you would like to remove all copies of '{0}'? (Y)es / (N)o: ", movie_to_delete.Title);
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // Only delete the movie if there all the copies are returned to the store
            if (movie_to_delete.RentingUsers.Count == 0) { MainProgram.movie_collec.DeleteMovie(movie_to_delete.Title); }
            else {
                Console.WriteLine("This movie cannot be deleted. Some copies of the movie is currently being rented.");
                Console.WriteLine("The following users are still renting this movie:");
                foreach (Member member in movie_to_delete.RentingUsers) { Console.WriteLine("\t - {0} {1}", member.FirstName, member.LastName); }
            }
            // Check if the user would like to add another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("Would you like to REMOVE another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to remove another movie, then stay on the DELETE MOVIE menu
            if (string.Equals(user_input, "y")) { StaffRemoveMovie(); }
            // Otherwise, return to the staff menu
            return;
        }

        /* Add Member
             * Returns:
             * 2: Add another member
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
        static public void StaffAddMember() {
            // Initialise important varbiales
            string first_name;
            string last_name;
            string address;
            string contact_number;
            string password;
            int temp_num;
            string user_input;
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the staff menu options
                Console.WriteLine("============= Add a Member =============");
                Console.WriteLine("\t Enter member details.");
                Console.WriteLine("==========================================\n");
                // Ask for the user's input
                if (!bool_first_entry) { Console.WriteLine("Please re-enter the member's details."); }
                else { Console.WriteLine("Please enter the member's details."); }
                // Collect all member details
                // 1. Member's first name
                // Perform the loop until the user has input a string
                do { Console.Write("\t First name: ");
                    first_name = Console.ReadLine();
                } while (first_name.Length == 0);
                // 2. Member's last name
                // Perform the loop until the user has input a string
                do { Console.Write("\t Last name: ");
                    last_name = Console.ReadLine();
                } while (last_name.Length == 0);
                // 3. Member's address
                // Perform the loop until the user has input a string
                do { Console.Write("\t Address: ");
                    address = Console.ReadLine();
                } while (address.Length == 0);
                // 4. Member's contact phone number
                // Perform the loop until the user has input a string of numbers
                do { Console.Write("\t Contact number: ");
                    contact_number = Console.ReadLine();
                } while ( !int.TryParse(contact_number, out temp_num) || (Convert.ToInt32(temp_num) < 0));
                // 5. Member's password
                // Perform the loop until the user has input a string
                do { Console.Write("\t Password: ");
                    password = Console.ReadLine();
                } while (password.Length == 0);
                // Check the details are correct
                Console.WriteLine("\nThe member details you entered are:");
                Console.WriteLine($@"Member Details:
                    Name: {first_name} {last_name}
                    Address: {address}
                    Contact Number: {contact_number}
                    Password: {password}
                    ");
                // Perform this loop until the user has chosen a valid option
                do {Console.Write("Are the member's DETAILS correct? (Y)es / (N)o / (0 to cancel): ");
                    user_input = Console.ReadLine().ToLower();
                } while (!( user_input.Equals("y") || user_input.Equals("n") || user_input.Equals("0") ));
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
            } while (user_input.Equals("n"));
            // If the user has asked to cancel, then return them to the staff menu
            if (user_input.Equals("0")) {
                return;
            }
            // If the user has confirmed the member details are correct
            if (user_input.Equals("y")) {
                if (MainProgram.member_collec.SearchForMember(first_name, last_name) == null) {
                    // If the member doesn't exist
                    MainProgram.member_collec.AddMember(new Member(first_name, last_name, address, contact_number, password) );
                } else {
                    // If the member exists, don't add the member
                    Console.WriteLine("Could not add the memeber. A member already exists with this name.");
                }
            }
            // Check if the user would like to add another member
            // Perform this loop until the user has chosen 'yes' or 'no'
            do {Console.Write("Would you like to ADD another member? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more members, stay on the ADD MEMBER menu
            if (string.Equals(user_input, "y")) { StaffAddMember(); }
            // Otherwise, return them to the staff menu
            return;
        }

        /* Find Member Number
             * Returns:
             * 2: Find another member's number
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
        static public void StaffSearchPhoneNumber() {
            // Initialise important varbiales
            Member temp_member;
            string first_name;
            string last_name;
            string user_input = "NA";
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the staff menu options
                Console.WriteLine("====== Find a Member's Phone Number ======");
                Console.WriteLine("\t Enter member details.");
                Console.WriteLine("==========================================\n");
                // Ask for the user's input
                if (!bool_first_entry) { Console.WriteLine("Please re-enter the member's details."); }
                else { Console.WriteLine("Please enter the member's details."); }
                // Collect all member details
                // 1. Member's first name
                // Perform the loop until the user has input a string
                do { Console.Write("\t First name: ");
                    first_name = Console.ReadLine();
                } while (first_name.Length == 0);
                // 2. Member's last name
                // Perform the loop until the user has input a string
                do { Console.Write("\t Last name: ");
                    last_name = Console.ReadLine();
                } while (last_name.Length == 0);
                // Perform this loop until the user has chosen a valid option
                do {Console.Write("Are the member's DETAILS correct? (Y)es / (N)o / (0 to cancel): ");
                    user_input = Console.ReadLine().ToLower();
                } while (!( user_input.Equals("y") || user_input.Equals("n") || user_input.Equals("0") ));
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
            } while (user_input.Equals("n"));
            // If the user has asked to cancel, then return them to the staff menu
            if (user_input.Equals("0")) { return; }
            // If the user has confirmed the member's details are correct
            if (user_input.Equals("y")) {
                temp_member = MainProgram.member_collec.SearchForMember(first_name, last_name);
                if (temp_member == null) {
                    // If the member doesn't exist
                    Console.WriteLine("The member doesn't exist. Could not find the member's phone number.");
                } else {
                    // If the member exists, don't add the member
                    Console.WriteLine("Member's contact number: " + temp_member.ContactNumber.ToString());
                }
            }
            // Check if the user would like to find another member's number
            // Perform this loop until the user has chosen 'yes' or 'no'
            do {Console.Write("Would you like to FIND another member's contact number? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more members, stay on the FIND MEMBER menu
            if (string.Equals(user_input, "y")) { StaffSearchPhoneNumber(); }
            // Otherwise, return them to the staff menu
            return;
        }

        static public void StaffPrintBST() {
            // Clear the screen
            Console.Clear();
            // Display all the currently renting movies
            Console.WriteLine("== Display the Binary Search Tree Structure ==");
            MainProgram.movie_collec.PrintBST();
            // Ask user when they would like to leave the page
            Console.WriteLine("\nPress any key when you would like to return to the member menu.");
            Console.ReadKey();
            // Return to the member's menu
            return;
        }
    }
}
