using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    class FieldBuilder
    {
        public FieldBuilder(Control parent)
        {
            this.parent = parent;
        }

        private Control parent;

        public PictureBox[,] Create(int height, int width)
        {
            var pictureBoxes = new PictureBox[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pictureBoxes[i, j] = new PictureBox
                    {
                        Parent = parent,
                        Location = new Point(j * 18, i * 18),
                        Size = new Size(20, 20),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(0),
                        BackColor = Color.White,
                        Tag = new Point(j, i)
                    }; 
                }
            }

            return pictureBoxes;
        }

        public void Delete(Control[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j].Dispose();
                }
            }
        }

    }
}
