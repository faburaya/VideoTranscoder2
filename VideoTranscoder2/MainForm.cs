using Windows.Storage;

namespace VideoTranscoder2;

public partial class MainForm : Form
{
    private StorageFile? InputFile { get; set; }

    private StorageFile? OutputFile { get; set; }

    public MainForm()
    {
        InitializeComponent();
    }

    private void EnableStartIfPossible()
    {
        if (InputFile != null && OutputFile != null)
        {
            buttonToStartStop.Text = "Transcode to HEVC (H.265)";
            buttonToStartStop.Enabled = true;
        }
    }

    private async void OnClickButtonForInput(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog =
            new()
            {
                Title = "Select an input video file"
            };

        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            InputFile = await StorageFile.GetFileFromPathAsync(openFileDialog.FileName);
            textBoxForInput.Text = InputFile.Path;
            EnableStartIfPossible();
        }
    }

    private async void OnClickButtonForOutput(object sender, EventArgs e)
    {
        using SaveFileDialog saveFileDialog =
            new()
            {
                Title = "Select an output video file",
                AddExtension = true,
                DefaultExt = "HEVC.mp4",
                CheckFileExists = false,
                CheckWriteAccess = true,
                OverwritePrompt = true,
                SupportMultiDottedExtensions = true,
            };

        if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            if (!File.Exists(saveFileDialog.FileName))
            {
                File.Create(saveFileDialog.FileName).Close();
            }
            OutputFile = await StorageFile.GetFileFromPathAsync(saveFileDialog.FileName);
            textBoxForOutput.Text = OutputFile.Path;
            EnableStartIfPossible();
        }
    }

    private async void OnClickButtonToStartStop(object sender, EventArgs e)
    {
        using CancellationTokenSource cancellationTokenSource = new();

    }
}
