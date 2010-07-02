using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Ant.Models.Common;

namespace Ant.Models
{
    public class ResetPasswordModel
    {
        public string k { get; set; }
        public string username { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }

        public bool Validate()
        {
            return ValidateResetHash(k, username);
        }

        public static bool ValidateResetHash(string hash, string username)
        {
            string key = string.Empty;
            try
            {
                key = Encryptor.Decrypt(hash);
            }
            catch
            {
                return false;
            }
            if (string.IsNullOrEmpty(key)) return false;
            int i = key.IndexOf('|');
            if (i < 0 || i == key.Length - 1) return false;

            var parseUsername = key.Substring(0, i);
            if (username != parseUsername) return false;

            var parseDateString = key.Substring(i + 1);
            DateTime parseDate;
            if(!DateTime.TryParse(parseDateString, out parseDate)) return false;

            if (DateTime.Now.AddDays(-2) > parseDate) return false;

            return true;
        }

        public static string CookResetHash(string userName)
        {
            var date = DateTime.Now.ToString();
            return Encryptor.Encrypt(string.Format("{0}|{1}", userName, date));
        }
    }
}