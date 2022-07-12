using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static BlockShift.State;

namespace BlockShift {
    public partial class Form1 : Form {

        


        
        public Pen p;
        Graphics graphics;
        Bitmap bmp;
        State state;

        public Form1(State s) {
            state = s;
            InitializeComponent();
            GenerateVaribles();
        }

        void GenerateVaribles() {
            graphics = pb_canvas.CreateGraphics();
            
            CreateCanvas();
        }

        //drawing a block's borders correctly requires being able to find the block of a particular location
        void CreateCanvas() {
            bmp = new Bitmap(pb_canvas.Width, pb_canvas.Height);
            graphics = Graphics.FromImage(bmp);
            pb_canvas.BackgroundImage = bmp;
            pb_canvas.BackgroundImageLayout = ImageLayout.None;

            bool winCheckOne = false;
            foreach(State.Location l in state.board.SolutionBlock.LocationList) {
                if (l.X == 1 && l.Y == 4) {
                    if (winCheckOne) {
                        winGame();
                        return;
                    }
                    winCheckOne = true;
                } else if (l.X == 2 && l.Y == 4) {
                    if (winCheckOne) {
                        winGame();
                        return;
                    }
                    winCheckOne = true;
                }
            }
            


            Pen p = new Pen(Color.LightGray, 1);

            //graphics.DrawLine(p, new Point(0, 320), new Point(320, 350));
            for(int i = 0; i < 4; i++) {
                graphics.DrawLine(p, new Point(60 * i, 0), new Point(60 * i, 330)); 
                for (int j = 0; j < 5; j++) {
                    graphics.DrawLine(p, new Point(0, 60 * j), new Point(320, 60 * j));
                }
            }

            List<State.Block> blockList = state.board.Blocks;
            p = new Pen(Color.Black, 2);
            SolidBrush b;
            foreach (State.Block s in blockList) {

               
                if (s.Equals(state.board.SelectedBlock)) {
                    b = new SolidBrush(Color.Red);
                } else if (s.Equals(state.board.SolutionBlock)) {
                    b = new SolidBrush(Color.Orange);
                }else{
                    b = new SolidBrush(Color.Gray);
                }
                foreach(State.Location l in s.LocationList) {
                    System.Diagnostics.Debug.WriteLine(l.X);
                    graphics.FillRectangle(b, new Rectangle(l.X * 60, l.Y * 60, 60, 60));

                    if(l.X == 0 || l.B != state.board.BoardLocations[l.X-1, l.Y].B) {
                        graphics.DrawLine(p, new Point(l.X * 60, l.Y * 60), new Point(l.X * 60, (l.Y + 1) * 60));
                    }
                    if (l.X == 3 || l.B != state.board.BoardLocations[l.X + 1, l.Y].B) {
                        graphics.DrawLine(p, new Point((l.X+1) * 60, l.Y * 60), new Point((l.X+1) * 60, (l.Y + 1) * 60));
                    }
                    if (l.Y == 0 || l.B != state.board.BoardLocations[l.X, l.Y-1].B) {
                        graphics.DrawLine(p, new Point(l.X * 60, l.Y * 60), new Point((l.X+1) * 60, l.Y * 60));
                    }
                    if (l.Y == 4 || l.B != state.board.BoardLocations[l.X, l.Y + 1].B) {
                        graphics.DrawLine(p, new Point(l.X * 60, (l.Y+1) * 60), new Point((l.X + 1) * 60, (l.Y + 1) * 60));
                    }



                }
            }




        }

        private void pb_canvas_MouseDown(object sender, MouseEventArgs e) {


           


            Point point = e.Location;

            int xCoord = point.X / 60;
            int yCoord = point.Y / 60;
            State.Location l = state.board.BoardLocations[xCoord, yCoord];
            state.board.SelectedBlock = l.B;

            CreateCanvas();
            //pb_canvas.Invalidate();


        }

        private void pb_canvas_MouseMove(object sender, MouseEventArgs e) {
            
        }

        private void pb_canvas_MouseUp(object sender, MouseEventArgs e) {
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            state = new State();
            CreateCanvas();
           
        }

       

        

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void leftButton_Click(object sender, EventArgs e) {
            Board b = state.board.clone();
            if (state.board.moveSelectedBlock("left")) {
                UndoManager.instance().record(b);
            }
            CreateCanvas();
            resetSolve();
        }

        private void upButton_Click(object sender, EventArgs e) {
            Board b = state.board.clone();
            if (state.board.moveSelectedBlock("up")) {
                UndoManager.instance().record(b);
            }
            CreateCanvas();
            resetSolve();
        }

        private void rightButton_Click(object sender, EventArgs e) {
            Board b = state.board.clone();
            if (state.board.moveSelectedBlock("right")) {
                UndoManager.instance().record(b);
            }
            CreateCanvas();
            resetSolve();
        }

        private void downButton_Click(object sender, EventArgs e) {
            Board b = state.board.clone();
            if (state.board.moveSelectedBlock("down")) {
                UndoManager.instance().record(b);
            }
            CreateCanvas();
            resetSolve();
        }

        private void resetSolve() {
            nextButton.Enabled = false;
            SolutionManager.instance().SolutionNode = null;
        }

        private void solve_Click(object sender, EventArgs e) {
            State.Node node = state.solve();
            nextButton.Enabled = true;
            SolutionManager.instance().SolutionNode = node;
                
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!UndoManager.instance().noMoves()) {
                state.setBoard(UndoManager.instance().getLast());
            }
            CreateCanvas();
        }

        private void nextButton_Click(object sender, EventArgs e) {
            Node currentSolution = SolutionManager.instance().advance();

            state.setBoard(currentSolution.Board);
            if (SolutionManager.instance().isDone()) {
                nextButton.Enabled = false;
            }

            CreateCanvas();
        }
    }
}
