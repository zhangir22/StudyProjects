using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;

namespace ExcelToWord
{
    class Program
    {
        private const string pathToWord = @"D:\ExcelToWord\Цыфра нумерации и найменования компании.docx";
        private const int maxColumn = 69;
        private const string nameCompany = @"D:\ExcelToWord\NameCompany.txt";
        private const string nameDirector = @"D:\ExcelToWord\NameDirector.txt";
        private const string excelData = @"D:\ExcelToWord\1 ДОРОЖНАЯ КАРТА ПРИВЛЕЧЕНИЯ ЗАКАЗЧИКОВ Нуркен2";
        static void Main(string[] args)
        {

            using (StreamReader d = new StreamReader(nameDirector, System.Text.Encoding.Default))
            {
                using (StreamReader c = new StreamReader(nameCompany, System.Text.Encoding.Default))
                {
                    string line;

                    List<string> names = new List<string>();
                    while ((line = d.ReadLine()) != null)
                    {

                        names.Add(line);
                    }

                    List<string> companies = new List<string>();

                    while ((line = c.ReadLine()) != null)
                    {
                        companies.Add(line);
                    }
                    for (int i = 0; i < maxColumn; i++) 
                    {
                      ReplaceTextDocx(names[i], companies[i]);
                        Thread.Sleep(1000);
                    }
                  
                }
            }

        }
        public static void ReplaceWordStub(string StubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: StubToReplace, ReplaceWith: text); //Ошибка
        }

        private static void ReplaceTextDocx(string nameDirector, string nameCompany)
        {
            File.Copy(pathToWord, @"D:\ExcelToWord\Files\" + nameCompany+".docx");
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;


            object fileName = @"D:\ExcelToWord\Files\" + nameCompany+".docx";
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;

            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);
            //Очищаем параметры поиска
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            //Задаём параметры замены и выполняем замену.
            object findText = "Фамилия Имя Руководителя";
            object replaceWith = nameDirector;
            object replace = 2;
            app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
            ref replace, ref missing, ref missing, ref missing, ref missing);



            
            app.Visible = false;
            //var wordApp = new Word.Application();


            //try
            //{
            //    var wordDocument = wordApp.Documents.Open(@"D:\ExcelToWord\Цыфра нумерации и найменования компании.docx");
            //    ReplaceWordStub("Фамилия Имя Руководителя", nameDirector, wordDocument);
            //    wordDocument.SaveAs($@"D:\ExcelToWord\Files\{nameCompany}.docx");
            //    Thread.Sleep(4000);
            //    wordDocument.Close();
            //    wordApp.Quit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}



        }





        private static void OutData()
        {
            using (StreamWriter n = new StreamWriter(nameDirector, false, System.Text.Encoding.Default))
            {
                using (StreamWriter w = new StreamWriter(nameCompany, false, System.Text.Encoding.Default))
                {
                    Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                    //Открываем книгу.                                                                                                                                                        
                    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(excelData, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    //Выбираем таблицу(лист).
                    Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                    ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
                    // Указываем номер столбца (таблицы Excel) из которого будут считываться данные.
                    int numCol = 4;

                    Microsoft.Office.Interop.Excel.Range usedColumn = ObjWorkSheet.UsedRange.Columns[numCol];

                    System.Array myvalues = (System.Array)usedColumn.Cells.Value;

                    string[] data = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();



                    int indexCompanyName = IndexOf(data, "ТОО Казцинк");
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (i >= indexCompanyName)
                        {
                            w.WriteLine(data[i]);
                        }
                        else
                        {

                        }
                    }
                    ////////////////////////////
                    numCol = 8;
                    usedColumn = ObjWorkSheet.UsedRange.Columns[numCol];
                    myvalues = (System.Array)usedColumn.Cells.Value;
                    data = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();
                    int indexDirectorName = IndexOf(data, "Контактное лицо");
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (i >= indexDirectorName)
                        {
                            n.WriteLine(data[i]);
                        }
                        else
                        {

                        }
                    }
                    ObjExcel.Quit();
                }
            }
        }
        private static int IndexOf(string[] array, string value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

