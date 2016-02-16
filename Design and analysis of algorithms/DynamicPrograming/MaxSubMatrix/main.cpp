#include <iostream>
#include <cstdio>
#include<limits.h>
using namespace std;
//f(0)=-5
/*
f(x,y)=f(x-1,y)+f(x,y-1)-f(x-1,y-1)+a(x,y)
g(x0,y0,x1,y1)=sum[i=x0->x1]sum[j=y0->y1]aij=
=f(x0-1,y0-1)-f(x0-1,y1)-f(x1,y0-1)+f(x1,y1)
*/

int n;
int arr[401][401];
int temp[401][401];
int flat[401];

int maxSubSeq(){
    int max_ending =INT_MIN;
    int maxCurrent = -100000;

    for(int j=1;j<=n;++j)
    {
        if(flat[j]< maxCurrent + flat[j])
        {
            maxCurrent+=flat[j];
        }
        else
        {
            maxCurrent=flat[j];
        }
        max_ending=max(max_ending,maxCurrent);
    }
    return max_ending;
}

int main()
{
    scanf("%d",&n);
    for(int i=1;i<=n;++i){
        for(int j=1;j<=n;++j){
            scanf("%d",&arr[i][j]);
        }
    }

    for(int i=1;i<=n;++i){
        for(int j=1;j<=n;++j){
            temp[i][j]=arr[i][j]+temp[i-1][j];
        }
    }

    int bestSum=INT_MIN;

    //produce arr from temp and calculate max sum for every row(one dimension)
    for(int x0=1;x0<=n;++x0){
        for(int x1=x0;x1<=n;++x1){
                for(int y=1;y<=n;++y){
                   flat[y]=temp[x1][y]-temp[x0-1][y];
        }
        bestSum=max(bestSum,maxSubSeq());
        }
    }

    printf("%d\n",bestSum);
    return 0;
}
