namespace ДП
{
    partial class CheckingWithTheDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingWithTheDevice));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxEmployee = new System.Windows.Forms.ComboBox();
            this.textBoxIDPrintedCircuitBoards = new System.Windows.Forms.ComboBox();
            this.textBoxDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxNotes = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonChangePanel = new System.Windows.Forms.Button();
            this.buttonAddPanel = new System.Windows.Forms.Button();
            this.textBoxNoShortCircuit = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxResistanceOfImportantCircuits = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.label6.Location = new System.Drawing.Point(56, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1418, 25);
            this.label6.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1301, 100);
            this.label1.TabIndex = 75;
            this.label1.Text = "     Проверка с помощью приборов     ";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column8,
            this.Column5});
            this.dataGridView.Location = new System.Drawing.Point(56, 473);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1418, 319);
            this.dataGridView.TabIndex = 73;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Номер платы";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Сопротивление важных цепей";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Отсутствие короткого замыкания";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата проверки";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Заметки";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 285;
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
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.Location = new System.Drawing.Point(1234, 36);
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
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(63, 300);
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
            this.buttonChange.Image = ((System.Drawing.Image)(resources.GetObject("buttonChange.Image")));
            this.buttonChange.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChange.Location = new System.Drawing.Point(63, 168);
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
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDelete.Location = new System.Drawing.Point(63, 234);
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
            this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(63, 102);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(240, 60);
            this.buttonAdd.TabIndex = 111;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label10.Location = new System.Drawing.Point(891, 421);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 37);
            this.label10.TabIndex = 79;
            this.label10.Text = "Поиск:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxSearch.Location = new System.Drawing.Point(1020, 418);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(454, 46);
            this.textBoxSearch.TabIndex = 80;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxEmployee);
            this.panel1.Controls.Add(this.textBoxIDPrintedCircuitBoards);
            this.panel1.Controls.Add(this.textBoxDate);
            this.panel1.Controls.Add(this.textBoxNotes);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.buttonChangePanel);
            this.panel1.Controls.Add(this.buttonAddPanel);
            this.panel1.Controls.Add(this.textBoxNoShortCircuit);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.textBoxResistanceOfImportantCircuits);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(309, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 258);
            this.panel1.TabIndex = 82;
            // 
            // textBoxEmployee
            // 
            this.textBoxEmployee.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxEmployee.FormattingEnabled = true;
            this.textBoxEmployee.Location = new System.Drawing.Point(746, 82);
            this.textBoxEmployee.Name = "textBoxEmployee";
            this.textBoxEmployee.Size = new System.Drawing.Size(237, 45);
            this.textBoxEmployee.TabIndex = 117;
            this.textBoxEmployee.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDPrintedCircuitBoards_KeyPress);
            // 
            // textBoxIDPrintedCircuitBoards
            // 
            this.textBoxIDPrintedCircuitBoards.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIDPrintedCircuitBoards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxIDPrintedCircuitBoards.FormattingEnabled = true;
            this.textBoxIDPrintedCircuitBoards.Location = new System.Drawing.Point(255, 81);
            this.textBoxIDPrintedCircuitBoards.Name = "textBoxIDPrintedCircuitBoards";
            this.textBoxIDPrintedCircuitBoards.Size = new System.Drawing.Size(237, 45);
            this.textBoxIDPrintedCircuitBoards.TabIndex = 116;
            this.textBoxIDPrintedCircuitBoards.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxIDPrintedCircuitBoards.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIDPrintedCircuitBoards_KeyPress);
            // 
            // textBoxDate
            // 
            this.textBoxDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxDate.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDate.Location = new System.Drawing.Point(746, 19);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(237, 45);
            this.textBoxDate.TabIndex = 116;
            this.textBoxDate.ValueChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxNotes.Location = new System.Drawing.Point(746, 138);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(237, 104);
            this.textBoxNotes.TabIndex = 116;
            this.textBoxNotes.Text = "";
            this.textBoxNotes.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(498, 82);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 46);
            this.label11.TabIndex = 85;
            this.label11.Text = "Фамилия сотрудника";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(9, 81);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(243, 46);
            this.label12.TabIndex = 83;
            this.label12.Text = "Номер платы";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label13.Location = new System.Drawing.Point(498, 138);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(243, 46);
            this.label13.TabIndex = 81;
            this.label13.Text = "Заметки";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label14.Location = new System.Drawing.Point(8, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 46);
            this.label14.TabIndex = 79;
            this.label14.Text = "ID";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxID.Location = new System.Drawing.Point(255, 18);
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
            this.buttonChangePanel.Location = new System.Drawing.Point(1001, 154);
            this.buttonChangePanel.Name = "buttonChangePanel";
            this.buttonChangePanel.Size = new System.Drawing.Size(150, 50);
            this.buttonChangePanel.TabIndex = 77;
            this.buttonChangePanel.Text = "Изменить";
            this.buttonChangePanel.UseVisualStyleBackColor = false;
            this.buttonChangePanel.Click += new System.EventHandler(this.buttonChangePanel_Click);
            // 
            // buttonAddPanel
            // 
            this.buttonAddPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(105)))), ((int)(((byte)(88)))));
            this.buttonAddPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddPanel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.buttonAddPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddPanel.Location = new System.Drawing.Point(1001, 61);
            this.buttonAddPanel.Name = "buttonAddPanel";
            this.buttonAddPanel.Size = new System.Drawing.Size(150, 50);
            this.buttonAddPanel.TabIndex = 71;
            this.buttonAddPanel.Text = "Добавить";
            this.buttonAddPanel.UseVisualStyleBackColor = false;
            this.buttonAddPanel.Click += new System.EventHandler(this.buttonAddPanel_Click);
            // 
            // textBoxNoShortCircuit
            // 
            this.textBoxNoShortCircuit.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNoShortCircuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxNoShortCircuit.Location = new System.Drawing.Point(256, 198);
            this.textBoxNoShortCircuit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxNoShortCircuit.Name = "textBoxNoShortCircuit";
            this.textBoxNoShortCircuit.Size = new System.Drawing.Size(237, 45);
            this.textBoxNoShortCircuit.TabIndex = 75;
            this.textBoxNoShortCircuit.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxNoShortCircuit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNoShortCircuit_KeyPress);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label15.Location = new System.Drawing.Point(498, 18);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(243, 46);
            this.label15.TabIndex = 73;
            this.label15.Text = "Дата проверки";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxResistanceOfImportantCircuits
            // 
            this.textBoxResistanceOfImportantCircuits.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResistanceOfImportantCircuits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.textBoxResistanceOfImportantCircuits.Location = new System.Drawing.Point(255, 139);
            this.textBoxResistanceOfImportantCircuits.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxResistanceOfImportantCircuits.Name = "textBoxResistanceOfImportantCircuits";
            this.textBoxResistanceOfImportantCircuits.Size = new System.Drawing.Size(237, 45);
            this.textBoxResistanceOfImportantCircuits.TabIndex = 74;
            this.textBoxResistanceOfImportantCircuits.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxResistanceOfImportantCircuits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxResistanceOfImportantCircuits_KeyPress);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label16.Location = new System.Drawing.Point(9, 197);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(243, 46);
            this.label16.TabIndex = 72;
            this.label16.Text = "Отсутствие короткого замыкания";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            this.label17.Location = new System.Drawing.Point(9, 143);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(243, 46);
            this.label17.TabIndex = 71;
            this.label17.Text = "Сопротивление важный цепей";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckingWithTheDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(186)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(1517, 816);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "CheckingWithTheDevice";
            this.Text = "Проверка с помощью приборов";
            this.Load += new System.EventHandler(this.CheckingWithTheDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox textBoxNotes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonChangePanel;
        private System.Windows.Forms.Button buttonAddPanel;
        private System.Windows.Forms.TextBox textBoxNoShortCircuit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxResistanceOfImportantCircuits;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker textBoxDate;
        private System.Windows.Forms.ComboBox textBoxEmployee;
        private System.Windows.Forms.ComboBox textBoxIDPrintedCircuitBoards;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}