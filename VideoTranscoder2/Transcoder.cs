using Windows.Storage;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;

namespace VideoTranscoder2;

internal class Transcoder(Action<double> onTranscodeProgress)
{
    public async Task<bool> TranscodeAsync(
        IStorageFile sourceFile,
        IStorageFile destinationFile,
        Codec encoder,
        VideoEncodingQuality quality,
        bool useFastestAlgorithm,
        CancellationToken cancellationToken = default)
    {
        var profile = encoder switch
        {
            Codec.HEVC => MediaEncodingProfile.CreateHevc(quality),
            Codec.AV1 => MediaEncodingProfile.CreateAv1(quality),
            Codec.H264 => MediaEncodingProfile.CreateMp4(quality),
            _ => throw new NotImplementedException($"Transcoder does not support {encoder}")
        };

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
