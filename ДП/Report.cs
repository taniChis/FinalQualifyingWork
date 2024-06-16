using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Application = System.Windows.Forms.Application;
using Word = Microsoft.Office.Interop.Word;

namespace ДП
{
    public partial class Report : Form
    {
        static private string name;
        
        ForSQL forSQL = new ForSQL();
        public Report()
        {
            InitializeComponent();
        }
        private void ReadSingleRowDataPrintedCircuitBoards(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetString(0),
                dataRecord.GetInt32(1),
                dataRecord.GetString(2));
        }
        private void ReadSingleRowDataVisualInspection(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetInt32(0),
                dataRecord.GetInt32(1),
                dataRecord.GetInt32(2),
                dataRecord.GetInt32(3),
                dataRecord.GetInt32(4),
                dataRecord.GetInt32(5),
                dataRecord.GetString(6),
                dataRecord.GetDateTime(7).ToString("dd.MM.yyyy"),
                dataRecord.GetString(8),
                dataRecord.GetString(9)
                );
        }
        private void ReadSingleRowDataCheckingWithTheDevice(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetString(0),
                dataRecord.GetInt32(1),
                dataRecord.GetDateTime(2).ToString("dd.MM.yyyy"),
                dataRecord.GetString(3),
                dataRecord.GetString(4));
        }
        private void ReadSingleRowDataCheckingWhenThePowerIsOn(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetDouble(0),
                dataRecord.GetString(1),
                dataRecord.GetDateTime(2).ToString("dd.MM.yyyy"),
                dataRecord.GetString(3),
                dataRecord.GetString(4));
        }
        private void ReadSingleRowDataCheckingTheOperation(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                 dataRecord.GetString(0),
                 dataRecord.GetString(1),
                 dataRecord.GetString(2),
                 dataRecord.GetDouble(3),
                 dataRecord.GetDateTime(4).ToString("dd.MM.yyyy"),
                 dataRecord.GetString(5),
                 dataRecord.GetString(6));
        }
        private void ReadSingleRowDataSoftwareUpdate(DataGridView dataGridView, IDataRecord dataRecord)
        {
            dataGridView.Rows.Add(
                dataRecord.GetDouble(0),
                dataRecord.GetDateTime(1).ToString("dd.MM.yyyy"),
                dataRecord.GetString(2),
                dataRecord.GetString(3));
        }
        private void ReadSingleRowDataAcceptanceOfPrintedCircuitBoards(DataGridView dataGridView, IDataRecord dataRecord)
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
                dataRecord.GetDouble(1),
                dataRecord.GetInt32(2),
                dataRecord.GetInt32(3),
                dataRecord.GetInt32(4),
                dataRecord.GetInt32(5),
                baseImage,
                elementsImage,
                dataRecord.GetDateTime(8).ToString("dd.MM.yyyy"),
                dataRecord.GetString(9),
                dataRecord.GetString(10));
        }

        public void RefreshDataGridData(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            try
            {
                string DecimalNumberOfPrintedCircuitBoards = textBoxIDPrintedCircuitBoards.Text;
                forSQL.openConnection();
                string queryStringPrintedCircuitBoards = "SELECT DecimalNumber, UniqueNumber, PrintedCircuitBoards.Name " +
                "FROM PrintedCircuitBoards " +
                "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards;";
                SQLiteCommand sqlCommandPrintedCircuitBoards = new SQLiteCommand(queryStringPrintedCircuitBoards, forSQL.getConnection());
                sqlCommandPrintedCircuitBoards.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerPrintedCircuitBoards = sqlCommandPrintedCircuitBoards.ExecuteReader();
                while (readerPrintedCircuitBoards.Read())
                    ReadSingleRowDataPrintedCircuitBoards(dataGridView, readerPrintedCircuitBoards);
                readerPrintedCircuitBoards.Close();

                string queryStringVisualInspection = "SELECT ThePresenceOfAllElementsOnTheBoard ," +
                        "TheElementsInstalledCorrectly  ," +
                        "ThepresenceOfSolderedLegs  ," +
                        "NocoldSolderingEffect  ," +
                        "NoFluxOnTheBoard  ," +
                        "Denominations  ," +
                        "MarkingOfTheBoard  ," +
                        "Date_ ," +
                        "Notes  ," +
                        "Employee.Surname " +
                        "FROM VisualInspection " +
                        "JOIN PrintedCircuitBoards ON VisualInspection.IDPrintedCircuitBoards = PrintedCircuitBoards.IDPrintedCircuitBoards " +
                        "JOIN Employee ON Employee.IDEmployee = VisualInspection.IDEmployee " +
                        "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards; ";
                SQLiteCommand sqlCommandVisualInspection = new SQLiteCommand(queryStringVisualInspection, forSQL.getConnection());
                sqlCommandVisualInspection.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerVisualInspection = sqlCommandVisualInspection.ExecuteReader();
                while (readerVisualInspection.Read())
                    ReadSingleRowDataVisualInspection(dataGridViewVisualInspection, readerVisualInspection);
                readerVisualInspection.Close();

                string queryStringCheckingWithTheDevice = "SELECT ResistanceOfImportantCircuits ," +
                    "NoShortCircuit ," +
                    "Date_ ," +
                    "Notes," +
                    "Employee.Surname " +
                    "FROM CheckingWithTheDevice " +
                    "JOIN PrintedCircuitBoards ON CheckingWithTheDevice.IDPrintedCircuitBoards = PrintedCircuitBoards.IDPrintedCircuitBoards " +
                    "JOIN Employee ON Employee.IDEmployee = CheckingWithTheDevice.IDEmployee " +
                    "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards;";
                SQLiteCommand sqlCommandCheckingWithTheDevice = new SQLiteCommand(queryStringCheckingWithTheDevice, forSQL.getConnection());
                sqlCommandCheckingWithTheDevice.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerCheckingWithTheDevice = sqlCommandCheckingWithTheDevice.ExecuteReader();
                while (readerCheckingWithTheDevice.Read())
                    ReadSingleRowDataCheckingWithTheDevice(dataGridViewCheckingWithTheDevice, readerCheckingWithTheDevice);
                readerCheckingWithTheDevice.Close();

                string queryStringCheckingWhenThePowerIsOn = "SELECT CurrentConsumption," +
                "ThePresenceOfAllVoltages," +
                "Date_," +
                "Notes," +
                "Employee.Surname " +
                "FROM CheckingWhenThePowerIsOn " +
                "JOIN PrintedCircuitBoards ON CheckingWhenThePowerIsOn.IDPrintedCircuitBoards = PrintedCircuitBoards.IDPrintedCircuitBoards " +
                "JOIN Employee ON Employee.IDEmployee = CheckingWhenThePowerIsOn.IDEmployee " +
                "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards; ";
                SQLiteCommand sqlCommandCheckingWhenThePowerIsOn = new SQLiteCommand(queryStringCheckingWhenThePowerIsOn, forSQL.getConnection());
                sqlCommandCheckingWhenThePowerIsOn.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerCheckingWhenThePowerIsOn = sqlCommandCheckingWhenThePowerIsOn.ExecuteReader();
                while (readerCheckingWhenThePowerIsOn.Read())
                    ReadSingleRowDataCheckingWhenThePowerIsOn(dataGridViewCheckingWhenThePowerIsOn, readerCheckingWhenThePowerIsOn);
                readerCheckingWhenThePowerIsOn.Close();

                string queryStringCheckingTheOperation = "SELECT CheckingTheOperation.Name," +
                "AddingImprovements ,"+
                "Problem ," +
                "Version ," +
                "Date_," +
                "Notes," +
                "Employee.Surname " +
                "FROM CheckingTheOperation " +
                "JOIN PrintedCircuitBoards ON CheckingTheOperation.IDPrintedCircuitBoards = PrintedCircuitBoards.IDPrintedCircuitBoards " +
                "JOIN Employee ON Employee.IDEmployee = CheckingTheOperation.IDEmployee " +
                "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards; ";
                SQLiteCommand sqlCommandCheckingTheOperation = new SQLiteCommand(queryStringCheckingTheOperation, forSQL.getConnection());
                sqlCommandCheckingTheOperation.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerCheckingTheOperation = sqlCommandCheckingTheOperation.ExecuteReader();
                while (readerCheckingTheOperation.Read())
                    ReadSingleRowDataCheckingTheOperation(dataGridViewCheckingTheOperation, readerCheckingTheOperation);
                readerCheckingTheOperation.Close();

                string queryStringSoftwareUpdate = "SELECT\r\n" +
                    "SoftwareUpdate.Version,\r\n" +
                    "SoftwareUpdate.Date_,\r\n" +
                    "SoftwareUpdate.Notes,\r\n" +
                    "Employee.Surname \r\n" +
                    "FROM SoftwareUpdatePrintedCircuitBoards \r\n" +
                    "JOIN SoftwareUpdate ON SoftwareUpdate.IDUpdate = SoftwareUpdatePrintedCircuitBoards.IDUpdate \r\n" +
                    "JOIN PrintedCircuitBoards ON PrintedCircuitBoards.IDPrintedCircuitBoards = SoftwareUpdatePrintedCircuitBoards.IDPrintedCircuitBoards \r\n" +
                    "JOIN Employee ON Employee.IDEmployee = SoftwareUpdate.IDEmployee "+
                    "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards; ";
                SQLiteCommand sqlCommandSoftwareUpdate = new SQLiteCommand(queryStringSoftwareUpdate, forSQL.getConnection());
                sqlCommandSoftwareUpdate.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerSoftwareUpdate = sqlCommandSoftwareUpdate.ExecuteReader();
                while (readerSoftwareUpdate.Read())
                    ReadSingleRowDataSoftwareUpdate(dataGridViewSoftwareUpdate, readerSoftwareUpdate);
                readerSoftwareUpdate.Close();

                string queryStringAcceptanceOfPrintedCircuitBoards = "SELECT "+
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
                 "JOIN Employee ON Employee.IDEmployee = AcceptanceOfPrintedCircuitBoards.IDEmployee "+
                 "WHERE DecimalNumber = @DecimalNumberOfPrintedCircuitBoards; ";
                SQLiteCommand sqlCommandAcceptanceOfPrintedCircuitBoards = new SQLiteCommand(queryStringAcceptanceOfPrintedCircuitBoards, forSQL.getConnection());
                sqlCommandAcceptanceOfPrintedCircuitBoards.Parameters.AddWithValue("@DecimalNumberOfPrintedCircuitBoards", DecimalNumberOfPrintedCircuitBoards);
                SQLiteDataReader readerAcceptanceOfPrintedCircuitBoards = sqlCommandAcceptanceOfPrintedCircuitBoards.ExecuteReader();
                while (readerAcceptanceOfPrintedCircuitBoards.Read())
                {
                    ReadSingleRowDataAcceptanceOfPrintedCircuitBoards(dataGridViewAcceptanceOfPrintedCircuitBoards, readerAcceptanceOfPrintedCircuitBoards);
                }
                readerAcceptanceOfPrintedCircuitBoards.Close();
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
        private System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
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
        private void Report_Load(object sender, EventArgs e)
        {
            buttonGenerate.Enabled = false;
            buttonPrint.Enabled = false;
            LoadDecimalNumberInComboBox();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void ClearDataGridView()
        {
            dataGridViewPrintedCircuitBoards.Rows.Clear();
            dataGridViewVisualInspection.Rows.Clear();
            dataGridViewCheckingWithTheDevice.Rows.Clear();
            dataGridViewCheckingWhenThePowerIsOn.Rows.Clear();
            dataGridViewCheckingTheOperation.Rows.Clear();
            dataGridViewSoftwareUpdate.Rows.Clear();
            dataGridViewAcceptanceOfPrintedCircuitBoards.Rows.Clear();
        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            RefreshDataGridData(dataGridViewPrintedCircuitBoards);
            buttonPrint.Enabled = true;
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Loading loadingform = new Loading();
            name = textBoxIDPrintedCircuitBoards.Text;
            string PathOldFile = $@"{Application.StartupPath}\Документы\Шаблон.docx"; 
            string PathNewFile = CopyFile(PathOldFile);
            if (PathNewFile != null)
            {
                loadingform.ShowDialog();
                CalcTable(PathNewFile, "[Table1]", dataGridViewPrintedCircuitBoards);
                CalcTable(PathNewFile, "[Table2]", dataGridViewVisualInspection);
                CalcTable(PathNewFile, "[Table3]", dataGridViewCheckingWithTheDevice);
                CalcTable(PathNewFile, "[Table4]", dataGridViewCheckingWhenThePowerIsOn);
                CalcTable(PathNewFile, "[Table5]", dataGridViewCheckingTheOperation);
                CalcTable(PathNewFile, "[Table6]", dataGridViewSoftwareUpdate);
                CalcTable(PathNewFile, "[Table7]", dataGridViewAcceptanceOfPrintedCircuitBoards);
                ConvertDocxToPdf(PathNewFile);
            }
        }

        static void CalcTable(string filePath, string tag, DataGridView dataGridView)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open(filePath);

            foreach (Word.Range range in doc.StoryRanges)
            {
                while (range.Find.Execute("[name]"))
                {
                    range.Text = range.Text.Replace("[name]", name);
                }
            }

            System.Data.DataTable table = new System.Data.DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                table.Columns.Add(column.HeaderText);
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow newRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value is Image)
                    {
                        newRow[cell.ColumnIndex] = "Photo";
                    }
                    else
                    {
                        newRow[cell.ColumnIndex] = cell.Value;
                    }
                }
                table.Rows.Add(newRow);
            }
            foreach (Word.Range range in doc.StoryRanges)
            {
                Word.Range rangeWithTag = range;
                while (rangeWithTag.Find.Execute(tag))
                {
                    rangeWithTag.Find.Execute(tag);
                    Word.Table newTable = doc.Tables.Add(rangeWithTag, table.Rows.Count + 1, table.Columns.Count);

                    newTable.Borders.Enable = 1;

                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        newTable.Cell(1, i + 1).Range.Text = dataGridView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < table.Rows.Count-1; i++)
                    {
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            newTable.Cell(i + 2, j + 1).Range.Text = table.Rows[i][j].ToString();
                        }
                    }
                    rangeWithTag = newTable.Range;
                }
            }
            doc.Save();
            doc.Close();
            wordApp.Quit();
        }
        private string CopyFile(string sourceFilePath)
        {
            string nameFile = $"{name} {DateTime.Today.ToString("dd MMMM yyyy")} {DateTime.Now.ToString("HH-mm-ss")}.docx";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx"; 
                saveFileDialog.FileName = nameFile; 
                saveFileDialog.InitialDirectory = Application.StartupPath;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationFilePath = saveFileDialog.FileName;

                    try
                    {
                        if (File.Exists(sourceFilePath))
                        {
                            File.Copy(sourceFilePath, destinationFilePath, true);
                            return destinationFilePath;
                        }
                        else
                        {
                            MessageBox.Show("Исходный файл не найден.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при копировании файла: " + ex.Message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public void ConvertDocxToPdf(string docxFilePath)
        {
            try
            {
                if (!File.Exists(docxFilePath))
                {
                    MessageBox.Show("Файл не найден: " + docxFilePath, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string pdfFilePath = Path.ChangeExtension(docxFilePath, ".pdf");
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Open(docxFilePath);
                doc.ExportAsFixedFormat(pdfFilePath, Word.WdExportFormat.wdExportFormatPDF);
                doc.Close();
                wordApp.Quit();
                MessageBox.Show("Конвертация успешно завершена. Файл сохранен как: " + pdfFilePath, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при конвертации файла: " + ex.Message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxIDPrintedCircuitBoards_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDataGridView();
            buttonPrint.Enabled = false;
            if (textBoxIDPrintedCircuitBoards.Text.Length == 0)
                buttonGenerate.Enabled = false;
            else
                buttonGenerate.Enabled = true;
        }
    }
}
