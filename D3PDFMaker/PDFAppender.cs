using System;
using System.IO;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace D3PDFMaker
{
    public class PDFAppend
    {
        private string srcpath;
        private string tmppath;

        private PdfReader pdfReader;
        private Document document;
        private FileStream fs;
        private PdfWriter writer;

        private int pageRotation;

        // コンストラクタ::必要なファイルを開く
        public PDFAppend(string srcPDF)
        {
            this.srcpath = srcPDF;
            this.tmppath = Path.GetTempFileName();

            pdfReader = new PdfReader(this.srcpath);
            var size = pdfReader.GetPageSizeWithRotation(1);
            pageRotation = pdfReader.GetPageRotation(1);
            document = new Document(size);
            fs = new FileStream(this.tmppath, FileMode.Create, FileAccess.Write);
            writer = PdfWriter.GetInstance(document, fs);
            document.Open();
        }

        // テンプレートをコピーする
        public PdfContentByte CopyTemplate()
        {
            var pdfContentByte = writer.DirectContent;
            var page = writer.GetImportedPage(pdfReader, 1);

            if (pageRotation == 90)
                pdfContentByte.AddTemplate(page, 0, -1, 1, 0, 0, pdfReader.GetPageSizeWithRotation(1).Height);
            else if (pageRotation == 180)
                pdfContentByte.AddTemplate(page, -1, 0, 0, -1, pdfReader.GetPageSizeWithRotation(1).Width, pdfReader.GetPageSizeWithRotation(1).Height);
            else if (pageRotation == 270)
                pdfContentByte.AddTemplate(page, 0, 1, -1, 0, pdfReader.GetPageSizeWithRotation(1).Width, 0);
            else
                pdfContentByte.AddTemplate(page, 1, 0, 0, 1, 0, 0);

            return pdfContentByte;
        }

        // PDF形式の画像をコピーする
        public PdfContentByte CopyPDFImg(PdfContentByte pdfContentByte, string PDFImg, float x, float y)
        {
            PdfReader img = new PdfReader(PDFImg);
            var page = writer.GetImportedPage(img, 1);
            pdfContentByte.AddTemplate(page, x, y);
            return pdfContentByte;
        }

        // 指定座標・フォントでテキストを追記する
        public void Append(ref PdfContentByte pdfContentByte, string text,
                          float x, float y, float wideBox, float fontSize, string FONT, Color fontcolor, string isVertical, int alignment = 0)
        {
            if(isVertical == "Identity-H") {
                SetFontH(ref pdfContentByte, FONT, fontSize, text, wideBox, fontcolor);
                ShowTextH(pdfContentByte, x, y + 1, text, alignment);
            }
            else
            {
                SetFontV(ref pdfContentByte, FONT, fontSize, text, wideBox, fontcolor, x, y);
                ShowTextV(pdfContentByte, text.HanToZen(), x, y, fontSize, wideBox);
            }
        }

        // クラスを閉じる
        public void Close()
        {
            document.Close();
            fs.Close();
            writer.Close();
            pdfReader.Close();
        }

        // 一時ファイルに出力しているデータを移動させる
        public void Save(string dstPDF)
        {
            if (File.Exists(dstPDF))
            {
                File.Delete(dstPDF);
            }
            File.Move(this.tmppath, dstPDF);
        }

        public string GetTempPathName()
        {
            return this.tmppath;
        }

        // PDFに文字情報を書き込む（横）
        public void ShowTextH(PdfContentByte pdfContentByte, float x, float y, string text, int alignment = Element.ALIGN_LEFT, float rotation = 0)
        {
            pdfContentByte.BeginText();
            pdfContentByte.ShowTextAligned(alignment, text, x, y, rotation);
            pdfContentByte.EndText();
        }

        // フォント・スケールを設定する（横）
        public void SetFontH(ref PdfContentByte pdfContentByte, string fontname, float fontsize, string text, float boxWidth, Color fontcolor)
        {
            var bf = BaseFont.CreateFont(fontname, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            pdfContentByte.SetFontAndSize(bf, fontsize);
            float hScale = this.GetHorizontalScaling(bf, text, fontsize, boxWidth);
            pdfContentByte.SetHorizontalScaling(hScale);
            BaseColor newcolor = new BaseColor(fontcolor.R, fontcolor.G, fontcolor.B);
            pdfContentByte.SetColorFill(newcolor);
        }

        // 指定幅に収まるよう長体をかけて調整する用の値を取得する（横）
        public float GetHorizontalScaling(BaseFont bf, string text, float fontsize, float boxWidth)
        {
            var widthPoint = bf.GetWidthPoint(text, fontsize);
            if (boxWidth > widthPoint) return 100f;
            else return boxWidth / widthPoint * 100;
        }

        // PDFに文字情報を書き込む（縦）
        public void ShowTextV(PdfContentByte pdfContentByte, string text, float x, float y, float fontSize, float boxHeight)
        {
            pdfContentByte.BeginText();
            float vScale = GetVerticalScaling(text, fontSize, boxHeight);
            pdfContentByte.SetTextMatrix(1, 0, 0, vScale, x, y);
            pdfContentByte.ShowText(text);
            pdfContentByte.EndText();
        }

        //　フォント・スケールを設定する（縦）
        public void SetFontV(ref PdfContentByte pdfContentByte, string fontname, float fontsize, string text, float boxHeight, Color fontcolor,
                             float x, float y, int alignment = Element.ALIGN_LEFT, float rotation = 0)
        {
            var bf = BaseFont.CreateFont(fontname, BaseFont.IDENTITY_V, BaseFont.EMBEDDED);
            pdfContentByte.SetFontAndSize(bf, fontsize);            
            BaseColor newcolor = new BaseColor(fontcolor.R, fontcolor.G, fontcolor.B);
            pdfContentByte.SetColorFill(newcolor);
        }

        // 指定幅に収まるよう長体をかけて調整する用の値を取得する（縦）
        public float GetVerticalScaling(string text, float fontSize, float boxHeight)
        {
            float heightPoint = text.Length * fontSize;
            if (boxHeight > heightPoint) return 1f;
            else return boxHeight / heightPoint;
        }

        public static int GetPageNum(string pdffile)
        {
            PdfReader pdfReader = new PdfReader(pdffile);
            int numberOfPages = pdfReader.NumberOfPages;
            pdfReader.Close();
            return numberOfPages;
        }
    }
}
