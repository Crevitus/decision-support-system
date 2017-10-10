namespace DSS
{
    partial class Form1
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
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.lblActPrice = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblSinglePercentage = new System.Windows.Forms.Label();
            this.btnCBR = new System.Windows.Forms.Button();
            this.btnANN = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(12, 402);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(236, 32);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "PLACEHOLDER";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(576, 568);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(221, 44);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Get Price";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnGetPrice);
            // 
            // cmbSelect
            // 
            this.cmbSelect.AllowDrop = true;
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(12, 69);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(785, 24);
            this.cmbSelect.TabIndex = 6;
            // 
            // lblActPrice
            // 
            this.lblActPrice.AutoSize = true;
            this.lblActPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActPrice.Location = new System.Drawing.Point(12, 456);
            this.lblActPrice.Name = "lblActPrice";
            this.lblActPrice.Size = new System.Drawing.Size(236, 32);
            this.lblActPrice.TabIndex = 7;
            this.lblActPrice.Text = "PLACEHOLDER";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(576, 509);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(221, 44);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Run Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(12, 349);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(236, 32);
            this.lblPercentage.TabIndex = 9;
            this.lblPercentage.Text = "PLACEHOLDER";
            // 
            // lblSinglePercentage
            // 
            this.lblSinglePercentage.AutoSize = true;
            this.lblSinglePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinglePercentage.Location = new System.Drawing.Point(12, 509);
            this.lblSinglePercentage.Name = "lblSinglePercentage";
            this.lblSinglePercentage.Size = new System.Drawing.Size(236, 32);
            this.lblSinglePercentage.TabIndex = 10;
            this.lblSinglePercentage.Text = "PLACEHOLDER";
            // 
            // btnCBR
            // 
            this.btnCBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCBR.ForeColor = System.Drawing.Color.Green;
            this.btnCBR.Location = new System.Drawing.Point(12, 14);
            this.btnCBR.Name = "btnCBR";
            this.btnCBR.Size = new System.Drawing.Size(198, 40);
            this.btnCBR.TabIndex = 11;
            this.btnCBR.Text = "CBR";
            this.btnCBR.UseVisualStyleBackColor = true;
            this.btnCBR.Click += new System.EventHandler(this.btnCBR_Click);
            // 
            // btnANN
            // 
            this.btnANN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnANN.ForeColor = System.Drawing.Color.Gray;
            this.btnANN.Location = new System.Drawing.Point(599, 14);
            this.btnANN.Name = "btnANN";
            this.btnANN.Size = new System.Drawing.Size(198, 40);
            this.btnANN.TabIndex = 13;
            this.btnANN.Text = "ANN";
            this.btnANN.UseVisualStyleBackColor = true;
            this.btnANN.Click += new System.EventHandler(this.btnANN_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.ForeColor = System.Drawing.Color.Black;
            this.btnTrain.Location = new System.Drawing.Point(576, 456);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(221, 41);
            this.btnTrain.TabIndex = 14;
            this.btnTrain.Text = "Train ANN";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Visible = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(576, 402);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(221, 41);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset ANN";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(576, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(221, 40);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save ANN";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebug.Location = new System.Drawing.Point(511, 14);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(82, 40);
            this.btnDebug.TabIndex = 17;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(809, 623);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnANN);
            this.Controls.Add(this.btnCBR);
            this.Controls.Add(this.lblSinglePercentage);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblActPrice);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPrice);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label lblActPrice;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblSinglePercentage;
        private System.Windows.Forms.Button btnCBR;
        private System.Windows.Forms.Button btnANN;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDebug;
    }
}

