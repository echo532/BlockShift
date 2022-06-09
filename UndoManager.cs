using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlockShift.State;

namespace BlockShift {
    class UndoManager {


        private static UndoManager _instance;
        private Stack<Board> allMoves = new Stack<Board> ();
        private UndoManager() { 
        }

        public static UndoManager instance() {
            if (_instance == null) {
                _instance = new UndoManager();
            }

            return _instance;
        }

        public void record(Board b) {
            allMoves.Push (b);
        }

        public Board getLast() { 
            return allMoves.Pop ();
        }

        public bool noMoves() {
            return allMoves.Count == 0;
        }

        



    }
}
