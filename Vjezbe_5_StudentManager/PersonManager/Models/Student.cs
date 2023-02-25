using System.Windows.Media.Imaging;
using Zadatak.Utils;

namespace Zadatak.Models
{
    public class Student
    {
        public int IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }

        public int YearOfStudy { get; set; }

        public override string ToString()
        {
            return $"Student - {this.FirstName}, Year Of Study - {this.YearOfStudy}";
        }

    }
}
