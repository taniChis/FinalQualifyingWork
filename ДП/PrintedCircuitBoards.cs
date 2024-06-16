using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ДП
{
    /// <summary>
    /// Перечисление
    /// </summary>
    public enum rowState
    {
        Existed,// состояние данных
        New,// новый
        Modified,// измененный
        ModifiedNew,// измененный новый
        Deleted// удаленный
    }
    public partial class PrintedCircuitBoards : Form
    {
        ForSQL forSQL = new ForSQL();
        int selectedRow;
        public PrintedCircuitBoards()
        {
            InitializeComponent();
        }
        private void ReadSingleRowData(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetString(1),
                dataRecord.GetInt32(2),
                dataRecord.GetString(3),
                rowState.ModifiedNew);
        }
        public void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            try
            {
                forSQL.openConnection();
                string queryString = "SELECT * FROM PrintedCircuitBoards;";
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
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintedCircuitBoards_Load(object sender, EventArgs e)
        {
            RefreshDataGridData(dataGridView);
            panel1.Enabled = false;

            buttonAddPanel.Enabled = false;
            buttonChangePanel.Enabled = false;

            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = false;
        }
        public void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                string searchQuery = "SELECT * FROM PrintedCircuitBoards " +
                "WHERE IDPrintedCircuitBoards LIKE '%" + textBoxSearch.Text + "%' OR " +
                "DecimalNumber LIKE '%" + textBoxSearch.Text + "%' OR " +
                "UniqueNumber LIKE '%" + textBoxSearch.Text + "%' OR " +
                "Name LIKE '%" + textBoxSearch.Text + "%'";
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            panel1.Enabled = true;
            buttonAddPanel.Visible = true;
            buttonChangePanel.Visible = false;
        }
        private void buttonAddPanel_Click(object sender, EventArgs e)
        {
            try
            {
                forSQL.openConnection();

                string decimalNumber = textBox1.Text;
                int uniqueNumber = Convert.ToInt32(textBox2.Text);
                string name = textBox3.Text;

                string queryAdd = $"INSERT INTO PrintedCircuitBoards (DecimalNumber, UniqueNumber, Name)\r\n" +
                    $"VALUES (@decimalNumber, @uniqueNumber, @name);";
                SQLiteCommand sqlCommand = new SQLiteCommand(queryAdd, forSQL.getConnection());
                sqlCommand.Parameters.AddWithValue("@decimalNumber", decimalNumber);
                sqlCommand.Parameters.AddWithValue("@uniqueNumber", uniqueNumber);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.ExecuteReader();
                MessageBox.Show("Запись успешно создана!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                forSQL.closeConnection();
                panel1.Visible = false;
                buttonAddPanel.Visible = false;
                RefreshDataGridData(dataGridView);
                ClearTextBox();
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
        private void ClearTextBox()
        {
            textBoxID.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = true;
        }
        private void Change()
        {
            string decimalNumber = textBox1.Text;
            int uniqueNumber = Convert.ToInt32(textBox2.Text);
            string name = textBox3.Text;

            if (dataGridView.Rows[selectedRow].Cells[0].Value != null)
            {
                dataGridView.Rows[selectedRow].SetValues(decimalNumber, uniqueNumber, name);
                dataGridView.Rows[selectedRow].Cells[4].Value = rowState.Modified;
            }
        }
        private void buttonChangePanel_Click(object sender, EventArgs e)
        {
            Change();
            UpdateRow();
            panel1.Enabled = false;
            buttonChangePanel.Visible = false;
            RefreshDataGridData(dataGridView);
            MessageBox.Show("Данные успешно отредактированы!", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextBox();
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
        private void deleteRow()
        {
            int index = dataGridView.CurrentCell.RowIndex;
            dataGridView.Rows[index].Visible = false;
            if (dataGridView.Rows[index].Cells[0].ToString() == string.Empty)
            {
                dataGridView.Rows[index].Cells[4].Value = rowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[4].Value = rowState.Deleted;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            panel1.Enabled = false;
            UpdateRow();
            RefreshDataGridData(dataGridView);
            MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateRow()
        {
            try
            {
                forSQL.openConnection();
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[4].Value == null)
                        continue;

                    var rowSt = (rowState)dataGridView.Rows[i].Cells[4].Value;

                    if (rowSt == rowState.Existed) 
                        continue;

                    if (rowSt == rowState.Deleted)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        string queryDelete = $" DELETE FROM PrintedCircuitBoards WHERE IDPrintedCircuitBoards = {id};";
                        var command = new SQLiteCommand(queryDelete, forSQL.getConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowSt == rowState.Modified)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value.ToString());
                        string decimalNumber = dataGridView.Rows[i].Cells[1].Value.ToString();
                        int uniqueNumber = Convert.ToInt32(dataGridView.Rows[i].Cells[2].Value.ToString());
                        string name = dataGridView.Rows[i].Cells[3].Value.ToString();

                        string queryChange = $"UPDATE PrintedCircuitBoards SET " +
                            $" DecimalNumber  = '{decimalNumber}'" +
                            $",UniqueNumber  = '{uniqueNumber}'" +
                            $",Name  = '{name}'" +
                            $"WHERE IDPrintedCircuitBoards  = '{id}'";

                        var command = new SQLiteCommand(queryChange, forSQL.getConnection());
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
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonAddPanel.Visible = false;
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
            }
        }
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0
                && textBox2.Text.Length != 0
                && textBox3.Text.Length != 0)
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
