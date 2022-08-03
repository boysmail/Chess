
namespace Chess
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnClassic = new System.Windows.Forms.Button();
            this.btnPuzzle = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnTestForm = new System.Windows.Forms.Button();
            this.panelPuzzle = new System.Windows.Forms.Panel();
            this.btnPuzzleBack = new System.Windows.Forms.Button();
            this.btnPuzzle1 = new System.Windows.Forms.Button();
            this.timerExit = new System.Windows.Forms.Timer(this.components);
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnSettingsBack = new System.Windows.Forms.Button();
            this.checkBoxHelper = new System.Windows.Forms.CheckBox();
            this.panelMenu.SuspendLayout();
            this.panelPuzzle.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(72, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chess";
            // 
            // btnClassic
            // 
            this.btnClassic.Location = new System.Drawing.Point(80, 133);
            this.btnClassic.Name = "btnClassic";
            this.btnClassic.Size = new System.Drawing.Size(150, 70);
            this.btnClassic.TabIndex = 1;
            this.btnClassic.Text = "Classic";
            this.btnClassic.UseVisualStyleBackColor = true;
            this.btnClassic.Click += new System.EventHandler(this.btnClassic_Click);
            // 
            // btnPuzzle
            // 
            this.btnPuzzle.Location = new System.Drawing.Point(80, 243);
            this.btnPuzzle.Name = "btnPuzzle";
            this.btnPuzzle.Size = new System.Drawing.Size(150, 70);
            this.btnPuzzle.TabIndex = 2;
            this.btnPuzzle.Text = "Puzzle";
            this.btnPuzzle.UseVisualStyleBackColor = true;
            this.btnPuzzle.Click += new System.EventHandler(this.btnPuzzle_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(80, 353);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(150, 70);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnTestForm);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnPuzzle);
            this.panelMenu.Controls.Add(this.btnClassic);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Location = new System.Drawing.Point(210, 17);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(298, 443);
            this.panelMenu.TabIndex = 4;
            // 
            // btnTestForm
            // 
            this.btnTestForm.Location = new System.Drawing.Point(9, 365);
            this.btnTestForm.Name = "btnTestForm";
            this.btnTestForm.Size = new System.Drawing.Size(65, 58);
            this.btnTestForm.TabIndex = 4;
            this.btnTestForm.Text = "Test Form";
            this.btnTestForm.UseVisualStyleBackColor = true;
            this.btnTestForm.Click += new System.EventHandler(this.btnTestForm_Click);
            // 
            // panelPuzzle
            // 
            this.panelPuzzle.Controls.Add(this.btnPuzzleBack);
            this.panelPuzzle.Controls.Add(this.btnPuzzle1);
            this.panelPuzzle.Location = new System.Drawing.Point(9, 46);
            this.panelPuzzle.Name = "panelPuzzle";
            this.panelPuzzle.Size = new System.Drawing.Size(696, 369);
            this.panelPuzzle.TabIndex = 5;
            this.panelPuzzle.Visible = false;
            // 
            // btnPuzzleBack
            // 
            this.btnPuzzleBack.Location = new System.Drawing.Point(34, 34);
            this.btnPuzzleBack.Name = "btnPuzzleBack";
            this.btnPuzzleBack.Size = new System.Drawing.Size(70, 40);
            this.btnPuzzleBack.TabIndex = 1;
            this.btnPuzzleBack.Text = "Back";
            this.btnPuzzleBack.UseVisualStyleBackColor = true;
            this.btnPuzzleBack.Click += new System.EventHandler(this.btnPuzzleBack_Click);
            // 
            // btnPuzzle1
            // 
            this.btnPuzzle1.Location = new System.Drawing.Point(34, 116);
            this.btnPuzzle1.Name = "btnPuzzle1";
            this.btnPuzzle1.Size = new System.Drawing.Size(70, 70);
            this.btnPuzzle1.TabIndex = 0;
            this.btnPuzzle1.Text = "Puzzle 1";
            this.btnPuzzle1.UseVisualStyleBackColor = true;
            this.btnPuzzle1.Click += new System.EventHandler(this.btnPuzzle1_Click);
            // 
            // timerExit
            // 
            this.timerExit.Interval = 5000;
            this.timerExit.Tick += new System.EventHandler(this.timerExit_Tick);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnSettingsBack);
            this.panelSettings.Controls.Add(this.checkBoxHelper);
            this.panelSettings.Location = new System.Drawing.Point(12, 32);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(696, 369);
            this.panelSettings.TabIndex = 2;
            this.panelSettings.Visible = false;
            // 
            // btnSettingsBack
            // 
            this.btnSettingsBack.Location = new System.Drawing.Point(31, 30);
            this.btnSettingsBack.Name = "btnSettingsBack";
            this.btnSettingsBack.Size = new System.Drawing.Size(70, 40);
            this.btnSettingsBack.TabIndex = 1;
            this.btnSettingsBack.Text = "Back";
            this.btnSettingsBack.UseVisualStyleBackColor = true;
            this.btnSettingsBack.Click += new System.EventHandler(this.btnSettingsBack_Click);
            // 
            // checkBoxHelper
            // 
            this.checkBoxHelper.AutoSize = true;
            this.checkBoxHelper.Checked = true;
            this.checkBoxHelper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHelper.Location = new System.Drawing.Point(108, 97);
            this.checkBoxHelper.Name = "checkBoxHelper";
            this.checkBoxHelper.Size = new System.Drawing.Size(130, 17);
            this.checkBoxHelper.TabIndex = 0;
            this.checkBoxHelper.Text = "Show Possible Moves";
            this.checkBoxHelper.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(744, 471);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelPuzzle);
            this.Controls.Add(this.panelSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelPuzzle.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnSettingsBack;

        private System.Windows.Forms.Button btnTestForm;

        private System.Windows.Forms.Panel panelPuzzle;
        private System.Windows.Forms.Button btnPuzzle1;
        private System.Windows.Forms.Button btnPuzzleBack;

        private System.Windows.Forms.Panel panelMenu;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClassic;
        private System.Windows.Forms.Button btnPuzzle;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timerExit;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxHelper;
    }
}

