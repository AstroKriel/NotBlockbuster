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
            Movie avatar = new Movie("Avatar", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie bugs = new Movie("Bug", Movie.Genres.Animated, Movie.Classifications.General, "John Lasseter", "Dave Foley", 95, new DateTime(3 / 121998), 2);
            Movie banjo = new Movie("Banjo", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie billy = new Movie("Billy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie django = new Movie("Django", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hellboy = new Movie("Hellboy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hello = new Movie("Hello", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie jargon = new Movie("Jargon", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie jaws = new Movie("Jaws", Movie.Genres.Thriller, Movie.Classifications.Mature, "Steven Spielberg", "Shark", 130, new DateTime(27 / 11 / 1975), 1);
            Movie pulp = new Movie("Pulp", Movie.Genres.Adventure, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "John Travolta", 178, new DateTime(24 / 11 / 1994), 8);
            Movie reaves = new Movie("Reaves", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie test = new Movie("Test", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
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

            int index;
            for (index = 0; index < 2; index++) { neco.RentMovie(billy); neco.ReturnMovie(billy); }
            for (index = 0; index < 5; index++) { neco.RentMovie(django); neco.ReturnMovie(django); }
            for (index = 0; index < 7; index++) { neco.RentMovie(jargon); neco.ReturnMovie(jargon); }
            for (index = 0; index < 10; index++) { neco.RentMovie(pulp); neco.ReturnMovie(pulp); }
            for (index = 0; index < 12; index++) { neco.RentMovie(bugs); neco.ReturnMovie(bugs); }
            for (index = 0; index < 19; index++) { neco.RentMovie(hello); neco.ReturnMovie(hello); }
            for (index = 0; index < 20; index++) { neco.RentMovie(jaws); neco.ReturnMovie(jaws); }
            for (index = 0; index < 30; index++) { neco.RentMovie(test); neco.ReturnMovie(test); }
            for (index = 0; index < 31; index++) { neco.RentMovie(hellboy); neco.ReturnMovie(hellboy); }
            for (index = 0; index < 33; index++) { neco.RentMovie(avatar); neco.ReturnMovie(avatar); }
            for (index = 0; index < 40; index++) { neco.RentMovie(banjo); neco.ReturnMovie(banjo); }
            for (index = 0; index < 44; index++) { neco.RentMovie(reaves); neco.ReturnMovie(reaves); }

            for (index = 0; index < 1; index++) { eve.RentMovie(django); eve.ReturnMovie(django); }
            for (index = 0; index < 9; index++) { eve.RentMovie(pulp); eve.ReturnMovie(pulp); }
            for (index = 0; index < 13; index++) { eve.RentMovie(bugs); eve.ReturnMovie(bugs); }
            for (index = 0; index < 17; index++) { eve.RentMovie(jaws); eve.ReturnMovie(jaws); }
            for (index = 0; index < 26; index++) { eve.RentMovie(hello); eve.ReturnMovie(hello); }
            for (index = 0; index < 28; index++) { eve.RentMovie(hellboy); eve.ReturnMovie(hellboy); }
            for (index = 0; index < 30; index++) { eve.RentMovie(avatar); eve.ReturnMovie(avatar); }
            for (index = 0; index < 33; index++) { eve.RentMovie(banjo); eve.ReturnMovie(banjo); }
            for (index = 0; index < 37; index++) { eve.RentMovie(test); eve.ReturnMovie(test); }
            for (index = 0; index < 40; index++) { eve.RentMovie(reaves); eve.ReturnMovie(reaves); }
            for (index = 0; index < 50; index++) { eve.RentMovie(billy); eve.ReturnMovie(billy); }
            for (index = 0; index < 55; index++) { eve.RentMovie(jargon); eve.ReturnMovie(jargon); }


            Console.WriteLine("New test");
            neco.RentMovie(avatar);
            neco.RentMovie(bugs);
            neco.RentMovie(banjo);
            neco.RentMovie(billy);
            neco.RentMovie(django);
            neco.RentMovie(hellboy);
            neco.RentMovie(jargon);
            neco.RentMovie(jaws);
            neco.RentMovie(pulp);
            neco.RentMovie(reaves);

            // Start the Program
            program_finished = false;
            while (!program_finished) {
                Components.Menu.MainMenu();
            }
        }
    }
}
