using System;
using System.Threading;

using Windows.Media.MediaProperties;
using Windows.Storage;

namespace VideoTranscoder2;

public partial class MainForm : Form
{
    private int _transcodingOpsFlag;

    private bool IsTranscoding
    {
        get => Interlocked.CompareExchange(ref _transcodingOpsFlag, 0, 0) == 1;

        set
        {
            if (value)
            {
                Interlocked.CompareExchange(ref _transcodingOpsFlag, 1, 0);
            }
            else
            {
                Interlocked.CompareExchange(ref _transcodingOpsFlag, 0, 1);
            }
        }
    }

    private const string LabelForTranscodeAction = "Transcode to HEVC (H.265)";

    private CancellationTokenSource _cancellationTokenSource;

    private StorageFile? InputFile { get; set; }

    private StorageFile? OutputFile { get; set; }

    public MainForm()
    {
        InitializeComponent();

        _cancellationTokenSource = new();

        foreach (var value in Enum.GetValues<VideoEncodingQuality>().Skip(1))
        {
            comboBoxForAlgo.Items.Add(value);
        }
        comboBoxForAlgo.SelectedIndex = 0;
    }

    private void EnableStartIfPossible()
    {
        if (InputFile != null &&
            OutputFile != null &&
            comboBoxForAlgo.SelectedIndex >= 0)
        {
            buttonToStartStop.Text = LabelForTranscodeAction;
            buttonToStartStop.Enabled = true;
        }
    }

    private void ReEnableInput()
    {
        buttonForInput.Enabled = true;
        buttonForOutput.Enabled = true;
        buttonToStartStop.Text = LabelForTranscodeAction;
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
        if (IsTranscoding)
        {
            await StopTranscodingAsync();
            IsTranscoding = false;
            ReEnableInput();
            return;
        }

        buttonToStartStop.Text = "Stop transcoding";
        buttonForInput.Enabled = false;
        buttonForOutput.Enabled = false;
        IsTranscoding = true;

        try
        {
            bool useFastestAlgorithm = checkBoxForAlgo.Checked;
            var quality = (VideoEncodingQuality?)comboBoxForAlgo.SelectedItem
                ?? throw new InvalidOperationException("Cannot get quality set in control!");

            var (completed, elapsedTime) =
                await StartTranscodingAsync(quality, useFastestAlgorithm);

            toolStripProgressBar.Value = 0;
            toolStripStatusLabel.Text = completed
                ? $"Completed in {elapsedTime}"
                : $"Stopped after {elapsedTime}";
        }
        catch (Exception ex)
        {
            await StopTranscodingAsync();
            buttonToStartStop.Enabled = false;
            toolStripStatusLabel.Text = "Failed";
            DisplayErrorMessageBox(ex);
        }

        IsTranscoding = false;
        ReEnableInput();
    }

    private async Task StopTranscodingAsync()
    {
        await _cancellationTokenSource.CancelAsync();
        _cancellationTokenSource = new();
    }

    private async Task<(bool completed, TimeSpan elapsedTime)>
        StartTranscodingAsync(VideoEncodingQuality quality, bool useFastestAlgorithm)
    {
        var startTime = DateTime.Now;

        Transcoder transcoder =
            new(progress =>
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                toolStripStatusLabel.Text = $"{progress:F1}% in {elapsedTime}";
                toolStripProgressBar.Value = (int)progress;
            });

        bool completed =
            await transcoder.TranscodeAsync(
                InputFile ?? throw new InvalidOperationException("No input has been chosen!"),
                OutputFile ?? throw new InvalidOperationException("No output has been chosen!"),
                quality,
                useFastestAlgorithm,
                _cancellationTokenSource.Token);

        return (completed, DateTime.Now - startTime);
    }

    private void OnSelectedIndexChangedComboBoxForAlgo(object sender, EventArgs e)
    {
        EnableStartIfPossible();
    }

    private void DisplayErrorMessageBox(Exception ex)
    {
        MessageBox.Show(this,
            ex.ToString(),
            "Caught exception!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
