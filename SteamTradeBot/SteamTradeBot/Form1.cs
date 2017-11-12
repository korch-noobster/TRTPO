using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SteamTradeBot
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Sell(object sender, DoWorkEventArgs e)
       {


           IWebElement SteamContainer = Browser.FindElement(By.ClassName("inventory_ctn"));

           int CardsProcessed = 0;
           bool FirstSell = true;


           List<IWebElement> Items = SteamContainer.FindElements(By.ClassName("itemHolder")).ToList();
           for (int i = 0; i < Items.Count; i++)
           {

               if (backgroundWorker1.CancellationPending) return;

               if (Items[i].GetAttribute("style") == "")
               {
                   System.Threading.Thread.Sleep(2000);
                    IWebElement ItemBtn = null;
                    ItemBtn = Items[i];
                    Actions ItemClick = new Actions(Browser);
                    ItemClick.MoveToElement(ItemBtn).Click().Perform();
                   // Items[i].Click();

                   String DivText = "";
                   IWebElement SellBtn = null;

                   System.Threading.Thread.Sleep(1000);
                   List<IWebElement> SellDivs = Browser.FindElements(By.ClassName("item_market_actions")).ToList();
                   for (int j = 0; j < SellDivs.Count; j++)
                   {
                       if (SellDivs[j].Displayed)
                       {
                           DivText = SellDivs[j].Text;
                           SellBtn = SellDivs[j].FindElement(By.CssSelector(".item_market_action_button.item_market_action_button_green"));
                       }
                   }

                   String priceStr = System.Text.RegularExpressions.Regex.Match(DivText, @"[0-9]+\,?[0-9]*").Value;
                   float Price = Single.Parse(priceStr) + (float)PriceChange.Value;


                   Actions SellClick = new Actions(Browser);
                   SellClick.MoveToElement(SellBtn).Click().Perform();

                   //SellBtn.Click();
                   System.Threading.Thread.Sleep(2000);

                   if (FirstSell)
                   {
                       Browser.FindElement(By.Id("market_sell_dialog_accept_ssa")).Click();
                       FirstSell = false;
                   }

                   Browser.FindElement(By.Id("market_sell_buyercurrency_input")).SendKeys(Price.ToString());
                   System.Threading.Thread.Sleep(1000);
                   Browser.FindElement(By.Id("market_sell_dialog_accept")).Click();
                   System.Threading.Thread.Sleep(1000);
                   Browser.FindElement(By.Id("market_sell_dialog_ok")).Click();

                   System.Threading.Thread.Sleep(3000);




                   Browser.FindElement(By.CssSelector(".newmodal_buttons .btn_grey_white_innerfade.btn_medium")).Click();

                   CardsProcessed++;
                   if (CardsProcessed == 25)
                   {
                       CardsProcessed = 0;
                       Browser.FindElement(By.Id("pagebtn_next")).Click();
                       System.Threading.Thread.Sleep(2000);
                   }
               }
           }



       }
        private void OpenBrowser_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://store.steampowered.com");
           
      
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }

  
        private void Stop_selling_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void PriceChange_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Start_selling_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
