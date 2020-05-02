using System;
using System.Collections.Generic;
using System.Globalization;


namespace NotBlockbuster {
    class MainProgram {
        /// <summary> // TODO: write
        /// This is the main method
        /// </summary>
        /// <returns></returns>
        public string MainMenu() {
            /* Main Menu
             * Returns the users option:
             * 1: Staff Login
             * 2: Member Login
             * 0: Exit
             */
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
            return user_input;
        }

        ////////////////////////////////////////////////////////////////////////
        /// STAFF MENU
        ////////////////////////////////////////////////////////////////////////
        public bool StaffLogin() {
            /* Staff Login
             * Returns a flag indicating if the staff login was successful.
             * true:  the login was successful
             * false: the login failed, or was canceled
             */
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
                if (string.Equals(user_id, "0") || string.Equals(user_pw, "0")) { return false; }
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("You entered the wrong login details too many time.");
                    return false; // return that the login failed, and send the user to main menu
                }
            } while (!( user_id.Equals("staff") && user_pw.Equals("today123") ));
            return true;
        }

        public string StaffMenu() {
            /* Staff Menu
             * Returns the users option:
             * 1: Add a new movie DVD
             * 2: Removie a movie DVD
             * 3: Register a new member
             * 4: Find a registered member's phone number
             * 0: Return to main menu
             */
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
                Console.WriteLine("\t 0. Return to main menu");
                Console.WriteLine("==========================================\n");
                // Display that the previous input was not correct
                if (!bool_first_entry) { Console.WriteLine("Your choice of {0} was not a valid option.", user_input); }
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Receive user input
                Console.Write("Please choose from (1-4, or '0' to return to the main menu): ");
                user_input = Console.ReadLine();
            } while (!( user_input.Equals("0") || user_input.Equals("1") || user_input.Equals("2") ||
                        user_input.Equals("3") || user_input.Equals("4") ));
            return user_input;
        }

        public string StaffAddMovie(MovieCollection movie_collec) {
            /* Add Movie
             * Returns:
             * 2: Add another movie
             * 1: The movie was successfully deleted
             * 0: Return to main menu
             */
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
            if (user_input.Equals("0")) { return "1"; }
            // If the user has confirmed the movie details are correct
            if (user_input.Equals("y")) {
                if (movie_collec.SearchMovie(user_title) == null) {
                    // If the movie doesn't exist
                    movie_collec.InsertMovie(new Movie( user_title,
                                                        (Movie.Genres)user_genre,
                                                        (Movie.Classifications)user_class,
                                                        user_director,
                                                        user_star,
                                                        user_length,
                                                        user_date,
                                                        user_copies));
                } else {
                    // If the movie exists, check if the user would like to update the movie details
                    Console.WriteLine("The movie already exists. Would you like to update the movie's details?");
                    // Perform this loop until the user has chosen 'yes' or 'no'
                    do {Console.Write("(Y)es / (N)o: ");
                        user_input = Console.ReadLine().ToLower();
                    } while (!( user_input.Equals("y") || user_input.Equals("n") ));
                    if (user_input.Equals("y")) {
                        // If the user would like to update the movie details
                        movie_collec.InsertMovie(new Movie(user_title,
                                                        (Movie.Genres)user_genre,
                                                        (Movie.Classifications)user_class,
                                                        user_director,
                                                        user_star,
                                                        user_length,
                                                        user_date,
                                                        user_copies));
                    } else { Console.WriteLine("The changes have been discarded."); } // Otherwise, discard movie details
                }
            }
            // Check if the user would like to add another movie
            // Perform this loop until the user has chosen 'yes' or 'no'
            do {Console.Write("\nWould you like to ADD another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more movies, stay on the ADD MOVIE menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return them to the staff menu
            return "1";
        }

        public string StaffDeleteMovie(MovieCollection movie_collec) { // TODO: remove movie from all users
            /* Delete Movie
             * Returns:
             * 2: Remove another movie
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
            // Initialise important variables
            int user_tries = 5;
            string user_input = "NA";
            bool bool_first_entry = true;
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
                    Console.WriteLine("Could not remove the movie. The movie '" + user_input + "' does not exist in the database.\n");
                    Console.WriteLine("You have {0} remaining tries.", user_tries);
                }
                Console.Write("\t Title: ");
                // Receive user input
                user_input = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("The movie are looking for is not in the database.");
                    return "1"; // return the user to the staff menu
                }
            } while (!( user_input.Equals("0") || user_input.Equals("1") ) && ( movie_collec.SearchMovie(user_input) == null ));
            // If the user is asking to return to the main menu
            if (user_input.Equals("0")) { return "0"; }
            // If the user is asking to return to the staff menu
            else if (user_input.Equals("1")) { return "1"; }
            // Otherwise, delete the movie
            movie_collec.DeleteMovie(user_input);
            // Check if the user would like to add another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("Would you like to REMOVE another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to remove another movie, then stay on the DELETE MOVIE menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return to the staff menu
            return "1";
        }

        public string StaffAddMember(MemberCollection member_collec) {
            /* Add Member
             * Returns:
             * 2: Add another member
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
            // Initialise important varbiales
            string first_name;
            string last_name;
            string address;
            string contact_number;
            string password;
            int temp_num;
            string user_input = "NA";
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
            if (user_input.Equals("0")) { return "1"; }
            // If the user has confirmed the member details are correct
            if (user_input.Equals("y")) {
                if (member_collec.SearchMember(first_name, last_name) == null) {
                    // If the member doesn't exist
                    member_collec.AddMember(new Member(first_name, last_name, address, contact_number, password) );
                } else {
                    // If the member exists, don't add the member
                    Console.WriteLine("Could not add the memeber. A member already exists with this name.");
                }
            }
            // Check if the user would like to add another member
            // Perform this loop until the user has chosen 'yes' or 'no'
            do {Console.Write("\nWould you like to ADD another member? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more members, stay on the ADD MEMBER menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return them to the staff menu
            return "1";
        }

        public string StaffSearchMemberNumber(MemberCollection member_collec) {
            /* Find Member Number
             * Returns:
             * 2: Find another member's number
             * 1: Return to the staff menu
             * 0: Return to the main menu
             */
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
            if (user_input.Equals("0")) { return "1"; }
            // If the user has confirmed the member's details are correct
            if (user_input.Equals("y")) {
                temp_member = member_collec.SearchMember(first_name, last_name);
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
            do {Console.Write("\nWould you like to FIND another member's contact number? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more members, stay on the ADD MEMBER menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return them to the staff menu
            return "1";
        }

        ////////////////////////////////////////////////////////////////////////
        /// MEMBER MENU
        ////////////////////////////////////////////////////////////////////////
        public int MemberLogin(MemberCollection member_collec) {
            /* Member Login
             * Returns the index to the member or a negative number to flag an unsucessful login.
             */
            // Initialise important variables
            int user_tries = 5;
            int member_index = -1;
            string user_id;
            string user_pw;
            bool bool_first_entry = true;
            bool member_exists = false;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the login menu
                Console.WriteLine("Welcome to Blockbuster's Community Library");
                Console.WriteLine("============== Member Login ==============");
                Console.WriteLine("\t Username and password is case insensitive.");
                Console.WriteLine("\t To cancel login:");
                Console.WriteLine("\t Set username or password to '0'");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("Please enter your member login details (or '0' to return to the main menu).");
                // Let the user know that their login failed
                if (!bool_first_entry) {
                    Console.WriteLine("\nIncorrect username and password combination.");
                    Console.WriteLine("You have {0} remaining tries.\n", user_tries);
                }
                // Receive the user's username
                Console.Write("Enter Username: ");
                user_id = Console.ReadLine().ToLower();
                // Receive the user's password
                Console.Write("Enter Password: ");
                user_pw = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // If the user chooses to cancel logging in
                if (string.Equals(user_id, "0") || string.Equals(user_pw, "0")) { return -1; }
                // Check that the password and username combination exists for a user
                for (int i = 0; i < member_collec.ActiveMembers; i++) {
                    if (    user_id.Equals(member_collec.ListMembers[i].Username.ToLower()) &&
                            user_pw.Equals(member_collec.ListMembers[i].Password.ToLower()) ) {
                        member_exists = true;
                        member_index = i;
                        break;
                    }
                }
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("You entered the wrong login details too many time.");
                    return -1; // return that the login failed, and send the user to main menu
                }
            } while (!member_exists);
            // If the member exists, then return the index for that member in the array of members
            return member_index;
        }

        public string MemberMenu() {
            /* Member Menu
             * Returns the users option:
             * 1: Display all movies
             * 2: Borrow a movie
             * 3: Return a movie
             * 4: List current borrowed movies
             * 5: Display top 10 most popular movies
             * 0: Return to the main menu
             */
            // Initialise important varbiales
            string user_input = "NA";
            bool bool_first_entry = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("============== Member Menu ===============");
                Console.WriteLine("\t 1. Display all movies");
                Console.WriteLine("\t 2. Borrow a movie");
                Console.WriteLine("\t 3. Return a movie");
                Console.WriteLine("\t 4. List current borrowed movie DVDs");
                Console.WriteLine("\t 5. Display top 10 most popular movies");
                Console.WriteLine("\t 0. Return to the main menu");
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
            return user_input;
        }

        public void MemberDisplayMovies(MovieCollection movie_collec) {
            // Clear the screen
            Console.Clear();
            // Display all the movies
            Console.WriteLine("=========== Display all Movies ===========");
            movie_collec.PrintAllMoviesInOrder();
            // Ask user when they would like to leave the page
            Console.WriteLine("Press any key when you would like to return to the member menu.");
            Console.ReadKey();
        }

        public string MemberBorrowMovie(Member member, MovieCollection movie_collec) {
            /* Borrow Movie
             * Returns:
             * 2: Borrow another movie
             * 1: Return to the member menu
             * 0: Return to the main menu
             */
             // Initialise important variables
            Movie movie_to_borrow;
            int user_tries = 5;
            string user_input = "NA";
            bool bool_first_entry = true;
            bool bool_can_rent_movie = true;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("============= Borrow a Movie =============");
                Console.WriteLine("\t Enter the movie's title.");
                Console.WriteLine("\t 1. Return to member menu.");
                Console.WriteLine("\t 0. Return to main menu.");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("Please enter the movie's title (or choose option '1' or '0').");
                // Display that the previous input was not correct
                if (!bool_first_entry) {
                    Console.WriteLine("Could not find the movie. The movie '" + user_input + "' does not exist in the database.\n");
                    Console.WriteLine("You have {0} remaining tries.", user_tries); // TODO: write all console messages like so
                }
                Console.Write("\t Title: ");
                // Receive user input
                user_input = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("The movie are looking for is not in the database.");
                    return "1"; // return the user to the member menu
                }
            } while (!( user_input.Equals("0") || user_input.Equals("1") ) && ( movie_collec.SearchMovie(user_input) == null ));
            // If the user is asking to return to the main menu
            if (user_input.Equals("0")) { return "0"; }
            // If the user is asking to return to the member menu
            else if (user_input.Equals("1")) { return "1"; }
            // Check that the user would like to borrow the movie
            // Perform this loop until the user has chosen a valid option
            movie_to_borrow = movie_collec.SearchMovie(user_input);
            do {Console.Write("Are you sure you would like to rent '{0}'? (Y)es / (N)o: ", movie_to_borrow.Title);
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to borrow the movie, then check that the movie has a free copy
            if (user_input.Equals("y")) {
                if (movie_to_borrow.NumAvCopies > 0) {
                    // Check that the member isn't already renting the movie
                    foreach (Movie movie in member.BorrowedMovies) {
                        // If the movie is already in the list of borrowed movies, then cancel rent
                        if (movie_to_borrow.CompareTo(movie) == 0) {
                            Console.WriteLine("You are already renting the movie '{0}'. You can only rent one copy at a time.\n", movie_to_borrow.Title);
                            bool_can_rent_movie = false;
                            break;
                        }
                    }
                    // Otherwise, borrow the movie
                    if (bool_can_rent_movie) {
                        member.BorrowMovie(movie_to_borrow); // add movie to user's list
                    }
                } else { Console.WriteLine("Sorry, there aren't any available copies of this movies at the momemnt.\n"); }
            }
            // Check if the user would like to borrow another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("Would you like to BORROW another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to borrow another movie, then stay on the BORROW MOVIE menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return to the member menu
            return "1";
        }

        public string MemberReturnMovie(Member member, MovieCollection movie_collec) {
            /* Return Movie
             * Returns:
             * 2: Return another movie
             * 1: Return to the member menu
             * 0: Return to the main menu
             */
             // Initialise important variables
            Movie movie_to_return;
            int user_tries = 5;
            string user_input = "NA";
            bool bool_first_entry = true;
            bool bool_could_return = false;
            // Perform the loop until the user has chosen a valid option
            do {// Clear the screen
                Console.Clear();
                // Display the main menu options
                Console.WriteLine("============= Return a Movie =============");
                Console.WriteLine("\t Enter the movie's title.");
                Console.WriteLine("\t 1. Return to member menu.");
                Console.WriteLine("\t 0. Return to main menu.");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("Please enter the movie's title (or choose option '1' or '0').");
                // Display that the previous input was not correct
                if (!bool_first_entry) {
                    Console.WriteLine("Could not find the movie. The movie '" + user_input + "' does not exist in the database.\n");
                    Console.WriteLine("You have {0} remaining tries.", user_tries); // TODO: write all console messages like so
                }
                Console.Write("\t Title: ");
                // Receive user input
                user_input = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("The movie are trying to return is not in the database.");
                    return "1"; // return the user to the member menu
                }
            } while (!( user_input.Equals("0") || user_input.Equals("1") ) && ( movie_collec.SearchMovie(user_input) == null ));
            // If the user is asking to return to the main menu
            if (user_input.Equals("0")) { return "0"; }
            // If the user is asking to return to the member menu
            else if (user_input.Equals("1")) { return "1"; }
            movie_to_return = movie_collec.SearchMovie(user_input);
            // Make the user confirm that they would like to return the movie
            do {Console.Write("Are you sure you would like to return '{0}'? (Y)es / (N)o: ", movie_to_return.Title);
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to return the movie, then check that they are currently renting the movie
            if (user_input.Equals("y")) {
                // Check that the user is renting the movie
                foreach (Movie movie in member.BorrowedMovies) {
                    // If the movie is already in the list of borrowed movies, then return it
                    if (movie_to_return.CompareTo(movie) == 0) {
                        member.ReturnMovie(movie_to_return); // add movie to user's list
                        bool_could_return = true;
                        break;
                    }
                }
                // If the movie was not in the user's list of currently renting, then let them know
                if (!bool_could_return) { Console.WriteLine("You aren't currently renting {0}, so could not return the movie.\n", movie_to_return.Title); }
            }
            // Check if the user would like to return another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("Would you like to RETURN another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to return another movie, then stay on the BORROW MOVIE menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return to the member menu
            return "1";
        }

        public void MemberDisplayRenting(Member member) {
            // Clear the screen
            Console.Clear();
            // Display all the currently renting movies
            Console.WriteLine("== Display all Currently Renting Movies ==");
            member.DisplayCurrentlyRenting();
            // Ask user when they would like to leave the page
            Console.WriteLine("Press any key when you would like to return to the member menu.");
            Console.ReadKey();
        }

        ////////////////////////////////////////////////////////////////////////
        /// MAIN PROGRAM
        ////////////////////////////////////////////////////////////////////////
        public static void Main() {
            // Initialise the Binary Search Tree (BST)
            MovieCollection movie_collec = new MovieCollection();
            // Create movie objects
            Movie django = new Movie("Django", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24/01/2013), 11);
            Movie pulp = new Movie("Pulp", Movie.Genres.Adventure, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "John Travolta", 178, new DateTime(24/11/1994), 8);
            Movie bugs = new Movie("Bug", Movie.Genres.Animated, Movie.Classifications.General, "John Lasseter", "Dave Foley", 95, new DateTime(3/121998), 2);
            Movie jaws = new Movie("Jaws", Movie.Genres.Thriller, Movie.Classifications.Mature, "Steven Spielberg", "Shark", 130, new DateTime(27/11/1975), 1);
            // Add movies to the BST
            movie_collec.InsertMovie(django);
            movie_collec.InsertMovie(pulp);
            movie_collec.InsertMovie(bugs);
            movie_collec.InsertMovie(jaws);

            // Initialise the array of members
            MemberCollection member_collec = new MemberCollection();
            Member neco = new Member("Neco", "Kriel", "6 Mossglen Close", "0401267646", "pass");
            Member bill = new Member("Bill", "peter", "7th Corner Street", "0401267646", "pass");
            // Add members to the array
            member_collec.AddMember(neco);
            member_collec.AddMember(bill);

            // Initialise the menu variables
            MainProgram mainProgram = new MainProgram();
            string input_mainmenu = "NA"; // main menu option
            string input_submenu = "NA"; // sub-menu option
            string input_subsubmenu = "NA"; // sub-sub-menu option
            int member_index = -1;
            // Start the Program
            while (true) {
                // Display main menu
                input_mainmenu = mainProgram.MainMenu();
                // Follow up on the user's menu selection
                if (input_mainmenu.Equals("0")) {
                    ///////////////////////////////////////
                    // If user chose to exit
                    Console.WriteLine("Shutting down...");
                    return;
                } else if (input_mainmenu.Equals("1")) {
                    ///////////////////////////////////////
                    // User chose to use staff menu
                    // Verify they can log in
                    if (mainProgram.StaffLogin()) {
                        // Stay on the staff menu until the user asks to leave
                        while (string.Equals(input_mainmenu, "1")) {
                            // Which sub-menu would the user like to enter?
                            input_submenu = mainProgram.StaffMenu();
                            if (input_submenu.Equals("0")) {
                                // if the user chose to return to the main menu
                                input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA";
                            } else if (input_submenu.Equals("1")) {
                                // if the user chose to add a movie
                                while (input_submenu.Equals("1")) {
                                    /* Would the user like to:
                                     * 2. add another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.StaffAddMovie(movie_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the staff menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "1"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // Print the BST structure to the console
                                    movie_collec.PrintBST(movie_collec.root); // TODO: remove
                                    Console.ReadLine();
                                }
                            } else if (input_submenu.Equals("2")) {
                                // If the user chose to remove a movie
                                while (input_submenu.Equals("2")) {
                                    /* Would the user like to:
                                     * 2. remove another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.StaffDeleteMovie(movie_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the staff menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "1"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // Print the BST structure to the console
                                    movie_collec.PrintBST(movie_collec.root); // TODO: remove
                                    Console.ReadLine();
                                }
                            } else if (input_submenu.Equals("3")) {
                                // If the user chose to register a new member
                                while (input_submenu.Equals("3")) {
                                    /* Would the user like to:
                                     * 2. remove another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.StaffAddMember(member_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the staff menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "1"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                }
                            } else if (input_submenu.Equals("4")) {
                                // If the user chose to search for a member's phone number
                                while (input_submenu.Equals("4")) {
                                    /* Would the user like to:
                                     * 2. remove another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.StaffSearchMemberNumber(member_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the staff menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "1"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                }
                            }
                        }
                    }
                } else {
                    ///////////////////////////////////////
                    // Otherwise, user chose to use member login
                    // Verify that the user can log-in
                    member_index = mainProgram.MemberLogin(member_collec);
                    if (member_index >= 0) {
                        // Stay on the member menu until the user asks to leave
                        while (string.Equals(input_mainmenu, "2")) {
                            // Which sub-menu would the user like to enter?
                            input_submenu = mainProgram.MemberMenu();
                            if (input_submenu.Equals("0")) {
                                // If the user chose to return to the main menu
                                input_mainmenu = "NA";
                                input_submenu = "NA";
                                input_subsubmenu = "NA";
                            } else if (input_submenu.Equals("1")) {
                                // If the user chose to display all movies
                                mainProgram.MemberDisplayMovies(movie_collec);
                            } else if (input_submenu.Equals("2")) {
                                // If the user chose to borrow a movie
                                while (input_submenu.Equals("2")) {
                                    /* Would the user like to:
                                     * 2. borrow another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.MemberBorrowMovie(member_collec.ListMembers[member_index], movie_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the member menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "2"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                }
                            } else if (input_submenu.Equals("3")) {
                                // If the user chose to return a movie
                                while (input_submenu.Equals("3")) {
                                    /* Would the user like to:
                                     * 2. return another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.MemberReturnMovie(member_collec.ListMembers[member_index], movie_collec);
                                    // User would like to return to the main menu
                                    if (input_subsubmenu.Equals("0")) { input_mainmenu = "NA"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                    // User would like to return to the member menu
                                    else if (input_subsubmenu.Equals("1")) { input_mainmenu = "2"; input_submenu = "NA"; input_subsubmenu = "NA"; }
                                }
                            } else if (input_submenu.Equals("4")) {
                                // If the user chose to list all borrowed movies
                                mainProgram.MemberDisplayRenting(member_collec.ListMembers[member_index]);
                            } else if (input_submenu.Equals("5")) {
                                // If the user chose to display all popular movies
                                Console.WriteLine("Still to be implemented...");
                            }
                        }
                    }
                }
            }

            // TODO: what happens if you search for a movie that doesn't exist
        }
    }
}
