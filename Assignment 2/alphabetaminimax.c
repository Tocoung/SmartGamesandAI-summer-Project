#include<stdio.h>
#include<stdbool.h>
#include<math.h>
// try to time the alpha beta pruning vs simple mini max. 
// depth is current depth in game tree.
// evals[] stores leaves of Game tree.
// try to relate the nodeindex of a parent to its child
// and how the nodeindex of the leaves is related to their index in the array 
int  alphabetaminimax(int depth, int nodeindex, bool player,int evals[],int alpha,int beta)
{
  if(depth==1)
  {
    if(player)
    {
      return fmax(evals[2*nodeindex-14],evals[2*nodeindex-13]);
    }
    else
    {
      return fmin(evals[2*nodeindex-14],evals[2*nodeindex-13]);
    }
  }
  else
  {
    if(player)
    {
      int a=-1000;
      for(int i=0;i<2;i++)
      {
        a=fmax(a,alphabetaminimax(depth-1,2*nodeindex+i+1,!player,evals,alpha,beta));
        alpha=fmax(a,alpha);
        if(alpha>=beta)
        {
          break;
        }
      }
      return a;
    }
    else
    {
      int a=1000;
      for(int i=0;i<2;i++)
      {
        a=fmin(a,alphabetaminimax(depth-1,2*nodeindex+i+1,!player,evals,alpha,beta));
        beta=fmin(a,beta);
        if(alpha>=beta)
        {
          break;
        }
      }
      return a;
    }
  }
}



int main()
{
	int evals[] = {3, 5, 2, 9, 12, 5, 7, -6,3,4,-3,9,-8,-3,-100,2};
	int res = alphabetaminimax(4, 0, true, evals,-1000,1000);
	printf("The optimal value is :%d\n",res);
	return 0;
}

// the best evals array possible is {3,5,2,9,5,12,-6,7,3,4,-3,9,-8,-3,-100,2}