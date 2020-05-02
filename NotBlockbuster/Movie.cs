using System;

namespace NotBlockbuster {
    public class Movie : IComparable<Movie> {
        // TODO: multiple occurances of the same movie

        // Possible movie genres
        public enum Genres {
            Action,
            Adventure,
            Animated,
            Comedy,
            Drama,
            Family,
            Other,
            SciFi,
            Thriller
        }

        // Possible movie classifications
        public enum Classifications {
            General,
            ParentalGuidance,
            Mature,
            MatureAccompanied
        }

        // Movie object constructor
        public Movie(   string title, Genres genre, Classifications classification, string director,
                        string starring, int duration, DateTime releaseDate, int numCopies) {
            Title = title;
            Genre = genre; // TODO: list
            Classification = classification;
            Director = director; // TODO: full name, list
            Starring = starring; // TODO: full name, list
            Duration = duration;
            ReleaseDate = releaseDate;
            NumAvCopies = numCopies;
        }

        // Get and Set movie properties
        public string Title { get; set; }
        public Genres Genre { get; set; }
        public Classifications Classification { get; set; }
        public string Director { get; set; }
        public string Starring { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumAvCopies { get; set; }

        // Print movie properties
        public override string ToString() {
            return $@"Movie Details:
                Title: {Title}
                Genre: {Genre}
                Classification: {Classification}
                Director: {Director}
                Stars: {Starring}
                Duration: {Duration}
                Release Date: {ReleaseDate.ToShortDateString()}
                Number of Copies: {NumAvCopies}
                ";
        }

        // Define movie comparitor
        // Returns (-1) if prior is smaller, (+1) if prior is larger, (0) if equal.
        public int CompareTo(Movie other) { return string.Compare(this.Title.ToLower(), other.Title.ToLower()); }
    }
}
