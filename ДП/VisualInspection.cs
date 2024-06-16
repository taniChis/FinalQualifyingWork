using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Data.SqlClient;

namespace ДП
{
    public partial class VisualInspection : Form
    {
        ForSQL forSQL = new ForSQL();
        int selectedRow;
        public VisualInspection()
        {
            InitializeComponent();
        }
        // <summary>
        // Метод перенеса данных из SQLite 
        // </summary>
        // <param name = "dataGridView" ></ param >
        // < param name="dataRecord"></param>
        private void ReadSingleRowData(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetString(1),
                dataRecord.GetInt32(2),
                dataRecord.GetInt32(3),
                dataRecord.GetInt32(4),
                dataRecord.GetInt32(5),
                dataRecord.GetInt32(6),
                dataRecord.GetInt32(7),
                dataRecord.GetString(8),
                dataRecord.GetDateTime(9).ToString("dd.MM.yyyy"),
                dataRecord.GetString(10),
                dataRecord.GetString(11),
                rowState.ModifiedNew);
        }
        /// <summary>
        /// Метод заполнения таблицы
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="queryString"></param>
        public void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            try
            {
                forSQL.openConnection();
                string queryString = "SELECT  ID," +
                "PrintedCircuitBoards.DecimalNumber," +
                "ThePresenceOfAllElementsOnTheBoard," +
                "TheElementsInstalledCorrectly," +
                "ThepresenceOfSolderedLegs," +
                "NocoldSolderingEffect," +
                "NoFluxOnTheBoard ," +
                "Denominations  ," +
                "MarkingOfTheBoard   ," +
                "Date_ ," +
                "Notes ," +
                "Employee.Surname " +
                "FROM VisualInspection " +
                "JOIN Employee ON Employee.IDEmployee = VisualInspection.IDEmployee " +
                "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = VisualInspection.IDPrintedCircuitBoards;";
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
        private void VisualInspection_Load(object sender, EventArgs e)
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
                string searchQuery = "SELECT  ID," +
                "PrintedCircuitBoards.DecimalNumber," +
                "ThePresenceOfAllElementsOnTheBoard," +
                "TheElementsInstalledCorrectly," +
                "ThepresenceOfSolderedLegs," +
                "NocoldSolderingEffect," +
                "NoFluxOnTheBoard ," +
                "Denominations  ," +
                "MarkingOfTheBoard   ," +
                "Date_ ," +
                "Notes ," +
                "Employee.Surname " +
                "FROM VisualInspection " +
                "JOIN Employee ON Employee.IDEmployee = VisualInspection.IDEmployee " +
                "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = VisualInspection.IDPrintedCircuitBoards "+
                "WHERE ID LIKE '%" + textBoxSearch.Text + "%' OR " +
                "PrintedCircuitBoards.DecimalNumber LIKE '%" + textBoxSearch.Text + "%' OR " +
                "ThePresenceOfAllElementsOnTheBoard LIKE '%" + textBoxSearch.Text + "%' OR " +
                "TheElementsInstalledCorrectly LIKE '%" + textBoxSearch.Text + "%' OR " +
                "ThepresenceOfSolderedLegs LIKE '%" + textBoxSearch.Text + "%' OR " +
                "NocoldSolderingEffect LIKE '%" + textBoxSearch.Text + "%' OR " +
                "NoFluxOnTheBoard LIKE '%" + textBoxSearch.Text + "%' OR " +
                "Denominations LIKE '%" + textBoxSearch.Text + "%' OR " +
                "MarkingOfTheBoard LIKE '%" + textBoxSearch.Text + "%' OR " +
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
            textBoxID.Text = "";
            textBoxIDPrintedCircuitBoards.Text = "";

            textBoxThePresenceOfAllElementsOnTheBoard.Text = "";
            textBoxTheElementsInstalledCorrectly.Text = "";
            textBoxThepresenceOfSolderedLegs.Text = "";
            textBoxNocoldSolderingEffect.Text = "";
            textBoxNoFluxOnTheBoard.Text = "";
            textBoxDenominations.Text = "";
            textBoxMarkingOfTheBoard.Text = "";

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

                int ThePresenceOfAllElementsOnTheBoard = int.Parse(textBoxThePresenceOfAllElementsOnTheBoard.Text);
                int TheElementsInstalledCorrectly = int.Parse(textBoxTheElementsInstalledCorrectly.Text);
                int ThepresenceOfSolderedLegs = int.Parse(textBoxThepresenceOfSolderedLegs.Text);
                int NocoldSolderingEffect = int.Parse(textBoxNocoldSolderingEffect.Text);
                int NoFluxOnTheBoard = int.Parse(textBoxNoFluxOnTheBoard.Text);
                int Denominations = int.Parse(textBoxDenominations.Text);
                string MarkingOfTheBoard = textBoxMarkingOfTheBoard.Text;
                
                string Date_ = (textBoxDate.Value).ToString();
                string Notes = textBoxNotes.Text;
                string Employee = textBoxEmployee.Text;

                DateTime date = DateTime.ParseExact(Date_, "dd.MM.yyyy HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));
                string formattedDate = date.ToString("yyyy-MM-dd");

                string queryAdd = $"INSERT INTO VisualInspection (ThePresenceOfAllElementsOnTheBoard, TheElementsInstalledCorrectly, ThepresenceOfSolderedLegs, NocoldSolderingEffect, NoFluxOnTheBoard, Denominations, MarkingOfTheBoard, Date_, Notes, IDEmployee, IDPrintedCircuitBoards)" +
                "VALUES(" +
                "@ThePresenceOfAllElementsOnTheBoard, " +
                "@TheElementsInstalledCorrectly, " +
                "@ThepresenceOfSolderedLegs, " +
                "@NocoldSolderingEffect, " +
                "@NoFluxOnTheBoard, " +
                "@Denominations, " +
                "@MarkingOfTheBoard, " +
                "@Date_, " +
                "@Notes, " +
                "(SELECT IDEmployee FROM Employee WHERE Surname = @Employee), " +
                "(SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards)); ";

                SQLiteCommand sqlCommand = new SQLiteCommand(queryAdd, forSQL.getConnection());
                sqlCommand.Parameters.AddWithValue("@ThePresenceOfAllElementsOnTheBoard", ThePresenceOfAllElementsOnTheBoard);
                sqlCommand.Parameters.AddWithValue("@TheElementsInstalledCorrectly", TheElementsInstalledCorrectly);
                sqlCommand.Parameters.AddWithValue("@ThepresenceOfSolderedLegs", ThepresenceOfSolderedLegs);
                sqlCommand.Parameters.AddWithValue("@NocoldSolderingEffect", NocoldSolderingEffect);
                sqlCommand.Parameters.AddWithValue("@NoFluxOnTheBoard", NoFluxOnTheBoard);
                sqlCommand.Parameters.AddWithValue("@Denominations", Denominations);
                sqlCommand.Parameters.AddWithValue("@MarkingOfTheBoard", MarkingOfTheBoard);
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
            int ThePresenceOfAllElementsOnTheBoard = int.Parse(textBoxThePresenceOfAllElementsOnTheBoard.Text);
            int TheElementsInstalledCorrectly = int.Parse(textBoxTheElementsInstalledCorrectly.Text);
            int ThepresenceOfSolderedLegs = int.Parse(textBoxThepresenceOfSolderedLegs.Text);
            int NocoldSolderingEffect = int.Parse(textBoxNocoldSolderingEffect.Text);
            int NoFluxOnTheBoard = int.Parse(textBoxNoFluxOnTheBoard.Text);
            int Denominations = int.Parse(textBoxDenominations.Text);
            string MarkingOfTheBoard = textBoxMarkingOfTheBoard.Text;
            string Date_ = textBoxDate.Text;
            string Notes = textBoxNotes.Text;
            string Employee = textBoxEmployee.Text;

            if (dataGridView.Rows[selectedRow].Cells[0].Value != null)
            {
                dataGridView.Rows[selectedRow].SetValues(id, PrintedCircuitBoards, ThePresenceOfAllElementsOnTheBoard, TheElementsInstalledCorrectly, ThepresenceOfSolderedLegs, NocoldSolderingEffect, NoFluxOnTheBoard, Denominations, MarkingOfTheBoard , Date_, Notes, Employee);
                dataGridView.Rows[selectedRow].Cells[12].Value = rowState.Modified;
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
                dataGridView.Rows[index].Cells[12].Value = rowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[12].Value = rowState.Deleted;
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
                    if (dataGridView.Rows[i].Cells[12].Value == null)
                        continue;

                    var rowSt = (rowState)dataGridView.Rows[i].Cells[12].Value;

                    if (rowSt == rowState.Existed)
                        continue;

                    if (rowSt == rowState.Deleted)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        string queryDelete = $" DELETE FROM VisualInspection WHERE ID = @id;";
                        SQLiteCommand command = new SQLiteCommand(queryDelete, forSQL.getConnection());
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    if (rowSt == rowState.Modified)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value.ToString());
                        string PrintedCircuitBoards = dataGridView.Rows[i].Cells[1].Value.ToString();
                        int ThePresenceOfAllElementsOnTheBoard = int.Parse(dataGridView.Rows[i].Cells[2].Value.ToString());
                        int TheElementsInstalledCorrectly = int.Parse(dataGridView.Rows[i].Cells[3].Value.ToString());
                        int ThepresenceOfSolderedLegs = int.Parse(dataGridView.Rows[i].Cells[4].Value.ToString());
                        int NocoldSolderingEffect = int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString());
                        int NoFluxOnTheBoard = int.Parse(dataGridView.Rows[i].Cells[6].Value.ToString());
                        int Denominations = int.Parse(dataGridView.Rows[i].Cells[7].Value.ToString());
                        string MarkingOfTheBoard = dataGridView.Rows[i].Cells[8].Value.ToString();
                        string Date_ = dataGridView.Rows[i].Cells[9].Value.ToString();
                        string Notes = dataGridView.Rows[i].Cells[10].Value.ToString();
                        string Employee = dataGridView.Rows[i].Cells[11].Value.ToString();

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

                        string queryChange = $"UPDATE VisualInspection SET " +
                        "ThePresenceOfAllElementsOnTheBoard = @ThePresenceOfAllElementsOnTheBoard, " +
                        "TheElementsInstalledCorrectly = @TheElementsInstalledCorrectly, " +
                        "ThepresenceOfSolderedLegs = @ThepresenceOfSolderedLegs, " +
                        "NocoldSolderingEffect = @NocoldSolderingEffect, " +
                        "NoFluxOnTheBoard= @NoFluxOnTheBoard, " +
                        "Denominations= @Denominations, " +
                        "MarkingOfTheBoard= @MarkingOfTheBoard, " +
                        "Date_ = @Date_, " +
                        "Notes = @Notes, " +
                        "IDEmployee = (SELECT IDEmployee FROM Employee WHERE Surname = @Employee), " +
                        "IDPrintedCircuitBoards = (SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards) " +
                        "WHERE ID = @id;";

                        SQLiteCommand command = new SQLiteCommand(queryChange, forSQL.getConnection());
                        command.Parameters.AddWithValue("@PrintedCircuitBoards", PrintedCircuitBoards);
                        command.Parameters.AddWithValue("@ThePresenceOfAllElementsOnTheBoard", ThePresenceOfAllElementsOnTheBoard);
                        command.Parameters.AddWithValue("@TheElementsInstalledCorrectly", TheElementsInstalledCorrectly);
                        command.Parameters.AddWithValue("@ThepresenceOfSolderedLegs", ThepresenceOfSolderedLegs);
                        command.Parameters.AddWithValue("@NocoldSolderingEffect", NocoldSolderingEffect);
                        command.Parameters.AddWithValue("@NoFluxOnTheBoard", NoFluxOnTheBoard);
                        command.Parameters.AddWithValue("@Denominations", Denominations);
                        command.Parameters.AddWithValue("@MarkingOfTheBoard", MarkingOfTheBoard);
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

                textBoxThePresenceOfAllElementsOnTheBoard.Text = row.Cells[2].Value.ToString();
                textBoxTheElementsInstalledCorrectly.Text = row.Cells[3].Value.ToString();
                textBoxThepresenceOfSolderedLegs.Text = row.Cells[4].Value.ToString();
                textBoxNocoldSolderingEffect.Text = row.Cells[5].Value.ToString();
                textBoxNoFluxOnTheBoard.Text = row.Cells[6].Value.ToString();
                textBoxDenominations.Text = row.Cells[7].Value.ToString();
                textBoxMarkingOfTheBoard.Text = row.Cells[8].Value.ToString();

                textBoxDate.Text = row.Cells[9].Value.ToString();
                textBoxNotes.Text = row.Cells[10].Value.ToString();
                textBoxEmployee.Text = row.Cells[11].Value.ToString();
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
                && textBoxThePresenceOfAllElementsOnTheBoard.Text.Length != 0
                && textBoxTheElementsInstalledCorrectly.Text.Length != 0
                && textBoxThepresenceOfSolderedLegs.Text.Length != 0
                && textBoxNocoldSolderingEffect.Text.Length != 0
                && textBoxNoFluxOnTheBoard.Text.Length != 0
                && textBoxDenominations.Text.Length != 0
                && textBoxMarkingOfTheBoard.Text.Length != 0
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
        private void textBoxThePresenceOfAllElementsOnTheBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 1)
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar == '0') || (e.KeyChar == '1'))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }
    }
}
