#include <iostream>
#include <cstdio>
#include <queue>
#include <stack>

using namespace std;

int n,m,e;
vector<pair <int,int> > edges[5001];
int dist[5001];

struct Node{
    int dist;
    int vert;

    bool operator <(const Node &other) const{
    return dist>other.dist;
}
};

struct light{
    int red;
    int green;

};

light lights[5005];

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
        if(!dist[cur]){
            dist[cur] = currentNode.dist;
            for(int i=0;i<edges[cur].size();i++){
                if(!dist[edges[cur][i].first])
                {
                Node neigh;
                neigh.dist = currentNode.dist + edges[cur][i].second;
                int timeWaiting = 0;
                //sum of the time for red and green per node
                int junctionDelay = lights[edges[cur][i].first].green + lights[edges[cur][i].first].red;

                if(neigh.dist <= junctionDelay) {
                        //
                    if(neigh.dist> lights[edges[cur][i].first].green){
                        neigh.dist = junctionDelay;
                    }
                }
                else{
                    int reminder=neigh.dist%junctionDelay;
                    if( reminder> lights[edges[cur][i].first].green){
                        timeWaiting = junctionDelay - reminder;
                    }
                    neigh.dist +=  timeWaiting;
                }


                neigh.vert = edges[cur][i].first;
                q.push(neigh);
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
       edges[b].push_back(make_pair(a,d));
    }

    for(int i=1; i<=n; i++){
        scanf("%d %d", &lights[i].green, &lights[i].red);
    }

    dijkstra(1);
    if(!dist[n])
    {
        printf("%d\n",-1);
    }
    else
    {
        printf("%d\n",dist[n]);
    }
    return 0;
}


