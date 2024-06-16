using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ДП
{
    public partial class Employee : Form
    {
        ForSQL forSQL = new ForSQL();
        int selectedRow;
        public Employee()
        {
            InitializeComponent();
        }
        private void ReadSingleRowData(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetString(1),
                dataRecord.GetString(2),
                dataRecord.GetString(3),
                dataRecord.GetString(4),
                rowState.ModifiedNew);
        }
        public void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            try
            {
                forSQL.openConnection();
                string queryString = "SELECT IDEmployee, Surname, Name, Patronymic, PostTb.Post\r\n" +
                    "FROM Employee \r\n" +
                    "JOIN PostTb ON Employee.IDPost = PostTb.IDPost;";
                SQLiteCommand sqlCommand = new SQLiteCommand(queryString, forSQL.getConnection());
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                    ReadSingleRowData(dataGridView, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при заполнении таблицы: " + ex.Message);
            }
            finally
            {
                forSQL.closeConnection();
            }
        }
        private void LoadPostInComboBox()
        {
            try
            {
                string query = "SELECT Post FROM PostTb;";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, forSQL.getConnection());
                forSQL.openConnection();
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string post = reader.GetString(0);
                    comboBoxPost.Items.Add(post);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                forSQL.closeConnection();
            }
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            checkRole(PersonalData.Post.ToUpper());
            RefreshDataGridData(dataGridView);
            LoadPostInComboBox();
            panel1.Enabled = false;

            buttonAddPanel.Enabled = false;
            buttonChangePanel.Enabled = false;

            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = false;
        }
        private string checkRole(string role)
        {
            switch (role)
            {
                case ("МЛАДШИЙ ПРОГРАММИСТ"):
                    panel1.Visible = false;
                    buttonAdd.Visible = false;
                    buttonChange.Visible = false;
                    buttonDelete.Visible = false;
                    buttonSave.Visible = false;
                    pictureBox1.Visible = true;
                    return role;
                case ("СТАРШИЙ ПРОГРАММИСТ"):
                    panel1.Visible = true;
                    buttonAdd.Visible = true;
                    buttonChange.Visible = true;
                    buttonDelete.Visible = true;
                    buttonSave.Visible = true;
                    pictureBox1.Visible = false;
                    return role;
                case ("СТАЖЕР"):
                    panel1.Visible = false;
                    buttonAdd.Visible = false;
                    buttonChange.Visible = false;
                    buttonDelete.Visible = false;
                    buttonSave.Visible = false;
                    pictureBox1.Visible = true;
                    return role;
                default: return role;
            }
        }
        public void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                string searchQuery = "SELECT IDEmployee, Surname, Name, Patronymic, PostTb.Post "+
                "FROM Employee "+
                "JOIN PostTb ON Employee.IDPost = PostTb.IDPost " +
                "WHERE IDEmployee LIKE '%" + textBoxSearch.Text + "%' OR "+
                "Surname LIKE '%" + textBoxSearch.Text + "%' OR "+
                "Name LIKE '%" + textBoxSearch.Text + "%' OR "+
                "Patronymic LIKE '%" + textBoxSearch.Text + "%' OR " +
                "PostTb.Post LIKE '%" + textBoxSearch.Text + "%'";
                SQLiteCommand sqlCommand = new SQLiteCommand(searchQuery, forSQL.getConnection());
                forSQL.openConnection();
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                    ReadSingleRowData(dataGridView, reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                forSQL.closeConnection();
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView);
        }
        private void ClearTextBox()
        {
            textBoxID.Text = "";
            textBoxSurname.Text = "";
            textBoxName.Text = "";
            textBoxPatronymic.Text = "";
            comboBoxPost.Text = "";
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClearTextBox();

            labelLogin.Visible = true;
            labelPassword.Visible = true;
            textBoxLogin.Visible = true;
            textBoxPassword.Visible = true;

            panel1.Enabled = true;
            buttonAddPanel.Visible = true;
            buttonChangePanel.Visible = false;
        }

        private void buttonAddPanel_Click(object sender, EventArgs e)
        {
            try
            {
                forSQL.openConnection();

                string surname = textBoxSurname.Text;
                string name = textBoxName.Text;
                string patronymic = textBoxPatronymic.Text;
                string post = comboBoxPost.Text;
                string login = textBoxLogin.Text;
                string password = PasswordHashing.hashPassword(textBoxPassword.Text);
           
                string queryAdd = $"INSERT INTO Employee (Surname, Name, Patronymic, IDPost, Login, Password_ )"+
                "VALUES (@surname," +
                "@name," +
                "@patronymic," +
                "(SELECT IDPost FROM PostTb WHERE Post = @post)," +
                "@login," +
                "@password);";

                SQLiteCommand sqlCommand = new SQLiteCommand(queryAdd, forSQL.getConnection());
                sqlCommand.Parameters.AddWithValue("@surname", surname);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@patronymic", patronymic);
                sqlCommand.Parameters.AddWithValue("@post", post);
                sqlCommand.Parameters.AddWithValue("@login", login);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.ExecuteReader();

                MessageBox.Show("Запись успешно создана!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                forSQL.closeConnection();
                panel1.Visible = false;
                buttonAddPanel.Visible = false;
                RefreshDataGridData(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                forSQL.closeConnection();
            }
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = true;
        }
        private void Change()
        {
            int id = Convert.ToInt32(textBoxID.Text);
            string surname = textBoxSurname.Text;
            string name = textBoxName.Text;
            string patronymic = textBoxPatronymic.Text;
            string post = comboBoxPost.Text;

            if (dataGridView.Rows[selectedRow].Cells[0].Value != null)
            {
                dataGridView.Rows[selectedRow].SetValues(id, surname, name, patronymic, post);
                dataGridView.Rows[selectedRow].Cells[5].Value = rowState.Modified;
            }
        }
        private void buttonChangePanel_Click(object sender, EventArgs e)
        {
            Change();
            UpdateRow();
            panel1.Enabled = false;
            buttonChangePanel.Visible = false;
            RefreshDataGridData(dataGridView);
            ClearTextBox();
            MessageBox.Show("Данные успешно отредактированы!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void deleteRow()
        {
            int index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows[index].Visible = false;
            if (dataGridView.Rows[index].Cells[0].ToString() == string.Empty)
            {
                dataGridView.Rows[index].Cells[5].Value = rowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[5].Value = rowState.Deleted;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = false;
            panel1.Enabled = false;
            deleteRow();
            ClearTextBox();
            MessageBox.Show("Вы успешно удалили запись! Сохраните данные!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateRow()
        {
            try
            {
                forSQL.openConnection();
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[5].Value == null)
                        continue;

                    var rowSt = (rowState)dataGridView.Rows[i].Cells[5].Value;

                    if (rowSt == rowState.Existed)
                        continue;

                    if (rowSt == rowState.Deleted)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        string queryDelete = $" DELETE FROM Employee WHERE IDEmployee = @id;";
                        SQLiteCommand command = new SQLiteCommand(queryDelete, forSQL.getConnection());
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    if (rowSt == rowState.Modified)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value.ToString());
                        string surname = dataGridView.Rows[i].Cells[1].Value.ToString();
                        string name = dataGridView.Rows[i].Cells[2].Value.ToString();
                        string patronymic = dataGridView.Rows[i].Cells[3].Value.ToString();
                        string post = dataGridView.Rows[i].Cells[4].Value.ToString();

                        string queryChange = $"UPDATE Employee SET " +
                        "Surname = @surname" +
                        ",Name = @name" +
                        ",Patronymic = @patronymic" +
                        ",IDPost = (SELECT IDPost FROM PostTb WHERE Post = @post)" +
                        "WHERE IDEmployee = @id;";

                        SQLiteCommand command = new SQLiteCommand(queryChange, forSQL.getConnection());
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@patronymic", patronymic);
                        command.Parameters.AddWithValue("@post", post);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                forSQL.closeConnection();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            panel1.Enabled = false;
            UpdateRow();
            RefreshDataGridData(dataGridView);
            MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labelLogin.Visible = false;
            labelPassword.Visible = false;
            textBoxLogin.Visible = false;
            textBoxPassword.Visible = false;

            buttonAddPanel.Visible = false;
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxSurname.Text = row.Cells[1].Value.ToString();
                textBoxName.Text = row.Cells[2].Value.ToString();
                textBoxPatronymic.Text = row.Cells[3].Value.ToString();
                comboBoxPost.Text = row.Cells[4].Value.ToString();
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSurname.Text.Length != 0
                && textBoxName.Text.Length != 0
                && textBoxPatronymic.Text.Length != 0
                && comboBoxPost.Text.Length != 0
                && textBoxLogin.Text.Length != 0
                && textBoxPassword.Text.Length != 0)
            {
                buttonAddPanel.Enabled = true;
                buttonChangePanel.Enabled = true;
            }
            else
            {
                buttonAddPanel.Enabled = false;
                buttonChangePanel.Enabled = false;
            }
        }
    }
}
