using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.ErrorModel
{
    public sealed record CustomError(string Code, string Message)
    {

    }
}
