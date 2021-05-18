using System.Windows.Forms;

namespace RecommenderSystem.UI
{
    public partial class SplashScreen : Form
    {
        private delegate void ProgressBarInfoDelegate(int value);

        private delegate void InfoLabelDelegate(string info);

        public SplashScreen()
        {
            InitializeComponent();
        }

        public void IncrementProgressBar(string info, int incrementValue)
        {
            this.progressBar.Increment(incrementValue);

            ProgressBarInfoCall(this.progressBar.Value);

            InfoLabelCall(info);
        }

        private void ProgressBarInfoCall(int value)
        {
            if (this.percentageLabel.InvokeRequired)
            {
                ProgressBarInfoDelegate del = new ProgressBarInfoDelegate(ProgressBarInfoCall);
                percentageLabel.Invoke(del, new object[] { value });
            }
            else
            {
                this.percentageLabel.Text = value + "%";
            }
        }

        private void InfoLabelCall(string info)
        {
            if (this.infoLabel.InvokeRequired)
            {
                InfoLabelDelegate del = new InfoLabelDelegate(InfoLabelCall);
                infoLabel.Invoke(del, new object[] { info });
            }
            else
            {
                this.infoLabel.Text = info;
            }
        }
    }
}
