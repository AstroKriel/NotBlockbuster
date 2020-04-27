﻿using System;
using System.Collections.Generic;
using System.Globalization;


namespace NotBlockbuster {
    class MainProgram {
        /// <summary>
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
                do {Console.Write("\t Release date: ");
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
                    Console.WriteLine("The movie already exists. Would you like to update the movie's details?");
                    do {Console.Write("(Y)es / (N)o: ");
                        user_input = Console.ReadLine().ToLower();
                    } while (!( user_input.Equals("y") || user_input.Equals("n") ));
                    if (user_input.Equals("y")) {
                        movie_collec.InsertMovie(new Movie(user_title,
                                                        (Movie.Genres)user_genre,
                                                        (Movie.Classifications)user_class,
                                                        user_director,
                                                        user_star,
                                                        user_length,
                                                        user_date,
                                                        user_copies));
                    } else { Console.WriteLine("The changes have been discarded."); }
                }
            }
            // Check if the user would like to add another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("\nWould you like to ADD another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to add more movies, stay on the ADD menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return to the staff menu
            return "1";
        }

        public string StaffDeleteMovie(MovieCollection movie_collec) {
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
                Console.Write("\tTitle: ");
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
            // If the user would like to remove another movie, then stay on the delete menu
            if (string.Equals(user_input, "y")) { return "2"; }
            // Otherwise, return to the staff menu
            return "1";
        }

        public static void Main() {
            // Initialise the Binary Search Tree (BST)
            MovieCollection movie_collec = new MovieCollection();

            // Initialise the array of members
            MemberCollection member_collec = new MemberCollection();

            // Create movie objects
            Movie a = new Movie("A", Movie.Genres.Thriller, Movie.Classifications.Mature, "Lachlan", "Lachlan", 180, new DateTime(24/04/1997), 1);
            Movie b = new Movie("B", Movie.Genres.Thriller, Movie.Classifications.Mature, "Lachlan", "Lachlan", 180, new DateTime(24/04/1997), 5);
            Movie c = new Movie("C", Movie.Genres.Thriller, Movie.Classifications.Mature, "Lachlan", "Lachlan", 180, new DateTime(24/04/1997), 3);
            Movie d = new Movie("D", Movie.Genres.Thriller, Movie.Classifications.Mature, "Lachlan", "Lachlan", 180, new DateTime(24/04/1997), 4);
            // Add movies to the BST
            movie_collec.InsertMovie(b);
            movie_collec.InsertMovie(d);
            movie_collec.InsertMovie(a);
            movie_collec.InsertMovie(c);

            // Start the Program
            MainProgram mainProgram = new MainProgram();
            string input_mainmenu = "NA"; // main menu option
            string input_submenu = "NA"; // sub-menu option
            string input_subsubmenu = "NA"; // sub-sub-menu option
            while (true) {
                // Display main menu
                input_mainmenu = mainProgram.MainMenu();
                // Follow up on the user's menu selection
                if (input_mainmenu.Equals("0")) {
                    // If user chose to exit
                    Console.WriteLine("Shutting down...");
                    return;
                } else if (input_mainmenu.Equals("1")) {
                    // User chose to use staff menu
                    // Verify they can log in
                    if (mainProgram.StaffLogin()) {
                        // Stay on the staff menu until the user asks to leave
                        while (string.Equals(input_mainmenu, "1")) {
                            // Which sub-menu would the user like to enter?
                            input_submenu = mainProgram.StaffMenu();
                            if (input_submenu.Equals("0")) {
                                // if the user chose to return to the main menu
                                input_mainmenu = "NA";
                                input_submenu = "NA";
                                input_subsubmenu = "NA";
                            } else if (input_submenu.Equals("1")) {
                                // if the user chose to add a movie
                                while (input_submenu.Equals("1")) {
                                    /* Would the user like to:
                                     * 2. add another movie
                                     * 1. return to the staff menu
                                     * 0. return to the main menu
                                     */
                                    input_subsubmenu = mainProgram.StaffAddMovie(movie_collec);
                                    // If user would like to return to another menu, sub-menu variable
                                    if (input_subsubmenu.Equals("0")) {
                                        // User would like to return to the main menu
                                        input_mainmenu = "NA";
                                        input_submenu = "NA";
                                        input_subsubmenu = "NA";
                                    } else if (input_subsubmenu.Equals("1")) {
                                        // User would like to return to the staff menu
                                        input_mainmenu = "1";
                                        input_submenu = "NA";
                                        input_subsubmenu = "NA";
                                    }
                                    // Print the BST structure to the console
                                    movie_collec.PrintBST(movie_collec.root);
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
                                    // If user would like to return to another menu, sub-menu variable
                                    if (input_subsubmenu.Equals("0")) {
                                        // User would like to return to the main menu
                                        input_mainmenu = "NA";
                                        input_submenu = "NA";
                                        input_subsubmenu = "NA";
                                    } else if (input_subsubmenu.Equals("1")) {
                                        // User would like to return to the staff menu
                                        input_mainmenu = "1";
                                        input_submenu = "NA";
                                        input_subsubmenu = "NA";
                                    }
                                }
                            } else if (input_submenu.Equals("3")) {
                                // If the user chose to register a new member
                            } else if (input_submenu.Equals("4")) {
                                // If the user chose to look for a member's phone number
                            }
                        }
                    }
                } else {
                    // Otherwise, user chose to use member login
                }
            }

            //// Check to see if deleting works properly
            //movie_collec.printBST(movie_collec.root); // Print the BST structure to the console
            //movie_collec.deletemovie("H");            // Delete movie my title
            //movie_collec.PrintBST(movie_collec.root); // Print the BST structure to the console

            //// Create member objects
            //Member neco = new Member("Neco", "6 Mossglen Close", "0401267646");
            //Member lach = new Member("Lachlan", "Far far away", "0000");
            //// Add members to the array
            //member_collec.AddMember(neco);
            //member_collec.AddMember(lach);
            //Console.WriteLine(member_collec.members[0].ToString());
            //Console.WriteLine(member_collec.members[1].ToString());
        }
    }
}