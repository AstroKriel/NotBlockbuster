﻿using System;
using System.Collections.Generic;

namespace NotBlockbuster {
    public class MovieCollection {
        ////////////////////////////////////////////////////////////////////////
        /// BST NODE CONSTRUCTOR + IMPORTANT VARIABLES
        ////////////////////////////////////////////////////////////////////////

        // Node of current movie with reference to its' two neighbors
        public class Node {
            // Node properties
            public Movie movie;
            public Node left, right;
            public Node(Movie movie) {
                this.movie = movie;
                left = right = null;
            }
        }

        // Root of the Binary Search Tree (BST)
        public Node root;

        // Count of the number of nodes in the BST
        public int count_movies;

        // BST is initialised as empty: with no root or nodes
        public MovieCollection() {
            root = null;
            count_movies = 0;
        }

        ////////////////////////////////////////////////////////////////////////
        /// SEARCH FOR A MOVIE IN THE COLLECTION
        ////////////////////////////////////////////////////////////////////////

        // Entry point for searching for a movie.
        // Recuresively calls SearchRec() to find if a movie exists and return the movie node
        // Function is always used before a movie is added or removed
        public Movie SearchMovie(string movie_title) { return SearchRec(this.root, movie_title.ToLower()); }

        // Search for a given movie in the BST 
        public Movie SearchRec(Node root, string movie_title) {
            // If the tree doesn't exist
            if (root == null) { return null; }
            // If this node is the movie
            else if (string.Equals(root.movie.Title.ToLower(), movie_title)) { return root.movie; }
            // Otherwise subset the tree in-search of the movie
            // If the root is (larger than) / (to the right of) the movie
            else if (string.Compare(movie_title, root.movie.Title.ToLower()) < 0) { return SearchRec(root.left, movie_title); }
            // Otherwise the root is (smaller than) / (to the left of) the movie
            return SearchRec(root.right, movie_title);
        }

        ////////////////////////////////////////////////////////////////////////
        /// ADD A MOVIE TO THE COLLECTION
        ////////////////////////////////////////////////////////////////////////

        // Entry point for inserting a movie.
        // Recuresively calls insertRec() to find where the movie's node belongs
        public void InsertMovie(Movie movie) {
            root = InsertRec(root, movie); // add the movie (node) to the BST
            count_movies++; // increment the number of movies (nodes) in the BST
            Console.WriteLine("Successfully added the movie '{0}'.\n", movie.Title);
        }

        // Insert a movie into the BST
        // Find where the movie (node) needs to go
        public Node InsertRec(Node root, Movie movie) {
            // If the tree is empty, make this movie the root
            if (root == null) { return new Node(movie); }
            // If the tree exists, then recur the movie down the branches
            if (movie.CompareTo(root.movie) < 0) { root.left = InsertRec(root.left, movie); } // choose left branch
            else if (movie.CompareTo(root.movie) > 0) { root.right = InsertRec(root.right, movie); } // choose right branch
            // return the (unchanged) node pointer
            return root;
        }

        ////////////////////////////////////////////////////////////////////////
        /// DELETE MOVIE FROM COLLECTION
        ////////////////////////////////////////////////////////////////////////

        // Entry point for deleting a movie.
        // Recuresively calls deleteRec() to find where the movie's node is and delete it
        public void DeleteMovie(string movie_title) {
            root = DeleteRec(root, movie_title.ToLower());
            count_movies--;
            Console.WriteLine("Successfully deleted the movie '{0}'.\n", movie_title);
        }

        // A recursive function that finds and deletes a movie
        public Node DeleteRec(Node root, string movie_title) {
            // If the tree is empty
            if (root == null) { return root; }
            // Otherwise recur down the tree
            // If the root is (larger than) / (to the right of) the movie
            if (string.Compare(movie_title, root.movie.Title.ToLower()) < 0) { root.left = DeleteRec(root.left, movie_title); }
            else if (string.Compare(movie_title, root.movie.Title.ToLower()) > 0) { root.right = DeleteRec(root.right, movie_title); }
            // if this node (root) movie is same as root's movie, then this is the node to be deleted  
            else {
                // If the node only has one neighbor, then return the neighbor
                if (root.left == null) { return root.right; }
                else if (root.right == null) { return root.left; }
                // Otherwise, replace the node with the next "smallest" node (inorder successor)
                root.movie = MinValue(root.right);
                // Delete the next smallest
                root.right = DeleteRec(root.right, root.movie.Title.ToLower());
            }
            return root;
        }

        // Calculate the successor (next "smallest") node
        public Movie MinValue(Node root) {
            Movie minv = root.movie;
            while (root.left != null) {
                minv = root.left.movie;
                root = root.left;
            }
            return minv;
        }

        ////////////////////////////////////////////////////////////////////////
        /// PRINT BST
        ////////////////////////////////////////////////////////////////////////

        // Entry point for printing the BST
        public void PrintBST() { // Node root
            Console.WriteLine("The Binary Search Tree:");
            PrintNode(root, 0); // start the tree with no indentation
            Console.WriteLine("\n");
        }

        // Number of separating characters between BST nodes
        public int LABEL_SPACE = 10;

        // Create horintal space in the console
        public void PrintSpacing(int space) { for (int i = LABEL_SPACE; i < space; i++) { Console.Write(" "); } }

        // Print the BST using reverse inorder traversal
        public void PrintNode(Node root, int space) {
            // If the current node doesn't exist
            if (root == null) { return; }
            // Space the tree's branch depth appart
            space += LABEL_SPACE;
            // Process the right branch first
            PrintNode(root.right, space);
            // Print current node after spaces
            Console.Write("\n");
            PrintSpacing(space); Console.Write("  /\n");
            PrintSpacing(space); Console.Write("(" + (space / LABEL_SPACE) + ") "+ root.movie.Title + "\n");
            PrintSpacing(space); Console.Write("  \\ \n");
            // Process the left branch
            PrintNode(root.left, space);
        }

        ////////////////////////////////////////////////////////////////////////
        /// PRINT MOVIES ALPHABETICALLY
        ////////////////////////////////////////////////////////////////////////

        // Global variable for adding to the array
        public int list_index;

        // Entry point for printing all movies in the library
        public void PrintMoviesInOrder() {
            // Initialise the list of all movies
            Movie[] array_movies = new Movie[count_movies];
            // Initialise the index to the start of the array
            list_index = 0;
            // Add movies to the list in alphabetical order
            SaveInOrder(root, array_movies);
            // Print the list of movie titles
            for (int i = 0; i < array_movies.Length; i++) {
                // Print the next letter in alphabet
                if (i == 0) {
                    Console.WriteLine("List of all the {0} movies in the library:", array_movies.Length);
                    Console.WriteLine("-- {0} --", array_movies[i].Title.ToUpper()[0]);
                } else if (array_movies[i - 1].Title.ToLower()[0] < array_movies[i].Title.ToLower()[0]) {
                    Console.WriteLine("-- {0} --", array_movies[i].Title.ToUpper()[0]);
                }
                // Print the movie title
                Console.WriteLine("\t - " + array_movies[i].ToString());
            }
            Console.Write("\n");
        }

        // Traverse BST and save all the movies in (alphabetical) order
        public void SaveInOrder(Node root, Movie[] array_movies) {
            if (root != null) {
                // Save the node to the left's movie title
                SaveInOrder(root.left, array_movies);
                // Add the current movie to the array
                array_movies[list_index++] = root.movie;
                // Save the node to the right's movie title
                SaveInOrder(root.right, array_movies);
            }
        }

        ////////////////////////////////////////////////////////////////////////
        /// PRINT MOVIES BY POPULARITY
        ////////////////////////////////////////////////////////////////////////

        public void PrintPopularMovies() {
            // Initialise the list of all movies
            Movie[] array_movies = new Movie[count_movies];
            // Initialise the index to the start of the array
            list_index = 0;
            // Add movies to the list in alphabetical order
            SaveInOrder(root, array_movies);
            // Order movies
            QuickSortMovies(array_movies, 0, array_movies.Length-1);
            // Print the most popular movies
            Console.WriteLine("The 10 Most Popular Movies");
            if (array_movies.Length > 0) {
                for (int i = 0; (i < array_movies.Length) && (i < 10); i++) {
                    if (array_movies[i].NumTimesRented > 1) {
                        Console.WriteLine("({0}) \t '{1}' {2} rented {3} times.", i+1, array_movies[i].Title,
                            new string(' ', 40-array_movies[i].Title.Length), array_movies[i].NumTimesRented);
                    } else {
                        Console.WriteLine("({0}) \t '{1}' {2} rented {3} time.", i+1, array_movies[i].Title,
                            new string(' ', 40-array_movies[i].Title.Length), array_movies[i].NumTimesRented);
                    }
                }
            } else { Console.WriteLine("There are currently no movies in the database."); }
        }

        // Entry point for sorting the movies by their popularity
        public void QuickSortMovies(Movie[] array_movies, int index_left, int index_right) {
            int index_pivot;
            if (index_left < index_right) {
                index_pivot = Partition(array_movies, index_left, index_right);
                QuickSortMovies(array_movies, index_left, index_pivot);
                QuickSortMovies(array_movies, index_pivot+1, index_right);
            }
        }

        // Sorting
        public int Partition(Movie[] array_movies, int index_left, int index_right) {
            int pivot_movie = array_movies[index_left].NumTimesRented;
            index_left--;
            index_right++;
            while (true) {
                do { index_left++; } while (array_movies[index_left].NumTimesRented > pivot_movie);
                do { index_right--; } while (array_movies[index_right].NumTimesRented < pivot_movie);
                if (index_left >= index_right) { return index_right; }
                // Swapping the left and right movies
                Movie temp_movie = array_movies[index_right];
                array_movies[index_right] = array_movies[index_left];
                array_movies[index_left] = temp_movie;
            }
        }
    }
}
