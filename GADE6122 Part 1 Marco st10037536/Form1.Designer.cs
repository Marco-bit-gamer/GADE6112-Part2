namespace GADE6122_Part_1_Marco_st10037536
{
    partial class HvsS
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
            this.txtMap = new System.Windows.Forms.TextBox();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.enemiesDropDown = new System.Windows.Forms.ComboBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnStay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMap
            // 
            this.txtMap.AcceptsTab = true;
            this.txtMap.Font = new System.Drawing.Font("Monospac821 BT", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMap.Location = new System.Drawing.Point(270, 41);
            this.txtMap.Multiline = true;
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(486, 426);
            this.txtMap.TabIndex = 0;
            this.txtMap.TextChanged += new System.EventHandler(this.txtMap_TextChanged);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(780, 221);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(291, 484);
            this.infoTextBox.TabIndex = 1;
            this.infoTextBox.Text = "";
            // 
            // enemiesDropDown
            // 
            this.enemiesDropDown.FormattingEnabled = true;
            this.enemiesDropDown.Location = new System.Drawing.Point(780, 41);
            this.enemiesDropDown.Name = "enemiesDropDown";
            this.enemiesDropDown.Size = new System.Drawing.Size(291, 33);
            this.enemiesDropDown.TabIndex = 2;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(136, 360);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(112, 107);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(16, 484);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(112, 107);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(252, 484);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(112, 107);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(136, 612);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(112, 107);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(780, 91);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(291, 107);
            this.btnAttack.TabIndex = 7;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnStay
            // 
            this.btnStay.Location = new System.Drawing.Point(134, 484);
            this.btnStay.Name = "btnStay";
            this.btnStay.Size = new System.Drawing.Size(112, 107);
            this.btnStay.TabIndex = 8;
            this.btnStay.Text = "Stay";
            this.btnStay.UseVisualStyleBackColor = true;
            this.btnStay.Click += new System.EventHandler(this.btnStay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(62, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(62, 100);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 34);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // HvsS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 738);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStay);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.enemiesDropDown);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.txtMap);
            this.Name = "HvsS";
            this.Text = "Hero vs Swamp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.ComboBox enemiesDropDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnStay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}
