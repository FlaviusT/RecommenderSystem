using Microsoft.WindowsAPICodePack.Dialogs;
using RecommenderSystem.InputGenerator;
using RecommenderSystem.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RecommenderSystem
{
    public partial class Interface : Form
    {
        #region Constructors
        public Interface()
        {
            InitializeComponent();

            _fileDialog.InitialDirectory = Path.GetDirectoryName(_applicationPath);
            _folderDialog.InitialDirectory = Path.GetDirectoryName(_applicationPath);

            CenterToScreen();
        }
        #endregion

        #region Delegates
        /// <summary>
        /// This delegate is used to display the splash screen(the progress bar)
        /// </summary>
        private delegate void DisplaySplashScreenDelegate();

        /// <summary>
        /// Delegate used to increment the progress bar from the splash screen
        /// </summary>
        private delegate void IncrementProgressBarDelegate(string info, int incrementValue);

        /// <summary>
        /// Delegate used to close the splash screen form
        /// </summary>
        private delegate void CloseSplashScreenDelegate();

        private delegate void BringToFrontDelegate(Form form);
        #endregion

        #region Class members
        /// <summary>
        /// This is the loading screen, while operations are active
        /// </summary>
        private SplashScreen _splashScreen;

        /// <summary>
        /// Path to the application(*.exe) file
        /// </summary>
        private string _applicationPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private OpenFileDialog _fileDialog = new OpenFileDialog();

        private CommonOpenFileDialog _folderDialog = new CommonOpenFileDialog();
        #endregion

        #region Form handlers
        private void Interface_Load(object sender, EventArgs e)
        {
            string configFilePath = Path.Combine(_applicationPath, Constants.CONFIGURATION_FILE_NAME);
            if (File.Exists(configFilePath))
            {
                Configuration configuration = null;

                // If the file is read only, clear the flag
                FileInfo fileInfo = new FileInfo(configFilePath);
                fileInfo.IsReadOnly = false;

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                    using (FileStream fs = new FileStream(configFilePath, FileMode.Open))
                    {
                        configuration = (Configuration)serializer.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("The configuration file is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (configuration != null)
                {
                    _titlesFileTextbox.Text = configuration.TitleFilePath;
                    _directorsFileTextbox.Text = configuration.DirectorsFilePath;
                    _titleRatingsTextbox.Text = configuration.RatingsFilePath;
                    _crewNamesTextbox.Text = configuration.NamesFilePath;
                    _castNamesTextbox.Text = configuration.CastFilePath;
                    _outputFolderTextbox.Text = configuration.OutputFolderPath;
                    _numberOfUsersTextbox.Text = configuration.NumberOfUsers;
                    _movieYearsRangeStart.Text = configuration.MovieYearsRangeStart;
                    _movieYearsRangeEnd.Text = configuration.MovieYearsRangeEnd;

                }
            }
        }

        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.
                   Show("Are you sure you want to exit?", "Closing the application", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                Configuration newConfiguration = new Configuration();

                newConfiguration.TitleFilePath = _titlesFileTextbox.Text;
                newConfiguration.DirectorsFilePath = _directorsFileTextbox.Text;
                newConfiguration.RatingsFilePath = _titleRatingsTextbox.Text;
                newConfiguration.NamesFilePath = _crewNamesTextbox.Text;
                newConfiguration.CastFilePath = _castNamesTextbox.Text;
                newConfiguration.OutputFolderPath = _outputFolderTextbox.Text;

                if (int.TryParse(_numberOfUsersTextbox.Text, out int userNumber))
                {
                    newConfiguration.NumberOfUsers = userNumber.ToString();
                }
                else
                {
                    newConfiguration.NumberOfUsers = "0";
                }

                if (int.TryParse(_movieYearsRangeStart.Text, out int movieStartRange))
                {
                    newConfiguration.MovieYearsRangeStart = movieStartRange.ToString();
                }
                else
                {
                    newConfiguration.MovieYearsRangeStart = "1998";
                }

                if (int.TryParse(_movieYearsRangeEnd.Text, out int movieEndRange))
                {
                    newConfiguration.MovieYearsRangeEnd = movieEndRange.ToString();
                }
                else
                {
                    newConfiguration.MovieYearsRangeEnd = "2020";
                }

                // Serialize the configuration model into an XML file
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                FileStream writer = new FileStream(Path.Combine(_applicationPath, Constants.CONFIGURATION_FILE_NAME), FileMode.Create);

                serializer.Serialize(writer, newConfiguration);

                writer.Close();

                // Dispose all resources of the forms
                FormCollection forms = Application.OpenForms;

                if (forms.Count > 0)
                {
                    Form splashScreenForm = forms["SplashScreen"];
                    Form smfGeneratorToolForm = forms["Interface"];

                    if (splashScreenForm != null)
                    {
                        splashScreenForm.Dispose();
                    }

                    if (smfGeneratorToolForm != null)
                    {
                        smfGeneratorToolForm.Dispose();
                    }
                }

                Environment.Exit(-1);
            }
            else
            {
                e.Cancel = true;

                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;

                FormCollection forms = Application.OpenForms;

                foreach (Form form in forms)
                {
                    if (form.Name.Equals("SplashScreenForm"))
                    {
                        form.TopMost = true;
                        form.Focus();
                        form.BringToFront();
                        form.TopMost = false;
                    }
                }
            }
        }

        private void Interface_Activated(object sender, EventArgs e)
        {
            FormCollection forms = Application.OpenForms;

            foreach (Form form in forms)
            {
                if (form.Name.Equals("SplashScreenForm"))
                {
                    BringToFront(form);
                    break;
                }
            }
        }
        #endregion

        #region OnClick handlers
        private void _dataCleanerButton_Click(object sender, System.EventArgs e)
        {
            if (!Directory.Exists(_outputFolderTextbox.Text))
            {
                Directory.CreateDirectory(_outputFolderTextbox.Text);
            }

            bool validInputData = CheckInputData();
            if (!validInputData)
            {
                return;
            }

            EnableDisableComponents(false);

            _splashScreen = new SplashScreen();
            _splashScreen.BringToFront();

            Thread splashScreenThread = new Thread(new ThreadStart(DisplaySplashScreenCall));
            splashScreenThread.IsBackground = true;
            splashScreenThread.Start();

            Thread executeThread = new Thread(new ThreadStart(ExecuteData));
            executeThread.IsBackground = true;
            executeThread.Start();
        }

        private void _exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _choseTitlesButton_Click(object sender, EventArgs e)
        {
            _titlesFileTextbox.Text = SelectFileDialog(" Titles file");
        }

        private void _chooseDirectorsButton_Click(object sender, EventArgs e)
        {
            _directorsFileTextbox.Text = SelectFileDialog(" Directors file");
        }

        private void _chooseRatingsButton_Click(object sender, EventArgs e)
        {
            _titleRatingsTextbox.Text = SelectFileDialog(" Ratings file");
        }

        private void _choseCrewButton_Click(object sender, EventArgs e)
        {
            _crewNamesTextbox.Text = SelectFileDialog(" Crew file");
        }

        private void _chooseCastButton_Click(object sender, EventArgs e)
        {
            _castNamesTextbox.Text = SelectFileDialog(" Cast file");
        }

        private void _chooseOutFolderButton_Click(object sender, EventArgs e)
        {
            // _folderDialog.Title = "Choose output folder";
            _folderDialog.IsFolderPicker = true;
            CommonFileDialogResult result = _folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                _outputFolderTextbox.Text = _folderDialog.FileName;

                _fileDialog.InitialDirectory = _folderDialog.FileName;
                _folderDialog.InitialDirectory = _folderDialog.FileName;
            }
        }
        #endregion

        #region Methods used for delegates
        private void DisplaySplashScreenCall()
        {
            if (_splashScreen.InvokeRequired)
            {
                DisplaySplashScreenDelegate d = new DisplaySplashScreenDelegate(DisplaySplashScreenCall);
                _splashScreen.Invoke(d, null);
            }
            else
            {
                _splashScreen.ShowDialog();
            }
        }

        private void BringToFront(Form form)
        {
            if (form.InvokeRequired)
            {
                BringToFrontDelegate d = new BringToFrontDelegate(BringToFront);
                form.Invoke(d, new object[] { form });
            }
            else
            {
                form.TopMost = true;
                form.Focus();
                form.BringToFront();
                form.TopMost = false;
            }
        }
        private void IncrementProgressBarCall(string info, int incrementValue)
        {
            if (_splashScreen.InvokeRequired)
            {
                IncrementProgressBarDelegate d = new IncrementProgressBarDelegate(IncrementProgressBarCall);
                _splashScreen.Invoke(d, new object[] { info, incrementValue });
            }
            else
            {
                _splashScreen.IncrementProgressBar(info, incrementValue);
            }
        }

        private void CloseSplashScreenCall()
        {
            if (_splashScreen.InvokeRequired)
            {
                CloseSplashScreenDelegate d = new CloseSplashScreenDelegate(CloseSplashScreenCall);
                _splashScreen.Invoke(d, null);
            }
            else
            {
                _splashScreen.Close();
                _splashScreen = null;
            }
        }
        #endregion

        #region Helper methods

        private void ExecuteData()
        {
            try
            {
                IncrementProgressBarCall("Intialize data...", 2);

                int userCounter = int.Parse(_numberOfUsersTextbox.Text);

                string titlesFile = _titlesFileTextbox.Text;
                string directorsFile = _directorsFileTextbox.Text;
                string ratingsFile = _titleRatingsTextbox.Text;
                string namesFile = _crewNamesTextbox.Text;
                string castFile = _castNamesTextbox.Text;

                string titlesCleanedFile = Path.Combine(_outputFolderTextbox.Text, Constants.TITLES_CLEANED_FILE_NAME);
                string directorsCleanedFile = Path.Combine(_outputFolderTextbox.Text, Constants.DIRECTORS_CLEANED_FILE_NAME);
                string ratingsCleanedFile = Path.Combine(_outputFolderTextbox.Text, Constants.RATINGS_CLEANED_FILE_NAME);
                string namesCleanedFile = Path.Combine(_outputFolderTextbox.Text, Constants.NAMES_CLEANED_FILE_NAME);
                string castCleanedFile = Path.Combine(_outputFolderTextbox.Text, Constants.CAST_CLEANED_FILE_NAME);

                string moviesOutputNotCleaned = Path.Combine(_outputFolderTextbox.Text, Constants.MOVIES_NOT_CLEARED);

                string moviesOutput = Path.Combine(_outputFolderTextbox.Text, Constants.MOVIES_OUTPUT);
                string usersOutput = Path.Combine(_outputFolderTextbox.Text, Constants.USERS_OUTPUT);
                string userRatingsOutput = Path.Combine(_outputFolderTextbox.Text, Constants.USER_RATINGS_OUTPUT);

                List<string> acceptedYears = GetAcceptedYears();

                IncrementProgressBarCall("Cleaning movies file...", 6);
                Writer.WriteMoviesShort(titlesFile, titlesCleanedFile, acceptedYears);

                IncrementProgressBarCall("Cleaning directors file...", 8);
                Writer.WriteDirectorsShort(titlesCleanedFile, directorsFile, directorsCleanedFile);

                IncrementProgressBarCall("Cleaning cast file...", 12);
                Writer.WriteCastShort(titlesCleanedFile, castFile, castCleanedFile);

                IncrementProgressBarCall("Cleaning crew file...", 6);
                Writer.WriteNamesShort(directorsCleanedFile, castCleanedFile, namesFile, namesCleanedFile);

                IncrementProgressBarCall("Cleaning ratings file...", 20);
                Writer.WriteRatingsShort(titlesCleanedFile, ratingsFile, ratingsCleanedFile);

                IncrementProgressBarCall("Creating results file...", 10);
                Writer.WriteMoviesResultsFile(titlesCleanedFile, ratingsCleanedFile, namesCleanedFile, directorsCleanedFile,
                    castCleanedFile, moviesOutputNotCleaned);

                IncrementProgressBarCall("Cleaning movies results file...", 8);
                Cleaner.CleanMoviesResultsFile(moviesOutputNotCleaned, moviesOutput);

                IncrementProgressBarCall("Creating users file...", 7);
                Writer.WriteUsers(userCounter, usersOutput);

                IncrementProgressBarCall("Creating user ratings file...", 6);
                Writer.WriteUsersRatings(usersOutput, moviesOutput, userRatingsOutput);

                //CheckOutputFiles(moviesFullCleaned, usersOutput, usersRatingsOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not clean the input files. Reason: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseSplashScreenCall();
                EnableDisableComponents(true);
            }
        }

        private string SelectFileDialog(string name)
        {
            string path = string.Empty;

            _fileDialog.Title = "Choose " + name;
            _fileDialog.FileName = "";

            if (_fileDialog.ShowDialog() == DialogResult.OK)
            {
                path = _fileDialog.FileName;

                _fileDialog.InitialDirectory = Path.GetDirectoryName(_fileDialog.FileName);
                _folderDialog.InitialDirectory = Path.GetDirectoryName(_fileDialog.FileName);
            }

            return path;
        }

        private bool CheckInputData()
        {
            if (!File.Exists(_titlesFileTextbox.Text))
            {
                MessageBox.Show("Invalid titles file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(_directorsFileTextbox.Text))
            {
                MessageBox.Show("Invalid directors file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(_titleRatingsTextbox.Text))
            {
                MessageBox.Show("Invalid ratings file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(_crewNamesTextbox.Text))
            {
                MessageBox.Show("Invalid crew file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(_castNamesTextbox.Text))
            {
                MessageBox.Show("Invalid cast file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(_outputFolderTextbox.Text))
            {
                MessageBox.Show("Invalid output folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(_numberOfUsersTextbox.Text, out int noUsers))
            {
                MessageBox.Show("Number of users have to be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(_movieYearsRangeStart.Text, out int startYear))
            {
                MessageBox.Show("Invalid value for movies start year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(_movieYearsRangeEnd.Text, out int endYear))
            {
                MessageBox.Show("Invalid value for movies end year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (startYear > endYear)
            {
                MessageBox.Show("The start year for movies cannot be smaller than the end year", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void EnableDisableComponents(bool isEnabled)
        {
            _dataCleanerButton.Enabled = isEnabled;
            _chooseCastButton.Enabled = isEnabled;
            _choseCrewButton.Enabled = isEnabled;
            _chooseRatingsButton.Enabled = isEnabled;
            _chooseDirectorsButton.Enabled = isEnabled;
            _choseTitlesButton.Enabled = isEnabled;
            _chooseOutFolderButton.Enabled = isEnabled;
            _titlesFileTextbox.Enabled = isEnabled;
            _directorsFileTextbox.Enabled = isEnabled;
            _titleRatingsTextbox.Enabled = isEnabled;
            _crewNamesTextbox.Enabled = isEnabled;
            _castNamesTextbox.Enabled = isEnabled;
            _outputFolderTextbox.Enabled = isEnabled;
            _numberOfUsersTextbox.Enabled = isEnabled;
            _movieYearsRangeStart.Enabled = isEnabled;
            _movieYearsRangeEnd.Enabled = isEnabled;
            _exitButton.Enabled = isEnabled;
        }

        private List<string> GetAcceptedYears()
        {
            List<string> acceptedYears = new List<string>();

            int startYear = int.Parse(_movieYearsRangeStart.Text);
            int endYear = int.Parse(_movieYearsRangeEnd.Text);

            for (int index = startYear; index <= endYear; index++)
            {
                acceptedYears.Add(index.ToString());
            }

            return acceptedYears;
        }
        #endregion
    }
}
