using System;

namespace NotBlockbuster {
    public class MovieCollection {
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

        // BST is initialised as empty: with no root or nodes
        public MovieCollection() { root = null; }

        // Entry point for inserting a movie.
        // Recuresively calls insertRec() to find where the movie's node belongs
        public void InsertMovie(Movie movie) { root = InsertRec(root, movie); }

        // Insert a movie into the BST
        public Node InsertRec(Node root, Movie movie) {
            // If the tree is empty, make this movie the root
            if (root == null) { return new Node(movie); }
            // If the tree exists, recur the movie down the branches
            if (movie.CompareTo(root.movie) < 0) { root.left = InsertRec(root.left, movie); } // choose left branch
            else if (movie.CompareTo(root.movie) > 0) { root.right = InsertRec(root.right, movie); } // choose right branch
            // return the (unchanged) node pointer
            return root;
        }

        // Entry point for searching for a movie.
        // Recuresively calls SearchRec() to find where the movie's node is and return it
        public Movie SearchMovie(string movie_title) { return SearchRec(this.root, movie_title.ToLower()); }

        // Search for a given movie in the BST 
        public Movie SearchRec(Node root, string movie_title) {
            // If the tree doesn't exist,
            if (root == null) { return null; }
            // If this node is the movie
            else if (string.Equals(root.movie.Title.ToLower(), movie_title)) { return root.movie; }
            // Otherwise subset the tree in-search of the movie
            // If the root is (larger than) / (to the right of) the movie
            else if (string.Compare(movie_title, root.movie.Title.ToLower()) < 0) { return SearchRec(root.left, movie_title); }
            // Otherwise the root is (smaller than) / (to the left of) the movie
            return SearchRec(root.right, movie_title);
        }

        // Entry point for deleting a movie.
        // Recuresively calls deleteRec() to find where the movie's node is and delete it
        public void DeleteMovie(string movie_title) {
            root = DeleteRec(root, movie_title.ToLower());
            Console.WriteLine("Successfully deleted the movie '" + movie_title + "'.\n");
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

        // Calculate the next "smallest" node
        public Movie MinValue(Node root) {
            Movie minv = root.movie;
            while (root.left != null) {
                minv = root.left.movie;
                root = root.left;
            }
            return minv;
        }

        public int LABEL_SPACE = 10;

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
            for (int i = LABEL_SPACE; i < space; i++) { Console.Write(" "); } // create horintal space
            Console.Write("  /\n");
            for (int i = LABEL_SPACE; i < space; i++) { Console.Write(" "); } // create horintal space
            Console.Write("(" + (space / LABEL_SPACE) + ") "+ root.movie.Title + "\n");
            for (int i = LABEL_SPACE; i < space; i++) { Console.Write(" "); } // create horintal space
            Console.Write("  \\ \n");
            // Process the left branch
            PrintNode(root.left, space);
        }

        // Wrapper over printNode()  
        public void PrintBST(Node root) {
            Console.WriteLine("The Binary Search Tree:");
            PrintNode(root, 0); // start the tree with no indentation
            Console.WriteLine("\n");
        }
    }
}
