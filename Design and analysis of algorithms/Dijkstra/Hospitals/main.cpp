#include <iostream>
#include <cstdio>
#include <queue>
#include <string.h>

using namespace std;

int n,m,h;
vector<pair <int,int> > edges[50001];
int dist[10001];
int visited[10001];
int hospitals[101];
int distances[101];

struct Node{
    int dist;
    int vert;

    bool operator <(const Node &other) const{
    return dist>other.dist;
}
};

void dijkstra(int s){

    Node node;
    node.dist = 0;
    node.vert = s;
    priority_queue<Node> q;
    q.push(node);
    while(!q.empty()){
        Node currentNode = q.top();
        q.pop();
        int cur = currentNode.vert;
        if(!visited[cur]){
            dist[cur] = currentNode.dist;
            visited[cur] = 1;
            for(int i=0;i<edges[cur].size();i++){
                if(!visited[edges[cur][i].first])
                {
                    Node neigh;
                    neigh.dist = currentNode.dist + edges[cur][i].second;
                    neigh.vert = edges[cur][i].first;
                    q.push(neigh);
                }
            }
        }
    }
}

int findMin(int *arr){
    int minEl=arr[0];
    for(int i=1;i<h;++i){
        if(minEl>arr[i])
            minEl=arr[i];
    }
    return minEl;
}

int main()
{
    scanf("%d %d %d", &n,&m,&h);
    int host;
    for(int i=0;i<h;++i){
        scanf("%d", &host);
        hospitals[i]=--host;
    }

    int f,s,d;
    for(int i=0;i<m;++i){
        scanf("%d %d %d", &f,&s,&d);
        --f;
        --s;
       edges[f].push_back(make_pair(s,d));
       edges[s].push_back(make_pair(f,d));
    }

    bool isHospital=false;
    for(int i=0;i<h;++i){
       dijkstra(hospitals[i]);
       for(int j=0;j<n;++j)
       {
           isHospital=false;
           for(int k=0;k<h;++k){
               if(hospitals[k]==j)
               {
                   isHospital=true;
                   break;
               }

           }
           if(isHospital)
            continue;
           //sum the distances from every hospital to every other house
           distances[i]+=dist[j];
       }
        memset(dist,0,sizeof(dist));
        memset(visited,0,sizeof(visited));
    }

    printf("%d\n",findMin(distances));

    return 0;
}

