using System;
using System.Threading;

using VideoTranscoder2.Utils;

using Windows.Media.MediaProperties;
using Windows.Storage;

namespace VideoTranscoder2;

public partial class MainForm : Form
{
    private const string LabelForTranscodeAction = "Transcode to HEVC (H.265)";

    private CancellationTokenSource _cancellationTokenSource = new();

    private AtomicBoolean IsTranscoding { get; } = new();

    private IStorageFile? InputFile { get; set; }

    private IStorageFile? OutputFile { get; set; }

    public MainForm()
    {
        InitializeComponent();

        foreach (var value in
            Enum.GetValues<VideoEncodingQuality>()
                .Where(_ => _ is not VideoEncodingQuality.Auto))
        {
            comboBoxForQuality.Items.Add(value);
        }
        comboBoxForQuality.SelectedIndex = 0;
    }

    private void EnableStartIfPossible()
    {
        if (InputFile != null &&
            OutputFile != null &&
            comboBoxForQuality.SelectedIndex >= 0)
        {
            buttonToStartStop.Text = LabelForTranscodeAction;
            buttonToStartStop.Enabled = true;
        }
    }

    private void DisableControls()
    {
        buttonForInput.Enabled = false;
        buttonForOutput.Enabled = false;
        checkBoxForAlgo.Enabled = false;
        comboBoxForQuality.Enabled = false;
    }

    private void ReEnableControls()
    {
        buttonForInput.Enabled = true;
        buttonForOutput.Enabled = true;
        checkBoxForAlgo.Enabled = true;
        comboBoxForQuality.Enabled = true;
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
                // create file:
                File.OpenWrite(saveFileDialog.FileName).Close();
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
            IsTranscoding.Set(false);
            ReEnableControls();
            return;
        }

        buttonToStartStop.Text = "Stop transcoding";
        DisableControls();
        IsTranscoding.Set(true);

        try
        {
            bool useFastestAlgorithm = checkBoxForAlgo.Checked;
            var quality = (VideoEncodingQuality?)comboBoxForQuality.SelectedItem
                ?? throw new InvalidOperationException("Cannot get quality set in control!");

            var transcoding =
                await StartTranscodingAsync(quality, useFastestAlgorithm);

            TimeSpan elapsedTime = transcoding.elapsedTime.RoundSeconds();
            string assessment = transcoding.outSizeRatio < 1.0 ? "👍" : "👎";

            toolStripProgressBar.Value = 0;
            toolStripStatusLabel.Text = transcoding.completed
                ? $"Completed in {elapsedTime} - OSR = {transcoding.outSizeRatio:F2} {assessment}"
                : $"Stopped after {elapsedTime}";
        }
        catch (Exception ex)
        {
            await StopTranscodingAsync();
            buttonToStartStop.Enabled = false;
            toolStripStatusLabel.Text = "Failed";
            this.DisplayMessageBox(ex);
        }

        IsTranscoding.Set(false);
        ReEnableControls();
    }

    private async Task StopTranscodingAsync()
    {
        await _cancellationTokenSource.CancelAsync();
        _cancellationTokenSource = new();
    }

    private async Task<(bool completed, TimeSpan elapsedTime, double outSizeRatio)>
        StartTranscodingAsync(VideoEncodingQuality quality, bool useFastestAlgorithm)
    {
        var startTime = DateTime.Now;

        Transcoder transcoder =
            new(progress =>
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                toolStripProgressBar.Value = (int)progress;
                toolStripStatusLabel.Text =
                    $"Transcoding... {progress:F1}% in {elapsedTime.RoundSeconds()}";
            });

        bool completed =
            await transcoder.TranscodeAsync(
                InputFile
                    ?? throw new InvalidOperationException("No input has been chosen!"),
                OutputFile?.Truncate()
                    ?? throw new InvalidOperationException("No output has been chosen!"),
                quality,
                useFastestAlgorithm,
                _cancellationTokenSource.Token);

        return (
            completed,
            DateTime.Now - startTime,
            Helpers.CalculateOutputSizeRatio(InputFile, OutputFile)
        );
    }

    private void OnSelectedIndexChangedComboBoxForAlgo(object sender, EventArgs e)
    {
        EnableStartIfPossible();
    }
}
