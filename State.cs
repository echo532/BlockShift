using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


using System.Diagnostics;

namespace BlockShift {

    [ComVisible(true)]
    public class State {

        public Board board;

        public void setBoard(Board b) {
            board = b;
        }




        public class Location {
            private int x;
            private int y;
            private bool occupied;
            Block b; //bi-directional relationship between Location <-> Block, used for drawing purposes, as well as to create a unique key for each puzzle

            public Location(int x, int y) {
                this.x = x;
                this.y = y;
                occupied = false;
                b = null;
            }

            public int X {
                get { return x; }
                set { x = value; }
            }

            public int Y {
                get { return y; }
                set { y = value; }
            }

            public bool Occupied {
                get { return occupied; }
                set { occupied = value; }
            }

            public Block B {
                get { return b; }
                set { b = value; }
            }



        }

        public class Block {
            private int width;
            private int height;


            public int Width {
                get { return width; }
            }

            public int Height {
                get { return height; }
            }

            private List<Location> locationList;
            public Block(int width, int height, List<Location> locationInputs) {
                
                locationList = new List<Location>();
                this.width = width;
                this.height = height;

                foreach (Location location in locationInputs) {
                    locationList.Add(location);
                    location.Occupied = true;
                    location.B = this;
                }
            }

            public List<Location> LocationList {
                get { return locationList; }
            }

            public String blockCode() {
                return "" + width + height;
            }

        }

        public class Board {
            private Location[,] boardLocations = new Location[4, 5];
            int row = 5;
            int col = 4;


            public Location[,] BoardLocations {
                get { return boardLocations; }
            }

            private List<Block> blocks = new List<Block>();

            public List<Block> Blocks {
                get { return blocks; }
            }

            private Block selectedBlock;


            public Block SelectedBlock {
                get { return selectedBlock; }
                set { selectedBlock = value; }
            }

            private Block solutionBlock;
            public Block SolutionBlock {
                get { return solutionBlock; }
                set { solutionBlock = value; }
            }

            public Board() {

            }

            public bool hasWon() {

                bool winCheckOne = false;
                foreach (State.Location l in SolutionBlock.LocationList) {
                    if (l.X == 1 && l.Y == 4) {
                        if (winCheckOne) {
                            return true;
                        }
                        winCheckOne = true;
                    } else if (l.X == 2 && l.Y == 4) {
                        if (winCheckOne) {
                            return true;
                        }
                        winCheckOne = true;
                    }
                }
                return false;
            }

            public bool moveSelectedBlock(String s) {
                int deltaX = 0;
                int deltaY = 0;
                int border = -1;
                if (s.Equals("down")) {
                    deltaY = 1;
                    border = 4;
                } else if (s.Equals("up")) {
                    deltaY = -1;
                    border = 0;
                } else if (s.Equals("left")) {
                    deltaX = -1;
                    border = 0;
                } else if (s.Equals("right")) {
                    deltaX = 1;
                    border = 3;
                }
                foreach (Location location in selectedBlock.LocationList) {
                    if (deltaX != 0 && location.X == border) {
                        return false;
                    } else if (deltaY != 0 && location.Y == border) {
                        return false;
                    }

                    if ((boardLocations[location.X + deltaX, location.Y + deltaY].Occupied && boardLocations[location.X + deltaX, location.Y + deltaY].B != selectedBlock)) {
                        return false;
                    }

                }
                List<Location> tempLocations = new List<Location>();
                foreach (Location location in selectedBlock.LocationList) {
                    tempLocations.Add(boardLocations[location.X + deltaX, location.Y + deltaY]);
                }

                foreach (Location location in selectedBlock.LocationList) {
                    location.B = null;
                    location.Occupied = false;
                }
                selectedBlock.LocationList.Clear();

                selectedBlock.LocationList.AddRange(tempLocations);
                foreach (Location location in selectedBlock.LocationList) {
                    location.B = selectedBlock;
                    location.Occupied = true;
                }

                //Debug.WriteLine(key());
                return true;
            }

            public override String ToString() {
                return key();
            }



            public String key() {
                String finalString = "";
                for (int r = 0; r < row; r++) {
                    for (int c = 0; c < col; c++) {
                        if (boardLocations[c, r].B == null) {
                            finalString += "00";
                        } else {
                            finalString += boardLocations[c, r].B.blockCode();
                        }

                    }
                    finalString += "\n";
                }

                return finalString;
            }

            private List<Location> duplicateLocs(Board copy, Block b) {
                List<Location> dupLocs = new List<Location>();
                foreach(Location loc in b.LocationList) {

                    dupLocs.Add(copy.BoardLocations[loc.X, loc.Y]);
                }

                return dupLocs;
            }

           

            public Board clone() {

                //list of locations
                //list of blocks
                Board copy = new Board();

                for (int i = 0; i < 4; i++) {
                    for (int j = 0; j < 5; j++) {
                        copy.BoardLocations[i, j] = new Location(i, j);

                    }
                }


                //have to handle Selected && Solution carefully
                if (selectedBlock != null) {
                    copy.SelectedBlock = new Block(SelectedBlock.Width, SelectedBlock.Height, duplicateLocs(copy, SelectedBlock));
                    copy.Blocks.Add(copy.SelectedBlock);
                }

                foreach(Block b in this.Blocks) {

                    if (b == this.SelectedBlock) {
                        if (b == this.SolutionBlock) {
                            copy.SolutionBlock = copy.SelectedBlock;
                        }
                        continue;
                    }
                    Block bCopy = new Block(b.Width, b.Height, duplicateLocs(copy, b));
                    copy.Blocks.Add(bCopy);
                    if (b == this.SolutionBlock) {
                        copy.SolutionBlock = bCopy;
                    }
                }

                return copy;


            }


        }


        


        public class Node {
            private Board board;

            private Node previous = null;

            private String direction;

            public Board Board{
                get {return board;}
            }

            public Node Previous {
                get { return previous; }
                set { previous = value; }
            }

            public String Direction {
                get { return direction; }
            }


            public Node(Board board, Node previous, string direction) {
                this.board = board;
                this.previous = previous;
                this.direction = direction;
            }
        }
        public Node solve() {
            Queue<Node> queue = new Queue<Node>();
            HashSet<String> seen = new HashSet<String>();
            Node start = new Node(board.clone(), null, "");
            Debug.Print(start.Board.key());
            queue.Enqueue(start);
            seen.Add(start.Board.key());
            String[] directionality = { "up", "down", "left", "right" };
            int counter = 0;
            while (queue.Any()) {
                counter++;
                if(counter%100000 == 0) {
                    Debug.Print("" + counter);
                }
                Node n = queue.Dequeue();

                //Debug.Print(n.Board.key());
                foreach (Block b in n.Board.Blocks) {
                    Location first = b.LocationList.ElementAt(0);
                    foreach(String d in directionality) {
                        Board copy = n.Board.clone();
                        Block bcopy = copy.BoardLocations[first.X, first.Y].B;
                        copy.SelectedBlock = bcopy;

                        if (copy.moveSelectedBlock(d)) {
                            // Debug.Print("**" + d + "**\n" + copy.key());
                            Node next = new Node(copy, n, d);
                            if (copy.hasWon()) {
                                Debug.Print(copy.key());
                                return next;
                            }
                            if (!seen.Contains(copy.key())){
                                queue.Enqueue(next);
                                seen.Add(copy.key());
                            }
                        }
                    }

                }
            }
            return null;
        }

        public State() { 
            
            board = new Board();

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 5; j++) {
                    board.BoardLocations[i, j] = new Location(i, j);

                }
            }

            board.SelectedBlock = new Block(1, 2, new List<Location> { board.BoardLocations[0, 0], board.BoardLocations[0, 1] });
            board.Blocks.Add(board.SelectedBlock);

            board.SolutionBlock = new Block(2, 2, new List<Location> { board.BoardLocations[1, 0], board.BoardLocations[1, 1], board.BoardLocations[2, 0], board.BoardLocations[2, 1] });

            board.Blocks.Add(board.SolutionBlock);
            board.Blocks.Add(new Block(1, 2, new List<Location> { board.BoardLocations[3, 0], board.BoardLocations[3, 1] }));

            board.Blocks.Add(new Block(1, 2, new List<Location> { board.BoardLocations[0, 2], board.BoardLocations[0, 3] }));
            board.Blocks.Add(new Block(1, 1, new List<Location> { board.BoardLocations[1, 2] }));
            board.Blocks.Add(new Block(1, 1, new List<Location> { board.BoardLocations[1, 3] }));
            board.Blocks.Add(new Block(1, 1, new List<Location> { board.BoardLocations[2, 2] }));
            board.Blocks.Add(new Block(1, 1, new List<Location> { board.BoardLocations[2, 3] }));
            board.Blocks.Add(new Block(1, 2, new List<Location> { board.BoardLocations[3, 2], board.BoardLocations[3, 3] }));
            board.Blocks.Add(new Block(2, 1, new List<Location> { board.BoardLocations[1, 4], board.BoardLocations[2, 4] }));


        }

    }
            
    
    
}
