// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Barebone.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected IStorage Storage { get; private set; }

        public ControllerBase(IStorage storage)
        {
            this.Storage = storage;
        }

        protected string GetCurrentUserName()
        {
            var claim = (System.Security.Claims.ClaimsIdentity)User.Identity;
            var name = claim.FindFirst("name");

            return name == null ? "Unknown" : name.Value;
        }
    }
}