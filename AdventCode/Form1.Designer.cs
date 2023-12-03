namespace AdventCode
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
            InputForAnswer = new TextBox();
            GetAnswer = new Button();
            answer = new TextBox();
            cbSelection = new ComboBox();
            SuspendLayout();
            // 
            // InputForAnswer
            // 
            InputForAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputForAnswer.Location = new Point(12, 12);
            InputForAnswer.Multiline = true;
            InputForAnswer.Name = "InputForAnswer";
            InputForAnswer.Size = new Size(722, 389);
            InputForAnswer.TabIndex = 0;
            // 
            // GetAnswer
            // 
            GetAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GetAnswer.Location = new Point(659, 407);
            GetAnswer.Name = "GetAnswer";
            GetAnswer.Size = new Size(75, 23);
            GetAnswer.TabIndex = 1;
            GetAnswer.Text = "Answer";
            GetAnswer.UseVisualStyleBackColor = true;
            GetAnswer.Click += button1_Click;
            // 
            // answer
            // 
            answer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            answer.Location = new Point(12, 436);
            answer.Name = "answer";
            answer.Size = new Size(722, 23);
            answer.TabIndex = 2;
            // 
            // cbSelection
            // 
            cbSelection.FlatStyle = FlatStyle.System;
            cbSelection.FormattingEnabled = true;
            cbSelection.Location = new Point(12, 407);
            cbSelection.Name = "cbSelection";
            cbSelection.Size = new Size(641, 23);
            cbSelection.TabIndex = 3;
            cbSelection.SelectedIndexChanged += cbSelection_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 471);
            Controls.Add(cbSelection);
            Controls.Add(answer);
            Controls.Add(GetAnswer);
            Controls.Add(InputForAnswer);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputForAnswer;
        private Button GetAnswer;
        private TextBox answer;
        private ComboBox cbSelection;
    }
}