using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace refresher_2
{
    public partial class frmStudentMarks : Form
    {   
        public frmStudentMarks()
        {
            InitializeComponent();
        }

        private void btnGenerateMarks_Click(object sender, EventArgs e)
        {   lstMarks.Items.Clear();
            if (!int.TryParse(txtNumberOfStudents.Text, out int numberOfStudents) && numberOfStudents > 0)
            {
                MessageBox.Show("Please enter a valid number of students greater than 0.");

            }
            else
            {   
                Random random = new Random();
                for (int i = 0; i < numberOfStudents; i++)
                {
                    int studentMarks = random.Next(0, 101);
                    lstMarks.Items.Add(studentMarks);

                }
                lblAverage.Text = "Average: " + Convert.ToString(CalculateAverageMarks());
                lbleLowest.Text = "Lowest: " + Convert.ToString(LowestMarks());
                lblHighest.Text = "Highest: " + Convert.ToString(HighestMarks());
            }


              
        }
        public double CalculateAverageMarks()
        {   double totalMarks = 0;
            for (int j=0; j < lstMarks.Items.Count; j++)
            {
                totalMarks += Convert.ToDouble(lstMarks.Items[j]);
            }
            return totalMarks / lstMarks.Items.Count;
        }
        public object HighestMarks()

        {
            double highestMarks = Convert.ToDouble(lstMarks.Items[0]);
            for (int k = 0; k < lstMarks.Items.Count; k++)
            {   
                int currentMark = Convert.ToInt32(lstMarks.Items[k]);
                if (currentMark > highestMarks)
                {
                    highestMarks = currentMark;

                }
            }
         return highestMarks;

        }
        public object LowestMarks()
        {
            double lowestMarks = Convert.ToDouble(lstMarks.Items[0]);

            for (int k = 0; k < lstMarks.Items.Count; k++)
            {
                int currentMark = Convert.ToInt32(lstMarks.Items[k]);
                if (currentMark < lowestMarks)
                {
                    lowestMarks = currentMark;
                }
            }
            return lowestMarks;
        }
    }
}
