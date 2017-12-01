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

        public IWebDriver Browser1 { get => Browser; set => Browser = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        void accept(float Price)
        {
            Browser1.FindElement(By.Id("market_sell_buyercurrency_input")).SendKeys(Price.ToString());
            System.Threading.Thread.Sleep(1000);
            Browser1.FindElement(By.Id("market_sell_dialog_accept")).Click();
            System.Threading.Thread.Sleep(1000);
            Browser1.FindElement(By.Id("market_sell_dialog_ok")).Click();
            System.Threading.Thread.Sleep(3000);
            Browser1.FindElement(By.CssSelector(".newmodal_buttons .btn_grey_white_innerfade.btn_medium")).Click();
        }

        private void Sell(object sender, DoWorkEventArgs e)
       {


           IWebElement SteamContainer = Browser1.FindElement(By.ClassName("inventory_ctn"));

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
                    Actions ItemClick = new Actions(Browser1);
                    ItemClick.MoveToElement(ItemBtn).Click().Perform();
                   String DivText = "";
                   IWebElement SellBtn = null;
                   System.Threading.Thread.Sleep(1000);
                   List<IWebElement> SellDivs = Browser1.FindElements(By.ClassName("item_market_actions")).ToList();
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
                   Actions SellClick = new Actions(Browser1);
                   SellClick.MoveToElement(SellBtn).Click().Perform();
                   System.Threading.Thread.Sleep(2000);
                   if (FirstSell)
                   {
                       Browser1.FindElement(By.Id("market_sell_dialog_accept_ssa")).Click();
                       FirstSell = false;
                   }
                    accept(Price);
                   CardsProcessed++;
                   if (CardsProcessed == 25)
                   {
                       CardsProcessed = 0;
                       Browser1.FindElement(By.Id("pagebtn_next")).Click();
                       System.Threading.Thread.Sleep(2000);
                   }
               }
           }
       }
        private void OpenBrowser_Click(object sender, EventArgs e)
        {
            Browser1 = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser1.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            Browser1.Manage().Window.Maximize();
            Browser1.Navigate().GoToUrl("http://store.steampowered.com");
           
      
        }

        private void Close_Click(object sender, EventArgs e)
        {
           
                Browser1.Quit();
            
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
