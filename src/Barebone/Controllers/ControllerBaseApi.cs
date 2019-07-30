using System;
using System.Collections.Generic;
using System.Text;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Barebone.Controllers
{
    [ApiController]
    public abstract class ControllerBaseApi : ControllerBase
    {
        public ControllerBaseApi(IStorage storage) : base(storage)
        {
        }
    }
}
