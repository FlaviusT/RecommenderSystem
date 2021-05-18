namespace RecommenderSystem
{
    partial class Interface
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
            this._dataCleanerButton = new System.Windows.Forms.Button();
            this._titlesFileTextbox = new System.Windows.Forms.TextBox();
            this._directorsFileTextbox = new System.Windows.Forms.TextBox();
            this._titleRatingsTextbox = new System.Windows.Forms.TextBox();
            this._crewNamesTextbox = new System.Windows.Forms.TextBox();
            this._titlesFileLabel = new System.Windows.Forms.Label();
            this._directorsFileLabel = new System.Windows.Forms.Label();
            this._titleRatingsFileLabel = new System.Windows.Forms.Label();
            this._crewNamesFileLabel = new System.Windows.Forms.Label();
            this._castFileLabel = new System.Windows.Forms.Label();
            this._castNamesTextbox = new System.Windows.Forms.TextBox();
            this._outputFolderLabel = new System.Windows.Forms.Label();
            this._outputFolderTextbox = new System.Windows.Forms.TextBox();
            this._inputFilesGroup = new System.Windows.Forms.GroupBox();
            this._numberOfUsersTextbox = new System.Windows.Forms.TextBox();
            this._userNumberLabel = new System.Windows.Forms.Label();
            this._chooseCastButton = new System.Windows.Forms.Button();
            this._choseCrewButton = new System.Windows.Forms.Button();
            this._chooseRatingsButton = new System.Windows.Forms.Button();
            this._chooseDirectorsButton = new System.Windows.Forms.Button();
            this._choseTitlesButton = new System.Windows.Forms.Button();
            this._chooseOutFolderButton = new System.Windows.Forms.Button();
            this._acceptedYearsLabel = new System.Windows.Forms.Label();
            this._movieYearsRangeStart = new System.Windows.Forms.TextBox();
            this._movieYearsRangeEnd = new System.Windows.Forms.TextBox();
            this._simpleLineLabel = new System.Windows.Forms.Label();
            this._exitButton = new System.Windows.Forms.Button();
            this._inputFilesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataCleanerButton
            // 
            this._dataCleanerButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._dataCleanerButton.Location = new System.Drawing.Point(187, 387);
            this._dataCleanerButton.Name = "_dataCleanerButton";
            this._dataCleanerButton.Size = new System.Drawing.Size(115, 32);
            this._dataCleanerButton.TabIndex = 0;
            this._dataCleanerButton.Text = "Clean data";
            this._dataCleanerButton.UseVisualStyleBackColor = true;
            this._dataCleanerButton.Click += new System.EventHandler(this._dataCleanerButton_Click);
            // 
            // _titlesFileTextbox
            // 
            this._titlesFileTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._titlesFileTextbox.Location = new System.Drawing.Point(149, 31);
            this._titlesFileTextbox.Name = "_titlesFileTextbox";
            this._titlesFileTextbox.Size = new System.Drawing.Size(327, 22);
            this._titlesFileTextbox.TabIndex = 1;
            // 
            // _directorsFileTextbox
            // 
            this._directorsFileTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._directorsFileTextbox.Location = new System.Drawing.Point(149, 71);
            this._directorsFileTextbox.Name = "_directorsFileTextbox";
            this._directorsFileTextbox.Size = new System.Drawing.Size(327, 22);
            this._directorsFileTextbox.TabIndex = 2;
            // 
            // _titleRatingsTextbox
            // 
            this._titleRatingsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._titleRatingsTextbox.Location = new System.Drawing.Point(149, 111);
            this._titleRatingsTextbox.Name = "_titleRatingsTextbox";
            this._titleRatingsTextbox.Size = new System.Drawing.Size(327, 22);
            this._titleRatingsTextbox.TabIndex = 3;
            // 
            // _crewNamesTextbox
            // 
            this._crewNamesTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._crewNamesTextbox.Location = new System.Drawing.Point(149, 151);
            this._crewNamesTextbox.Name = "_crewNamesTextbox";
            this._crewNamesTextbox.Size = new System.Drawing.Size(327, 22);
            this._crewNamesTextbox.TabIndex = 4;
            // 
            // _titlesFileLabel
            // 
            this._titlesFileLabel.AutoSize = true;
            this._titlesFileLabel.Location = new System.Drawing.Point(4, 36);
            this._titlesFileLabel.Name = "_titlesFileLabel";
            this._titlesFileLabel.Size = new System.Drawing.Size(96, 17);
            this._titlesFileLabel.TabIndex = 9;
            this._titlesFileLabel.Text = "Titles file path";
            // 
            // _directorsFileLabel
            // 
            this._directorsFileLabel.AutoSize = true;
            this._directorsFileLabel.Location = new System.Drawing.Point(4, 76);
            this._directorsFileLabel.Name = "_directorsFileLabel";
            this._directorsFileLabel.Size = new System.Drawing.Size(119, 17);
            this._directorsFileLabel.TabIndex = 10;
            this._directorsFileLabel.Text = "Directors file path";
            // 
            // _titleRatingsFileLabel
            // 
            this._titleRatingsFileLabel.AutoSize = true;
            this._titleRatingsFileLabel.Location = new System.Drawing.Point(4, 116);
            this._titleRatingsFileLabel.Name = "_titleRatingsFileLabel";
            this._titleRatingsFileLabel.Size = new System.Drawing.Size(139, 17);
            this._titleRatingsFileLabel.TabIndex = 11;
            this._titleRatingsFileLabel.Text = "Title ratings fiile path";
            // 
            // _crewNamesFileLabel
            // 
            this._crewNamesFileLabel.AutoSize = true;
            this._crewNamesFileLabel.Location = new System.Drawing.Point(4, 156);
            this._crewNamesFileLabel.Name = "_crewNamesFileLabel";
            this._crewNamesFileLabel.Size = new System.Drawing.Size(139, 17);
            this._crewNamesFileLabel.TabIndex = 12;
            this._crewNamesFileLabel.Text = "Crew names file path";
            // 
            // _castFileLabel
            // 
            this._castFileLabel.AutoSize = true;
            this._castFileLabel.Location = new System.Drawing.Point(4, 196);
            this._castFileLabel.Name = "_castFileLabel";
            this._castFileLabel.Size = new System.Drawing.Size(90, 17);
            this._castFileLabel.TabIndex = 13;
            this._castFileLabel.Text = "Cast file path";
            // 
            // _castNamesTextbox
            // 
            this._castNamesTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._castNamesTextbox.Location = new System.Drawing.Point(149, 191);
            this._castNamesTextbox.Name = "_castNamesTextbox";
            this._castNamesTextbox.Size = new System.Drawing.Size(327, 22);
            this._castNamesTextbox.TabIndex = 14;
            // 
            // _outputFolderLabel
            // 
            this._outputFolderLabel.AutoSize = true;
            this._outputFolderLabel.Location = new System.Drawing.Point(27, 340);
            this._outputFolderLabel.Name = "_outputFolderLabel";
            this._outputFolderLabel.Size = new System.Drawing.Size(91, 17);
            this._outputFolderLabel.TabIndex = 15;
            this._outputFolderLabel.Text = "Output folder";
            // 
            // _outputFolderTextbox
            // 
            this._outputFolderTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._outputFolderTextbox.Location = new System.Drawing.Point(172, 335);
            this._outputFolderTextbox.Name = "_outputFolderTextbox";
            this._outputFolderTextbox.Size = new System.Drawing.Size(327, 22);
            this._outputFolderTextbox.TabIndex = 16;
            // 
            // _inputFilesGroup
            // 
            this._inputFilesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._inputFilesGroup.Controls.Add(this._simpleLineLabel);
            this._inputFilesGroup.Controls.Add(this._movieYearsRangeEnd);
            this._inputFilesGroup.Controls.Add(this._movieYearsRangeStart);
            this._inputFilesGroup.Controls.Add(this._acceptedYearsLabel);
            this._inputFilesGroup.Controls.Add(this._numberOfUsersTextbox);
            this._inputFilesGroup.Controls.Add(this._userNumberLabel);
            this._inputFilesGroup.Controls.Add(this._chooseCastButton);
            this._inputFilesGroup.Controls.Add(this._choseCrewButton);
            this._inputFilesGroup.Controls.Add(this._chooseRatingsButton);
            this._inputFilesGroup.Controls.Add(this._chooseDirectorsButton);
            this._inputFilesGroup.Controls.Add(this._choseTitlesButton);
            this._inputFilesGroup.Controls.Add(this._castNamesTextbox);
            this._inputFilesGroup.Controls.Add(this._castFileLabel);
            this._inputFilesGroup.Controls.Add(this._crewNamesFileLabel);
            this._inputFilesGroup.Controls.Add(this._titleRatingsFileLabel);
            this._inputFilesGroup.Controls.Add(this._directorsFileLabel);
            this._inputFilesGroup.Controls.Add(this._titlesFileLabel);
            this._inputFilesGroup.Controls.Add(this._crewNamesTextbox);
            this._inputFilesGroup.Controls.Add(this._titleRatingsTextbox);
            this._inputFilesGroup.Controls.Add(this._directorsFileTextbox);
            this._inputFilesGroup.Controls.Add(this._titlesFileTextbox);
            this._inputFilesGroup.Location = new System.Drawing.Point(23, 12);
            this._inputFilesGroup.Name = "_inputFilesGroup";
            this._inputFilesGroup.Size = new System.Drawing.Size(598, 278);
            this._inputFilesGroup.TabIndex = 17;
            this._inputFilesGroup.TabStop = false;
            this._inputFilesGroup.Text = "Input files";
            // 
            // _numberOfUsersTextbox
            // 
            this._numberOfUsersTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._numberOfUsersTextbox.Location = new System.Drawing.Point(149, 236);
            this._numberOfUsersTextbox.Name = "_numberOfUsersTextbox";
            this._numberOfUsersTextbox.Size = new System.Drawing.Size(100, 22);
            this._numberOfUsersTextbox.TabIndex = 21;
            // 
            // _userNumberLabel
            // 
            this._userNumberLabel.AutoSize = true;
            this._userNumberLabel.Location = new System.Drawing.Point(4, 236);
            this._userNumberLabel.Name = "_userNumberLabel";
            this._userNumberLabel.Size = new System.Drawing.Size(113, 17);
            this._userNumberLabel.TabIndex = 20;
            this._userNumberLabel.Text = "Number of users";
            // 
            // _chooseCastButton
            // 
            this._chooseCastButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseCastButton.Location = new System.Drawing.Point(490, 185);
            this._chooseCastButton.Name = "_chooseCastButton";
            this._chooseCastButton.Size = new System.Drawing.Size(98, 30);
            this._chooseCastButton.TabIndex = 19;
            this._chooseCastButton.Text = "Browse files";
            this._chooseCastButton.UseVisualStyleBackColor = true;
            this._chooseCastButton.Click += new System.EventHandler(this._chooseCastButton_Click);
            // 
            // _choseCrewButton
            // 
            this._choseCrewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._choseCrewButton.Location = new System.Drawing.Point(490, 145);
            this._choseCrewButton.Name = "_choseCrewButton";
            this._choseCrewButton.Size = new System.Drawing.Size(98, 30);
            this._choseCrewButton.TabIndex = 18;
            this._choseCrewButton.Text = "Browse files";
            this._choseCrewButton.UseVisualStyleBackColor = true;
            this._choseCrewButton.Click += new System.EventHandler(this._choseCrewButton_Click);
            // 
            // _chooseRatingsButton
            // 
            this._chooseRatingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseRatingsButton.Location = new System.Drawing.Point(490, 105);
            this._chooseRatingsButton.Name = "_chooseRatingsButton";
            this._chooseRatingsButton.Size = new System.Drawing.Size(98, 30);
            this._chooseRatingsButton.TabIndex = 17;
            this._chooseRatingsButton.Text = "Browse files";
            this._chooseRatingsButton.UseVisualStyleBackColor = true;
            this._chooseRatingsButton.Click += new System.EventHandler(this._chooseRatingsButton_Click);
            // 
            // _chooseDirectorsButton
            // 
            this._chooseDirectorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseDirectorsButton.Location = new System.Drawing.Point(490, 65);
            this._chooseDirectorsButton.Name = "_chooseDirectorsButton";
            this._chooseDirectorsButton.Size = new System.Drawing.Size(98, 30);
            this._chooseDirectorsButton.TabIndex = 16;
            this._chooseDirectorsButton.Text = "Browse files";
            this._chooseDirectorsButton.UseVisualStyleBackColor = true;
            this._chooseDirectorsButton.Click += new System.EventHandler(this._chooseDirectorsButton_Click);
            // 
            // _choseTitlesButton
            // 
            this._choseTitlesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._choseTitlesButton.Location = new System.Drawing.Point(490, 25);
            this._choseTitlesButton.Name = "_choseTitlesButton";
            this._choseTitlesButton.Size = new System.Drawing.Size(98, 30);
            this._choseTitlesButton.TabIndex = 15;
            this._choseTitlesButton.Text = "Browse files";
            this._choseTitlesButton.UseVisualStyleBackColor = true;
            this._choseTitlesButton.Click += new System.EventHandler(this._choseTitlesButton_Click);
            // 
            // _chooseOutFolderButton
            // 
            this._chooseOutFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseOutFolderButton.Location = new System.Drawing.Point(513, 329);
            this._chooseOutFolderButton.Name = "_chooseOutFolderButton";
            this._chooseOutFolderButton.Size = new System.Drawing.Size(98, 30);
            this._chooseOutFolderButton.TabIndex = 20;
            this._chooseOutFolderButton.Text = "Browse files";
            this._chooseOutFolderButton.UseVisualStyleBackColor = true;
            this._chooseOutFolderButton.Click += new System.EventHandler(this._chooseOutFolderButton_Click);
            // 
            // _acceptedYearsLabel
            // 
            this._acceptedYearsLabel.AutoSize = true;
            this._acceptedYearsLabel.Location = new System.Drawing.Point(261, 236);
            this._acceptedYearsLabel.Name = "_acceptedYearsLabel";
            this._acceptedYearsLabel.Size = new System.Drawing.Size(132, 17);
            this._acceptedYearsLabel.TabIndex = 22;
            this._acceptedYearsLabel.Text = "Movies years range";
            // 
            // _movieYearsRangeStart
            // 
            this._movieYearsRangeStart.Location = new System.Drawing.Point(399, 236);
            this._movieYearsRangeStart.Name = "_movieYearsRangeStart";
            this._movieYearsRangeStart.Size = new System.Drawing.Size(57, 22);
            this._movieYearsRangeStart.TabIndex = 23;
            // 
            // _movieYearsRangeEnd
            // 
            this._movieYearsRangeEnd.Location = new System.Drawing.Point(480, 236);
            this._movieYearsRangeEnd.Name = "_movieYearsRangeEnd";
            this._movieYearsRangeEnd.Size = new System.Drawing.Size(57, 22);
            this._movieYearsRangeEnd.TabIndex = 24;
            // 
            // _simpleLineLabel
            // 
            this._simpleLineLabel.AutoSize = true;
            this._simpleLineLabel.Location = new System.Drawing.Point(462, 238);
            this._simpleLineLabel.Name = "_simpleLineLabel";
            this._simpleLineLabel.Size = new System.Drawing.Size(13, 17);
            this._simpleLineLabel.TabIndex = 25;
            this._simpleLineLabel.Text = "-";
            // 
            // _exitButton
            // 
            this._exitButton.Location = new System.Drawing.Point(364, 387);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(115, 32);
            this._exitButton.TabIndex = 21;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 446);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._chooseOutFolderButton);
            this.Controls.Add(this._inputFilesGroup);
            this.Controls.Add(this._outputFolderTextbox);
            this.Controls.Add(this._outputFolderLabel);
            this.Controls.Add(this._dataCleanerButton);
            this.Name = "Interface";
            this.ShowIcon = false;
            this.Text = "Recommender system";
            this.Activated += new System.EventHandler(this.Interface_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Interface_FormClosing);
            this.Load += new System.EventHandler(this.Interface_Load);
            this._inputFilesGroup.ResumeLayout(false);
            this._inputFilesGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _dataCleanerButton;
        private System.Windows.Forms.TextBox _titlesFileTextbox;
        private System.Windows.Forms.TextBox _directorsFileTextbox;
        private System.Windows.Forms.TextBox _titleRatingsTextbox;
        private System.Windows.Forms.TextBox _crewNamesTextbox;
        private System.Windows.Forms.Label _titlesFileLabel;
        private System.Windows.Forms.Label _directorsFileLabel;
        private System.Windows.Forms.Label _titleRatingsFileLabel;
        private System.Windows.Forms.Label _crewNamesFileLabel;
        private System.Windows.Forms.Label _castFileLabel;
        private System.Windows.Forms.TextBox _castNamesTextbox;
        private System.Windows.Forms.Label _outputFolderLabel;
        private System.Windows.Forms.TextBox _outputFolderTextbox;
        private System.Windows.Forms.GroupBox _inputFilesGroup;
        private System.Windows.Forms.Button _chooseCastButton;
        private System.Windows.Forms.Button _choseCrewButton;
        private System.Windows.Forms.Button _chooseRatingsButton;
        private System.Windows.Forms.Button _chooseDirectorsButton;
        private System.Windows.Forms.Button _choseTitlesButton;
        private System.Windows.Forms.Button _chooseOutFolderButton;
        private System.Windows.Forms.TextBox _numberOfUsersTextbox;
        private System.Windows.Forms.Label _userNumberLabel;
        private System.Windows.Forms.Label _simpleLineLabel;
        private System.Windows.Forms.TextBox _movieYearsRangeEnd;
        private System.Windows.Forms.TextBox _movieYearsRangeStart;
        private System.Windows.Forms.Label _acceptedYearsLabel;
        private System.Windows.Forms.Button _exitButton;
    }
}

