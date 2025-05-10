

using Azure.Messaging;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace MovieProject.Service.Helpers;

public sealed class CloudinaryHelper : ICloudinaryHelper
{
    private readonly Cloudinary _cloudinary;

    private readonly Account _account;
    private readonly CloudinarySettings _settings;

    public CloudinaryHelper(IOptions<CloudinarySettings> clounOtions)
    {
        _settings=clounOtions.Value;    
        _account=new Account(_settings.CloudName,_settings.ApiKey,_settings.ApiSecret);

        _cloudinary = new Cloudinary(_account);
    }

    public string UploadImage(IFormFile formFile, string imageDirectory)
    {
        var imageUploadResult = new ImageUploadResult();

        if (formFile.Length>0)
        { 
            using var stream =formFile.OpenReadStream();

            var upLoadParams = new ImageUploadParams
            {
                File = new FileDescription(formFile.Name, stream),
                Folder = imageDirectory
            };
            imageUploadResult=_cloudinary.Upload(upLoadParams);

            string url = _cloudinary.Api.UrlImgUp.BuildUrl(imageUploadResult.PublicId);
            return $"{url}";

        }
        return string.Empty;
    }
}
