#include <iostream>
#include <cstdio>
using namespace std;
//f(0)=-5
/*
f(1)=max(f(0)+6,6)=6
f(2)=max(f(1)-7,-7)=-1
...
f(5)=max(f(4)+9,9)=12
take the largest sum
*/

int n;
int arr[1000000];

int main()
{
    scanf("%d",&n);
    for(int i=0;i<n;++i){
        scanf("%d",&arr[i]);
    }
    int max_ending =0;
    int maxCurrent = 0;
    for(int j=0;j<n;++j){
        max_ending = max(arr[j], max_ending + arr[j]);
        maxCurrent = max(maxCurrent, max_ending);
    }

    printf("%d\n",maxCurrent);
    return 0;
}
