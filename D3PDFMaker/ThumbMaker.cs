using System.IO;

namespace D3PDFMaker
{
    public class ThumbMaker
    {
        public string Generate(string pdfFile)
        {
            string tmpPath = System.IO.Path.GetTempFileName();
            string pngPath = tmpPath + "-000001.png";
            string _tmpPath = '"' + tmpPath + '"';
            string pdftopng = '"' + System.IO.Path.Combine(form1.binPath, "pdftopng.exe") + '"';

            string tmpPdf = convertToTempFile(pdfFile);
            string _pdfFile = '"' + tmpPdf + '"';

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

            try { 
                File.Delete(tmpPath);
                File.Delete(tmpPdf);
                File.Move(pngPath, tmpPath);
            }
            catch (FileNotFoundException)
            {
                return "";
            }

            return tmpPath;
        }

        private string convertToTempFile(string file)
        {
            string tmpPath = System.IO.Path.GetTempFileName();
            File.Copy(file, tmpPath, overwrite: true);
            return tmpPath;
        }
    }
}