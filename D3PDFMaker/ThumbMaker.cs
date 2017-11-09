using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;

namespace D3PDFMaker
{
    public class ThumbMaker
    {
        private GhostscriptVersionInfo dll = null;
        private GhostscriptRasterizer _rasterizer = null;
        private int pageCount = 0;

        public string[] Generate(string pdfFile, int dpi = 96, bool multi = false)
        {
            string binPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string gsDllPath = Path.Combine(binPath, "gsdll32.dll");
            dll = new Ghostscript.NET.GhostscriptVersionInfo(new Version(9, 2, 2), gsDllPath, string.Empty,
                                                             Ghostscript.NET.GhostscriptLicense.GPL);

            using (FileStream stream = new FileStream(pdfFile, FileMode.Open, FileAccess.Read))
            {
                _rasterizer = new GhostscriptRasterizer();
                _rasterizer.Open(stream, dll, false);

                if (multi) pageCount = _rasterizer.PageCount;
                else pageCount = 1;

                string[] tmpPathArr = new string[pageCount];

                for (int pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                {
                    string tmpPath = Path.GetTempFileName();
                    Image img = _rasterizer.GetPage(dpi, dpi, pageNumber);
                    img.Save(tmpPath, ImageFormat.Png);

                    tmpPathArr[pageNumber - 1] = tmpPath;
                }

                _rasterizer.Close();
                return tmpPathArr;
            }
        }
    }
}
