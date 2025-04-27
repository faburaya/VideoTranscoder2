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

    public static double CalculateOutputSizeRatio(
        string inputFilePath, string outputFilePath)
    {
        using FileStream inputStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read);
        using FileStream outputStream = File.Open(outputFilePath, FileMode.Open, FileAccess.Read);
        return (double)outputStream.Length / inputStream.Length;
    }
}
