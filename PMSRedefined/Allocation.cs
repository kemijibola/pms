using PMSRedefined.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSRedefined
{
    public partial class Allocation : Form
    {
        public Allocation()
        {
            InitializeComponent();
        }

        private void Allocation_Load(object sender, EventArgs e)
        {
            pmsstoreEntities entties = new pmsstoreEntities();
            var queryLecturers = (from d in entties.tbl_CSLecturer
                select d).ToList();
            this.listBox1.DataSource = queryLecturers;
            this.listBox1.ValueMember = "Guid";
            this.listBox1.DisplayMember = "Name";
            this.listBox1.SelectedIndex = -1;

            var queryStudents = (from p in entties.tbl_Student
                select p).ToList();
            this.checkedListBox1.DataSource = queryStudents;
            this.checkedListBox1.DisplayMember = "Name";
            this.checkedListBox1.ValueMember = "GUID";

            var querySession = (from p in entties.tbl_Session
                select p).ToList();
            this.comboBox1.DataSource = querySession;
            this.comboBox1.DisplayMember = "SessionName";
            this.comboBox1.ValueMember = "GUID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pmsstoreEntities entties = new pmsstoreEntities();
         
            foreach (var j in this.checkedListBox1.CheckedItems)
            {
                tbl_Student studentItem = (tbl_Student) j;
                tbl_CSLecturer lecturerItem = (tbl_CSLecturer) this.listBox1.SelectedItem;
                int sessionId =Convert.ToInt32(this.comboBox1.SelectedValue);
                //check if the student has been allocated to any lecturer before in selected session
                var queryCheck = (from p in entties.tbl_Allocation
                    where p.StudentID == studentItem.GUID && p.SessionID == sessionId
                    select p).FirstOrDefault();
                if (queryCheck != null)
                {
                    //this student is already assigned to this or another lecturer this session, therefore continue to the next student
                   continue;
                }


                tbl_Allocation allocation = new tbl_Allocation();
                allocation.DateAllocated = DateTime.Now;
                allocation.LecturerID = lecturerItem.GUID;
                allocation.SessionID = Convert.ToInt32(this.comboBox1.SelectedValue);
                allocation.StudentID = studentItem.GUID;
             
                entties.tbl_Allocation.Add(allocation);
            }
            entties.SaveChanges();
        }

        private void RefreshItems()
        {
            try
            {
                pmsstoreEntities entties = new pmsstoreEntities();

                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    foreach (var j in this.checkedListBox1.CheckedItems)
                    {

                        this.checkedListBox1.SetItemChecked(i, false);
                        break;
                    }
                }

                tbl_CSLecturer lecturerItem = (tbl_CSLecturer)this.listBox1.SelectedItem;
                int sessionId = Convert.ToInt32(this.comboBox1.SelectedValue);
                var queryAllocation = (from p in entties.tbl_Allocation
                                       where p.LecturerID == lecturerItem.GUID && p.SessionID == sessionId
                                       select p).ToList();
                foreach (var allocation in queryAllocation)
                {
                    foreach (var j in this.checkedListBox1.Items)
                    {
                        tbl_Student studentItem = (tbl_Student)j;
                        if (studentItem.GUID == allocation.StudentID)
                        {
                            this.checkedListBox1.SelectedItem = j;
                            int index = this.checkedListBox1.SelectedIndex;
                            this.checkedListBox1.SetItemChecked(index, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                pmsstoreEntities entties = new pmsstoreEntities();

                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    foreach (var j in this.checkedListBox1.CheckedItems)
                    {                  
                        
                        this.checkedListBox1.SetItemChecked(i, false);
                        break;
                    }
                }
          
                tbl_CSLecturer lecturerItem = (tbl_CSLecturer)this.listBox1.SelectedItem;
                   int sessionId =Convert.ToInt32(this.comboBox1.SelectedValue);
                var queryAllocation = (from p in entties.tbl_Allocation
                    where p.LecturerID == lecturerItem.GUID && p.SessionID == sessionId
                    select p).ToList();
                foreach (var allocation in queryAllocation)
                {
                    foreach (var j in this.checkedListBox1.Items)
                    {
                        tbl_Student studentItem = (tbl_Student)j;
                        if (studentItem.GUID == allocation.StudentID)
                        {
                            this.checkedListBox1.SelectedItem = j;
                            int index = this.checkedListBox1.SelectedIndex;                                 
                            this.checkedListBox1.SetItemChecked(index,true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pmsstoreEntities entties = new pmsstoreEntities();

            foreach (var j in this.checkedListBox1.CheckedItems)
            {
                tbl_Student studentItem = (tbl_Student)j;
                tbl_CSLecturer lecturerItem = (tbl_CSLecturer)this.listBox1.SelectedItem;
                int sessionId = Convert.ToInt32(this.comboBox1.SelectedValue);
                //check if the student has been allocated to any lecturer before in selected session
                var queryCheck = (from p in entties.tbl_Allocation
                                  where p.StudentID == studentItem.GUID && p.SessionID == sessionId
                                  select p).FirstOrDefault();
                if (queryCheck != null)
                {
                   //remove
                    entties.tbl_Allocation.Remove(queryCheck);                   
                }             
            }
            entties.SaveChanges();
            RefreshItems();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
