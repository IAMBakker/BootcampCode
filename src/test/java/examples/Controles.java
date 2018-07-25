package examples;

import org.assertj.core.api.Assertions;
import org.testng.annotations.Test;
import org.testng.asserts.Assertion;

public class Controles {

    @Test
    public void stringTest(){
        String text = "This text is not for the faint hearted";

        Assertions.assertThat(text.contains("faint")).as("\"" + text + "\" should contain faint.").isFalse();

    }

    @Test
    public void integerTest(){
        int twelve = 12;
        int five = 5;

        Assertions.assertThat(12 - 5).as("twelve minus five is not zero").isNotZero();

    }

    @Test
    public void booleanTest(){
        boolean falseBoolean = false;
        falseBoolean = true;
        Assertions.assertThat(falseBoolean).as("falseBoolean is false").isFalse();

    }
}
