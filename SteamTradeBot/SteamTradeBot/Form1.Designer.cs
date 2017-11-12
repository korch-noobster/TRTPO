namespace SteamTradeBot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenBrowser = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.Stop_selling = new System.Windows.Forms.Button();
            this.Start_selling = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceChange = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PriceChange)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenBrowser
            // 
            this.OpenBrowser.Location = new System.Drawing.Point(12, 12);
            this.OpenBrowser.Name = "OpenBrowser";
            this.OpenBrowser.Size = new System.Drawing.Size(216, 33);
            this.OpenBrowser.TabIndex = 0;
            this.OpenBrowser.Text = "Открыть Steam в браузере";
            this.OpenBrowser.UseVisualStyleBackColor = true;
            this.OpenBrowser.Click += new System.EventHandler(this.OpenBrowser_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(523, 206);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(90, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "Закрыть";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Stop_selling
            // 
            this.Stop_selling.Location = new System.Drawing.Point(12, 193);
            this.Stop_selling.Name = "Stop_selling";
            this.Stop_selling.Size = new System.Drawing.Size(231, 48);
            this.Stop_selling.TabIndex = 2;
            this.Stop_selling.Text = "Остановить продажу";
            this.Stop_selling.UseVisualStyleBackColor = true;
            this.Stop_selling.Click += new System.EventHandler(this.Stop_selling_Click);
            // 
            // Start_selling
            // 
            this.Start_selling.Location = new System.Drawing.Point(12, 128);
            this.Start_selling.Name = "Start_selling";
            this.Start_selling.Size = new System.Drawing.Size(231, 48);
            this.Start_selling.TabIndex = 3;
            this.Start_selling.Text = "Начать продажу";
            this.Start_selling.UseVisualStyleBackColor = true;
            this.Start_selling.Click += new System.EventHandler(this.Start_selling_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Sell);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Добавить к минимальной цене в валюте установленной стимом";
            // 
            // PriceChange
            // 
            this.PriceChange.DecimalPlaces = 2;
            this.PriceChange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PriceChange.Location = new System.Drawing.Point(493, 71);
            this.PriceChange.Name = "PriceChange";
            this.PriceChange.Size = new System.Drawing.Size(120, 22);
            this.PriceChange.TabIndex = 5;
            this.PriceChange.ValueChanged += new System.EventHandler(this.PriceChange_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 253);
            this.Controls.Add(this.PriceChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start_selling);
            this.Controls.Add(this.Stop_selling);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.OpenBrowser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PriceChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenBrowser;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Stop_selling;
        private System.Windows.Forms.Button Start_selling;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PriceChange;
    }
}

