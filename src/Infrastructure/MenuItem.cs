// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Infrastructure
{
    public class MenuItem
    {
        public string Url { get; set; }
        public string Name { get; }
        public int Position { get; }

        public IList<MenuItem> SubMenus { get; }

        public MenuItem(string url, string name, int position, List<MenuItem> subMenus = null)
        {
            this.Url = url;
            this.Name = name;
            this.Position = position;
            
            this.SubMenus = subMenus ?? new List<MenuItem>();
        }
    }
}