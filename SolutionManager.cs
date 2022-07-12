using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlockShift.State;

namespace BlockShift {
    class SolutionManager {


        private static SolutionManager _instance;

        private Node solutionNode;
        
        private SolutionManager() { 
        }

        public static SolutionManager instance() {
            if (_instance == null) {
                _instance = new SolutionManager();
            }

            return _instance;
        }

        public Node SolutionNode {
            get { return solutionNode; }
            set { solutionNode = value; }
        }

        public bool isDone() {
            if (solutionNode == null) {
                return true;
            }

            return solutionNode.Previous == null;
        }

        public Node advance() {
            

            if(solutionNode == null) {
                return null;
            }

            Node nextNode = solutionNode;

            if (nextNode.Previous == null) {
                solutionNode = null;
                return nextNode;
            }

            while(nextNode.Previous.Previous != null) {
                nextNode = nextNode.Previous;

            }
           
            nextNode.Previous = null;


            return nextNode;


        }

        



    }
}
