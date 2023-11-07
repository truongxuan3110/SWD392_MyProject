using OnlineLearning.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineLearning.Utils
{
    public static class CommonUtil
    {
        public static string ConvertToBase64(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    // Chuyển đổi hình ảnh thành chuỗi Base64
                    string base64String = Convert.ToBase64String(imageBytes);
                   return "data:image/png;base64," + base64String; // Lưu hình ảnh dưới dạng chuỗi Base64 vào DTO
                }
            }
            return "";
        }
    }
}
