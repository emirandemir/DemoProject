﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductInValied = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductCountOfCategoryError = "Bir Kategoride En Fazla 10 Ürün Bulunabilir";
        public static string ProductNameAlreadyExists ="Zaten bu isimde başka bir ürün var";
        internal static string CategoryLimitExceted="Kategori Limiti Aşıldığı için yeni ürün eklenemiyor";
    }
}
