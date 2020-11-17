using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsDatasetStructure
{
    public partial class frmDatasetHomework : Form
    {
        public frmDatasetHomework()
        {
            InitializeComponent();
        }

        DataSet mySet;
        string mode = " ";
        string selectNumber;
        int currentIndex = 0;


        private void Display()
        {
            DataRow myrow = mySet.Tables["Students"].Rows[0];
            txtFullname.Text = myrow["FullName"].ToString();
            datBday.Value = Convert.ToDateTime(myrow["Birthdate"]);
            txtGender.Text = myrow["Gender"].ToString();
            txtAverage.Text = myrow["Average"].ToString();
        }


        private void CreateDataset()
        {
            // to create a dataset, always use 'new'
            mySet = new DataSet();

            //  ---  CREATE Table Courses  -------------------
            DataTable myTb = new DataTable("Courses");

            // Create column (or field) RefCourse
            DataColumn myCol = new DataColumn("RefCourse");
            myCol.DataType = Type.GetType("System.Int64");
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Number
            myCol = new DataColumn("Number", Type.GetType("System.String"));
            myCol.MaxLength = 20;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Title
            myCol = new DataColumn("Title", Type.GetType("System.String"));
            myCol.MaxLength = 100;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Teacher
            myCol = new DataColumn("Teacher", Type.GetType("System.String"));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Duration
            myCol = new DataColumn("Duration", Type.GetType("System.Int16"));
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create primary key (number)
            DataColumn[] keys = new DataColumn[1];
            keys[0] = myTb.Columns["Number"];
            myTb.PrimaryKey = keys;


            mySet.Tables.Add(myTb);  // Save the table in the dataset


            //  ---  CREATE Table STUDENTS  -------------------
            myTb = new DataTable("Students");

            // Create column (or field) RefStudent
            myCol = new DataColumn("RefStudent");
            myCol.DataType = Type.GetType("System.Int64");
            myCol.AutoIncrement = true;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) FullName
            myCol = new DataColumn("FullName", Type.GetType("System.String"));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Gender
            myCol = new DataColumn("Gender", Type.GetType("System.String"));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Birthdate
            myCol = new DataColumn("Birthdate", Type.GetType("System.DateTime"));
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) Average
            myCol = new DataColumn("Average", Type.GetType("System.Single"));
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create column (or field) ReferCourse
            myCol = new DataColumn("ReferCourse", Type.GetType("System.Int64"));
            myTb.Columns.Add(myCol);  // Save the column in the table

            // Create primary key (RefStudent)
            DataColumn[] keystuds = new DataColumn[1];
            keystuds[0] = myTb.Columns["RefStudent"];
            myTb.PrimaryKey = keystuds;

            mySet.Tables.Add(myTb);  // Save the table in the dataset

            //  ------- Create RELATIONSHIP ----------------
            DataRelation myRel = new DataRelation("Cours_Stud",
                mySet.Tables["Courses"].Columns["RefCourse"], mySet.Tables["Students"].Columns["ReferCourse"]);
            mySet.Relations.Add(myRel);  // Save the relation in the dataset


            // ------- ENTERING DATA IN TABLES -- COURSES ------  //
            DataRow myRow = mySet.Tables["Courses"].NewRow();
            // myRow["RefCourse"] = 1;  // it is autonumber, so automaticaly create its own values
            myRow["Number"] = "420-AP1-AS";
            myRow["Title"] = "Algorithm and Porgramming";
            myRow["Teacher"] = "Fode Toure";
            myRow["Duration"] = 90;
            mySet.Tables["Courses"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Courses"].NewRow();
            // myRow["RefCourse"] = 2;  // it is autonumber, so automaticaly create its own values
            myRow["Number"] = "420-DA3-AS";
            myRow["Title"] = "Multi-Tiers Applications";
            myRow["Teacher"] = "Coa NGuyen";
            myRow["Duration"] = 85;
            mySet.Tables["Courses"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Courses"].NewRow();
            // myRow["RefCourse"] = 3;  // it is autonumber, so automaticaly create its own values
            myRow["Number"] = "420-DB2-AS";
            myRow["Title"] = "Database Oracle";
            myRow["Teacher"] = "Mohamed Zeroug";
            myRow["Duration"] = 75;
            mySet.Tables["Courses"].Rows.Add(myRow); // Save the record in the table


            // ------- ENTERING DATA IN TABLES -- STUDENTS ------  //
            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 0;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Bill Gates";
            myRow["Gender"] = "Male";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 90;
            myRow["ReferCourse"] = 1;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 1;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Steve Jobs";
            myRow["Gender"] = "Male";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 80;
            myRow["ReferCourse"] = 2;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 2;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Sophie Marceau";
            myRow["Gender"] = "Female";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 70;
            myRow["ReferCourse"] = 1;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 0;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Donald Trump";
            myRow["Gender"] = "Unknown";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 5;
            myRow["ReferCourse"] = 3;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 0;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Alexandra Cortez";
            myRow["Gender"] = "Female";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 95;
            myRow["ReferCourse"] = 2;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table

            myRow = mySet.Tables["Students"].NewRow();
            // myRow["RefStudent"] = 0;  // it is autonumber, so automaticaly create its own values
            myRow["FullName"] = "Michael Jackson";
            myRow["Gender"] = "Unkown";
            myRow["Birthdate"] = DateTime.Today;
            myRow["Average"] = 50;
            myRow["ReferCourse"] = 1;
            mySet.Tables["Students"].Rows.Add(myRow); // Save the record in the table


        }

        private void frmDatasetHomework_Load(object sender, EventArgs e)
        {
            // Call the function to manualy create the dataset
            CreateDataset();


            //txtNumber.Text = mySet.Tables["Courses"].Rows[2]["Title"].ToString();
            //fill the list box with all the courses numbers
            // loop with indexes
            /*for(int inx = 0; inx < mySet.Tables["Courses"].Rows.Count; inx++)
            {
                lstCourseNumbers.Items.Add(mySet.Tables["Courses"].Rows[inx]["Number"].ToString());
            }*/


            //Loop OOP version with object in colection
            foreach (DataRow myRow in mySet.Tables["Courses"].Rows)
            {
                lstCourseNumbers.Items.Add(myRow["Number"].ToString());
            }


            //active button 
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;


            //part 2
            //OOP version with a method




            Display();
           // currentIndex = 1;
            lblInfo.Text = "Student "+ (currentIndex + 1 ) + " on a total of " + mySet.Tables["Students"].Rows.Count;
           

        }

        private void lstCourseNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lstCourseNumbers.SelectedIndex != -1)
            {
                selectNumber = lstCourseNumbers.SelectedItem.ToString();

                /*
                // search for a record in table.row
                //Loop version
                foreach (DataRow myRow in mySet.Tables["Courses"].Rows)
                {
                    if (selectNumber == myRow["Number"].ToString()) // if the number is found 
                    {
                        txtNumber.Text = myRow["Number"].ToString();
                        txtTitle.Text = myRow["Title"].ToString();
                        txtTeacher.Text = myRow["Teacher"].ToString();
                        txtDuration.Text = myRow["Duration"].ToString();
                        return;
                    }
                }
                */

                //OOP version with a method
                DataRow myrow = mySet.Tables["Courses"].Rows.Find(selectNumber);
                txtNumber.Text = myrow["Number"].ToString();
                txtTitle.Text = myrow["Title"].ToString();
                txtTeacher.Text = myrow["Teacher"].ToString();
                txtDuration.Text = myrow["Duration"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtNumber.Text = txtTitle.Text = txtDuration.Text = txtTeacher.Text = " ";
            txtNumber.Focus();
            
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtNumber.Enabled = false;
            txtTitle.Focus();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Delete this Course?","Course Deletion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning).ToString() == "Yes")
            {
                DataRow myRow = mySet.Tables["Courses"].Rows.Find(selectNumber);
                mySet.Tables["Courses"].Rows.Remove(myRow);

                lstCourseNumbers.Items.Remove(selectNumber);
                lstCourseNumbers.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow myRow;
            if(mode == "Add")
            {
                //check if number is not exist in list
                if (lstCourseNumbers.Items.Contains(txtNumber.Text) == true)
                {
                    MessageBox.Show("This Course number is already exist", "Adding Fails", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumber.Focus();
                    return;
                }
                else
                {
                    myRow = mySet.Tables["Courses"].NewRow();

                    myRow["Number"] = txtNumber.Text;
                    myRow["Title"] = txtTitle.Text;
                    myRow["Teacher"] = txtTeacher.Text;
                    myRow["Duration"] = Convert.ToInt16(txtDuration.Text);
                    mySet.Tables["Courses"].Rows.Add(myRow); // Save the record in the table

                    lstCourseNumbers.Items.Add(myRow["Number"].ToString());
                }
            }
            else// mode == Edit
            {
                myRow = mySet.Tables["Courses"].Rows.Find(selectNumber);
                myRow["Title"] = txtTitle.Text;
                myRow["Teacher"] = txtTeacher.Text;
                myRow["Duration"] = Convert.ToInt16(txtDuration.Text);

                txtNumber.Enabled = true;

            }

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //OOP version with a method
            Display();
            currentIndex = 1;
            lblInfo.Text = "Student "+(currentIndex) +" on a total of " + mySet.Tables["Students"].Rows.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //OOP version with a method
            DataRow myrow = mySet.Tables["Students"].Rows[mySet.Tables["Students"].Rows.Count -1];
            txtFullname.Text = myrow["FullName"].ToString();
            datBday.Value = Convert.ToDateTime(myrow["Birthdate"]);
            txtGender.Text = myrow["Gender"].ToString();
            txtAverage.Text = myrow["Average"].ToString();
            currentIndex = 6;
            lblInfo.Text = "Student " + (currentIndex) + " on a total of " + mySet.Tables["Students"].Rows.Count;
        }

        

        

         private void btnNext_Click(object sender, EventArgs e)
         {

            if (currentIndex < mySet.Tables["Students"].Rows.Count -1)
            {

                currentIndex += 1;

                DataRow myrow = mySet.Tables["Students"].Rows[currentIndex];
                txtFullname.Text = myrow["FullName"].ToString();
                datBday.Value = Convert.ToDateTime(myrow["Birthdate"]);
                txtGender.Text = myrow["Gender"].ToString();
                txtAverage.Text = myrow["Average"].ToString();

                lblInfo.Text = "Student " + (currentIndex +1) + " on a total of " + mySet.Tables["Students"].Rows.Count;


            }
             
         }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            if (currentIndex > 0)
            {

                currentIndex -= 1;

                DataRow myrow = mySet.Tables["Students"].Rows[currentIndex];
                txtFullname.Text = myrow["FullName"].ToString();
                datBday.Value = Convert.ToDateTime(myrow["Birthdate"]);
                txtGender.Text = myrow["Gender"].ToString();
                txtAverage.Text = myrow["Average"].ToString();

                lblInfo.Text = "Student " + (currentIndex) + " on a total of " + mySet.Tables["Students"].Rows.Count;

            }  

            
        }
    }
}
