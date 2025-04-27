using System;
using System.Threading;

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
    }

    private void EnableStartIfPossible()
    {
        if (InputFile != null && OutputFile != null)
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
        try
        {
            if (IsTranscoding)
            {
                await StopTranscodingAsync();
                IsTranscoding = false;
                ReEnableInput();
            }
            else
            {
                buttonToStartStop.Text = "Stop transcoding";
                buttonForInput.Enabled = false;
                buttonForOutput.Enabled = false;
                IsTranscoding = true;

                _ = StartTranscodingAsync()
                    .ContinueWith(async transcoding =>
                    {

                        var (completed, elapsedTime) = await transcoding;
                        toolStripProgressBar.Value = 0;
                        toolStripStatusLabel.Text = completed
                            ? $"Completed in {elapsedTime}"
                            : $"Stopped after {elapsedTime}";

                        IsTranscoding = false;
                        ReEnableInput();
                    });
            }
        }
        catch (Exception ex)
        {
            await StopTranscodingAsync();
            IsTranscoding = false;
            buttonToStartStop.Enabled = false;
            toolStripStatusLabel.Text = "Failed";

            MessageBox.Show(this,
                ex.ToString(),
                "Caught exception!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            ReEnableInput();
        }
    }

    private async Task StopTranscodingAsync()
    {
        await _cancellationTokenSource.CancelAsync();
        _cancellationTokenSource = new();
    }

    private async Task<(bool completed, TimeSpan elapsedTime)> StartTranscodingAsync()
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
                _cancellationTokenSource.Token);

        return (completed, DateTime.Now - startTime);
    }
}
