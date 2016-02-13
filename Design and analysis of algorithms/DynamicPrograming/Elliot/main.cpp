#include <iostream>
#include<cstdio>
using namespace std;

int main()
{
     int n;
    scanf("%d",&n);
    int i=0;
    int prices[n];

    int k;
    scanf("%d",&k);


    int q;
    scanf("%d",&q);
    long long quantities[q];

    int numbers;
    while (i<n){
        scanf("%d",&numbers);
        prices[i]=numbers;
        i++;
    }
    short j=0;
    while (j<q){
        scanf("%d",&numbers);
        quantities[j]=numbers;
        j++;
    }

    long long currSum;
    int p;
    int startIndex=0;
    j=0;
    bool out;
    while (j<q){
        i=0;
        p=k;
        out=false;
        currSum=quantities[j++];
        while (i<n){
            currSum=currSum-prices[i++];
            p--;
        if(currSum<=0)
        {
            printf("%d\n",startIndex);
            out=true;
            break;
        }
        if(p==0)
        {
            i=startIndex=i-k+1;
            p=k;
            currSum=quantities[j-1];
        }

    }
    if(!out)
    printf("%d\n",-1);

    }

}
