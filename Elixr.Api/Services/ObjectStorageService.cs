using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System;
using System.Security.Cryptography;
using System.Text;
using Amazon.S3.Model;

namespace Elixr2.Api.Services
{
    public class ObjectStorageService
    {
        private readonly string s3AccessKeyId;
        private readonly string s3SecretKey;
        public ObjectStorageService(string s3AccessKeyId, string s3SecretKey)
        {
            this.s3AccessKeyId = s3AccessKeyId;
            this.s3SecretKey = s3SecretKey;
        }
        public async Task SaveStream(Stream stream, string path)
        {
            Amazon.S3.AmazonS3Client s3Client = new Amazon.S3.AmazonS3Client(s3AccessKeyId, s3SecretKey, Amazon.RegionEndpoint.USWest2);
            var signatureRequest = new GetPreSignedUrlRequest
            {
                BucketName = "elixr-assets",
                Key = path,
                Verb = Amazon.S3.HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };;

            var signedUrl = s3Client.GetPreSignedURL(signatureRequest);
            using(var client = new HttpClient())
            {
                var streamContent = new StreamContent(stream);
                await client.PutAsync(signedUrl, streamContent);
            }
        }

    }
}