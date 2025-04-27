using Windows.Storage;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;

namespace VideoTranscoder2;

internal class Transcoder(Action<double> onTranscodeProgress)
{
    public async Task<bool> TranscodeAsync(
        IStorageFile sourceFile,
        IStorageFile destinationFile,
        CancellationToken cancellationToken = default)
    {
        var profile = MediaEncodingProfile.CreateHevc(VideoEncodingQuality.Auto);

        MediaTranscoder transcoder = new()
        {
            HardwareAccelerationEnabled = true
        };

        PrepareTranscodeResult prepareOp =
            await transcoder
                .PrepareFileTranscodeAsync(sourceFile, destinationFile, profile);

        if (!prepareOp.CanTranscode)
        {
            throw new InvalidOperationException(
                $"Cannot transcode: {prepareOp.FailureReason}");
        }

        Task transcoding =
            prepareOp
                .TranscodeAsync()
                .AsTask(cancellationToken,
                    new Progress<double>(onTranscodeProgress));

        await transcoding;

        return transcoding.Status switch
        {
            TaskStatus.RanToCompletion => true,
            TaskStatus.Canceled => false,
            TaskStatus.Faulted =>
                throw transcoding.Exception ??
                    new AggregateException(
                        new InvalidOperationException(
                            "Transcoding failed but exception is not available.")),

            _ => throw new NotImplementedException(
                $"Transcoding status '{transcoding.Status}' was not expected!")
        };
    }
}
