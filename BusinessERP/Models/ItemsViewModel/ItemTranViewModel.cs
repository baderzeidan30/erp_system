﻿using System;

namespace BusinessERP.Models.ItemsViewModel
{
    public class ItemTranViewModel
    {
        public Int64 ItemId { get; set; }
        public int TranQuantity { get; set; }
        public bool IsAddition { get; set; }
        public string ActionMessage { get; set; }
        public string CurrentUserName { get; set; }
        public Int64 TenantId { get; set; }
    }
}