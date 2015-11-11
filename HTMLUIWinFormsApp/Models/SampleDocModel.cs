using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUIWinFormsApp.Models
{
    [ComVisible(true)]
    public class SampleDocModel
    {
        public string filePath { get; set; }

        public string content { get; set; }

        public SampleDocModel()
        {
        }
    }
}
