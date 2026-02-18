namespace SlidingWindow.Test;

public class SlidingWindowTest
{
    
    [Fact]
    public void Test_SlidingWindow_Get1_0_0()
    {

        int[] view = [1, 2, 3, 4];

        SlidingWindow sw = new SlidingWindow(view, 0, 4);

        int[] expected = [1, 2, 3, 4];

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }
    
    [Fact]
    public void Test_SlidingWindow_Get2_2_2()
    {

        int[] view = [1, 2, 3, 4];

        SlidingWindow sw = new SlidingWindow(view, 0, 4);

        int[] expected = [3, 4];

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }
    [Fact]
    public void Test_SlidingWindow_Get3_1_3()
    {

        int[] view = [1, 2, 3, 4];
        

        SlidingWindow sw = new SlidingWindow(view, 1, 3);

        int[] expected = [2, 3, 4];



        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }
    
    [Fact]
    public void Test_SlidingWindow_SetGet3_1_3()
    {

        int[] view = [1, 2, 3, 4];
        

        SlidingWindow sw = new SlidingWindow(view, 1, 3);

        int[] expected = [10, 10, 10];

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            sw.SetElement(e, i);
        }


        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }
    
    [Fact]
    public void Test_SlidingWindow_SetGet1_1_3()
    {

        int[] view = [1, 10, 10, 10];
        
        SlidingWindow sw = new SlidingWindow(view, 0, 4);

        int[] expected = [10, 10, 10];

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }

    [Fact]
    public void Test_SlidingWindow_SetGet2_4_6()
    {
        int[] view = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

        SlidingWindow sw = new SlidingWindow(view, 4, 6);

        int[] expected = [45, 67, 23, 10, 78, 22];

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            sw.SetElement(e, i);
        }

        for(int i = 0; i < expected.Length; i++) {
            int e = expected[i];
            Assert.Equal(e, sw.GetElement(i));
        } 
    }
}
