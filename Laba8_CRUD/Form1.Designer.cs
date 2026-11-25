namespace Laba8_CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            labelName = new Label();
            numericAge = new NumericUpDown();
            textBoxName = new TextBox();
            labelAge = new Label();
            labelGroup = new Label();
            textBoxGroup = new TextBox();
            labelGrade = new Label();
            numericGrade = new NumericUpDown();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            labelStatus = new Label();
            buttonExport = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(346, 182);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(571, 341);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(206, 169);
            labelName.Name = "labelName";
            labelName.Size = new Size(40, 15);
            labelName.TabIndex = 1;
            labelName.Text = "ФИО: ";
            // 
            // numericAge
            // 
            numericAge.Location = new Point(206, 315);
            numericAge.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numericAge.Name = "numericAge";
            numericAge.Size = new Size(120, 23);
            numericAge.TabIndex = 2;
            numericAge.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(206, 187);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 3;
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(206, 297);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(56, 15);
            labelAge.TabIndex = 4;
            labelAge.Text = "Возраст: ";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(206, 397);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(52, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Группа: ";
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(206, 415);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(100, 23);
            textBoxGroup.TabIndex = 6;
            // 
            // labelGrade
            // 
            labelGrade.AutoSize = true;
            labelGrade.Location = new Point(209, 482);
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(88, 15);
            labelGrade.TabIndex = 7;
            labelGrade.Text = "Средний балл:";
            // 
            // numericGrade
            // 
            numericGrade.DecimalPlaces = 2;
            numericGrade.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericGrade.Location = new Point(206, 500);
            numericGrade.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericGrade.Name = "numericGrade";
            numericGrade.Size = new Size(120, 23);
            numericGrade.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(348, 559);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(89, 45);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click_1;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(480, 559);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(81, 45);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click_1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(593, 559);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(84, 45);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click_1;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(717, 559);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 45);
            buttonClear.TabIndex = 12;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(348, 626);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(45, 15);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "Готово";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(838, 557);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(79, 49);
            buttonExport.TabIndex = 14;
            buttonExport.Text = "Экспорт в CSV";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(951, 569);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(89, 35);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 698);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExport);
            Controls.Add(labelStatus);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(numericGrade);
            Controls.Add(labelGrade);
            Controls.Add(textBoxGroup);
            Controls.Add(labelGroup);
            Controls.Add(labelAge);
            Controls.Add(textBoxName);
            Controls.Add(numericAge);
            Controls.Add(labelName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа №8 — CRUD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Label labelName;
        private NumericUpDown numericAge;
        private TextBox textBoxName;
        private Label labelAge;
        private Label labelGroup;
        private TextBox textBoxGroup;
        private Label labelGrade;
        private NumericUpDown numericGrade;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
        private Label labelStatus;
        private Button buttonExport;
        private Button buttonCancel;
    }
}
