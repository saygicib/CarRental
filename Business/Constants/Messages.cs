using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarInvalid = "Araba eklenemedi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string CarMaintenanceTime = "Arabalar listelenemedi. Sistem bakımda.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorInvalid = "Renk eklenemedi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorMaintenanceTime = "Renkler listelenemedi. Sistem bakımda.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandInvalid = "Marka eklenemedi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandListed = "Marka listelendi.";
        public static string BrandNotFound = "Marka bulunamadı.";
        public static string BrandMaintenanceTime = "Markalar listelenemedi. Sistem bakımda.";
        public static string Error = "İstek gerçekleştirilemedi.";
        public static string Successful = "İşlem başarılı.";
        public static string ImageLimitExceded = "Resim limiti doldu";
        public static string ImageAdded = "Resim eklendi.";
        public static string ImageDeleted = "Resim silindi.";
        public static string ImageUpdate = "Resim güncellendi.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
