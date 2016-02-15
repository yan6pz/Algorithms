#include <iostream>
#include <stdio.h>
#include <cstring>
using namespace std;

const int N=1<<10;
const int M=1<<10;

int visited[N][M];
int adjMatrix[N][M];
int maxDist,maxVertexX,maxVertexY;
int n,m;

void dfs(int row,int col,int d){

    visited[row][col]=true;
    //left
    if(!visited[row][col-1] && (col-1)>=0 &&adjMatrix[row][col-1]==1)
        dfs(row,col-1,d+1);
    //right
    if(!visited[row][col+1] && (col+1)<m &&adjMatrix[row][col+1]==1)
        dfs(row,col+1,d+1);

    //up
    if(!visited[row-1][col] && (row-1)>=0 &&adjMatrix[row-1][col]==1)
        dfs(row-1,col,d+1);

    //down
    if(!visited[row+1][col] && (row+1)<n &&adjMatrix[row+1][col]==1)
        dfs(row+1,col,d+1);

    if(maxDist<d){
            maxDist=d;
            maxVertexX=row;
            maxVertexY=col;
        }

}

void findLeaf(){
    for(int i=0;i<n;i++){
        for(int j=0;j<m;j++){
                if(adjMatrix[i][j]==1)
                {
                    dfs(i,j,1);
                    return;
                }

        }
    }
}


int main()
{
    scanf("%d %d", &m,&n);

    string line;

    for(int i=0;i< n; i++){
        cin>>line;
        int j=0;
        for(std::string::iterator it = line.begin(); it != line.end(); ++it) {
            if(*it == '#'){
                adjMatrix[i][j] = 0;
            }
            if(*it == '.'){
                adjMatrix[i][j] = 1;
            }
            j++;
        }
    }
    findLeaf();

    memset(visited,0,sizeof(visited));

    dfs(maxVertexX,maxVertexY,1);

    printf("%d\n",maxDist-1);

    return 0;
}
