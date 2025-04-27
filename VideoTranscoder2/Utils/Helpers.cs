using System.Windows.Forms;

using Windows.Storage;

namespace VideoTranscoder2.Utils;

internal static class Helpers
{
    public static void DisplayMessageBox(this Form form, Exception ex)
    {
        MessageBox.Show(form,
            ex.ToString(),
            "Caught exception!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    public static TimeSpan RoundSeconds(this TimeSpan duration)
    {
        return TimeSpan.FromSeconds(Math.Floor(duration.TotalSeconds));
    }

    public static IStorageFile Truncate(this IStorageFile file)
    {
        File.Open(file.Path, FileMode.Truncate, FileAccess.Write).Close();
        return file;
    }

    public static double CalculateOutputSizeRatio(
        IStorageFile inputFile, IStorageFile outputFile)
    {
        using FileStream inputStream = File.Open(inputFile.Path, FileMode.Open, FileAccess.Read);
        using FileStream outputStream = File.Open(outputFile.Path, FileMode.Open, FileAccess.Read);
        return (double)outputStream.Length / inputStream.Length;
    }
}
