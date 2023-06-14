using Core.SeleniumWrapper.Elements;
using Core.SeleniumWrapper.ElementsFactory;
using OpenQA.Selenium;
using SauceDemoTest.AppConfigurations;

namespace SauceDemoTest.Pages.Components;

public sealed class Footer
{
    private ElementFactory Factory { get; }

    public Footer()
    {
        Factory = EntityContainer.Factory;
    }
    
    private static readonly By s_copyrightLocator = By.ClassName("footer_copy");
    private static readonly By s_robotImgLocator = By.ClassName("footer_robot");
    private static readonly By s_twitterLinkLocator = By.CssSelector(".social_twitter a");
    private static readonly By s_facebookLinkLocator = By.CssSelector(".social_facebook a");
    private static readonly By s_linkedinLinkLocator = By.CssSelector(".social_linkedin a");
    
    private ILinkElement TwitterLink => Factory.CreateElement<ILinkElement>(s_twitterLinkLocator, nameof(TwitterLink));
    private ILinkElement FacebookLink => Factory.CreateElement<ILinkElement>(s_facebookLinkLocator, nameof(FacebookLink));
    private ILinkElement LinkedinLink => Factory.CreateElement<ILinkElement>(s_linkedinLinkLocator, nameof(LinkedinLink));
    private ILabelElement CopyrightText => Factory.CreateElement<ILabelElement>(s_copyrightLocator, nameof(CopyrightText));
    private ILabelElement RobotImg => Factory.CreateElement<ILabelElement>(s_robotImgLocator, nameof(RobotImg));

    public bool CopyrightDisplayed => CopyrightText.Displayed;
    public bool RobotImgDisplayed => RobotImg.Displayed;

    public void OpenTwitterLink()
    {
        TwitterLink.Click();
    }
    
    public void OpenFacebookLink()
    {
        FacebookLink.Click();
    }
    
    public void OpenLinkedinLink()
    {
        LinkedinLink.Click();
    }
}