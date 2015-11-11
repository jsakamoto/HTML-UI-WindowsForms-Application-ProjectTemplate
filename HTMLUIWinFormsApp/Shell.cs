using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HTMLUIWinFormsApp.Models;

namespace HTMLUIWinFormsApp
{
    public class Shell
    {
        private Form _MainForm;

        public Shell(Form mainForm)
        {
            _MainForm = mainForm;
        }

        public SampleDocModel openFile()
        {
            var openFileDlg = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "text (*.txt)|*.txt|All files (*.*)|*.*"
            };
            var result = openFileDlg.ShowDialog(_MainForm);
            if (result != DialogResult.OK) return null;

            var doc = new SampleDocModel
            {
                filePath = openFileDlg.FileName,
                content = File.ReadAllText(openFileDlg.FileName)
            };

            return doc;
        }

        public SampleDocModel saveFile(dynamic doc)
        {
            var resultDoc = new SampleDocModel
            {
                filePath = doc.filePath,
                content = doc.content
            };

            if (resultDoc.filePath == "")
            {
                var saveFileDlg = new SaveFileDialog
                {
                    CheckPathExists = true,
                    Filter = "text (*.txt)|*.txt|All files (*.*)|*.*"
                };
                var result = saveFileDlg.ShowDialog(_MainForm);
                if (result != DialogResult.OK) return null;

                resultDoc.filePath = saveFileDlg.FileName;
            }

            File.WriteAllText(resultDoc.filePath, resultDoc.content);
            return resultDoc;
        }
    }
}
