package examples;

import org.testng.annotations.Test;

public class HelloWorldTest {

    @Test
    public void printText(){
        String text = "HELLO WORLD!";
        System.out.println(text.charAt(0)+ text.substring(1, text.length()).toLowerCase());
    }
}
