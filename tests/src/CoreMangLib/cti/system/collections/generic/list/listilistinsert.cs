using System;
using System.Collections.Generic;
using System.Collections;
/// <summary>
///Insert(System.Int32,System.Object)
/// </summary>
public class ListIListInsert
{
    public static int Main()
    {
        ListIListInsert ListIListInsert = new ListIListInsert();
        TestLibrary.TestFramework.BeginTestCase("ListIListInsert");
        if (ListIListInsert.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negitive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling Add method of IList,T is Value type.");
        try
        {
            List<int> myList = new List<int>();
            int count = 10;
            int[] expectValue = new int[20];
            for (int z = 0; z < 20; z++)
            {
                expectValue[z] = 0;
            }
            IList myIList = ((IList)myList);
            object element = null;
            for (int i = 1; i <= count; i++)
            {
                element = 0;
                myIList.Add(element);
            }
            for (int i = 1; i <= count; i++)
            {
                element = i * count;
                myIList.Insert(i-1,element);
                expectValue[i - 1] = (int)element;
            }
            IEnumerator returnValue = myIList.GetEnumerator();
            int j = 0;
            for (IEnumerator itr = returnValue; itr.MoveNext(); )
            {
                int current = (int)itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("001.1." + j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: Calling Add method of IList,T is reference type.");
        try
        {
            List<string> myList = new List<string>();
            int count = 10;
            string[] expectValue = new string[20];
            for (int z = 0; z < 20; z++)
            {
                expectValue[z] = string.Empty;
            }
            object element = null;
            IList myIList = ((IList)myList);
            for (int i = 1; i <= count; i++)
            {
                element = string.Empty;
                myIList.Add(element);
            }
            for (int i = 1; i <= count; i++)
            {
                element = i.ToString();
                myIList.Insert(i - 1, element);
                expectValue[i - 1] = element.ToString();
            }
            IEnumerator returnValue = myIList.GetEnumerator();
            int j = 0;
            for (IEnumerator itr = returnValue; itr.MoveNext(); )
            {
                string current = (string)itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("002.1." + j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest1: item is of a type that is not assignable to the IList.");
        try
        {
            List<int> myList = new List<int>();
            IList myIList = ((IList)myList);
            //int type should be add. but add null ArgumentException should be caught.
            myIList.Add(0);
            myIList.Insert(0, null);
            TestLibrary.TestFramework.LogError("101.1.", "ArgumentException should be caught.");
            retVal = false;

        }
        catch (ArgumentException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool NegTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest2: index is not a valid index in the IList.");
        try
        {
            List<int> myList = new List<int>();
            IList myIList = ((IList)myList);
            //int type should be add. but add null ArgumentException should be caught.
            myIList.Insert(int.MaxValue, 0);
            TestLibrary.TestFramework.LogError("102.1.", "ArgumentOutOfRangeException should be caught.");
            retVal = false;

        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("102.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }


}

