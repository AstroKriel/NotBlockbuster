using System;

namespace NotBlockbuster {
    static class MainProgram {
        // GLOBAL VARIABLES
        public static MovieCollection movie_collec;
        public static MemberCollection member_collec;
        public static Member member;
        public static bool program_finished;
        public static bool session_finished;

        ////////////////////////////////////////////////////////////////////////
        /// MAIN PROGRAM
        ////////////////////////////////////////////////////////////////////////
        public static void Main() {
            // Initialise the Binary Search Tree (BST)
            movie_collec = new MovieCollection();
            // Initialise the array of members
            member_collec = new MemberCollection();

            // Create movie objects
            Movie django = new Movie("Django", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie pulp = new Movie("Pulp", Movie.Genres.Adventure, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "John Travolta", 178, new DateTime(24 / 11 / 1994), 8);
            Movie bugs = new Movie("Bug", Movie.Genres.Animated, Movie.Classifications.General, "John Lasseter", "Dave Foley", 95, new DateTime(3 / 121998), 2);
            Movie jaws = new Movie("Jaws", Movie.Genres.Thriller, Movie.Classifications.Mature, "Steven Spielberg", "Shark", 130, new DateTime(27 / 11 / 1975), 1);
            Movie avatar = new Movie("Avatar", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie banjo = new Movie("Banjo", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie billy = new Movie("Billy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie jargon = new Movie("Jargon", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hello = new Movie("Hello", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie test = new Movie("Test", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hellboy = new Movie("Hellboy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie reaves = new Movie("Reaves", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            // Add movies to the BST
            movie_collec.InsertMovie(django);
            movie_collec.InsertMovie(pulp);
            movie_collec.InsertMovie(bugs);
            movie_collec.InsertMovie(jaws);
            movie_collec.InsertMovie(avatar);
            movie_collec.InsertMovie(banjo);
            movie_collec.InsertMovie(billy);
            movie_collec.InsertMovie(jargon);
            movie_collec.InsertMovie(hello);
            movie_collec.InsertMovie(test);
            movie_collec.InsertMovie(hellboy);
            movie_collec.InsertMovie(reaves);
            // Create member objects
            Member neco = new Member("Neco", "Kriel", "6 Mossglen Close", "0401267646", "pass");
            Member eve = new Member("Eve", "Test", "7th Corner Street", "0401267646", "pass");
            // Add members to the array
            member_collec.AddMember(neco);
            member_collec.AddMember(eve);

            // Start the Program
            program_finished = false;
            while (!program_finished) {
                Components.Menu.MainMenu();
            }
        }
    }
}
