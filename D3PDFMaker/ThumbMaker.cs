using System.IO;

namespace D3PDFMaker
{
    public class ThumbMaker
    {
        string binPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public string Generate(string pdfFile)
        {
            string tmpPath = System.IO.Path.GetTempFileName();
            string pngPath = tmpPath + "-000001.png";
            string _tmpPath = '"' + tmpPath + '"';
            string rcsPath = System.IO.Path.Combine(binPath, "resources");
            string pdftopng = '"' + System.IO.Path.Combine(rcsPath, "pdftopng.exe") + '"';
            string _pdfFile = '"' + pdfFile + '"';

            var extProcess = new System.Diagnostics.Process();
            extProcess.StartInfo.FileName = pdftopng;
            // 1ページ目だけ読み込む
            extProcess.StartInfo.Arguments = " -f 1";
            extProcess.StartInfo.Arguments += " -l 1";
            // 解像度を指定
            extProcess.StartInfo.Arguments += " -r 100";

            extProcess.StartInfo.Arguments += " " + _pdfFile;
            extProcess.StartInfo.Arguments += " " + _tmpPath;

            extProcess.StartInfo.CreateNoWindow = true;
            extProcess.StartInfo.UseShellExecute = false;
            extProcess.Start();
            extProcess.WaitForExit();
            extProcess.Dispose();

            File.Delete(tmpPath);
            File.Move(pngPath, tmpPath);

            return tmpPath;
        }
    }
}