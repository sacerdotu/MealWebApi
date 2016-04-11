﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ProviderMenuItemEntity
    {
        public long ProviderMenuItemID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int MenuItemTypeID { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public DateTime Date { get; set; }
    }
}
