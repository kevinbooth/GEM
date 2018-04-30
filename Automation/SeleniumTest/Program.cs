using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             ##################OUTDATED TESTS#####################
            //tester.startTest();
            //tester.createLinkTest();
            //tester.loginLinkTest();
            //tester.loginTest();
            //tester.endTest();
            */
            var tester = new FirstTestCase();
            tester.browseLinkTest();
            tester.newCreateLinkTest();
            tester.registerLinkTest();
            tester.rightLoginLinkTest();
            tester.registerTest();
            tester.loginPageTest();
            tester.loginToReg();
            tester.forgotPassword();
            tester.createPublicEventTest();
            tester.searchTest();
            tester.sortTest();
            tester.deletePublicEventTest();
            tester.updateProfile();
        }
    }
}
