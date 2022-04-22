import java.util.ArrayList;
import java.util.Arrays;

public class Main
{
	 
	
	 public static void main(String args[]) 
	    {
		 MyClassSort mcs =  new MyClassSort();
		 mcs.GO();
	    }
	   
}
class MyClassSort
{
	static ArrayList<ArrayList<Integer>> DictSortVal = new ArrayList<ArrayList<Integer>>();
	static ArrayList<ArrayList<Integer>>  DictBuf = new ArrayList<ArrayList<Integer>> ();
	static ArrayList<Integer> Key = new ArrayList<Integer> (Arrays.asList(5,  4, 4,  3,  4, 5,  5, 3, 4,1,  2, 4,  3, 5, 1,   1, 4, 5));
	static ArrayList<Integer> Val = new ArrayList<Integer> (Arrays.asList(0, 13, 2,  4, 11, 2,  1, 3, 5,  123, 31, 2,  1, 0, 23,  1, 0, 1)) ;
	
	public  void GO()
	{
		    System.out.println("before Sort");
	        for (int i = 0; i < Key.size()-1; i++)
	        {
	        	 System.out.println(Key.get(i) + " = " +  Val.get(i) + ", ");
	        }

	        DictSortVal = BubbleSortVal( Key, Val);
	        
	        System.out.println("\n after Sort for  Val");
	        for (int i = 0; i < DictSortVal.get(0).size() - 1; i++)
	        {
	        	System.out.println(DictSortVal.get(0).get(i) +" = " + DictSortVal.get(1).get(i) + ", ");
	        }
	
	        DictBuf = BubbleSortKey(DictSortVal.get(0), DictSortVal.get(1));

	        System.out.println("\n after Sort for Key");
	        for (int i = 0; i < DictBuf.get(0).size() - 1; i++)
	        {
	        	System.out.println(DictBuf.get(0).get(i) +" = " + DictSortVal.get(1).get(i) + ", ");
	        }
	}
	
	static void Swap(ArrayList<Integer> arrList, int ind1, int ind2)
    {
		int tmp = arrList.get(ind1);
		arrList.set(ind1, arrList.get(ind2));
	    arrList.set(ind2, tmp);
    }
	static ArrayList<ArrayList<Integer>> BubbleSortKey( ArrayList<Integer> key, ArrayList<Integer> val)
    {
        int len = key.size();
        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < len - i; j++)
            {
                if (key.get(j) > key.get(j+1))
                {
                    Swap( key, j, j + 1);
                    Swap( val, j, j + 1 );
                }
            }
        }
        ArrayList<Integer> sortKey = new ArrayList<Integer>();
        ArrayList<Integer> sortVal = new ArrayList<Integer>();

        for (Integer e : key) {sortKey.add(e);}
        for (Integer e : val) {sortVal.add(e);}
        
        ArrayList<ArrayList<Integer>>  custDict = new ArrayList<ArrayList<Integer>> ();
        custDict.add(sortKey);
        custDict.add(sortVal);
        return custDict;
    }
	static ArrayList<ArrayList<Integer>> BubbleSortVal(ArrayList<Integer> key, ArrayList<Integer> val)
    {
		int len = key.size();
        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < len - i; j++)
            {
                if (val.get(j) > val.get(j+1))
                {
                    Swap( key, j, j + 1);
                    Swap( val, j, j + 1 );
                }
            }
        }

        ArrayList<Integer> sortKey = new ArrayList<Integer>();
        ArrayList<Integer> sortVal = new ArrayList<Integer>();

        for (Integer e : key) {sortKey.add(e);}
        for (Integer e : val) {sortVal.add(e);}
        
        ArrayList<ArrayList<Integer>>  custDict = new ArrayList<ArrayList<Integer>> ();
        custDict.add(sortKey);
        custDict.add(sortVal);
  
        return custDict;
    }	
	
	
}

