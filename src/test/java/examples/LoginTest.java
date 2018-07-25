package examples;

import io.github.bonigarcia.wdm.ChromeDriverManager;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.remote.RemoteWebDriver;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

import static org.testng.AssertJUnit.assertTrue;

public class LoginTest {

    public WebDriver driver;

    @BeforeTest
    public void setUp(){
        ChromeDriverManager.getInstance().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
        driver.get("https://techblog.polteq.com/testshop/index.php");
    }

//    @BeforeTest
//    public void setUpRemote(){
//        driver = new RemoteWebDriver(new ChromeOptions());
//        driver.manage().window().maximize();
//        driver.get("https://techblog.polteq.com/testshop/index.php");
//    }

    @AfterTest
    public void tearDown(){
//        driver.quit();
    }

    @Test
    public void loginTest(){

        driver.findElement(By.cssSelector("a.login")).click();

        driver.findElement(By.cssSelector("input#email")).sendKeys("ico.bakker+123@gmail.com");

        driver.findElement(By.cssSelector("input#passwd")).sendKeys("test123");

        driver.findElement(By.cssSelector("button#SubmitLogin")).click();

        boolean userIsIcoBakker = driver.findElement(By.xpath("//a[@title='View my customer account']")).getText().contains("Ico bakker");
        assertTrue("User should be ico bakker after succesfull login with these credentials", userIsIcoBakker);

        boolean pageTitleIsMyAccount = driver.findElement(By.cssSelector("h1.page-heading"))
                .getText().equals("MY ACCOUNT");

        assertTrue("pageTitleIsMyAccount should be true", pageTitleIsMyAccount);
    }
}
