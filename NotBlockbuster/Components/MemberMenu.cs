using System;

namespace NotBlockbuster.Components {
    public class MemberMenus {
        ////////////////////////////////////////////////////////////////////////
        /// MEMBER MENU
        ////////////////////////////////////////////////////////////////////////

        /* Member Login
             * Returns the index to the member or a negative number to flag an unsucessful login.
             */
        static public void MemberLogin() {
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
                // If the user chooses to cancel logging in, return them to the main menu
                if (string.Equals(user_id, "0") || string.Equals(user_pw, "0")) {
                    MainProgram.session_finished = true;
                    return;
                }
                // Check that the password and username combination exists for a user
                for (int i = 0; i < MainProgram.member_collec.ActiveMembers; i++) {
                    if (    user_id.Equals(MainProgram.member_collec.ListMembers[i].Username.ToLower()) &&
                            user_pw.Equals(MainProgram.member_collec.ListMembers[i].Password.ToLower()) ) {
                        member_exists = true;
                        member_index = i;
                        break;
                    }
                }
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("You entered the wrong login details too many time.");
                    MainProgram.session_finished = true;
                    return; // return that the login failed, and send the user to main menu
                }
            } while (!member_exists);
            // If the member exists, then show them the member menu
            MainProgram.member = MainProgram.member_collec.ListMembers[member_index];
            MainProgram.session_finished = false;
            while (!MainProgram.session_finished) { MemberMenu(); }
        }

        /* Member Menu
             * Returns the users option:
             * 1: Display all movies
             * 2: Borrow a movie
             * 3: Return a movie
             * 4: List current borrowed movies
             * 5: Display top 10 most popular movies
             * 0: Return to the main menu
             */
        static public void MemberMenu() {
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
            if (user_input.Equals("0")) {
                // Return the user to the main menu
                //MainMenu();
                MainProgram.session_finished = true;
                return;
            } else if (user_input.Equals("1")) {
                // Display all the movies
                MemberPrintAllMovies();
            } else if (user_input.Equals("2")) {
                // Borrow a movie
                MemberRentMovie();
            } else if (user_input.Equals("3")) {
                // Return a movie
                MemberReturnMovie();
            } else if (user_input.Equals("4")) {
                // List all the borrowed movies
                MemberPrintRenting();
            } else if (user_input.Equals("5")){
                // Display the top 10 rented movies
                MemberPrintPopularMovies();
            }
        }

        static public void MemberPrintAllMovies() {
            // Clear the screen
            Console.Clear();
            // Display all the movies
            Console.WriteLine("=========== Display all Movies ===========");
            MainProgram.movie_collec.PrintBST();
            MainProgram.movie_collec.PrintMoviesInOrder();
            // Ask user when they would like to leave the page
            Console.WriteLine("Press any key when you would like to return to the member menu.");
            Console.ReadKey();
            // Return to the member's menu
            return;
        }

        /* Borrow Movie
            * Returns:
            * 2: Borrow another movie
            * 1: Return to the member menu
            * 0: Return to the main menu
            */
        static public void MemberRentMovie() {
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
                    Console.WriteLine("Could not find the movie. The movie '{0}' does not exist in the database.\n", user_input);
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
                    return;
                }
            } while (!( user_input.Equals("0") || user_input.Equals("1") ) && (MainProgram.movie_collec.SearchMovie(user_input) == null ));
            // If the user is asking to return to the main menu
            if (user_input.Equals("0")) {
                MainProgram.session_finished = true;
                return;
            }
            // If the user is asking to return to the member menu
            else if (user_input.Equals("1")) {
                return;
            }
            // Check that the user would like to borrow the movie
            // Perform this loop until the user has chosen a valid option
            movie_to_borrow = MainProgram.movie_collec.SearchMovie(user_input);
            do {Console.Write("Are you sure you would like to rent '{0}'? (Y)es / (N)o: ", movie_to_borrow.Title);
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to borrow the movie
            if (user_input.Equals("y")) {
                // If the user has reached the max number of rentable movies, then they aren't allowed to rent any more
                if (MainProgram.member.BorrowedMovies.Count >= 10) {
                    Console.WriteLine("\nYou have reached the maximum number (10) of movies you are allowed to rent.\n");
                    // Ask user when they would like to leave the page
                    Console.WriteLine("Press any key when you would like to return to the member menu.");
                    Console.ReadKey();
                    return;
                }
                // Otherwise, check that the movie has available copies to borrow
                if (movie_to_borrow.NumAvCopies > 0) {
                    // Check that the member isn't already renting the movie
                    foreach (Movie movie in MainProgram.member.BorrowedMovies) {
                        // If the movie is already in the list of borrowed movies, then cancel rent
                        if (movie_to_borrow.CompareTo(movie) == 0) {
                            Console.WriteLine("\nYou are already renting the movie '{0}'. You can only rent one copy at a time.\n", movie_to_borrow.Title);
                            bool_can_rent_movie = false;
                            break;
                        }
                    }
                    // Otherwise, borrow the movie
                    if (bool_can_rent_movie) {
                        MainProgram.member.RentMovie(movie_to_borrow); // add movie to user's list
                        movie_to_borrow.AddUser(MainProgram.member); // add the user to the list of people currently renting the movie
                    }
                } else { Console.WriteLine("Sorry, there aren't any available copies of this movies at the momemnt.\n"); }
            }
            // Check if the user would like to borrow another movie
            // Perform this loop until the user has chosen a valid option
            do {Console.Write("Would you like to BORROW another movie? (Y)es / (N)o: ");
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to borrow another movie, then stay on the BORROW MOVIE menu
            if (string.Equals(user_input, "y")) { MemberRentMovie(); }
            // Return to the member's menu
            return;
        }

        /* Return Movie
            * Returns:
            * 2: Return another movie
            * 1: Return to the member menu
            * 0: Return to the main menu
            */
        static public void MemberReturnMovie() {
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
                    Console.WriteLine("Could not find the movie. The movie '{0}' does not exist in the database.\n", user_input);
                    Console.WriteLine("You have {0} remaining tries.", user_tries); // TODO: write all console messages like so
                }
                Console.Write("\t Title: ");
                // Receive user input
                user_input = Console.ReadLine().ToLower();
                // If the user's input is incorrect, display so when the menu is re-drawn
                bool_first_entry = false;
                // Check to see if the user has exceeded the maximum number of allowable unsucessful tries
                if (--user_tries < 1) {
                    Console.WriteLine("The movie you are trying to return is not in the database.");
                    return;
                }
            } while (!( user_input.Equals("0") || user_input.Equals("1") ) && (MainProgram.movie_collec.SearchMovie(user_input) == null ));
            // If the user is asking to return to the main menu
            if (user_input.Equals("0")) {
                MainProgram.session_finished = true;
                return;
            }
            // If the user is asking to return to the member menu
            else if (user_input.Equals("1")) { return; }
            movie_to_return = MainProgram.movie_collec.SearchMovie(user_input);
            // Make the user confirm that they would like to return the movie
            do {Console.Write("Are you sure you would like to return '{0}'? (Y)es / (N)o: ", movie_to_return.Title);
                user_input = Console.ReadLine().ToLower();
            } while (!( user_input.Equals("y") || user_input.Equals("n") ));
            // If the user would like to return the movie, then check that they are currently renting the movie
            if (user_input.Equals("y")) {
                // Check that the user is renting the movie
                foreach (Movie movie in MainProgram.member.BorrowedMovies) {
                    // If the movie is already in the list of borrowed movies, then return it
                    if (movie_to_return.CompareTo(movie) == 0) {
                        MainProgram.member.ReturnMovie(movie_to_return); // remove the movie from the user's list
                        movie_to_return.RemoveUser(MainProgram.member); // remove the user from the list of people currently renting the movie
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
            // If the user would like to return another movie, then stay on the RETURN MOVIE menu
            if (string.Equals(user_input, "y")) { MemberReturnMovie(); }
            // Return to the member's menu
            return;
        }

        static public void MemberPrintRenting() {
            // Clear the screen
            Console.Clear();
            // Display all the currently renting movies
            Console.WriteLine("== Display all Currently Renting Movies ==");
            MainProgram.member.PrintCurrentlyRenting();
            // Ask user when they would like to leave the page
            Console.WriteLine("Press any key when you would like to return to the member menu.");
            Console.ReadKey();
            // Return to the member's menu
            return;
        }
        static public void MemberPrintPopularMovies() {
            // Clear the screen
            Console.Clear();
            // Display all the currently renting movies
            Console.WriteLine("== Display the Top 10 Rented Movies ==");
            MainProgram.movie_collec.PrintPopularMovies();
            // Ask user when they would like to leave the page
            Console.WriteLine("\nPress any key when you would like to return to the member menu.");
            Console.ReadKey();
            // Return to the member's menu
            return;
        }
    }
}
