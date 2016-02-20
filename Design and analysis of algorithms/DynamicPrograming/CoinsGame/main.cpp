#include <iostream>
#include <cstdio>
#include <string.h>
using namespace std;

int k,l,m;
int *coins;
bool *hasWin;
char *result;

int main()
{
    scanf("%d %d %d",&k,&l,&m);
    coins=new int[m];

    for(int i=0;i<m;++i){
        scanf("%d",&coins[i]);
    }
    hasWin=new bool[1000001];
    hasWin[0]=false;
    hasWin[1]=true;
    hasWin[k]=true;
    hasWin[l]=true;
    result=new char[m];

    for(int i=0;i<m;++i){
        int coin=coins[i];
        //memset(hasWin,0,m);

        for(int j=2;j<=coin;++j){
            if(j!=k&&j!=l)
            {
                hasWin[j]=!hasWin[j-1];
            }
            if(j>k)
            {
                if(!hasWin[j-k])
                {
                    hasWin[j]=!hasWin[j-k];
                    continue;
                }
            }
            if(j>l)
            {
                if(!hasWin[j-l])
                {
                    hasWin[j]=!hasWin[j-l];
                    continue;
                }
            }
        }
        result[i]=hasWin[coin]?'A':'B';
    }
    result[m]='\0';

    printf("%s\n",result);
    return 0;
}

