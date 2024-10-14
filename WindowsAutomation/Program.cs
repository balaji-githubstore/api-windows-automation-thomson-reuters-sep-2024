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
    public class Program
    {
        static void Main(string[] args)
        {
            Application app = Application.Launch("notepad.exe");

            Window npwindow = app.GetMainWindow(new UIA3Automation());
            Console.WriteLine(npwindow.Title);

            //send the text in text editor
            //npwindow.FindFirstByXPath("//*[@Name='Text Editor']").AsTextBox().Click();
            //npwindow.FindFirstByXPath("//*[@Name='Text Editor']").AsTextBox().Enter("hello");

            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            AutomationElement ele = Retry.Find(() => npwindow.FindFirstDescendant(cf.ByName("Text Editor")).DrawHighlight(), new RetrySettings() { IgnoreException = true, Timeout = TimeSpan.FromSeconds(60) });
            ele.Click();
            ele.AsTextBox().Enter("hello");


            //npwindow.FindFirstByXPath("//MenuItem[@Name='File']").Click();

            //npwindow.FindFirstByXPath("//*[@Name='Exit']").Click();
            //ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            //AutomationElement ele = Retry.Find(() => npwindow.FindFirstDescendant(cf.ByName("Exit")).DrawHighlight(), 
            //    new RetrySettings() { IgnoreException = true, Timeout = TimeSpan.FromSeconds(60) });
            //ele.Click();

            //click on don't save
            //npwindow.FindFirstByXPath("//Button[@Name=\"Don't Save\"]").Click();

            //  npwindow.FindFirstByXPath("//MenuItem[@Name='File']").AsMenuItem().Click();

            FlaUI.Core.AutomationElements.Menu _menu = npwindow.FindFirstDescendant(cf.Menu()).AsMenu();

            MenuItem _menuItem = _menu.Items["MenuBar"];
            _menuItem.DrawHighlight();
            _menuItem = _menuItem.Invoke();


        }

    }
}
