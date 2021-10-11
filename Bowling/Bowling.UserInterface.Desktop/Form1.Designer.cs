
namespace Bowling.UserInterface.Desktop
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.GameNameTextBox = new System.Windows.Forms.TextBox();
            this.GameNameButton = new System.Windows.Forms.Button();
            this.GameNameInputLabel = new System.Windows.Forms.Label();
            this.GameNamePlayerTextBox = new System.Windows.Forms.TextBox();
            this.GameNamePlayerLabel = new System.Windows.Forms.Label();
            this.GameNameAddAnotherPlayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayButton.Location = new System.Drawing.Point(224, 172);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(309, 79);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play!";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.AutoSize = true;
            this.GameNameLabel.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameNameLabel.Location = new System.Drawing.Point(267, 9);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(221, 36);
            this.GameNameLabel.TabIndex = 1;
            this.GameNameLabel.Text = "Setup Your Game!";
            this.GameNameLabel.Visible = false;
            // 
            // GameNameTextBox
            // 
            this.GameNameTextBox.Location = new System.Drawing.Point(267, 48);
            this.GameNameTextBox.Name = "GameNameTextBox";
            this.GameNameTextBox.Size = new System.Drawing.Size(222, 23);
            this.GameNameTextBox.TabIndex = 2;
            this.GameNameTextBox.Visible = false;
            // 
            // GameNameButton
            // 
            this.GameNameButton.Location = new System.Drawing.Point(267, 106);
            this.GameNameButton.Name = "GameNameButton";
            this.GameNameButton.Size = new System.Drawing.Size(222, 30);
            this.GameNameButton.TabIndex = 3;
            this.GameNameButton.Text = "Create";
            this.GameNameButton.UseVisualStyleBackColor = true;
            this.GameNameButton.Visible = false;
            this.GameNameButton.Click += new System.EventHandler(this.GameNameButton_Click);
            // 
            // GameNameInputLabel
            // 
            this.GameNameInputLabel.AutoSize = true;
            this.GameNameInputLabel.Location = new System.Drawing.Point(188, 51);
            this.GameNameInputLabel.Name = "GameNameInputLabel";
            this.GameNameInputLabel.Size = new System.Drawing.Size(76, 15);
            this.GameNameInputLabel.TabIndex = 4;
            this.GameNameInputLabel.Text = "Game Name:";
            this.GameNameInputLabel.Visible = false;
            // 
            // GameNamePlayerTextBox
            // 
            this.GameNamePlayerTextBox.Location = new System.Drawing.Point(267, 77);
            this.GameNamePlayerTextBox.Name = "GameNamePlayerTextBox";
            this.GameNamePlayerTextBox.Size = new System.Drawing.Size(222, 23);
            this.GameNamePlayerTextBox.TabIndex = 5;
            this.GameNamePlayerTextBox.Visible = false;
            // 
            // GameNamePlayerLabel
            // 
            this.GameNamePlayerLabel.AutoSize = true;
            this.GameNamePlayerLabel.Location = new System.Drawing.Point(188, 80);
            this.GameNamePlayerLabel.Name = "GameNamePlayerLabel";
            this.GameNamePlayerLabel.Size = new System.Drawing.Size(77, 15);
            this.GameNamePlayerLabel.TabIndex = 6;
            this.GameNamePlayerLabel.Text = "Player Name:";
            this.GameNamePlayerLabel.Visible = false;
            // 
            // GameNameAddAnotherPlayerButton
            // 
            this.GameNameAddAnotherPlayerButton.Location = new System.Drawing.Point(495, 77);
            this.GameNameAddAnotherPlayerButton.Name = "GameNameAddAnotherPlayerButton";
            this.GameNameAddAnotherPlayerButton.Size = new System.Drawing.Size(83, 23);
            this.GameNameAddAnotherPlayerButton.TabIndex = 7;
            this.GameNameAddAnotherPlayerButton.Text = "Add Another";
            this.GameNameAddAnotherPlayerButton.UseVisualStyleBackColor = true;
            this.GameNameAddAnotherPlayerButton.Visible = false;
            this.GameNameAddAnotherPlayerButton.Click += new System.EventHandler(this.GameNameAddAnotherPlayerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameNameAddAnotherPlayerButton);
            this.Controls.Add(this.GameNamePlayerLabel);
            this.Controls.Add(this.GameNamePlayerTextBox);
            this.Controls.Add(this.GameNameInputLabel);
            this.Controls.Add(this.GameNameButton);
            this.Controls.Add(this.GameNameTextBox);
            this.Controls.Add(this.GameNameLabel);
            this.Controls.Add(this.PlayButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.TextBox GameNameTextBox;
        private System.Windows.Forms.Button GameNameButton;
        private System.Windows.Forms.Label GameNameInputLabel;
        private System.Windows.Forms.TextBox GameNamePlayerTextBox;
        private System.Windows.Forms.Label GameNamePlayerLabel;
        private System.Windows.Forms.Button GameNameAddAnotherPlayerButton;
    }
}

