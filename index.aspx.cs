using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Photo_Resize
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filename = upFile.FileName ;
            string path = Path.Combine(HttpContext.Current.Request.MapPath("."), "Photos");
            
            // Enregistre la photo originale
            using var stream = new FileStream(Path.Combine(path, filename), FileMode.Create);
            upFile.FileContent.CopyTo(stream);

            int width = int.Parse(Width.Text);
            int height = int.Parse(Height.Text);
            // Enregistre la photo modifiée
            ReSize(stream, Path.Combine(path, filename), width, height);
        }
        public void ReSize(Stream stream, string adresse, int Width, int Height)
        {
            // encode en jpg et en profondeur couleur de 24 bits
            var myImageCodecInfo = GetEncoderInfo("image/jpeg");
            var myEncoder = Encoder.ColorDepth;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 24L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            // utilise un Bitmap avec les nouvelles dimensions pour recréer l'image en .jpg
            using Bitmap bitmap = new Bitmap(Width, Height);
            using Graphics graphic = Graphics.FromImage(bitmap);
            using (System.Drawing.Image image = System.Drawing.Image.FromStream(stream))
            {
                Rectangle rectangle = new Rectangle(0, 0, Width, Height);
                graphic.DrawImage(image, rectangle);
            }
            // copie le fichier redimensionné sur le serveur
            bitmap.Save(adresse + "_ReSize.jpg", myImageCodecInfo, myEncoderParameters);
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

    }
}