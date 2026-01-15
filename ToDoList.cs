using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }
        DataTable todoList = new DataTable();
        bool isEditMode = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            //Create columns for DataTable
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            //point our DataGridView to DataTable
            toDoListView.DataSource = todoList;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            //fill textfield with data from table
            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditMode) 
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
            }
            else
            {
                //Add new row to DataTable
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            //clear textfields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditMode = false;
        }
    }
}
