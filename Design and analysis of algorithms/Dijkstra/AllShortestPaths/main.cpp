#include <iostream>
#include <cstdio>
#include <queue>
#include <limits.h>

using namespace std;

int n,m,s,e;
const int mod=1000000007;
vector <pair <int,int> > edges[100001];
long long dist[100001];
bool visited[100001];
int cnt[100001];

struct Node{
    long long dist;
    int vert;

    bool operator <(const Node &other) const{
    return dist>other.dist;
}
};

void dijkstra(){

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
            visited[cur]=true;

            for(unsigned int i=0;i<edges[cur].size();i++){
                if(!visited[edges[cur][i].first] )
                {
                    long long curDist=currentNode.dist + edges[cur][i].second;
                    if(curDist>dist[edges[cur][i].first])
                        continue;
                    if(curDist<dist[edges[cur][i].first])
                    {
                        dist[edges[cur][i].first]=curDist;
                        cnt[edges[cur][i].first]=cnt[cur];
                        Node neigh;
                        neigh.dist = curDist;
                        neigh.vert = edges[cur][i].first;
                        q.push(neigh);

                    }
                    else if(curDist==dist[edges[cur][i].first])
                    {
                        cnt[edges[cur][i].first]+=cnt[cur];
                        cnt[edges[cur][i].first]%=mod;
                    }

                }
            }
        }
    }
}

int main()
{
    scanf("%d %d", &n,&m);
    int a,b,d;
    for(int i=0;i<m;++i){
         scanf("%d %d %d", &a,&b,&d);
       edges[a].push_back(make_pair(b,d));
    }
    s=1;
    e=n;
    for(int i=1;i<=n;++i){
        dist[i]=1LL<<60;
        cnt[i]=1;
    }
    dijkstra();
    if(!visited[e])
    {
        printf("%d %d\n",-1,0);
    }
    else
    {
        printf("%lld %d\n",dist[e],cnt[n]%mod);
    }
    return 0;
}


