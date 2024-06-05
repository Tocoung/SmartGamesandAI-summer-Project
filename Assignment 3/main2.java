import java.util.*;
public class Main 
{
    public static void main(String[] args) 
    {
        int n=4;
        float a[][]=new float[n][n];
        for(int i=0;i<n;i++)
        {
          for(int j=0;j<n;j++)
          {
            a[i][j]=0;
          }
        }
        int r[][]=new int[n][n];
        for(int i=0;i<n;i++)
        {
          for(int j=0;j<n;j++)
          {
            r[i][j]=-1;
          }
        }
        r[0][0]=0;
        r[0][3]=0;
        while(true)
        {
          float b[][]=new float[n][n];
          for(int i=0;i<n;i++)
          {
            for(int j=0;j<n;j++)
            {
              if(i==0&&j==0)
              {
                continue;
              }
              if(i==0&&j==3)
              {
                continue;
              }
              int ii=0;
              int jj=j;
              if(i==0)
              {
                ii=0;
              }
              else
              {
                ii=i-1;
              }
              b[i][j]+=0.25*(r[ii][jj]+a[ii][jj]);
              if(j==0)
              {
                jj=0;
              }
              else
              {
                jj=j-1;
              }
              ii=i;
              b[i][j]+=0.25*(r[ii][jj]+a[ii][jj]);
              if(j==3)
              {
                jj=3;
              }
              else
              {
                jj=j+1;
              }
              ii=i;
              b[i][j]+=0.25*(r[ii][jj]+a[ii][jj]);
              if(i==3)
              {
                ii=3;
              }
              else
              {
                ii=i+1;
              }
              jj=j;
              b[i][j]+=0.25*(r[ii][jj]+a[ii][jj]);
            }
          }
          float min=Math.abs(a[0][1]-b[0][1]);
          for(int i=0;i<n;i++)
          {
            for(int j=0;j<n;j++)
            {
              if(i==0&&j==0)
              {
                continue;
              }
              if(i==0&&j==3)
              {
                continue;
              }
              min=Math.min(min,Math.abs(a[i][j]-b[i][j]));
            }
          }
          if(min<0.001)
          {
            for(int i=0;i<n;i++)
            {
              for(int j=0;j<n;j++)
              {
                a[i][j]=b[i][j];
              }
            }
            for(int i=0;i<n;i++)
            {
              for(int j=0;j<n;j++)
              {
                System.out.print(b[i][j]+"\t");
              }
              System.out.println();
            }
            break;
          }
          else
          {
            for(int i=0;i<n;i++)
            {
              for(int j=0;j<n;j++)
              {
                a[i][j]=b[i][j];
              }
            }
          }
        }
        String policy[][]=new String[n][n];
        for(int i=0;i<n;i++)
        {
          for(int j=0;j<n;j++)
          {
            policy[i][j]="";
          }
        }
        String w[]={"Up","Left","Down","Right"};
        for(int i=0;i<n;i++)
        {
          for(int j=0;j<n;j++)
          {
            float m[]=new float[n];
            if(i==0&&j==0)
            {
              continue;
            }
            if(i==0&&j==3)
            {
              continue;
            }
            int ii=0;
            int jj=j;
            if(i==0)
            {
              ii=0;
            }
            else
            {
              ii=i-1;
            }
            m[0]=(r[ii][jj]+a[ii][jj]);
            if(j==0)
            {
              jj=0;
            }
            else
            {
              jj=j-1;
            }
            ii=i;
            m[1]=(r[ii][jj]+a[ii][jj]);
            if(j==3)
            {
              jj=3;
            }
            else
            {
              jj=j+1;
            }
            ii=i;
            m[3]=(r[ii][jj]+a[ii][jj]);
            if(i==3)
            {
              ii=3;
            }
            else
            {
              ii=i+1;
            }
            jj=j;
            m[2]=(r[ii][jj]+a[ii][jj]);
            float mm=m[0];
            for(int k=0;k<n;k++)
            {
              mm=Math.max(mm,m[k]);
            }
            //System.out.println(m[0]+" "+m[1]+" "+m[2]+" "+m[3]);
            for(int k=0;k<n;k++)
            {
              if(mm==m[k])
              {
                policy[i][j]+=w[k]+" ";
              }
            }
          }
        }
        for(int i=0;i<n;i++)
        {
          for(int j=0;j<n;j++)
          {
            System.out.print(policy[i][j]+"\t");
          }
          System.out.println();
        }
    }
}
