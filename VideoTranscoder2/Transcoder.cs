using Windows.Storage;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;
using Windows.Foundation;
using System.Diagnostics;

namespace VideoTranscoder2;

internal class Transcoder(Action<double> onTranscodeProgress)
{
    public async Task<bool> TranscodeAsync(
        IStorageFile sourceFile,
        IStorageFile destinationFile,
        VideoEncodingQuality quality,
        bool useFastestAlgorithm,
        CancellationToken cancellationToken = default)
    {
        var profile = MediaEncodingProfile.CreateHevc(quality);

        MediaTranscoder transcoder = new()
        {
            HardwareAccelerationEnabled = true,
            VideoProcessingAlgorithm = useFastestAlgorithm
                ? MediaVideoProcessingAlgorithm.MrfCrf444
                : MediaVideoProcessingAlgorithm.Default
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
                    new Progress<double>(
                        progress => onTranscodeProgress(progress)));

        try
        {
            await transcoding;
            return true;
        }
        catch (TaskCanceledException)
        {
            return false;
        }
    }
}
