#include <iostream>
#include <cstdio>
#include <cstring>
#include <algorithm>

using namespace std;
int n;
int dp[4001];
char s[4001];
bool isPalindrome[4001][4001];

int main()
{
        scanf("%s",&s);
        dp[0]=0;
        for(int i=1;i<=strlen(s);++i)
        {
            int maxInt=1<<30;
            for(int j=0;j<i;++j)
            {
                if(s[i-1]==s[j]&&(j+1>=i-2 || isPalindrome[j+1][i-2]))
                {
                    isPalindrome[j][i-1]=true;
                    maxInt=min(maxInt,dp[j]);
                }
            }
            dp[i]=maxInt+1;
        }

    printf("%d\n",dp[strlen(s)]);
    return 0;
}
