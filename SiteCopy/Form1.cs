using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace SiteCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CopyText_Click(object sender, EventArgs e)
        {
            SiteBody.Text = null;
            Button_change();
            SplitText.LoadText(Link.Text);

        }
        public void Button_change()
        {
            CopyText.Enabled = !CopyText.Enabled;
        }
    }
    public class SplitText
    {
        static Form1 form = Application.OpenForms[0] as Form1;
        public static void  LoadText(string link)
        {
            try
            {
                WebBrowser wb = new WebBrowser();
                wb.ScriptErrorsSuppressed = true;
                wb.DocumentCompleted +=
                    new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                wb.Navigate(link);
            }
            catch (Exception msg) 
            {
                Log.Write(msg);
                MessageBox.Show(msg.ToString());
            }
        }
        private static void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try { 
            WebBrowser wb = (WebBrowser)sender;
            wb.Document.ExecCommand("SelectAll", false, null);
            wb.Document.ExecCommand("Copy", false, null);
            form.Button_change();
            wb.Dispose();
            Paircount();
            }
            catch (Exception msg)
            {
                Log.Write(msg);
                MessageBox.Show(msg.ToString());
            }
        }
        private static void Paircount()
        {
            try { 
            var res = Textsplit(Clipboard.GetText().ToUpper());
            Clipboard.Clear();
            foreach (var pair in res.OrderByDescending(pair => pair.Value))
                form.SiteBody.Text +=
                    (pair.Key + " : " + pair.Value + "\n"); }
            catch (Exception msg) 
            {
                Log.Write(msg);
                MessageBox.Show(msg.ToString());
            }
        }
        private static Dictionary<string, int> Textsplit(string text)
        {
            char[] splitter = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

            var res = new Dictionary<string, int>();

            foreach (var word in text.Split(splitter).Skip(1))
            {
                var count = 0;
                if (WordCheck(word))
                {
                    res.TryGetValue(word, out count);
                    res[word] = count + 1;
                }
            }
            
            return res;
        }
        private static bool WordCheck(string word)
        {
            string[] unicwords = new string[] { "РАЗРАБОТКА", "ПРОГРАММНОГО", "ОБЕСПЕЧЕНИЯ" };
            foreach (var uword in unicwords)
            {
                if (uword == word)
                    return true;
            }
            return false;
        }
    }
    public class Log
    {
        private static object sync = new object();
        public static void Write(Exception ex)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
            }
        }
    }
}
