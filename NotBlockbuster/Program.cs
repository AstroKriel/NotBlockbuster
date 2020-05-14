using System;

namespace NotBlockbuster {
    static class MainProgram {
        // GLOBAL VARIABLES
        public static MovieCollection movie_collec;
        public static MemberCollection member_collec;
        public static Member member;
        public static bool program_finished;
        public static bool session_finished;

        // MAIN PROGRAM
        public static void Main() {
            // Initialise the Binary Search Tree (BST)
            movie_collec = new MovieCollection();
            // Initialise the array of members
            member_collec = new MemberCollection();


            ////////////////////////////////////////////////////////////////////////
            /// FOR TESTING FUNCTIONALITY
            ////////////////////////////////////////////////////////////////////////

            // Create movie objects
            Movie bugs = new Movie("A Bug's Life", Movie.Genres.Animated, Movie.Classifications.General, "John Lasseter", "Dave Foley", 95, new DateTime(3 / 121998), 2);
            Movie avatar = new Movie("Avatar", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie banjo = new Movie("Banjo Billy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie billy = new Movie("Billy Jean", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie django = new Movie("Django Unchained", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie frozen = new Movie("Frozen", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hellboy = new Movie("Hellboy", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie hellboy2 = new Movie("Hellboy II: The Golden Army", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie jaws = new Movie("Jaws", Movie.Genres.Thriller, Movie.Classifications.Mature, "Steven Spielberg", "Shark", 130, new DateTime(27 / 11 / 1975), 3);
            Movie lego = new Movie("Lego Movie", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie pulp = new Movie("Pulp Fiction", Movie.Genres.Adventure, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "John Travolta", 178, new DateTime(24 / 11 / 1994), 8);
            Movie spiderman = new Movie("Spiderman", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            Movie totalrecall = new Movie("Total Recall", Movie.Genres.Action, Movie.Classifications.MatureAccompanied, "Quentin Tarantino", "Leonardo DiCaprio", 165, new DateTime(24 / 01 / 2013), 11);
            // Add movies to the BST
            movie_collec.InsertMovie(avatar);
            movie_collec.InsertMovie(banjo);
            movie_collec.InsertMovie(bugs);
            movie_collec.InsertMovie(billy);
            movie_collec.InsertMovie(django);
            movie_collec.InsertMovie(frozen);
            movie_collec.InsertMovie(hellboy);
            movie_collec.InsertMovie(hellboy2);
            movie_collec.InsertMovie(jaws);
            movie_collec.InsertMovie(pulp);
            movie_collec.InsertMovie(lego);
            movie_collec.InsertMovie(spiderman);
            movie_collec.InsertMovie(totalrecall);
            // Create member objects
            Member neco = new Member("Neco", "Kriel", "6 Mossglen Close", "0401267646", "1234");
            Member eve = new Member("Eve", "Test", "7th Corner Street", "0401267646", "1234");
            // Add members to the array
            member_collec.AddMember(neco);
            member_collec.AddMember(eve);
            // Add movies to Neco's record
            int index;
            for (index = 0; index < 2; index++) { neco.RentMovie(billy); neco.ReturnMovie(billy); }
            for (index = 0; index < 5; index++) { neco.RentMovie(django); neco.ReturnMovie(django); }
            for (index = 0; index < 10; index++) { neco.RentMovie(pulp); neco.ReturnMovie(pulp); }
            for (index = 0; index < 10; index++) { neco.RentMovie(spiderman); neco.ReturnMovie(spiderman); }
            for (index = 0; index < 5; index++) { neco.RentMovie(bugs); neco.ReturnMovie(bugs); }
            for (index = 0; index < 7; index++) { neco.RentMovie(lego); neco.ReturnMovie(lego); }
            for (index = 0; index < 20; index++) { neco.RentMovie(jaws); neco.ReturnMovie(jaws); }
            for (index = 0; index < 20; index++) { neco.RentMovie(totalrecall); neco.ReturnMovie(totalrecall); }
            for (index = 0; index < 20; index++) { neco.RentMovie(hellboy); neco.ReturnMovie(hellboy); }
            for (index = 0; index < 20; index++) { neco.RentMovie(avatar); neco.ReturnMovie(avatar); }
            for (index = 0; index < 40; index++) { neco.RentMovie(banjo); neco.ReturnMovie(banjo); }
            for (index = 0; index < 44; index++) { neco.RentMovie(frozen); neco.ReturnMovie(frozen); }
            // Add movies to Neco's currently renting list
            neco.RentMovie(avatar);
            neco.RentMovie(bugs);
            neco.RentMovie(banjo);
            neco.RentMovie(billy);
            neco.RentMovie(django);
            neco.RentMovie(hellboy);
            neco.RentMovie(spiderman);
            neco.RentMovie(jaws);
            neco.RentMovie(pulp);
            neco.RentMovie(frozen);
            // Add movies to Eve's record
            for (index = 0; index < 1; index++) { eve.RentMovie(django); eve.ReturnMovie(django); }
            for (index = 0; index < 9; index++) { eve.RentMovie(pulp); eve.ReturnMovie(pulp); }
            for (index = 0; index < 13; index++) { eve.RentMovie(bugs); eve.ReturnMovie(bugs); }
            for (index = 0; index < 17; index++) { eve.RentMovie(jaws); eve.ReturnMovie(jaws); }
            for (index = 0; index < 26; index++) { eve.RentMovie(lego); eve.ReturnMovie(lego); }
            for (index = 0; index < 28; index++) { eve.RentMovie(hellboy); eve.ReturnMovie(hellboy); }
            for (index = 0; index < 30; index++) { eve.RentMovie(avatar); eve.ReturnMovie(avatar); }
            for (index = 0; index < 33; index++) { eve.RentMovie(banjo); eve.ReturnMovie(banjo); }
            for (index = 0; index < 37; index++) { eve.RentMovie(totalrecall); eve.ReturnMovie(totalrecall); }
            for (index = 0; index < 40; index++) { eve.RentMovie(frozen); eve.ReturnMovie(frozen); }
            for (index = 0; index < 50; index++) { eve.RentMovie(billy); eve.ReturnMovie(billy); }
            for (index = 0; index < 55; index++) { eve.RentMovie(spiderman); eve.ReturnMovie(spiderman); }


            ////////////////////////////////////////////////////////////////////////
            /// START OF THE PROGRAM
            ////////////////////////////////////////////////////////////////////////
            
            program_finished = false;
            while (!program_finished) {
                Components.Menu.MainMenu();
            }
        }
    }
}
