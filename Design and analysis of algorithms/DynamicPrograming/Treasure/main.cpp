#include <iostream>
#include <cstdio>
#include<algorithm>
using namespace std;
/*
remove the last index
y2=x1+y1-x2
reduce to three dimensions

*/
int n,m;
int matrix[70][70];
int dyn[150][70][70];

int main()
{
    scanf("%d %d",&n,&m);
    for(int i=0;i<n;++i){
        for(int j=0;j<m;++j){
            scanf("%d",&matrix[i][j]);
        }
    }
    dyn[0][0][0]=matrix[0][0];
        //n+m-1 diagonals
    for(int i=1;i<n+m-1;++i){
        for(int j=0;j<=i;++j){
            for(int k=0;k<=i;++k)
                {
                    int x1=j;int y1=i-j;
                    int x2=k;int y2=i-k;

                    dyn[i][x1][x2]=matrix[x1][y1]+((x1==x2) ? 0 :matrix[x2][y2]);

                    int bestVal=0;
                    //all possible directions from where can come choose that with best value
                    if(x1>0 && x2>0)
                        bestVal=max(bestVal,dyn[i-1][x1-1][x2-1]);
                    if(x1>0 && y2>0)
                        bestVal=max(bestVal,dyn[i-1][x1-1][x2]);
                    if(y1>0 && x2>0)
                        bestVal=max(bestVal,dyn[i-1][x1][x2-1]);
                    if(y1>0 && y2>0)
                        bestVal=max(bestVal,dyn[i-1][x1][x2]);

                    dyn[i][x1][x2]+=bestVal;
                }
        }
    }
    printf("%d\n",dyn[n+m-2][n-1][n-1]);

    return 0;
}

