using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Application.Helpers
{
    public class UploadHerlper
    {
        public static MultipartFormDataContent CreateMultipartWithName(List<IFormFile> Files, string property)
        {
            try
            {
                var multiForm = new MultipartFormDataContent();

                foreach (var row in Files)
                {
                    var contentFile = row.OpenReadStream();

                    string ext = Path.GetExtension(row.FileName).ToLower();

                    ext = ext.Substring(1, ext.Length - 1);

                    var name = $"{ row.FileName }";

                    var file = new StreamContent(contentFile);

                    var imageContent = new ByteArrayContent(file.ReadAsByteArrayAsync().Result);

                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                    multiForm.Add(imageContent, property, name);
                }

                return multiForm;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
