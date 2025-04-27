using Windows.Storage;
using Windows.Storage.Pickers;

namespace VideoTranscoder2
{
    public partial class MainForm : Form
    {
        private static readonly string[] AllowedSourceFileExtensions = [".avi", ".wmv", ".m4a", ".mp4"];

        private readonly FileOpenPicker _inputFilePicker;

        private StorageFile? InputFile { get; set; }

        private StorageFile? OutputFile { get; set; }

        public MainForm()
        {
            InitializeComponent();

            _inputFilePicker = new();

            foreach (var fileExtension in AllowedSourceFileExtensions)
            {
                _inputFilePicker.FileTypeFilter.Add(fileExtension);
            }
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
            InputFile = await _inputFilePicker.PickSingleFileAsync();
            textBoxForInput.Text = InputFile.Path;
            EnableStartIfPossible();
        }
    }
}
