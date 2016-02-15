#include <iostream>
#include <stdio.h>
#include <cstring>
#include <queue>

using namespace std;
const int N=1000;
const int M=1000;

int visited[N][M];
int mapF[N][M];
int dir[4][2]={{0,1},{-1,0},{1,0},{0,-1}};
int n,m;
int x1,y1,a,b,c,d;

queue <pair <int,int> > q;

void bfs(int x,int y){
	q.push(make_pair(x,y));
    visited[x][y]=1;

    while(!q.empty()){
      pair<int,int> top=q.front();
      q.pop();
      for(int i=0;i<4;++i){
        x=top.first+dir[i][0];
        y=top.second+dir[i][1];
        if(x>=0&& x<n&& y<m && y>=0 && !visited[x][y] && !mapF[x][y]){
            q.push(make_pair(x,y));
            visited[x][y]=visited[top.first][top.second]+1;
        }
      }
}
}

int main()
{
    scanf("%d %d", &n,&m);

    char str;
    for(int i=0;i<n;i++){
        //scanf("%c", &str);
        for(int j=0;j<m;j++){
            scanf("%c", &str);
            if(str == '#'){
                mapF[i][j] = 1;
            }
            else if(str == '.'){
                mapF[i][j] = 0;
            }
            else
            {

                j--;
            }
        }
    }

    scanf("%d %d", &a,&b);
    scanf("%d %d", &c,&d);

    bfs(a,b);

    printf("%d\n",visited[c][d]-1);
    return 0;
}


/*
4 6
# # # . # #
. . # . . #
# . . . . #
# # # # # #
0 3
1 0
*/
