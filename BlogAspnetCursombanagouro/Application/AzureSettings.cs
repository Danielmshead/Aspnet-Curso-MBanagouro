using System;
using System.Configuration;

namespace BlogAspnetCursombanagouro.Application
{
    public class AzureSettings
    {
        public static string BlobContainerName
        {
            get { return ConfigurationManager.AppSettings["AzureSettings.BlobContainerName"] ?? String.Empty; }
        }

        public static string BlobUrl
        {
            get { return ConfigurationManager.AppSettings["AzureSettings.BlobUrl"] ?? String.Empty; }
        }

        public static string StorageConnectionString
        {
            get { return ConfigurationManager.AppSettings["AzureSettings.StorageConnectionString"] ?? String.Empty; }
        }
    }
}