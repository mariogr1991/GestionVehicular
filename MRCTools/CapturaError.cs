using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.IO;


namespace MRCTools
{
    class CapturaError
    {
        public void Log(string mensaje)
        {
            string path = @"C:\Log\GestionVehicular\" + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " " + mensaje);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    AgregarLinea(mensaje, sw);
                }
            }

        }

        public  void AgregarLinea(string mensaje, TextWriter w)
        {
            w.WriteLine(DateTime.Now.ToString() + " " + mensaje);
        }
    }
}
