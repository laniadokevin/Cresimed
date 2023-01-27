using System;
using System.Collections.Generic;
using System.Text;
using TestYourself.Core.Entities;
using System.Threading.Tasks;
using TestYourself.Core.Services;
using TestYourself.Core.Entities.Database;
using Microsoft.AspNetCore.Http;

namespace TestYourself.Core.Interfaces
{
    public interface IBufferedFileUploadService
    {
        bool UploadFile(IFormFile file, string date);
    }
}
