#include <iostream>
#include <cstdio>
#include <algorithm>

using namespace std;
int n;
int *arr;
int sum=0;
//maximum possible sum 300*500
bool hasSum[150000];

int calculateAllPossibleSums(){
    //base
    hasSum[0] = true;
    int tmp = 0;
    for (int i=0;i<n;++i){
        for(int j=sum;j>=0;--j){
            if(hasSum[j])
            {
                //if we has sum j we can make sum (current element +j)
                hasSum[arr[i]+j]=true;
            }
        }
        tmp += arr[i];
    }
    return 0;
}

int main()
{
    scanf("%d",&n);
    arr=new int[n];

    for(int i=0;i<n;++i)
    {
        scanf("%d",&arr[i]);
        sum+=arr[i];
    }

    calculateAllPossibleSums();

    int divided=sum/2;
    for(int i=divided;i>=0;--i){
        //check if we have sum from the split and if not increase the difference
        if(hasSum[i]){
            printf("%d\n", sum-i-i);
            break;
        }
    }
    return 0;

}
