#include <iostream>
#include<cstdio>
#include <stdio.h>
#include <cstring>

using namespace std;

const int N=1<<10;
int neiCount[N];
int neiDist[N][N];
int neiVal[N][N];
int maxDist,maxVertex;
int visit[N];

void dfs(int x,int d){
    int y,dy;
    visit[x]=1;
    for(int i=0;i<neiCount[x];++i){
        y=neiVal[x][i];
        dy=neiDist[x][i];
        if(!visit[y]){
            dfs(y,d+dy);
        }
    }
    if(maxDist<d){
        maxDist=d;
        maxVertex=x;
    }
}

void edge(int x, int y, int d){
    neiDist[x][neiCount[x]]=d;
    neiVal[x][neiCount[x]]=y;
    neiCount[x]++;
}

int main()
{
    int n;
    scanf("%d", &n);
    int x,y,d;
    for(int i=1;i<n;++i){
        scanf("%d %d %d", &x,&y,&d);
        --x;--y;
        edge(x,y,d);
        edge(y,x,d);
    }
    //find leaf with longest path
    for(int i=0;i<n;++i){
        if(neiCount[i]==1){
            dfs(i,0);
            break;
        }
    }
    maxDist=0;
    memset(visit,0,sizeof(visit));
    //find end leaf (end point of the diagonal via prev leaf
    dfs(maxVertex,0);
    printf("%d\n",maxDist);

    return 0;
}
