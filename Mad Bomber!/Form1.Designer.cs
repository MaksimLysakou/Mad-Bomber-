namespace Mad_Bomber_
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RenderWindow = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RenderWindow
            // 
            this.RenderWindow.AccumBits = ((byte)(0));
            this.RenderWindow.AutoCheckErrors = false;
            this.RenderWindow.AutoFinish = false;
            this.RenderWindow.AutoMakeCurrent = true;
            this.RenderWindow.AutoSwapBuffers = true;
            this.RenderWindow.BackColor = System.Drawing.Color.Black;
            this.RenderWindow.ColorBits = ((byte)(32));
            this.RenderWindow.DepthBits = ((byte)(16));
            this.RenderWindow.Location = new System.Drawing.Point(0, 0);
            this.RenderWindow.Name = "RenderWindow";
            this.RenderWindow.Size = new System.Drawing.Size(911, 492);
            this.RenderWindow.StencilBits = ((byte)(0));
            this.RenderWindow.TabIndex = 0;
            // 
            // drawTimer
            // 
            this.drawTimer.Enabled = true;
            this.drawTimer.Interval = 30;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 492);
            this.Controls.Add(this.RenderWindow);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public Tao.Platform.Windows.SimpleOpenGlControl RenderWindow;
        private System.Windows.Forms.Timer drawTimer;
    }
}

