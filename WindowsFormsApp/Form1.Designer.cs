namespace WindowsFormsApp
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
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbThreadNum = new System.Windows.Forms.TextBox();
            this.bStop = new System.Windows.Forms.Button();
            this.lv_log = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(271, 24);
            this.bStart.Margin = new System.Windows.Forms.Padding(2);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(63, 26);
            this.bStart.TabIndex = 2;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bLaunchTheads_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thread number";
            // 
            // tbThreadNum
            // 
            this.tbThreadNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.tbThreadNum.Location = new System.Drawing.Point(154, 26);
            this.tbThreadNum.Margin = new System.Windows.Forms.Padding(2);
            this.tbThreadNum.Name = "tbThreadNum";
            this.tbThreadNum.Size = new System.Drawing.Size(114, 26);
            this.tbThreadNum.TabIndex = 1;
            this.tbThreadNum.Text = "2";
            this.tbThreadNum.Enter += new System.EventHandler(this.tbThreadNum_Enter);
            this.tbThreadNum.Leave += new System.EventHandler(this.tbThreadNum_TextChanged);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(338, 23);
            this.bStop.Margin = new System.Windows.Forms.Padding(2);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(63, 26);
            this.bStop.TabIndex = 3;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // lv_log
            // 
            this.lv_log.GridLines = true;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(16, 73);
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(388, 410);
            this.lv_log.TabIndex = 4;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.VirtualListSize = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 490);
            this.Controls.Add(this.lv_log);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbThreadNum);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbThreadNum;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.ListView lv_log;
    }
}

