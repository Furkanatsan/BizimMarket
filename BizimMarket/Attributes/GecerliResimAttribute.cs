using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizimMarket.Attributes
{
    public class GecerliResimAttribute:ValidationAttribute
    {
        public int ResimMaxMb { get; set; } = 1;

        public override bool IsValid(object value)//IFormFile turunde bir resim gelicek
        {
            if (value!= null)
            {
                IFormFile resim = (IFormFile)value;
                if (!resim.ContentType.StartsWith("image/"))
                {
                    ErrorMessage="Geçersiz resim dosyası eklediniz.";
                    return false;
                }
                else if (resim.Length > ResimMaxMb * 1024 * 1024)
                {
                    ErrorMessage="Resim boyutu "+ResimMaxMb.ToString()+" Mb'dan nüyük olamaz.";
                    return false;
                }

            }
            else
            {
                //ErrorMessage="Resim Eklemediniz.";
                return true;//dersek resim zorunlu olmaz
            }
            return true;
        }
    }
}
