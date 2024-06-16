namespace ДП
{
    partial class CheckingTheOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingTheOperation));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxEmployee = new System.Windows.Forms.ComboBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.textBoxNotes = new System.Windows.Forms.RichTextBox();
            this.textBoxIDPrintedCircuitBoards = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxProblem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonChangePanel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonAddPanel = new System.Windows.Forms.Button();
            this.textBoxAddingImprovements = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 46);
            this.label3.TabIndex = 71;
            this.label3.Text = "Название";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(561, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 37);
            this.label2.TabIndex = 101;
            this.label2.Text = "Поиск:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 45F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1244, 100);
            this.label1.TabIndex = 97;
            this.label1.Text = "     Проверка функциональности     ";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column9,
            this.Column10,
            this.Column4,
            this.Column6,
            this.Column8,
            this.Column5});
            this.dataGridView.Location = new System.Drawing.Point(24, 164);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(905, 465);
            this.dataGridView.TabIndex = 95;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Номер платы";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Добавление доработок";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Проблема";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Версия";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата теста";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Заметки";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 300;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Фамилия сотрудника";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 180;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "rowState";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 125;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxSearch.Location = new System.Drawing.Point(689, 112);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(240, 46);
            this.textBoxSearch.TabIndex = 102;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.label6.Location = new System.Drawing.Point(935, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 661);
            this.label6.TabIndex = 105;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxEmployee);
            this.panel1.Controls.Add(this.textBoxVersion);
            this.panel1.Controls.Add(this.textBoxNotes);
            this.panel1.Controls.Add(this.textBoxIDPrintedCircuitBoards);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBoxDate);
            this.panel1.Controls.Add(this.textBoxProblem);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ID);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.buttonChangePanel);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.buttonAddPanel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxAddingImprovements);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(977, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 658);
            this.panel1.TabIndex = 104;
            // 
            // textBoxEmployee
            // 
            this.textBoxEmployee.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxEmployee.FormattingEnabled = true;
            this.textBoxEmployee.Location = new System.Drawing.Point(248, 373);
            this.textBoxEmployee.Name = "textBoxEmployee";
            this.textBoxEmployee.Size = new System.Drawing.Size(237, 45);
            this.textBoxEmployee.TabIndex = 124;
            this.textBoxEmployee.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDPrintedCircuitBoards_KeyPress);
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxVersion.Location = new System.Drawing.Point(248, 271);
            this.textBoxVersion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(237, 45);
            this.textBoxVersion.TabIndex = 89;
            this.textBoxVersion.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVersion_KeyPress);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxNotes.Location = new System.Drawing.Point(247, 424);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(237, 149);
            this.textBoxNotes.TabIndex = 123;
            this.textBoxNotes.Text = "";
            this.textBoxNotes.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxIDPrintedCircuitBoards
            // 
            this.textBoxIDPrintedCircuitBoards.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIDPrintedCircuitBoards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxIDPrintedCircuitBoards.FormattingEnabled = true;
            this.textBoxIDPrintedCircuitBoards.Location = new System.Drawing.Point(247, 67);
            this.textBoxIDPrintedCircuitBoards.Name = "textBoxIDPrintedCircuitBoards";
            this.textBoxIDPrintedCircuitBoards.Size = new System.Drawing.Size(237, 45);
            this.textBoxIDPrintedCircuitBoards.TabIndex = 121;
            this.textBoxIDPrintedCircuitBoards.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxIDPrintedCircuitBoards.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDPrintedCircuitBoards_KeyPress);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(3, 270);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 46);
            this.label11.TabIndex = 88;
            this.label11.Text = "Версия";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDate
            // 
            this.textBoxDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxDate.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDate.Location = new System.Drawing.Point(247, 324);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(237, 45);
            this.textBoxDate.TabIndex = 122;
            this.textBoxDate.Value = new System.DateTime(2024, 5, 11, 0, 0, 0, 0);
            this.textBoxDate.ValueChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxProblem
            // 
            this.textBoxProblem.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProblem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxProblem.Location = new System.Drawing.Point(248, 220);
            this.textBoxProblem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxProblem.Name = "textBoxProblem";
            this.textBoxProblem.Size = new System.Drawing.Size(237, 45);
            this.textBoxProblem.TabIndex = 87;
            this.textBoxProblem.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(2, 219);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(243, 46);
            this.label10.TabIndex = 86;
            this.label10.Text = "Проблема";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label9.Location = new System.Drawing.Point(3, 373);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 46);
            this.label9.TabIndex = 85;
            this.label9.Text = "Фамилия сотрудника";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label8.Location = new System.Drawing.Point(2, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 46);
            this.label8.TabIndex = 83;
            this.label8.Text = "Номер платы";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(3, 428);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 46);
            this.label7.TabIndex = 81;
            this.label7.Text = "Заметки";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.ID.Location = new System.Drawing.Point(2, 10);
            this.ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(243, 46);
            this.ID.TabIndex = 79;
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxID.Location = new System.Drawing.Point(248, 16);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(237, 45);
            this.textBoxID.TabIndex = 78;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // buttonChangePanel
            // 
            this.buttonChangePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonChangePanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChangePanel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonChangePanel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChangePanel.Location = new System.Drawing.Point(294, 598);
            this.buttonChangePanel.Name = "buttonChangePanel";
            this.buttonChangePanel.Size = new System.Drawing.Size(150, 50);
            this.buttonChangePanel.TabIndex = 77;
            this.buttonChangePanel.Text = "Изменить";
            this.buttonChangePanel.UseVisualStyleBackColor = false;
            this.buttonChangePanel.Click += new System.EventHandler(this.buttonChangePanel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxName.Location = new System.Drawing.Point(247, 118);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(237, 45);
            this.textBoxName.TabIndex = 74;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // buttonAddPanel
            // 
            this.buttonAddPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonAddPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddPanel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonAddPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddPanel.Location = new System.Drawing.Point(60, 598);
            this.buttonAddPanel.Name = "buttonAddPanel";
            this.buttonAddPanel.Size = new System.Drawing.Size(150, 50);
            this.buttonAddPanel.TabIndex = 71;
            this.buttonAddPanel.Text = "Добавить";
            this.buttonAddPanel.UseVisualStyleBackColor = false;
            this.buttonAddPanel.Click += new System.EventHandler(this.buttonAddPanel_Click);
            // 
            // textBoxAddingImprovements
            // 
            this.textBoxAddingImprovements.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddingImprovements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxAddingImprovements.Location = new System.Drawing.Point(247, 169);
            this.textBoxAddingImprovements.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxAddingImprovements.Name = "textBoxAddingImprovements";
            this.textBoxAddingImprovements.Size = new System.Drawing.Size(237, 45);
            this.textBoxAddingImprovements.TabIndex = 75;
            this.textBoxAddingImprovements.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(3, 322);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 46);
            this.label5.TabIndex = 73;
            this.label5.Text = "Дата теста";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(3, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 46);
            this.label4.TabIndex = 72;
            this.label4.Text = "Добавление доработок";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonExit.Image = global::ДП.Properties.Resources.ExitPhoto;
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.Location = new System.Drawing.Point(1258, 38);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(240, 60);
            this.buttonExit.TabIndex = 115;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonSave.Image = global::ДП.Properties.Resources.SavePhoto;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(473, 710);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(240, 60);
            this.buttonSave.TabIndex = 114;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChange.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonChange.Image = global::ДП.Properties.Resources.ChangePhoto;
            this.buttonChange.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChange.Location = new System.Drawing.Point(473, 635);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(240, 60);
            this.buttonChange.TabIndex = 113;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonDelete.Image = global::ДП.Properties.Resources.DeletePhoto;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDelete.Location = new System.Drawing.Point(227, 710);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(240, 60);
            this.buttonDelete.TabIndex = 112;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonAdd.Image = global::ДП.Properties.Resources.AddPhoto;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(227, 635);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(240, 60);
            this.buttonAdd.TabIndex = 111;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // CheckingTheOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(186)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(1529, 779);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "CheckingTheOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка функциональности";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CheckingTheOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxProblem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonChangePanel;
        private System.Windows.Forms.Button buttonAddPanel;
        private System.Windows.Forms.TextBox textBoxAddingImprovements;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox textBoxEmployee;
        private System.Windows.Forms.RichTextBox textBoxNotes;
        private System.Windows.Forms.ComboBox textBoxIDPrintedCircuitBoards;
        private System.Windows.Forms.DateTimePicker textBoxDate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}