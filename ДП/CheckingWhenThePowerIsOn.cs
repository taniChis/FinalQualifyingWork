using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДП
{
    public partial class CheckingWhenThePowerIsOn : Form
    {
        ForSQL forSQL = new ForSQL();
        int selectedRow;
        public CheckingWhenThePowerIsOn()
        {
            InitializeComponent();
        }
        private void ReadSingleRowData(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetString(1),
                dataRecord.GetDouble(2),
                dataRecord.GetString(3),
                dataRecord.GetDateTime(4).ToString("dd.MM.yyyy"),
                dataRecord.GetString(5),
                dataRecord.GetString(6),
                rowState.ModifiedNew);
        }
        public void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            try
            {
                forSQL.openConnection();
                string queryString = "SELECT ID ," +
                "PrintedCircuitBoards.DecimalNumber," +
                "CurrentConsumption ," +
                "ThePresenceOfAllVoltages ," +
                "Date_ ," +
                "Notes ," +
                "Employee.Surname" +
                " FROM CheckingWhenThePowerIsOn" +
                " JOIN Employee ON Employee.IDEmployee = CheckingWhenThePowerIsOn.IDEmployee" +
                " JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = CheckingWhenThePowerIsOn.IDPrintedCircuitBoards";
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
        private void LoadEmployeeInComboBox()
        {
            try
            {
                forSQL.openConnection();
                string query = "SELECT Surname FROM Employee;";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, forSQL.getConnection());
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string post = reader.GetString(0);
                    textBoxEmployee.Items.Add(post);
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
        private void LoadDecimalNumberInComboBox()
        {
            try
            {
                forSQL.openConnection();
                string query = "SELECT DecimalNumber FROM PrintedCircuitBoards;";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, forSQL.getConnection());
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string post = reader.GetString(0);
                    textBoxIDPrintedCircuitBoards.Items.Add(post);
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
        private void CheckingWhenThePowerIsOn_Load(object sender, EventArgs e)
        {
            RefreshDataGridData(dataGridView);
            LoadEmployeeInComboBox();
            LoadDecimalNumberInComboBox();

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
                forSQL.openConnection();
                dataGridView.Rows.Clear();
                string searchQuery = "SELECT ID ," +
                "PrintedCircuitBoards.DecimalNumber ," +
                "CurrentConsumption ," +
                "ThePresenceOfAllVoltages ," +
                "Date_ ," +
                "Notes ," +
                "Employee.Surname " +
                "FROM CheckingWhenThePowerIsOn " +
                "JOIN Employee ON Employee.IDEmployee = CheckingWhenThePowerIsOn.IDEmployee " +
                "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = CheckingWhenThePowerIsOn.IDPrintedCircuitBoards " +
                "WHERE ID LIKE '%" + textBoxSearch.Text + "%' OR " +
                "PrintedCircuitBoards.DecimalNumber LIKE '%" + textBoxSearch.Text + "%' OR " +
                "CurrentConsumption LIKE '%" + textBoxSearch.Text + "%' OR " +
                "ThePresenceOfAllVoltages LIKE '%" + textBoxSearch.Text + "%' OR " +
                "Date_ LIKE '%" + textBoxSearch.Text + "%' OR " +
                "Notes LIKE '%" + textBoxSearch.Text + "%' OR " +
                "Employee.Surname LIKE '%" + textBoxSearch.Text + "%'";
                SQLiteCommand sqlCommand = new SQLiteCommand(searchQuery, forSQL.getConnection());
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
        private void ClearTextBox()
        {
            textBoxIDPrintedCircuitBoards.Text = "";
            textBoxCurrentConsumption.Text = "";
            textBoxThePresenceOfAllVoltages.Text = "";
            textBoxDate.Text = "";
            textBoxNotes.Text = "";
            textBoxEmployee.Text = "";
        }
        private void buttonAddPanel_Click(object sender, EventArgs e)
        {
            try
            {
                forSQL.openConnection();
                string PrintedCircuitBoards = textBoxIDPrintedCircuitBoards.Text;
                double CurrentConsumption = double.Parse(textBoxCurrentConsumption.Text);
                string ThePresenceOfAllVoltages = textBoxThePresenceOfAllVoltages.Text;
                string Date_ = (textBoxDate.Value).ToString();
                string Notes = textBoxNotes.Text;
                string Employee = textBoxEmployee.Text;

                DateTime date = DateTime.ParseExact(Date_, "dd.MM.yyyy HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));
                string formattedDate = date.ToString("yyyy-MM-dd");

                string queryAdd = $"INSERT INTO CheckingWhenThePowerIsOn (CurrentConsumption, ThePresenceOfAllVoltages, Date_, Notes, IDEmployee, IDPrintedCircuitBoards)" +
                "VALUES(" +
                "@CurrentConsumption, " +
                "@ThePresenceOfAllVoltages, " +
                "@Date_, " +
                "@Notes, " +
                "(SELECT IDEmployee FROM Employee WHERE Surname = @Employee), " +
                "(SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards)); ";

                SQLiteCommand sqlCommand = new SQLiteCommand(queryAdd, forSQL.getConnection());
                sqlCommand.Parameters.AddWithValue("@CurrentConsumption", CurrentConsumption);
                sqlCommand.Parameters.AddWithValue("@ThePresenceOfAllVoltages", ThePresenceOfAllVoltages);
                sqlCommand.Parameters.AddWithValue("@Date_", formattedDate);
                sqlCommand.Parameters.AddWithValue("@Notes", Notes);
                sqlCommand.Parameters.AddWithValue("@Employee", Employee);
                sqlCommand.Parameters.AddWithValue("@PrintedCircuitBoards", PrintedCircuitBoards);
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
            string PrintedCircuitBoards = textBoxIDPrintedCircuitBoards.Text;
            double CurrentConsumption = double.Parse(textBoxCurrentConsumption.Text);
            string ThePresenceOfAllVoltages = textBoxThePresenceOfAllVoltages.Text;
            string Date_ = textBoxDate.Text;
            string Notes = textBoxNotes.Text;
            string Employee = textBoxEmployee.Text;

            if (dataGridView.Rows[selectedRow].Cells[0].Value != null)
            {
                dataGridView.Rows[selectedRow].SetValues(id, PrintedCircuitBoards, CurrentConsumption, ThePresenceOfAllVoltages, Date_, Notes, Employee);
                dataGridView.Rows[selectedRow].Cells[7].Value = rowState.Modified;
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
                dataGridView.Rows[index].Cells[7].Value = rowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[7].Value = rowState.Deleted;
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
                    if (dataGridView.Rows[i].Cells[7].Value == null)
                        continue;

                    var rowSt = (rowState)dataGridView.Rows[i].Cells[7].Value;

                    if (rowSt == rowState.Existed)
                        continue;

                    if (rowSt == rowState.Deleted)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        string queryDelete = $" DELETE FROM CheckingWhenThePowerIsOn WHERE ID = @id;";
                        SQLiteCommand command = new SQLiteCommand(queryDelete, forSQL.getConnection());
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    if (rowSt == rowState.Modified)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value.ToString());
                        string PrintedCircuitBoards = dataGridView.Rows[i].Cells[1].Value.ToString();
                        double CurrentConsumption = double.Parse(dataGridView.Rows[i].Cells[2].Value.ToString());
                        string ThePresenceOfAllVoltages = dataGridView.Rows[i].Cells[3].Value.ToString();
                        string Date_ = dataGridView.Rows[i].Cells[4].Value.ToString();
                        string Notes = dataGridView.Rows[i].Cells[5].Value.ToString();
                        string Employee = dataGridView.Rows[i].Cells[6].Value.ToString();

                        string[] formats = { "dd MMMM yyyy 'г.'", "d MMMM yyyy 'г.'" };
                        DateTime date = DateTime.MinValue;

                        foreach (string format in formats)
                        {
                            if (DateTime.TryParseExact(Date_, format, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out date))
                            {
                                break; 
                            }
                        }
                        string formattedDate = date.ToString("yyyy-MM-dd");

                        string queryChange = $"UPDATE CheckingWhenThePowerIsOn SET " +
                        "CurrentConsumption = @CurrentConsumption" +
                        ",ThePresenceOfAllVoltages = @ThePresenceOfAllVoltages" +
                        ",Date_ = @Date_ " +
                        ", Notes = @Notes" +
                        ",IDEmployee = (SELECT IDEmployee FROM Employee WHERE Surname = @Employee)" +
                        ",IDPrintedCircuitBoards = (SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards) " +
                        "WHERE ID = @id;";

                        SQLiteCommand command = new SQLiteCommand(queryChange, forSQL.getConnection());
                        command.Parameters.AddWithValue("@PrintedCircuitBoards", PrintedCircuitBoards);
                        command.Parameters.AddWithValue("@CurrentConsumption", CurrentConsumption);
                        command.Parameters.AddWithValue("@ThePresenceOfAllVoltages", ThePresenceOfAllVoltages);
                        command.Parameters.AddWithValue("@Date_", formattedDate);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@Employee", Employee);
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
            buttonAddPanel.Visible = false;
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[selectedRow];
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxIDPrintedCircuitBoards.Text = row.Cells[1].Value.ToString();
                textBoxCurrentConsumption.Text = row.Cells[2].Value.ToString();
                textBoxThePresenceOfAllVoltages.Text = row.Cells[3].Value.ToString();
                textBoxDate.Text = row.Cells[4].Value.ToString();
                textBoxNotes.Text = row.Cells[5].Value.ToString();
                textBoxEmployee.Text = row.Cells[6].Value.ToString();
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxIDPrintedCircuitBoards_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIDPrintedCircuitBoards.Text.Length != 0
                && textBoxCurrentConsumption.Text.Length != 0
                && textBoxThePresenceOfAllVoltages.Text.Length != 0
                && textBoxDate.Text.Length != 0
                && textBoxEmployee.Text.Length != 0
                && textBoxNotes.Text.Length != 0)
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
