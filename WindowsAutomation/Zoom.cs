using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutomation
{
    public class Zoom
    {
        static void Main(string[] args)
        {
            Application app = Application.Launch(@"C:\Users\Balaji_Dinakaran\AppData\Roaming\Zoom\bin\Zoom.exe");
            Thread.Sleep(3000);

            Window zoomWindow= app.GetMainWindow(new UIA3Automation());

            //Window zoomWindow = app.GetAllTopLevelWindows(new UIA3Automation()).FirstOrDefault(w => w.Name.ToLower().Contains("Zoom workplace"));

            Console.WriteLine(zoomWindow.Title);
            Console.WriteLine(zoomWindow.Name);

            //Button[@Name='Sign in']
            zoomWindow.FindFirstByXPath("//Button[@Name='Sign in']").AsButton().Click();

            //Enter your email
            //Thread.Sleep(3000);
            ConditionFactory cf=new ConditionFactory(new UIA3PropertyLibrary());
            //zoomWindow.FindFirstDescendant(cf.ByName("Enter your email")).AsTextBox().Enter("jjjj");

            Thread.Sleep(3000);
            AutomationElement ele = Retry.Find(() => zoomWindow.FindFirstDescendant(cf.ByName("Enter your password")).DrawHighlight(), new RetrySettings() { IgnoreException = true, Timeout = TimeSpan.FromSeconds(60) });
            ele.Click();
            ele.AsTextBox().Enter("hello");

            //zoomWindow.FindFirstByXPath("//*[@Name='Enter your password']").AsTextBox().Focus();
            //oomWindow.FindFirstByXPath("//*[@Name='Enter your password']").AsTextBox().Enter("hello");

            //Enter your password
            //Sign in


            // app.Close();
            //will start at 9:55
        }
    }
}
