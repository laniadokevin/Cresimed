using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Interfaces;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using TestYourself.Core.Entities.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestYourself.Data.Repositories
{
    public class BufferedFileUploadLocalService : IBufferedFileUploadService
    {
        public bool UploadFile(IFormFile file,string date)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/images/questions/"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName.Replace(System.IO.Path.GetExtension(file.FileName), "") + date + System.IO.Path.GetExtension(file.FileName)), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
