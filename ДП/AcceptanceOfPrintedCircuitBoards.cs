using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ДП.Properties;

namespace ДП
{
    public partial class AcceptanceOfPrintedCircuitBoards : Form
    {
        ForSQL forSQL = new ForSQL();
        private int selectedRow;
        public AcceptanceOfPrintedCircuitBoards()
        {
            InitializeComponent();
            buttonPhotoOfThePrintedBase.Text = "Обновить \nфото";
            buttonPhotoWithElements.Text = "Обновить \nфото";
        }
        private void ReadSingleRowData(DataGridView dataGridView, IDataRecord dataRecord)
        {
            object valueFromDatabasePhotoOfThePrintedBase = dataRecord["PhotoOfThePrintedBase"];
            object valueFromDatabasePhotoWithElements = dataRecord["PhotoWithElements"];

            byte[] baseImageData;
            byte[] elementsImageData;
            System.Drawing.Image baseImage;
            System.Drawing.Image elementsImage;
            if (valueFromDatabasePhotoOfThePrintedBase == DBNull.Value && valueFromDatabasePhotoWithElements == DBNull.Value)
            {
                baseImage = null;
                elementsImage = null;
            }
            else
            {
                baseImageData = (byte[])dataRecord["PhotoOfThePrintedBase"];
                elementsImageData = (byte[])dataRecord["PhotoWithElements"];

                baseImage = ByteArrayToImage(baseImageData);
                elementsImage = ByteArrayToImage(elementsImageData);
            }
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetString(1),
                dataRecord.GetInt32(2),
                dataRecord.GetDouble(3),
                dataRecord.GetInt32(4),
                dataRecord.GetInt32(5),
                dataRecord.GetInt32(6),
                dataRecord.GetInt32(7),
                baseImage,
                elementsImage,
                dataRecord.GetDateTime(10).ToString("dd.MM.yyyy"),
                dataRecord.GetString(11),
                dataRecord.GetString(12),
                rowState.ModifiedNew);
        }
        private void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            string queryString = "SELECT IDOfTheReception, \r\n" +
                "PrintedCircuitBoards.DecimalNumber,\r\n" +
                "Bends, \r\n" +
                "Square, \r\n" +
                "WarpingEffect, \r\n" +
                "PresenceOfFrame, \r\n" +
                "ImpedanceСontrol, \r\n" +
                "ElectricalTest, \r\n" +
                "PhotoOfThePrintedBase, \r\n" +
                "PhotoWithElements, \r\n" +
                "Date_, \r\n" +
                "Notes, \r\n" +
                "Employee.Surname\r\n" +
                "FROM AcceptanceOfPrintedCircuitBoards\r\n" +
                "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = AcceptanceOfPrintedCircuitBoards.IDPrintedCircuitBoards \r\n" +
                "JOIN Employee ON Employee.IDEmployee = AcceptanceOfPrintedCircuitBoards.IDEmployee;";
            SQLiteCommand sqlCommand = new SQLiteCommand(queryString, forSQL.getConnection());
            forSQL.openConnection();
            SQLiteDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowData(dataGridView, reader);
            }
            reader.Close();
        }
        private System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
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
        private void AcceptanceOfPrintedCircuitBoards_Load(object sender, EventArgs e)
        {
            RefreshDataGridData(dataGridView);
            LoadEmployeeInComboBox();
            LoadDecimalNumberInComboBox();

            panel1.Enabled = false;

            buttonAddPanel.Enabled = false;
            buttonChangePanel.Enabled = false;

            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = false;

            buttonPhotoOfThePrintedBase.Visible = false;
            buttonPhotoWithElements.Visible = false;
        }
        private void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                string searchQuery = "SELECT IDOfTheReception, \r\n" +
                    "PrintedCircuitBoards.DecimalNumber,\r\n" +
                    "Bends, \r\n" +
                    "Square, \r\n" +
                    "WarpingEffect, \r\n" +
                    "PresenceOfFrame, \r\n" +
                    "ImpedanceСontrol, \r\n" +
                    "ElectricalTest, \r\n" +
                    "PhotoOfThePrintedBase, \r\n" +
                    "PhotoWithElements, \r\n" +
                    "Date_, \r\n" +
                    "Notes, \r\n" +
                    "Employee.Surname\r\n" +
                    "FROM AcceptanceOfPrintedCircuitBoards\r\n" +
                    "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = AcceptanceOfPrintedCircuitBoards.IDPrintedCircuitBoards \r\n" +
                    "JOIN Employee ON Employee.IDEmployee = AcceptanceOfPrintedCircuitBoards.IDEmployee " +
                    "WHERE IDOfTheReception LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "PrintedCircuitBoards.DecimalNumber LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "Bends LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "Square LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "WarpingEffect LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "PresenceOfFrame LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "ImpedanceСontrol LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "ElectricalTest LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "Date_ LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "Notes LIKE '%" + textBoxSearch.Text + "%' OR " +
                    "Employee.Surname LIKE '%" + textBoxSearch.Text + "%'";
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
            buttonPhotoOfThePrintedBase.Visible = false;
            buttonPhotoWithElements.Visible = false;
        }
        private void ClearTextBox()
        {
            textBoxID.Text = "";
            textBoxIDPrintedCircuitBoards.Text = "";

            textBoxBends.Text = "";
            textBoxSquare.Text = "";
            textBoxWarpingEffect.Text = "";
            textBoxPresenceOfFrame.Text = "";
            textBoxImpedanceСontrol.Text = "";
            textBoxElectricalTest.Text = "";
            pictureBoxPhotoOfThePrintedBase.Image = Resources.Dowload;
            pictureBoxPhotoWithElements.Image = Resources.Dowload;
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

                int Bends = int.Parse(textBoxBends.Text);
                double Square = double.Parse(textBoxSquare.Text);
                int WarpingEffect = int.Parse(textBoxWarpingEffect.Text);
                int PresenceOfFrame = int.Parse(textBoxPresenceOfFrame.Text);
                int ImpedanceСontrol = int.Parse(textBoxImpedanceСontrol.Text);
                int ElectricalTest = int.Parse(textBoxElectricalTest.Text);
                byte[] photoOfThePrintedBaseBytes = ImageToByteArray(pictureBoxPhotoOfThePrintedBase.Image);
                byte[] photoWithElementsBytes = ImageToByteArray(pictureBoxPhotoWithElements.Image);
                string Date_ = (textBoxDate.Value).ToString();
                string Notes = textBoxNotes.Text;
                string Employee = textBoxEmployee.Text;

                DateTime date = DateTime.ParseExact(Date_, "dd.MM.yyyy HH:mm:ss", CultureInfo.GetCultureInfo("ru-RU"));
                string formattedDate = date.ToString("yyyy-MM-dd");

                string insertQuery = "INSERT INTO AcceptanceOfPrintedCircuitBoards(Bends, Square, WarpingEffect, PresenceOfFrame, ImpedanceСontrol, ElectricalTest, PhotoOfThePrintedBase, PhotoWithElements, Date_, Notes, IDEmployee, IDPrintedCircuitBoards )\r\n" +
                "VALUES(" +
                "@Bends," +
                "@Square," +
                "@WarpingEffect," +
                "@PresenceOfFrame," +
                "@ImpedanceСontrol," +
                "@ElectricalTest," +
                "@PhotoOfThePrintedBase," +
                "@PhotoWithElements," +
                "@formattedDate, " +
                "@Notes, " +
                "(SELECT IDEmployee FROM Employee WHERE Surname = @Employee), "+
                "(SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards));";

                SQLiteCommand insertQueryCommand = new SQLiteCommand(insertQuery, forSQL.getConnection());
                insertQueryCommand.Parameters.AddWithValue("@Bends", Bends);
                insertQueryCommand.Parameters.AddWithValue("@Square", Square);
                insertQueryCommand.Parameters.AddWithValue("@WarpingEffect", WarpingEffect);
                insertQueryCommand.Parameters.AddWithValue("@PresenceOfFrame", PresenceOfFrame);
                insertQueryCommand.Parameters.AddWithValue("@ImpedanceСontrol", ImpedanceСontrol);
                insertQueryCommand.Parameters.AddWithValue("@ElectricalTest", ElectricalTest);
                insertQueryCommand.Parameters.AddWithValue("@PhotoOfThePrintedBase", photoOfThePrintedBaseBytes);
                insertQueryCommand.Parameters.AddWithValue("@PhotoWithElements", photoWithElementsBytes);
                insertQueryCommand.Parameters.AddWithValue("@formattedDate", formattedDate);
                insertQueryCommand.Parameters.AddWithValue("@Notes", Notes);
                insertQueryCommand.Parameters.AddWithValue("@Employee", Employee);
                insertQueryCommand.Parameters.AddWithValue("@PrintedCircuitBoards", PrintedCircuitBoards);
                insertQueryCommand.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                forSQL.closeConnection();
                panel1.Enabled = false;
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
        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            buttonAddPanel.Visible = false;
            buttonChangePanel.Visible = true;
            buttonPhotoOfThePrintedBase.Visible = true;
            buttonPhotoWithElements.Visible = true;
        }
        private void Change()
        {
            int id = Convert.ToInt32(textBoxID.Text);
            string PrintedCircuitBoards = textBoxIDPrintedCircuitBoards.Text;
            int Bends = int.Parse(textBoxBends.Text);
            double Square = double.Parse(textBoxSquare.Text);
            int WarpingEffect = int.Parse(textBoxWarpingEffect.Text);
            int PresenceOfFrame = int.Parse(textBoxPresenceOfFrame.Text);
            int ImpedanceСontrol = int.Parse(textBoxImpedanceСontrol.Text);
            int ElectricalTest = int.Parse(textBoxElectricalTest.Text);
            string Date_ = textBoxDate.Text;
            string Notes = textBoxNotes.Text;
            string Employee = textBoxEmployee.Text;

            if (dataGridView.Rows[selectedRow].Cells[0].Value != null)
            {
                dataGridView.Rows[selectedRow].Cells[0].Value = id;
                dataGridView.Rows[selectedRow].Cells[1].Value = PrintedCircuitBoards;
                dataGridView.Rows[selectedRow].Cells[2].Value = Bends;
                dataGridView.Rows[selectedRow].Cells[3].Value = Square;
                dataGridView.Rows[selectedRow].Cells[4].Value = WarpingEffect;
                dataGridView.Rows[selectedRow].Cells[5].Value = PresenceOfFrame;
                dataGridView.Rows[selectedRow].Cells[6].Value = ImpedanceСontrol;
                dataGridView.Rows[selectedRow].Cells[7].Value = ElectricalTest;
                dataGridView.Rows[selectedRow].Cells[10].Value = Date_;
                dataGridView.Rows[selectedRow].Cells[11].Value = Notes;
                dataGridView.Rows[selectedRow].Cells[12].Value = Employee;
                dataGridView.Rows[selectedRow].Cells[13].Value = rowState.Modified;
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
                dataGridView.Rows[index].Cells[13].Value = rowState.Deleted;
                return;
            }
            dataGridView.Rows[index].Cells[13].Value = rowState.Deleted;
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
                for (int i = 1; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[13].Value == null) continue;
                    var rowSt = (rowState)dataGridView.Rows[i].Cells[13].Value;
                    if (rowSt == rowState.Existed) continue;
                    if (rowSt == rowState.Deleted)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                        string queryDelete = $" DELETE FROM AcceptanceOfPrintedCircuitBoards WHERE IDOfTheReception = @IDOfTheReception;";
                        SQLiteCommand command = new SQLiteCommand(queryDelete, forSQL.getConnection());
                        command.Parameters.AddWithValue("@IDOfTheReception", id);
                        command.ExecuteNonQuery();
                    }
                    if (rowSt == rowState.Modified)
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value.ToString());
                        string PrintedCircuitBoards = Convert.ToString(dataGridView.Rows[i].Cells[1].Value.ToString());
                        int Bends = Convert.ToInt32(dataGridView.Rows[i].Cells[2].Value.ToString());
                        double Square = Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value.ToString());
                        int WarpingEffect = Convert.ToInt32(dataGridView.Rows[i].Cells[4].Value.ToString());
                        int PresenceOfFrame = Convert.ToInt32(dataGridView.Rows[i].Cells[5].Value.ToString());
                        int ImpedanceСontrol = Convert.ToInt32(dataGridView.Rows[i].Cells[6].Value.ToString());
                        int ElectricalTest = Convert.ToInt32(dataGridView.Rows[i].Cells[7].Value.ToString());
                        string Date_ = Convert.ToString(dataGridView.Rows[i].Cells[10].Value.ToString());
                        string Notes = Convert.ToString(dataGridView.Rows[i].Cells[11].Value.ToString());
                        string Employee = Convert.ToString(dataGridView.Rows[i].Cells[12].Value.ToString());
                        
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

                        string queryChange = "UPDATE AcceptanceOfPrintedCircuitBoards SET " +
                        "Bends = @Bends," +
                        "Square = @Square," +
                        "WarpingEffect = @WarpingEffect," +
                        "PresenceOfFrame = @PresenceOfFrame," +
                        "ImpedanceСontrol = @ImpedanceСontrol," +
                        "ElectricalTest = @ElectricalTest," +
                        "Date_ = @formattedDate, " +
                        "Notes = @Notes, " +
                        "IDEmployee = (SELECT IDEmployee FROM Employee WHERE Surname = @Employee), " +
                        "IDPrintedCircuitBoards = (SELECT IDPrintedCircuitBoards FROM PrintedCircuitBoards WHERE DecimalNumber = @PrintedCircuitBoards) " +
                        "WHERE IDOfTheReception = @IDOfTheReception;";

                        SQLiteCommand command = new SQLiteCommand(queryChange, forSQL.getConnection());
                        command.Parameters.AddWithValue("@IDOfTheReception", id);
                        command.Parameters.AddWithValue("@Bends", Bends);
                        command.Parameters.AddWithValue("@Square", Square);
                        command.Parameters.AddWithValue("@WarpingEffect", WarpingEffect);
                        command.Parameters.AddWithValue("@PresenceOfFrame", PresenceOfFrame);
                        command.Parameters.AddWithValue("@ImpedanceСontrol", ImpedanceСontrol);
                        command.Parameters.AddWithValue("@ElectricalTest", ElectricalTest);
                        command.Parameters.AddWithValue("@formattedDate", formattedDate);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@Employee", Employee);
                        command.Parameters.AddWithValue("@PrintedCircuitBoards", PrintedCircuitBoards);
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
                textBoxBends.Text = row.Cells[2].Value.ToString();
                textBoxSquare.Text = row.Cells[3].Value.ToString();
                textBoxWarpingEffect.Text = row.Cells[4].Value.ToString();
                textBoxPresenceOfFrame.Text = row.Cells[5].Value.ToString();
                textBoxImpedanceСontrol.Text = row.Cells[6].Value.ToString();
                textBoxElectricalTest.Text = row.Cells[7].Value.ToString();
                pictureBoxPhotoOfThePrintedBase.Image = (System.Drawing.Image)(row.Cells[8].Value);
                pictureBoxPhotoWithElements.Image = (System.Drawing.Image)(row.Cells[9].Value);
                textBoxDate.Text = row.Cells[10].Value.ToString();
                textBoxNotes.Text = row.Cells[11].Value.ToString();
                textBoxEmployee.Text = row.Cells[12].Value.ToString();
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
                && textBoxBends.Text.Length != 0
                && textBoxSquare.Text.Length != 0
                && textBoxWarpingEffect.Text.Length != 0
                && textBoxPresenceOfFrame.Text.Length != 0
                && textBoxImpedanceСontrol.Text.Length != 0
                && textBoxElectricalTest.Text.Length != 0
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0' || e.KeyChar == '1')
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }
        private void textBoxSquare_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            bool containsDot = textBox.Text.Contains(".");
            if ((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.' && !containsDot) || (e.KeyChar == (char)Keys.Back))
                return;
            e.Handled = true;
        }
        private void buttonPhotoOfThePrintedBase_Click(object sender, EventArgs e)
        {
            forSQL.openConnection();
            int ID = int.Parse(textBoxID.Text);
            string query = "UPDATE AcceptanceOfPrintedCircuitBoards SET PhotoOfThePrintedBase = @PhotoOfThePrintedBase WHERE IDOfTheReception = @ID;";
            SQLiteCommand command = new SQLiteCommand(query, forSQL.getConnection());
            command.Parameters.AddWithValue("@ID", ID);
            using (var memoryStream = new MemoryStream())
            {
                pictureBoxPhotoOfThePrintedBase.Image.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.Position = 0;
                var sqlParameter = new SQLiteParameter("@PhotoOfThePrintedBase", DbType.Binary, (int)memoryStream.Length)
                {
                    Value = memoryStream.ToArray()
                };
                command.Parameters.Add(sqlParameter);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Фото загружено в базу данных. Пожалуйста, нажмите на кнопку Сохранить ", "Успешная загрузка фото", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void buttonPhotoWithElements_Click(object sender, EventArgs e)
        {
            forSQL.openConnection();
            int ID = int.Parse(textBoxID.Text);
            string query = "UPDATE AcceptanceOfPrintedCircuitBoards SET PhotoWithElements = @PhotoWithElements WHERE IDOfTheReception = @ID; ";
            SQLiteCommand command = new SQLiteCommand(query, forSQL.getConnection());
            command.Parameters.AddWithValue("@ID", ID);
            using (var memoryStream = new MemoryStream())
            {
                pictureBoxPhotoWithElements.Image.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.Position = 0;
                var sqlParameter = new SQLiteParameter("@PhotoWithElements", DbType.Binary, (int)memoryStream.Length)
                {
                    Value = memoryStream.ToArray()
                };
                command.Parameters.Add(sqlParameter);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Фото загружено в базу данных. Пожалуйста, нажмите на кнопку Сохранить ", "Успешная загрузка фото", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pictureBoxPhotoOfThePrintedBase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhotoOfThePrintedBase.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private void pictureBoxPhotoWithElements_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhotoWithElements.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
