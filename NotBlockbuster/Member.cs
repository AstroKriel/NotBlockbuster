﻿using System;
using System.Collections;

namespace NotBlockbuster {
    public class Member {
        // Create variable to store the list of currently renting movies
        public ArrayList BorrowedMovies;

        // Member object constructor
        public Member(string first_name, string last_name, string address, string contact_number, string password) {
            BorrowedMovies = new ArrayList();
            Username       = last_name + first_name;
            FirstName      = first_name;
            LastName       = last_name;
            Address        = address;
            ContactNumber  = contact_number;
            Password       = password;
        }

        // Define function to add movie to the list of borrowed movies
        public void RentMovie(Movie movie) {
            BorrowedMovies.Add(movie);
            movie.NumAvCopies--; // decrement the number of available copies TODO: check this is working
            movie.NumTimesRented++;
            Console.WriteLine("Successfully borrowed movie.\n");
        }

        public void ReturnMovie(Movie movie) {
            BorrowedMovies.Remove(movie);
            movie.NumAvCopies++; // increment the number of available copies TODO: check this is working
            Console.WriteLine("Successfully returned movie.\n");
        }

        // Get and Set movie properties
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }

        // Print member information
        public override string ToString() {
            return $@"Member Details:
                Name: {FirstName} {LastName}
                Address: {Address}
                Contact Number: {ContactNumber}
                Password: {Password}
                ";
        }

        // Define member comparitor (case insensitive)
        // Returns (-1) if prior is smaller, (+1) if prior is larger, (0) if equal.
        public int CompareTo(string other_username) { return string.Compare(this.Username.ToString().ToLower(), other_username.ToLower()); }

        public void PrintCurrentlyRenting() {
            Console.WriteLine("List of movies you are currently renting:");
            if (BorrowedMovies.Count > 0) {
                int i = 1;
                foreach (Movie movie in BorrowedMovies) { Console.WriteLine("\t ({0}) {1}", i++, movie.Title); }
            }
            else { Console.WriteLine("You do not have any outstanding movies at the moment."); }
            Console.Write("\n");
        }
    }
}
