package examples;

import org.testng.annotations.Test;

public class AboutMethods {

    @Test
    public void printMethods(){
        System.out.println(
                multiply(25, 3)
        );
    }

    private int multiply(int a, int b){
        return a * b;
    }
}
