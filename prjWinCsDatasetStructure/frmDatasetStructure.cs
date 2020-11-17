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
    public partial class frmDatasetStructure : Form
    {
        public frmDatasetStructure()
        {
            InitializeComponent();
        }

        DataSet mySet;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // call the function to create our dataset
            CreateDataset();
            // fill the listbox with all the tables of mySet
            //// Index Loop version
            //for(int indx = 0; indx < mySet.Tables.Count; indx++)
            //{
            //    lstTables.Items.Add(mySet.Tables[indx].TableName);
            //}

            // OOP Loop Version
            foreach (DataTable myTb in mySet.Tables)
            {
                lstTables.Items.Add(myTb.TableName);
            }


           // gridResult.DataSource = mySet.Tables["Students"];
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

            // Create primary key (RefCourse)
            DataColumn[] keys = new DataColumn[1];
            keys[0] = myTb.Columns["RefCourse"];
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


        private void frmDatasetStructure_Load(object sender, EventArgs e)
        {

        }

        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        { 
            lstColumns.Items.Clear();
            string selectTab = lstTables.SelectedItem.ToString(); 
            // fill the list with the columns names
            foreach (DataColumn mycol in mySet.Tables[selectTab].Columns)
            {
                lstColumns.Items.Add(mycol.ColumnName);
            }


            // display the data of the selected table in the grid
            gridResult.DataSource = mySet.Tables[selectTab];


        }
    }
}
