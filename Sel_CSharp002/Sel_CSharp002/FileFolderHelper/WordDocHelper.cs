using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.FileFolderHelper
{
    public class WordDocHelper
    {
        public void ConvertDocToPdf(string fullFilePath,string FullPathAfterConversion)
        {
            try
            {
                Document doc = new Document();
                doc.LoadFromFile(fullFilePath);
                doc.SaveToFile(FullPathAfterConversion, FileFormat.PDF);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool VerifyTextInWordDoc(string fullFilePath,string TextToBeFound)
        {
            bool IsFound = false;
            try
            {
                Document doc = new Document();
                doc.LoadFromFile(fullFilePath);
                TextSelection text=doc.FindString(TextToBeFound, true, true);
                IsFound = text.Count > 0 ? true:false;

            }catch(Exception ex)
            {
                throw ex;
            }return IsFound;
        }
        public bool GetSectionData(Section section,String TextToBeFound)
        {
            bool IsFound = false;

            foreach(Table table in section.Tables)
            {
                string text = string.Empty;
                for (int i = 0; i<table.Rows.Count; i++){
                    for(int j = 0; j < table.Rows[i].Cells.Count; j++)
                    {
                        TableCell cell=table.Rows[i].Cells[j];
                        foreach(Paragraph para in cell.Paragraphs)
                        {
                            text += para.Text;
                        }
                    }
                }
                IsFound = text.Contains(TextToBeFound);
                if (IsFound) break;
            }
            return IsFound;
        }
        
    }
}
