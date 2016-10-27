using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Services
{
    public interface ICustomContentFileService
    {
        bool HasFile(string userId, int customContentId);
        string GetUserUploadPath(string userId);
        bool HasUserUploadFolder(string userId);
        void CreateUserUploadFolder(string userId);
        void RemoveUserFiles(string userId, string name);
        void CreateUserUploadFolderIfNotExist(string userId);
    }

    public class CustomContentFileService : ICustomContentFileService
    {
        private const string UploadFolderRelativePath = "uploads/custom-content";
        private readonly IHostingEnvironment _environment;

        private string UploadFolderFullPath
        {
            get
            {
                var uploadFolderFullPath = Path.Combine(_environment.WebRootPath, UploadFolderRelativePath);

                return uploadFolderFullPath;
            }
        }

        public CustomContentFileService(
            IHostingEnvironment environment
            )
        {
            _environment = environment;
        }

        public string GetUserUploadPath(string userId)
        {
            var userUploadFullPath = Path.Combine(UploadFolderFullPath, userId);

            return userUploadFullPath;
        }

        public bool HasUserUploadFolder(string userId)
        {
            var path = GetUserUploadPath(userId);
            var hasUserUploadFolder = Directory.Exists(path);

            return hasUserUploadFolder;
        }

        public void CreateUserUploadFolder(string userId)
        {
            var path = GetUserUploadPath(userId);
            Directory.CreateDirectory(path);
        }

        public void CreateUserUploadFolderIfNotExist(string userId)
        {
            var hasUserUploadFolder = HasUserUploadFolder(userId);
            if (!hasUserUploadFolder)
                CreateUserUploadFolder(userId);
        }

        public bool HasFile(string userId, int customContentId)
        {
            var userUploadPath = GetUserUploadPath(userId);

            if (!Directory.Exists(userUploadPath))
                return false;

            var userUploadDirectory = new DirectoryInfo(userUploadPath);
            var hasFileByNameWithoutException = userUploadDirectory.GetFiles()
                .Any(f => Path.GetFileNameWithoutExtension(f.FullName) == customContentId.ToString());

            return hasFileByNameWithoutException;
        }

        public void RemoveUserFiles(string userId, string name)
        {
            var userUploadPath = GetUserUploadPath(userId);
            var userUploadFolder = new DirectoryInfo(userUploadPath);
            var existingFiles = userUploadFolder.GetFiles()
                .Where(f => Path.GetFileNameWithoutExtension(f.FullName) == name);

            foreach (var existingFile in existingFiles)
                File.Delete(existingFile.FullName);
        }

    }
}
