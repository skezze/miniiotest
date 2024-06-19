
using Amazon.S3.Transfer;
using Amazon.S3;

namespace miniiotest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string bucketName = "audiofiles";
            const string filePath = @"D:\bigtextfile.txt";
            const string serviceURL = "http://localhost:9000"; // URL вашего MinIO сервера
            const string accessKey = "your-access-key";
            const string secretKey = "your-secret-key";

       
            var s3Config = new AmazonS3Config
            {
                ServiceURL = serviceURL,
                ForcePathStyle = true
            };

            var s3Client = new AmazonS3Client(accessKey, secretKey, s3Config);

            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload completed");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine($"Error encountered on server. Message: '{e.Message}' when writing an object");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown encountered on server. Message: '{e.Message}' when writing an object");
            }
        }
    }
}