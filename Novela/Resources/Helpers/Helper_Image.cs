using SkiaSharp;

namespace Novela.Resources.Helpers;

public static class Helper_Image
{
    public static async Task<byte[]> image_compress(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        memoryStream.Position = 0;

        using var originalBitmap = SKBitmap.Decode(memoryStream);

        if (originalBitmap == null)
            throw new Exception("Failed to decode image.");

        const int maxSize = 1024;

        int originalWidth = originalBitmap.Width;
        int originalHeight = originalBitmap.Height;

        float ratio = Math.Min(
            (float)maxSize / originalWidth,
            (float)maxSize / originalHeight);

        ratio = Math.Min(ratio, 1f);

        int newWidth = (int)(originalWidth * ratio);
        int newHeight = (int)(originalHeight * ratio);

        using var resizedBitmap = originalBitmap.Resize(
            new SKImageInfo(newWidth, newHeight),
            SKFilterQuality.Medium);

        using var image = SKImage.FromBitmap(resizedBitmap);
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 75);

        return data.ToArray();
    }

    public static async Task<string> image_coversave (FileResult result, int book_id, string old_path = null)
    {
        var coversDir = Path.Combine(FileSystem.AppDataDirectory, "covers");

        Directory.CreateDirectory(coversDir);

        var fileName = $"cover_{book_id}_{Guid.NewGuid()}.jpg";
        var destPath = Path.Combine(coversDir, fileName);

            using var stream = await result.OpenReadAsync();

        var compressedData = await Helper_Image.image_compress(stream);

        await File.WriteAllBytesAsync(destPath, compressedData);

            if (!string.IsNullOrEmpty(old_path) && File.Exists(old_path))
        File.Delete(old_path);

        return destPath;
    }
}