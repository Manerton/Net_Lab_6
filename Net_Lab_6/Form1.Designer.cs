namespace Net_Lab_6
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
            this.ConnectToServerButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.RichTextBox();
            this.EnterMessageTextBox = new System.Windows.Forms.TextBox();
            this.UsersListOnForm = new System.Windows.Forms.CheckedListBox();
            this.CreateChatButton = new System.Windows.Forms.Button();
            this.ChatListTab = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterChatMessageTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InputIP = new System.Windows.Forms.TextBox();
            this.InputPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.InputName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SendFileButton = new System.Windows.Forms.Button();
            this.PrivateChatRadioButton = new System.Windows.Forms.RadioButton();
            this.AllChatRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectToServerButton
            // 
            this.ConnectToServerButton.Location = new System.Drawing.Point(273, 37);
            this.ConnectToServerButton.Name = "ConnectToServerButton";
            this.ConnectToServerButton.Size = new System.Drawing.Size(113, 23);
            this.ConnectToServerButton.TabIndex = 1;
            this.ConnectToServerButton.Text = "Подключиться";
            this.ConnectToServerButton.UseVisualStyleBackColor = true;
            this.ConnectToServerButton.Click += new System.EventHandler(this.ConnectToServerButton_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatTextBox.Location = new System.Drawing.Point(12, 113);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.ReadOnly = true;
            this.ChatTextBox.Size = new System.Drawing.Size(259, 323);
            this.ChatTextBox.TabIndex = 3;
            this.ChatTextBox.Text = "";
            // 
            // EnterMessageTextBox
            // 
            this.EnterMessageTextBox.Enabled = false;
            this.EnterMessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterMessageTextBox.Location = new System.Drawing.Point(12, 442);
            this.EnterMessageTextBox.Name = "EnterMessageTextBox";
            this.EnterMessageTextBox.Size = new System.Drawing.Size(259, 22);
            this.EnterMessageTextBox.TabIndex = 4;
            this.EnterMessageTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterMessageTextBox_KeyUp);
            // 
            // UsersListOnForm
            // 
            this.UsersListOnForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersListOnForm.FormattingEnabled = true;
            this.UsersListOnForm.Location = new System.Drawing.Point(567, 113);
            this.UsersListOnForm.Name = "UsersListOnForm";
            this.UsersListOnForm.Size = new System.Drawing.Size(156, 157);
            this.UsersListOnForm.TabIndex = 5;
            // 
            // CreateChatButton
            // 
            this.CreateChatButton.Enabled = false;
            this.CreateChatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateChatButton.Location = new System.Drawing.Point(566, 276);
            this.CreateChatButton.Name = "CreateChatButton";
            this.CreateChatButton.Size = new System.Drawing.Size(157, 27);
            this.CreateChatButton.TabIndex = 8;
            this.CreateChatButton.Text = "Создать чат";
            this.CreateChatButton.UseVisualStyleBackColor = true;
            this.CreateChatButton.Click += new System.EventHandler(this.CreateChatButton_Click);
            // 
            // ChatListTab
            // 
            this.ChatListTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatListTab.Location = new System.Drawing.Point(277, 113);
            this.ChatListTab.Name = "ChatListTab";
            this.ChatListTab.SelectedIndex = 0;
            this.ChatListTab.Size = new System.Drawing.Size(284, 323);
            this.ChatListTab.TabIndex = 9;
            this.ChatListTab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.ChatListTab_Selecting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Общий чат";
            // 
            // EnterChatMessageTextBox
            // 
            this.EnterChatMessageTextBox.Enabled = false;
            this.EnterChatMessageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterChatMessageTextBox.Location = new System.Drawing.Point(277, 442);
            this.EnterChatMessageTextBox.Name = "EnterChatMessageTextBox";
            this.EnterChatMessageTextBox.Size = new System.Drawing.Size(284, 22);
            this.EnterChatMessageTextBox.TabIndex = 11;
            this.EnterChatMessageTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterChatMessageTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(274, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Групповые чаты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Введите IP";
            // 
            // InputIP
            // 
            this.InputIP.Location = new System.Drawing.Point(6, 37);
            this.InputIP.Name = "InputIP";
            this.InputIP.Size = new System.Drawing.Size(151, 22);
            this.InputIP.TabIndex = 2;
            this.InputIP.Text = "127.0.0.1";
            // 
            // InputPort
            // 
            this.InputPort.Location = new System.Drawing.Point(163, 37);
            this.InputPort.Name = "InputPort";
            this.InputPort.Size = new System.Drawing.Size(104, 22);
            this.InputPort.TabIndex = 14;
            this.InputPort.Text = "25565";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(162, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Введите порт";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ConnectToServerButton);
            this.groupBox1.Controls.Add(this.InputPort);
            this.groupBox1.Controls.Add(this.InputIP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 73);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogInButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.InputName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(413, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 73);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // LogInButton
            // 
            this.LogInButton.Enabled = false;
            this.LogInButton.Location = new System.Drawing.Point(174, 38);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(130, 23);
            this.LogInButton.TabIndex = 16;
            this.LogInButton.Text = "Авторизоваться";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Введите имя";
            // 
            // InputName
            // 
            this.InputName.Location = new System.Drawing.Point(9, 39);
            this.InputName.Name = "InputName";
            this.InputName.Size = new System.Drawing.Size(159, 22);
            this.InputName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(564, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Список пользователей";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SendFileButton);
            this.groupBox3.Controls.Add(this.PrivateChatRadioButton);
            this.groupBox3.Controls.Add(this.AllChatRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(568, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 126);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // SendFileButton
            // 
            this.SendFileButton.Enabled = false;
            this.SendFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendFileButton.Location = new System.Drawing.Point(6, 84);
            this.SendFileButton.Name = "SendFileButton";
            this.SendFileButton.Size = new System.Drawing.Size(143, 36);
            this.SendFileButton.TabIndex = 2;
            this.SendFileButton.Text = "Отправить файл";
            this.SendFileButton.UseVisualStyleBackColor = true;
            this.SendFileButton.Click += new System.EventHandler(this.SendFileButton_Click);
            // 
            // PrivateChatRadioButton
            // 
            this.PrivateChatRadioButton.AutoSize = true;
            this.PrivateChatRadioButton.Enabled = false;
            this.PrivateChatRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrivateChatRadioButton.Location = new System.Drawing.Point(19, 42);
            this.PrivateChatRadioButton.Name = "PrivateChatRadioButton";
            this.PrivateChatRadioButton.Size = new System.Drawing.Size(107, 20);
            this.PrivateChatRadioButton.TabIndex = 1;
            this.PrivateChatRadioButton.Text = "Частный чат";
            this.PrivateChatRadioButton.UseVisualStyleBackColor = true;
            // 
            // AllChatRadioButton
            // 
            this.AllChatRadioButton.AutoSize = true;
            this.AllChatRadioButton.Checked = true;
            this.AllChatRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllChatRadioButton.Location = new System.Drawing.Point(19, 16);
            this.AllChatRadioButton.Name = "AllChatRadioButton";
            this.AllChatRadioButton.Size = new System.Drawing.Size(94, 20);
            this.AllChatRadioButton.TabIndex = 0;
            this.AllChatRadioButton.TabStop = true;
            this.AllChatRadioButton.Text = "Общий чат";
            this.AllChatRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 476);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnterChatMessageTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatListTab);
            this.Controls.Add(this.CreateChatButton);
            this.Controls.Add(this.UsersListOnForm);
            this.Controls.Add(this.EnterMessageTextBox);
            this.Controls.Add(this.ChatTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectToServerButton;
        private System.Windows.Forms.RichTextBox ChatTextBox;
        private System.Windows.Forms.TextBox EnterMessageTextBox;
        private System.Windows.Forms.CheckedListBox UsersListOnForm;
        private System.Windows.Forms.Button CreateChatButton;
        private System.Windows.Forms.TabControl ChatListTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnterChatMessageTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputIP;
        private System.Windows.Forms.TextBox InputPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox InputName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SendFileButton;
        private System.Windows.Forms.RadioButton PrivateChatRadioButton;
        private System.Windows.Forms.RadioButton AllChatRadioButton;
    }
}

