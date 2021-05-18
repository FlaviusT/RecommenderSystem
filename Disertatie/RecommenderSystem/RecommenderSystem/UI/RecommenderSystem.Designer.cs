namespace RecommenderSystem
{
    partial class RecommenderSystem
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
            this._simpleLineLabel = new System.Windows.Forms.Label();
            this._movieYearsRangeEnd = new System.Windows.Forms.TextBox();
            this._movieYearsRangeStart = new System.Windows.Forms.TextBox();
            this._acceptedYearsLabel = new System.Windows.Forms.Label();
            this._numberOfUsersTextbox = new System.Windows.Forms.TextBox();
            this._userNumberLabel = new System.Windows.Forms.Label();
            this._chooseCastButton = new System.Windows.Forms.Button();
            this._choseCrewButton = new System.Windows.Forms.Button();
            this._chooseRatingsButton = new System.Windows.Forms.Button();
            this._chooseDirectorsButton = new System.Windows.Forms.Button();
            this._choseTitlesButton = new System.Windows.Forms.Button();
            this._chooseOutFolderButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this._outputGroupbox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._algorithmsGroupbox = new System.Windows.Forms.GroupBox();
            this._hybridAlgorithms = new System.Windows.Forms.GroupBox();
            this._memoryBasedAlgorithmsGroupbox = new System.Windows.Forms.GroupBox();
            this._modelBasedAlgorithmsGroupbox = new System.Windows.Forms.GroupBox();
            this._viewStatisticsButton = new System.Windows.Forms.Button();
            this._startAnalysisButton = new System.Windows.Forms.Button();
            this._chooseUserRatingsPathButton = new System.Windows.Forms.Button();
            this._chooseUsersPathButton = new System.Windows.Forms.Button();
            this._chooseMoviesPathButton = new System.Windows.Forms.Button();
            this._userRatingsTextbox = new System.Windows.Forms.TextBox();
            this._usersTextbox = new System.Windows.Forms.TextBox();
            this._moviesTextBox = new System.Windows.Forms.TextBox();
            this._userRatingsLabel = new System.Windows.Forms.Label();
            this._usersLabel = new System.Windows.Forms.Label();
            this._moviesLabel = new System.Windows.Forms.Label();
            this._knnCheckbox = new System.Windows.Forms.CheckBox();
            this._inputFilesGroup.SuspendLayout();
            this._outputGroupbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this._algorithmsGroupbox.SuspendLayout();
            this._modelBasedAlgorithmsGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataCleanerButton
            // 
            this._dataCleanerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dataCleanerButton.Location = new System.Drawing.Point(259, 496);
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
            this._titlesFileTextbox.Size = new System.Drawing.Size(351, 22);
            this._titlesFileTextbox.TabIndex = 1;
            // 
            // _directorsFileTextbox
            // 
            this._directorsFileTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._directorsFileTextbox.Location = new System.Drawing.Point(149, 71);
            this._directorsFileTextbox.Name = "_directorsFileTextbox";
            this._directorsFileTextbox.Size = new System.Drawing.Size(351, 22);
            this._directorsFileTextbox.TabIndex = 2;
            // 
            // _titleRatingsTextbox
            // 
            this._titleRatingsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._titleRatingsTextbox.Location = new System.Drawing.Point(149, 111);
            this._titleRatingsTextbox.Name = "_titleRatingsTextbox";
            this._titleRatingsTextbox.Size = new System.Drawing.Size(351, 22);
            this._titleRatingsTextbox.TabIndex = 3;
            // 
            // _crewNamesTextbox
            // 
            this._crewNamesTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._crewNamesTextbox.Location = new System.Drawing.Point(149, 151);
            this._crewNamesTextbox.Name = "_crewNamesTextbox";
            this._crewNamesTextbox.Size = new System.Drawing.Size(351, 22);
            this._crewNamesTextbox.TabIndex = 4;
            // 
            // _titlesFileLabel
            // 
            this._titlesFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._titlesFileLabel.AutoSize = true;
            this._titlesFileLabel.Location = new System.Drawing.Point(4, 36);
            this._titlesFileLabel.Name = "_titlesFileLabel";
            this._titlesFileLabel.Size = new System.Drawing.Size(96, 17);
            this._titlesFileLabel.TabIndex = 9;
            this._titlesFileLabel.Text = "Titles file path";
            // 
            // _directorsFileLabel
            // 
            this._directorsFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._directorsFileLabel.AutoSize = true;
            this._directorsFileLabel.Location = new System.Drawing.Point(4, 76);
            this._directorsFileLabel.Name = "_directorsFileLabel";
            this._directorsFileLabel.Size = new System.Drawing.Size(119, 17);
            this._directorsFileLabel.TabIndex = 10;
            this._directorsFileLabel.Text = "Directors file path";
            // 
            // _titleRatingsFileLabel
            // 
            this._titleRatingsFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._titleRatingsFileLabel.AutoSize = true;
            this._titleRatingsFileLabel.Location = new System.Drawing.Point(4, 116);
            this._titleRatingsFileLabel.Name = "_titleRatingsFileLabel";
            this._titleRatingsFileLabel.Size = new System.Drawing.Size(139, 17);
            this._titleRatingsFileLabel.TabIndex = 11;
            this._titleRatingsFileLabel.Text = "Title ratings fiile path";
            // 
            // _crewNamesFileLabel
            // 
            this._crewNamesFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._crewNamesFileLabel.AutoSize = true;
            this._crewNamesFileLabel.Location = new System.Drawing.Point(4, 156);
            this._crewNamesFileLabel.Name = "_crewNamesFileLabel";
            this._crewNamesFileLabel.Size = new System.Drawing.Size(139, 17);
            this._crewNamesFileLabel.TabIndex = 12;
            this._crewNamesFileLabel.Text = "Crew names file path";
            // 
            // _castFileLabel
            // 
            this._castFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this._castNamesTextbox.Size = new System.Drawing.Size(351, 22);
            this._castNamesTextbox.TabIndex = 14;
            // 
            // _outputFolderLabel
            // 
            this._outputFolderLabel.AutoSize = true;
            this._outputFolderLabel.Location = new System.Drawing.Point(7, 47);
            this._outputFolderLabel.Name = "_outputFolderLabel";
            this._outputFolderLabel.Size = new System.Drawing.Size(91, 17);
            this._outputFolderLabel.TabIndex = 15;
            this._outputFolderLabel.Text = "Output folder";
            // 
            // _outputFolderTextbox
            // 
            this._outputFolderTextbox.Location = new System.Drawing.Point(152, 42);
            this._outputFolderTextbox.Name = "_outputFolderTextbox";
            this._outputFolderTextbox.Size = new System.Drawing.Size(348, 22);
            this._outputFolderTextbox.TabIndex = 16;
            // 
            // _inputFilesGroup
            // 
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
            this._inputFilesGroup.Location = new System.Drawing.Point(16, 30);
            this._inputFilesGroup.Name = "_inputFilesGroup";
            this._inputFilesGroup.Size = new System.Drawing.Size(622, 278);
            this._inputFilesGroup.TabIndex = 17;
            this._inputFilesGroup.TabStop = false;
            this._inputFilesGroup.Text = "Input files";
            // 
            // _simpleLineLabel
            // 
            this._simpleLineLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._simpleLineLabel.AutoSize = true;
            this._simpleLineLabel.Location = new System.Drawing.Point(450, 238);
            this._simpleLineLabel.Name = "_simpleLineLabel";
            this._simpleLineLabel.Size = new System.Drawing.Size(13, 17);
            this._simpleLineLabel.TabIndex = 25;
            this._simpleLineLabel.Text = "-";
            // 
            // _movieYearsRangeEnd
            // 
            this._movieYearsRangeEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._movieYearsRangeEnd.Location = new System.Drawing.Point(468, 236);
            this._movieYearsRangeEnd.Name = "_movieYearsRangeEnd";
            this._movieYearsRangeEnd.Size = new System.Drawing.Size(57, 22);
            this._movieYearsRangeEnd.TabIndex = 24;
            // 
            // _movieYearsRangeStart
            // 
            this._movieYearsRangeStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._movieYearsRangeStart.Location = new System.Drawing.Point(387, 236);
            this._movieYearsRangeStart.Name = "_movieYearsRangeStart";
            this._movieYearsRangeStart.Size = new System.Drawing.Size(57, 22);
            this._movieYearsRangeStart.TabIndex = 23;
            // 
            // _acceptedYearsLabel
            // 
            this._acceptedYearsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._acceptedYearsLabel.AutoSize = true;
            this._acceptedYearsLabel.Location = new System.Drawing.Point(249, 236);
            this._acceptedYearsLabel.Name = "_acceptedYearsLabel";
            this._acceptedYearsLabel.Size = new System.Drawing.Size(132, 17);
            this._acceptedYearsLabel.TabIndex = 22;
            this._acceptedYearsLabel.Text = "Movies years range";
            // 
            // _numberOfUsersTextbox
            // 
            this._numberOfUsersTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._numberOfUsersTextbox.Location = new System.Drawing.Point(149, 236);
            this._numberOfUsersTextbox.Name = "_numberOfUsersTextbox";
            this._numberOfUsersTextbox.Size = new System.Drawing.Size(82, 22);
            this._numberOfUsersTextbox.TabIndex = 21;
            // 
            // _userNumberLabel
            // 
            this._userNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._userNumberLabel.AutoSize = true;
            this._userNumberLabel.Location = new System.Drawing.Point(4, 236);
            this._userNumberLabel.Name = "_userNumberLabel";
            this._userNumberLabel.Size = new System.Drawing.Size(113, 17);
            this._userNumberLabel.TabIndex = 20;
            this._userNumberLabel.Text = "Number of users";
            // 
            // _chooseCastButton
            // 
            this._chooseCastButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._chooseCastButton.Location = new System.Drawing.Point(512, 185);
            this._chooseCastButton.Name = "_chooseCastButton";
            this._chooseCastButton.Size = new System.Drawing.Size(98, 30);
            this._chooseCastButton.TabIndex = 19;
            this._chooseCastButton.Text = "Browse files";
            this._chooseCastButton.UseVisualStyleBackColor = true;
            this._chooseCastButton.Click += new System.EventHandler(this._chooseCastButton_Click);
            // 
            // _choseCrewButton
            // 
            this._choseCrewButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._choseCrewButton.Location = new System.Drawing.Point(512, 145);
            this._choseCrewButton.Name = "_choseCrewButton";
            this._choseCrewButton.Size = new System.Drawing.Size(98, 30);
            this._choseCrewButton.TabIndex = 18;
            this._choseCrewButton.Text = "Browse files";
            this._choseCrewButton.UseVisualStyleBackColor = true;
            this._choseCrewButton.Click += new System.EventHandler(this._choseCrewButton_Click);
            // 
            // _chooseRatingsButton
            // 
            this._chooseRatingsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._chooseRatingsButton.Location = new System.Drawing.Point(512, 105);
            this._chooseRatingsButton.Name = "_chooseRatingsButton";
            this._chooseRatingsButton.Size = new System.Drawing.Size(98, 30);
            this._chooseRatingsButton.TabIndex = 17;
            this._chooseRatingsButton.Text = "Browse files";
            this._chooseRatingsButton.UseVisualStyleBackColor = true;
            this._chooseRatingsButton.Click += new System.EventHandler(this._chooseRatingsButton_Click);
            // 
            // _chooseDirectorsButton
            // 
            this._chooseDirectorsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._chooseDirectorsButton.Location = new System.Drawing.Point(512, 65);
            this._chooseDirectorsButton.Name = "_chooseDirectorsButton";
            this._chooseDirectorsButton.Size = new System.Drawing.Size(98, 30);
            this._chooseDirectorsButton.TabIndex = 16;
            this._chooseDirectorsButton.Text = "Browse files";
            this._chooseDirectorsButton.UseVisualStyleBackColor = true;
            this._chooseDirectorsButton.Click += new System.EventHandler(this._chooseDirectorsButton_Click);
            // 
            // _choseTitlesButton
            // 
            this._choseTitlesButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._choseTitlesButton.Location = new System.Drawing.Point(512, 25);
            this._choseTitlesButton.Name = "_choseTitlesButton";
            this._choseTitlesButton.Size = new System.Drawing.Size(98, 30);
            this._choseTitlesButton.TabIndex = 15;
            this._choseTitlesButton.Text = "Browse files";
            this._choseTitlesButton.UseVisualStyleBackColor = true;
            this._choseTitlesButton.Click += new System.EventHandler(this._choseTitlesButton_Click);
            // 
            // _chooseOutFolderButton
            // 
            this._chooseOutFolderButton.Location = new System.Drawing.Point(512, 34);
            this._chooseOutFolderButton.Name = "_chooseOutFolderButton";
            this._chooseOutFolderButton.Size = new System.Drawing.Size(98, 30);
            this._chooseOutFolderButton.TabIndex = 20;
            this._chooseOutFolderButton.Text = "Browse files";
            this._chooseOutFolderButton.UseVisualStyleBackColor = true;
            this._chooseOutFolderButton.Click += new System.EventHandler(this._chooseOutFolderButton_Click);
            // 
            // _exitButton
            // 
            this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._exitButton.Location = new System.Drawing.Point(1029, 566);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(115, 32);
            this._exitButton.TabIndex = 21;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
            // 
            // _outputGroupbox
            // 
            this._outputGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._outputGroupbox.Controls.Add(this._chooseOutFolderButton);
            this._outputGroupbox.Controls.Add(this._outputFolderLabel);
            this._outputGroupbox.Controls.Add(this._outputFolderTextbox);
            this._outputGroupbox.Location = new System.Drawing.Point(16, 339);
            this._outputGroupbox.Name = "_outputGroupbox";
            this._outputGroupbox.Size = new System.Drawing.Size(622, 100);
            this._outputGroupbox.TabIndex = 22;
            this._outputGroupbox.TabStop = false;
            this._outputGroupbox.Text = "Output";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this._inputFilesGroup);
            this.groupBox1.Controls.Add(this._outputGroupbox);
            this.groupBox1.Controls.Add(this._dataCleanerButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 558);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataCleaner";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._algorithmsGroupbox);
            this.groupBox2.Controls.Add(this._viewStatisticsButton);
            this.groupBox2.Controls.Add(this._startAnalysisButton);
            this.groupBox2.Controls.Add(this._chooseUserRatingsPathButton);
            this.groupBox2.Controls.Add(this._chooseUsersPathButton);
            this.groupBox2.Controls.Add(this._chooseMoviesPathButton);
            this.groupBox2.Controls.Add(this._userRatingsTextbox);
            this.groupBox2.Controls.Add(this._usersTextbox);
            this.groupBox2.Controls.Add(this._moviesTextBox);
            this.groupBox2.Controls.Add(this._userRatingsLabel);
            this.groupBox2.Controls.Add(this._usersLabel);
            this.groupBox2.Controls.Add(this._moviesLabel);
            this.groupBox2.Location = new System.Drawing.Point(666, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 541);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // _algorithmsGroupbox
            // 
            this._algorithmsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._algorithmsGroupbox.Controls.Add(this._hybridAlgorithms);
            this._algorithmsGroupbox.Controls.Add(this._memoryBasedAlgorithmsGroupbox);
            this._algorithmsGroupbox.Controls.Add(this._modelBasedAlgorithmsGroupbox);
            this._algorithmsGroupbox.Location = new System.Drawing.Point(18, 158);
            this._algorithmsGroupbox.Name = "_algorithmsGroupbox";
            this._algorithmsGroupbox.Size = new System.Drawing.Size(488, 316);
            this._algorithmsGroupbox.TabIndex = 19;
            this._algorithmsGroupbox.TabStop = false;
            this._algorithmsGroupbox.Text = "Algorithms";
            // 
            // _hybridAlgorithms
            // 
            this._hybridAlgorithms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._hybridAlgorithms.Location = new System.Drawing.Point(6, 229);
            this._hybridAlgorithms.Name = "_hybridAlgorithms";
            this._hybridAlgorithms.Size = new System.Drawing.Size(466, 66);
            this._hybridAlgorithms.TabIndex = 21;
            this._hybridAlgorithms.TabStop = false;
            this._hybridAlgorithms.Text = "Hybrid";
            // 
            // _memoryBasedAlgorithmsGroupbox
            // 
            this._memoryBasedAlgorithmsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._memoryBasedAlgorithmsGroupbox.Location = new System.Drawing.Point(6, 139);
            this._memoryBasedAlgorithmsGroupbox.Name = "_memoryBasedAlgorithmsGroupbox";
            this._memoryBasedAlgorithmsGroupbox.Size = new System.Drawing.Size(466, 84);
            this._memoryBasedAlgorithmsGroupbox.TabIndex = 20;
            this._memoryBasedAlgorithmsGroupbox.TabStop = false;
            this._memoryBasedAlgorithmsGroupbox.Text = "Memory based";
            // 
            // _modelBasedAlgorithmsGroupbox
            // 
            this._modelBasedAlgorithmsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._modelBasedAlgorithmsGroupbox.Controls.Add(this._knnCheckbox);
            this._modelBasedAlgorithmsGroupbox.Location = new System.Drawing.Point(5, 28);
            this._modelBasedAlgorithmsGroupbox.Name = "_modelBasedAlgorithmsGroupbox";
            this._modelBasedAlgorithmsGroupbox.Size = new System.Drawing.Size(466, 105);
            this._modelBasedAlgorithmsGroupbox.TabIndex = 19;
            this._modelBasedAlgorithmsGroupbox.TabStop = false;
            this._modelBasedAlgorithmsGroupbox.Text = "Model based";
            // 
            // _viewStatisticsButton
            // 
            this._viewStatisticsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._viewStatisticsButton.Location = new System.Drawing.Point(173, 489);
            this._viewStatisticsButton.Name = "_viewStatisticsButton";
            this._viewStatisticsButton.Size = new System.Drawing.Size(115, 32);
            this._viewStatisticsButton.TabIndex = 10;
            this._viewStatisticsButton.Text = "View statistics";
            this._viewStatisticsButton.UseVisualStyleBackColor = true;
            this._viewStatisticsButton.Click += new System.EventHandler(this._viewStatisticsButton_Click);
            // 
            // _startAnalysisButton
            // 
            this._startAnalysisButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startAnalysisButton.Location = new System.Drawing.Point(24, 489);
            this._startAnalysisButton.Name = "_startAnalysisButton";
            this._startAnalysisButton.Size = new System.Drawing.Size(115, 32);
            this._startAnalysisButton.TabIndex = 9;
            this._startAnalysisButton.Text = "Start analysis";
            this._startAnalysisButton.UseVisualStyleBackColor = true;
            this._startAnalysisButton.Click += new System.EventHandler(this._startAnalysisButton_Click);
            // 
            // _chooseUserRatingsPathButton
            // 
            this._chooseUserRatingsPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseUserRatingsPathButton.Location = new System.Drawing.Point(408, 106);
            this._chooseUserRatingsPathButton.Name = "_chooseUserRatingsPathButton";
            this._chooseUserRatingsPathButton.Size = new System.Drawing.Size(98, 30);
            this._chooseUserRatingsPathButton.TabIndex = 8;
            this._chooseUserRatingsPathButton.Text = "Browse files";
            this._chooseUserRatingsPathButton.UseVisualStyleBackColor = true;
            this._chooseUserRatingsPathButton.Click += new System.EventHandler(this._chooseUserRatingsPathButton_Click);
            // 
            // _chooseUsersPathButton
            // 
            this._chooseUsersPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseUsersPathButton.Location = new System.Drawing.Point(408, 70);
            this._chooseUsersPathButton.Name = "_chooseUsersPathButton";
            this._chooseUsersPathButton.Size = new System.Drawing.Size(98, 30);
            this._chooseUsersPathButton.TabIndex = 7;
            this._chooseUsersPathButton.Text = "Browse files";
            this._chooseUsersPathButton.UseVisualStyleBackColor = true;
            this._chooseUsersPathButton.Click += new System.EventHandler(this._chooseUsersPathButton_Click);
            // 
            // _chooseMoviesPathButton
            // 
            this._chooseMoviesPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseMoviesPathButton.Location = new System.Drawing.Point(408, 34);
            this._chooseMoviesPathButton.Name = "_chooseMoviesPathButton";
            this._chooseMoviesPathButton.Size = new System.Drawing.Size(98, 30);
            this._chooseMoviesPathButton.TabIndex = 6;
            this._chooseMoviesPathButton.Text = "Browse files";
            this._chooseMoviesPathButton.UseVisualStyleBackColor = true;
            this._chooseMoviesPathButton.Click += new System.EventHandler(this._chooseMoviesPathButton_Click);
            // 
            // _userRatingsTextbox
            // 
            this._userRatingsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._userRatingsTextbox.Location = new System.Drawing.Point(125, 110);
            this._userRatingsTextbox.Name = "_userRatingsTextbox";
            this._userRatingsTextbox.Size = new System.Drawing.Size(277, 22);
            this._userRatingsTextbox.TabIndex = 5;
            // 
            // _usersTextbox
            // 
            this._usersTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._usersTextbox.Location = new System.Drawing.Point(125, 75);
            this._usersTextbox.Name = "_usersTextbox";
            this._usersTextbox.Size = new System.Drawing.Size(277, 22);
            this._usersTextbox.TabIndex = 4;
            // 
            // _moviesTextBox
            // 
            this._moviesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._moviesTextBox.Location = new System.Drawing.Point(125, 40);
            this._moviesTextBox.Name = "_moviesTextBox";
            this._moviesTextBox.Size = new System.Drawing.Size(277, 22);
            this._moviesTextBox.TabIndex = 3;
            // 
            // _userRatingsLabel
            // 
            this._userRatingsLabel.AutoSize = true;
            this._userRatingsLabel.Location = new System.Drawing.Point(5, 115);
            this._userRatingsLabel.Name = "_userRatingsLabel";
            this._userRatingsLabel.Size = new System.Drawing.Size(117, 17);
            this._userRatingsLabel.TabIndex = 2;
            this._userRatingsLabel.Text = "User ratings path";
            // 
            // _usersLabel
            // 
            this._usersLabel.AutoSize = true;
            this._usersLabel.Location = new System.Drawing.Point(5, 80);
            this._usersLabel.Name = "_usersLabel";
            this._usersLabel.Size = new System.Drawing.Size(99, 17);
            this._usersLabel.TabIndex = 1;
            this._usersLabel.Text = "Users file path";
            // 
            // _moviesLabel
            // 
            this._moviesLabel.AutoSize = true;
            this._moviesLabel.Location = new System.Drawing.Point(5, 45);
            this._moviesLabel.Name = "_moviesLabel";
            this._moviesLabel.Size = new System.Drawing.Size(106, 17);
            this._moviesLabel.TabIndex = 0;
            this._moviesLabel.Text = "Movies file path";
            // 
            // _knnCheckbox
            // 
            this._knnCheckbox.AutoSize = true;
            this._knnCheckbox.Location = new System.Drawing.Point(18, 28);
            this._knnCheckbox.Name = "_knnCheckbox";
            this._knnCheckbox.Size = new System.Drawing.Size(160, 21);
            this._knnCheckbox.TabIndex = 0;
            this._knnCheckbox.Text = "kNearestNeighbours";
            this._knnCheckbox.UseVisualStyleBackColor = true;
            // 
            // RecommenderSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._exitButton);
            this.MinimumSize = new System.Drawing.Size(1224, 669);
            this.Name = "RecommenderSystem";
            this.ShowIcon = false;
            this.Text = "Recommender system";
            this.Activated += new System.EventHandler(this.RecommenderSystem_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecommenderSystem_FormClosing);
            this.Load += new System.EventHandler(this.RecommenderSystem_Load);
            this._inputFilesGroup.ResumeLayout(false);
            this._inputFilesGroup.PerformLayout();
            this._outputGroupbox.ResumeLayout(false);
            this._outputGroupbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._algorithmsGroupbox.ResumeLayout(false);
            this._modelBasedAlgorithmsGroupbox.ResumeLayout(false);
            this._modelBasedAlgorithmsGroupbox.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox _outputGroupbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _userRatingsTextbox;
        private System.Windows.Forms.TextBox _usersTextbox;
        private System.Windows.Forms.TextBox _moviesTextBox;
        private System.Windows.Forms.Label _userRatingsLabel;
        private System.Windows.Forms.Label _usersLabel;
        private System.Windows.Forms.Label _moviesLabel;
        private System.Windows.Forms.Button _chooseUserRatingsPathButton;
        private System.Windows.Forms.Button _chooseUsersPathButton;
        private System.Windows.Forms.Button _chooseMoviesPathButton;
        private System.Windows.Forms.GroupBox _algorithmsGroupbox;
        private System.Windows.Forms.GroupBox _hybridAlgorithms;
        private System.Windows.Forms.GroupBox _memoryBasedAlgorithmsGroupbox;
        private System.Windows.Forms.GroupBox _modelBasedAlgorithmsGroupbox;
        private System.Windows.Forms.Button _viewStatisticsButton;
        private System.Windows.Forms.Button _startAnalysisButton;
        private System.Windows.Forms.CheckBox _knnCheckbox;
    }
}

