using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Texts;

namespace Sel_CSharp002.FileFolderHelper
{
    public class PdfHelper
    {
        #region PDF functionality
        public bool VerifyTextInPdf(string fileName,string stringToBeFound,int fromPageNo = 0)
        {
            bool IsFound = false;
            try
            {
                string pdfText = ExtractTextFromPdf(fileName, fromPageNo);
                IsFound = pdfText.Contains(stringToBeFound);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IsFound;
        }
        public string ExtractTextFromPdf(string filePath,int fromPageNo = 0)
        {
            string strText = String.Empty;
            PdfDocument doc = new PdfDocument(filePath);
            if (fromPageNo == 0)
            {
                foreach (PdfPageBase page in doc.Pages)
                {
                    strText += page.ExtractText();
                }
            }
            else
            {
                strText += doc.Pages[fromPageNo - 1].ExtractText();
            }
            return strText;
        }
        #endregion
    }
}
