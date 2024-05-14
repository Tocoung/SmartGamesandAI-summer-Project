#include<stdio.h>
#include<stdbool.h>
#include<math.h>

int minimax(int depth, int nodeindex, bool player,int evals[])
{
  if(depth==2)
  {
    if(player)
    {
      return fmax(evals[2*nodeindex-6],evals[2*nodeindex-5]);
    }
    else
    {
      return fmin(evals[2*nodeindex-6],evals[2*nodeindex-5]);
    }
  }
  else
  {
    if(player)
    {
      return fmax(minimax(depth-1,2*nodeindex+1,!player,evals),minimax(depth-1,2*nodeindex+2,!player,evals));
    }
    else
    {
      return fmin(minimax(depth-1,2*nodeindex+1,!player,evals),minimax(depth-1,2*nodeindex+2,!player,evals));
    }
  }
}
int main()
{
	int evals[] = {3, 5, 2, 9, 12, 5, 23, 23};
	int res = minimax(4, 0, true, evals);
	printf("The optimal value is :%d\n",res);
	return 0;
}
