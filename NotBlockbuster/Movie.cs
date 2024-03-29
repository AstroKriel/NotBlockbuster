﻿using System;
using System.Collections; // for non-core functionality

namespace NotBlockbuster {
    public class Movie : IComparable<Movie> {
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

        // Create variable to store the list of currently renting movies
        public ArrayList RentingUsers;

        // Movie object constructor
        public Movie(   string title, Genres genre, Classifications classification, string director,
                        string starring, int duration, DateTime releaseDate, int numCopies) {
            Title = title;
            Genre = genre;
            Classification = classification;
            Director = director;
            Starring = starring;
            Duration = duration;
            ReleaseDate = releaseDate;
            NumAvCopies = numCopies;
            NumTimesRented = 0;
            RentingUsers = new ArrayList();
        }

        // A function that adds a user to the list of users currently borrowing the movie
        public void AddUser(Member member) {
            RentingUsers.Add(member);
        }

        // A function that removes a user from the list of users currently borrowing the movie
        public void RemoveUser(Member member) {
            RentingUsers.Remove(member);
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
        public int NumTimesRented { get; set; }

        // Print movie properties
        public override string ToString() {
            return  "Title: " + Title +
                    "\n\t\t Genre: " + Genre + 
                    "\n\t\t Classification: " + Classification + 
                    "\n\t\t Director: " + Director + 
                    "\n\t\t Stars: " + Starring + 
                    "\n\t\t Duration: " + Duration +
                    "\n\t\t Release Date: " + ReleaseDate.ToShortDateString() + 
                    "\n\t\t Number of Copies: " + NumAvCopies;
        }

        // Define movie comparitor
        // Returns (-1) if prior is smaller, (+1) if prior is larger, (0) if equal.
        public int CompareTo(Movie other) { return string.Compare(this.Title.ToLower(), other.Title.ToLower()); }
    }
}
