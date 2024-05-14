import java.util.*;
public class Main 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        int n=scanner.nextInt();
        int a[]=new int[n];
        HashMap<Integer,Integer> map=new HashMap<>();
        for(int i=0;i<n;i++)
        {
          a[i]=scanner.nextInt();
          map.put(a[i],i+1);
        }
        int b[]=new int[n];
        b[0]=map.get(-1);
        for(int i=1;i<n;i++)
        {
          b[i]=map.get(b[i-1]);
        }
        for(int i=0;i<n;i++)
        {
          System.out.print(b[i]+" ");
        }
        scanner.close();
    }
}
