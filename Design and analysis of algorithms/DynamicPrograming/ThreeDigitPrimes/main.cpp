#include <iostream>
#include <cstdio>
#include <math.h>

using namespace std;

int n;
int mod=1000000009;
long long dp[10000][100];
bool primes[1000];

int findThreeDigitPrimes(){
   for(int i=99;i<999;++i)
    {
        bool isPrime=true;
        for(int j=2;j<sqrt(i)+1;++j){
            if(i%j==0){
                isPrime=false;
                break;
            }
        }
        if(isPrime){
            primes[i]=true;
            if(i>99)
                dp[3][i%100]++;
            }
    }
    return 0;
}
int main()
{
    scanf("%d",&n);
    findThreeDigitPrimes();

    for(int i=4;i<=n;++i){
        //traverse the last two digits
        for(int j=0;j<100;++j){
            //traverse the hundreds
            for(int k=0;k<10;++k)
            {
                if(primes[k*100+j])
                {
                    dp[i][j]+=dp[i-1][j/10+k*10];
                    dp[i][j]%=mod;
                }
            }
        }
     }

    long long ans=0;
    for(int i=0;i<100;++i){
        //for every n-th prime
        ans+=dp[n][i];
        ans%=mod;
    }
    printf("%d\n",ans);
    return 0;
}
