using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8_3
{
    public partial class Form1 : Form
    {
        private TrueFalse database;

        public Form1()
        {
            InitializeComponent();
            ChangeEnableButtons();
        }

        #region menu strip
        private void subMenuNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Земля круглая?", true);
                database.Save();

                RefreshList();
                lbxDatabase.SelectedIndex = 0;

                ChangeEnableButtons();
            }
        }

        private void subMenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.Load();
                
                RefreshList();
                lbxDatabase.SelectedIndex = 0;

                ChangeEnableButtons();
            }
        }

        private void subMenuSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void subMenuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFileDialog.FileName;
                database.Save();
            }
        }

        private void subMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Beard! Or Lie! v.1.0.0\nAivar Sergeev\nCopyWrite 2021 (c)", "About the Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Events
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxDatabase.SelectedIndex;
            database.Remove(selectedIndex);
            RefreshList();
            if (database.Count > 0)
            {
                lbxDatabase.SelectedIndex = selectedIndex >= database.Count ? database.Count - 1 : selectedIndex;
            }
            else
            {
                txtQuestion.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Add("#" + (database.Count + 1).ToString(), true);
            RefreshList();
            lbxDatabase.SetSelected(database.Count - 1, true);
        }

        private void lbxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDatabase.SelectedIndex >= 0)
            {
                txtQuestion.Text = database[lbxDatabase.SelectedIndex].Text;
                cbxAnswer.Checked = database[lbxDatabase.SelectedIndex].TrueFalse;
            }
        }

        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {
            if (lbxDatabase.SelectedIndex >= 0)
            {
                database[lbxDatabase.SelectedIndex].Text = txtQuestion.Text;
                lbxDatabase.Items[lbxDatabase.SelectedIndex] = $"{lbxDatabase.SelectedIndex + 1}. {txtQuestion.Text}";
            }
        }

        private void cbxAnswer_CheckedChanged(object sender, EventArgs e)
        {
            database[lbxDatabase.SelectedIndex].TrueFalse = cbxAnswer.Checked;
        }
        #endregion

        private void RefreshList()
        {
            lbxDatabase.Items.Clear();
            for (int i = 0; i < database.Count; i++)
            {
                lbxDatabase.Items.Add($"{i + 1}. {database[i].Text}");
            }
        }

        private void ChangeEnableButtons()
        {
            bool enabled = database != null;
            btnAdd.Enabled = enabled;
            btnRemove.Enabled = enabled;
            subMenuSave.Enabled = enabled;
            subMenuSaveAs.Enabled = enabled;
            cbxAnswer.Enabled = enabled;
        }
    }
}
