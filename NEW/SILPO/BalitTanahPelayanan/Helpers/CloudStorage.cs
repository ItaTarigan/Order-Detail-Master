using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using BalitTanahPelayanan.Data;

namespace BalitTanahPelayanan.Helpers
{
    public class CloudStorage
    {
        public static async Task<bool> BlobPostAsync(byte[] data, string filename)
        {
            var content = new MemoryStream(data, false);
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;

            // Upload file info 
            //string sourceFile = null;
            //string fileName = null;

            //string destinationFile = null;
            string storageConnectionString = AppConstants.BlobStorageConnection;
            string blobContainer = AppConstants.DefaultBlobCountainer;

            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                try
                {
                    // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    // Create a container called 'balittanah' and append a GUID value to it to make the name unique.
                    cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainer);
                    if (cloudBlobContainer.Exists())
                    {
                        
                        BlobContainerPermissions permissions = new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        };
                        await cloudBlobContainer.SetPermissionsAsync(permissions);
                        
                        // Get a reference to the blob address, then upload the file to the blob.
                        // Use the value of filename for the blob name.
                        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
                        await cloudBlockBlob.UploadFromStreamAsync(content);

                        return true;
                    }
                    else
                    {
                        await cloudBlobContainer.CreateAsync();

                        // Set the permissions so the blobs are public. 
                        BlobContainerPermissions permissions = new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        };
                        await cloudBlobContainer.SetPermissionsAsync(permissions);

                        // Get a reference to the blob address, then upload the file to the blob.
                        // Use the value of filename for the blob name.
                        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
                        await cloudBlockBlob.UploadFromStreamAsync(content);
                    }

                    return true;
                }
                catch (StorageException ex)
                {
                    Console.WriteLine("Error returned from the service: {0}", ex.Message);
                    LogHelpers.source = MethodBase.GetCurrentMethod().DeclaringType.Name;
                    LogHelpers.message = ex.Message;
                    LogHelpers.user = "System";
                    LogHelpers.WriteLog();
                }
                //finally
                //{
                //    // Clean up resources. This includes the container and the two temp files.
                //    Console.WriteLine("Deleting the container and any blobs it contains");
                //    if (cloudBlobContainer != null)
                //    {
                //        await cloudBlobContainer.DeleteIfExistsAsync();
                //    }
                //}
            }
            else
            {
                Console.WriteLine(
                    "A connection string has not been defined in the web.config appsetting. " +
                    "Add a environment variable named 'BlobStorageConnection' with your storage " +
                    "connection string as a value.");
            }

            return false;
        }
    }

    public class OnPremStorage
    {
        public static async Task<bool> BlobPostAsync(byte[] data, string filename, string Folder = "general")
        {
            try
            {

                string UploadPath = AppConstants.UploadFolderPath;
                if (string.IsNullOrEmpty(UploadPath))
                {
                    UploadPath = FileHelpers.GetAbsolutePath("/uploads") + "/";
                    if (!Directory.Exists(UploadPath))
                    {
                        Directory.CreateDirectory(UploadPath);
                    }
                }

                var TargetFullName = Path.Combine(UploadPath, Folder) + "\\" + filename;
                File.WriteAllBytes(TargetFullName, data);
                
                return true;

            }
            catch (StorageException ex)
            {
                Console.WriteLine("Error returned from the service: {0}", ex.Message);
                LogHelpers.source = MethodBase.GetCurrentMethod().DeclaringType.Name;
                LogHelpers.message = ex.Message;
                LogHelpers.user = "System";
                LogHelpers.WriteLog();
                return false;
            }

        }
    }
}