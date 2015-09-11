/*
 *用于保存文件的类
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *  
 */

using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace Compiler
{
    class OpaFile
    {
        public bool IsOpen=false;
        public bool IsModifid=false;
        private string file;
        private string filename;
        public string OpenFile()
        {
            
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Txt File|*.txt|All File|*.*";
            OFD.InitialDirectory = Application.StartupPath;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                file = System.IO.File.ReadAllText(OFD.FileName, Encoding.Default);
                IsOpen = true;
                filename = OFD.FileName;
                return file;
            }
            else
            {
                return null;
            }
        }
        public void SaveFile(string text)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Txt File|*.txt|All File|*.*";
            SFD.InitialDirectory = Application.StartupPath;
            if (IsOpen)
            {
                File.WriteAllText(filename, text);
            }
            else
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(SFD.FileName, text);
                }
                else
                {

                }
            }
        }
        public void SaveFileAs(string text)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Txt File|*.txt|All File|*.*";
            SFD.InitialDirectory = Application.StartupPath;
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFD.FileName, text);
            }
            else
            {

            }
        }
    }
}
