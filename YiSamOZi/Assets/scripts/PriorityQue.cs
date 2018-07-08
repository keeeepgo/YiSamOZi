using System.Collections.Generic;
using System;
namespace temp
{
    public class PriorityQue {
    

    public void main()
    {
        SortedList<int, string> test=new SortedList<int, string>();
        test.Add(3, "asd");
        test.Add(1,"sss");
        test.Add(5, "qwe");
        Console.WriteLine(test[0]);
    }
}
}
