using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DCMLIB
{
    class DicomDictionaryEntry
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Keyword { get; set; }
        public string VR { get; set; }
        public string VM { get; set; }
    }

     class DicomDictionary
    {
        public  List<DicomDictionaryEntry> DDE = new List<DicomDictionaryEntry>();  //静态变量，对象数组，存储文件的每一行
        public DicomDictionary(string Filename)   //加载方法
        {
            var path = Path.Combine(@"F:\textfiles\", Filename);  //文件路径
            var files = File.ReadLines(path);   //读文件到files中
            foreach (var itrm in files)   //一行一行遍历
            {
                string[] s = ((String)itrm).Split('\t');
                DicomDictionaryEntry DDEY = new DicomDictionaryEntry();
                DDEY.Tag = s[0];
                DDEY.Name = s[1];
                DDEY.Keyword = s[2];
                DDEY.VR = s[3];
                DDEY.VM = s[4];
                DDE.Add(DDEY);  //遍历一行，放入DDE中
            }

        }
        public DicomDictionaryEntry GetEntry(ushort gtag,ushort etag)  //搜索方法
        {
            string s ="\"(" + gtag.ToString("X4") + "," +  etag.ToString("X4") + ")\"";
            DicomDictionaryEntry DDEYother = new DicomDictionaryEntry();
            foreach (DicomDictionaryEntry obj in this.DDE) //遍历搜索
            {
                if (obj.Tag == s)
                {
                    DDEYother = obj;
                    break;
                }

            }
            return DDEYother;
        }
    }
}
