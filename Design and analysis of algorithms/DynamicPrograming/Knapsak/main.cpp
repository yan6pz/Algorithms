#include<stdio.h>
#include <algorithm>
using namespace std;

// Returns the maximum value that can be put in a knapsack of capacity W
int knapSack(int capacity, int worth[], int val[], int n)
{
    int i, w;
    int dyn[n+1][capacity+1];
    //bool taken[n+1][capacity+1];

   // Build table dyn[][] in bottom up manner
    for (i = 0; i <= n; i++)
    {
       for (w = 0; w <= capacity; w++)
       {
           if (i==0 || w==0)
           {
               dyn[i][w] = 0;
           }
           else if (worth[i-1] <= w)
           {
               //the value from the previous element +the value of dyn for current element without the value of current element
               dyn[i][w] = max(val[i-1] + dyn[i-1][w-worth[i-1]],  dyn[i-1][w]);
           }
           else
           {
               dyn[i][w] = dyn[i-1][w];
           }
       }
   }

    int line = capacity;
    i =n;
    while (i> 0)
    {
        if(dyn[i][line] != dyn[i-1][line] )
        {
            printf("index:%d -> val:%d ",i-1,val[i-1]);
            i--;
            line = line - worth[i];
        }
        else
        {
            i--;
        }
    }

   return dyn[n][capacity];
}

int main()
{
    int val[] = {60, 100, 120,100,10,300};
    int worth[] = {10, 20, 30,11,5,45};
    int capacity = 31;
    int n = sizeof(val)/sizeof(val[0]);
    printf("%d", knapSack(capacity, worth, val, n));
    return 0;
}
