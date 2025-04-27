using Windows.Storage;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;

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
                ? MediaVideoProcessingAlgorithm.Default
                : MediaVideoProcessingAlgorithm.MrfCrf444
        };

        PrepareTranscodeResult prepareOp =
            await transcoder
                .PrepareFileTranscodeAsync(sourceFile, destinationFile, profile);

        if (!prepareOp.CanTranscode)
        {
            string reason =
                prepareOp.FailureReason switch
                {
                    TranscodeFailureReason.Unknown => "WinRT API cannot handle provided settings",
                    _ => prepareOp.FailureReason.ToString(),
                };

            throw new InvalidOperationException($"Cannot transcode: {reason}");
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
