using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace inlämningsuppgift
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        private Pen pen;
        private List<Shape> shapes;
        private Stack<Shape> undoStack;
        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
            InitializeComboBox();


        }
        private void InitializeComboBox()
        {
            toolBox.Items.Add("Circle");
            toolBox.Items.Add("Square");
            toolBox.Items.Add("Triangle");
        }
        private void InitializeDrawing()
        {
            graphics = drawingPanel.CreateGraphics();
            pen = new Pen(Color.Black);
            shapes = new List<Shape>();
            undoStack = new Stack<Shape>();
            graphics.Clear(drawingPanel.BackColor);
        }

        private void DrawShapes()
        {
            graphics.Clear(Color.White);
            foreach (Shape shape in shapes)
            {

                shape.Draw(graphics);

            }
        }
        private void InitializeComponent()
        {
            colorButton = new System.Windows.Forms.Button();
            clearButton = new System.Windows.Forms.Button();
            undoButton = new System.Windows.Forms.Button();
            redoButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            openButton = new System.Windows.Forms.Button();
            drawingPanel = new Panel();
            toolBox = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // colorButton
            // 
            colorButton.BackColor = Color.Cyan;
            colorButton.Location = new Point(793, 66);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(108, 35);
            colorButton.TabIndex = 1;
            colorButton.Text = "Färg";
            colorButton.UseVisualStyleBackColor = false;
            colorButton.Click += colorButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(793, 223);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(108, 35);
            clearButton.TabIndex = 2;
            clearButton.Text = "Radera";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // undoButton
            // 
            undoButton.BackColor = Color.FromArgb(255, 192, 128);
            undoButton.Location = new Point(793, 171);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(108, 35);
            undoButton.TabIndex = 3;
            undoButton.Text = "Ångra";
            undoButton.UseVisualStyleBackColor = false;
            undoButton.Click += undoButton_Click;
            // 
            // redoButton
            // 
            redoButton.BackColor = Color.FromArgb(255, 192, 255);
            redoButton.Location = new Point(793, 121);
            redoButton.Name = "redoButton";
            redoButton.Size = new Size(108, 35);
            redoButton.TabIndex = 4;
            redoButton.Text = "Göra om";
            redoButton.UseVisualStyleBackColor = false;
            redoButton.Click += redButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(192, 192, 0);
            saveButton.Location = new Point(934, 417);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(108, 35);
            saveButton.TabIndex = 5;
            saveButton.Text = "Spara";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // openButton
            // 
            openButton.BackColor = Color.Gold;
            openButton.Location = new Point(797, 417);
            openButton.Name = "openButton";
            openButton.Size = new Size(108, 35);
            openButton.TabIndex = 6;
            openButton.Text = "Öppna";
            openButton.UseVisualStyleBackColor = false;
            openButton.Click += openButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.BackColor = Color.FromArgb(192, 255, 192);
            drawingPanel.Location = new Point(0, 0);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(766, 655);
            drawingPanel.TabIndex = 12;
           
            drawingPanel.MouseDown += drawingPanel_MouseDown;
            // 
            // toolBox
            // 
            toolBox.BackColor = Color.SandyBrown;
            toolBox.FormattingEnabled = true;
            toolBox.Location = new Point(793, 12);
            toolBox.Name = "toolBox";
            toolBox.Size = new Size(157, 28);
            toolBox.TabIndex = 8;
            toolBox.Text = "   Välja ............";
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(1069, 743);
            Controls.Add(toolBox);
            Controls.Add(drawingPanel);
            Controls.Add(openButton);
            Controls.Add(saveButton);
            Controls.Add(redoButton);
            Controls.Add(undoButton);
            Controls.Add(clearButton);
            Controls.Add(colorButton);
            ForeColor = Color.Black;
            Name = "Form1";
            Text = "ProgramsRitning";
            ResumeLayout(false);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            graphics.Clear(drawingPanel.BackColor);

        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                undoStack.Push(shapes[shapes.Count - 1]);
                shapes.RemoveAt(shapes.Count - 1);
                RedrawPanel();

            }

        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                shapes.Add(undoStack.Pop());
                RedrawPanel();

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            // Skapa en ny bitmap
            Bitmap bitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(drawingPanel.BackColor);

                // Rita varje figur på den nya bitmapen
                foreach (Shape shape in shapes)
                {
                    shape.Draw(graphics);
                }
            }

            // Spara den nya bitmapen till fil
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|Bitmap Image|*.bmp|JPEG Image|*.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog.FileName);
            }



        }



        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                graphics.DrawImage(bitmap, new Point(0, 0));
            }
        }



        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolBox.SelectedItem != null)
            {
                switch (toolBox.SelectedItem.ToString())
                {
                    case "Circle":
                        shapes.Add(new Circle(e.Location, pen.Color));
                        break;
                    case "Square":
                        shapes.Add(new Kvadrater(e.Location, pen.Color));
                        break;
                    case "Triangle":
                        shapes.Add(new Triangle(e.Location, pen.Color));
                        break;
                    default:
                        break;
                }
            }

            DrawNewShapes();
        }

        private void DrawNewShapes()
        {
            foreach (Shape shape in shapes.Skip(shapes.Count - 1))
            {
                shape.Draw(graphics);
            }
        }

        private void RedrawPanel()
        {
            // Rensa panelen
            graphics.Clear(drawingPanel.BackColor);
            // Rita alla figurer igen
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphics);
            }
        }

      
    }
}
