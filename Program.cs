using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ////BYTE TO PDF
            //try
            //{
            //    string filePath = @"";
            //    byte[] bytes = System.IO.File.ReadAllBytes(filePath);

            //    await File.WriteAllBytesAsync(@"", bytes);

            //}
            //catch
            //{
            //    throw;
            //}
            try
            {
                Console.WriteLine("Azure Blob Storage v12 - .NET quickstart sample\n");
                string connectionString = "";


                string filePath = @"";
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);

                // Create a BlobServiceClient object which will be used to create a container client
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                //Create a unique name for the container
                string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

                // Create the container and return a container client object
                BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

                // Create a local file in the ./data/ directory for uploading and downloading
                string localPath = @"";
                string fileName = "quickstart.txt";
                string localFilePath = Path.Combine(localPath, fileName);

                // Write text to the file

                await File.WriteAllBytesAsync(localFilePath, bytes);

                // Get a reference to a blob
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

                // Upload data from the local file
                await blobClient.UploadAsync(localFilePath, true);

                Console.ReadKey();
            }
            catch
            {
                throw;
            }
        }
    }
}
