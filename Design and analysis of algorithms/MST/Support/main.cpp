#include <iostream>
#include<vector>
#include<algorithm>
#include <cstdio>
#include <queue>
#include <set>

using namespace std;

int n,w;
int x,y,c;
int parent[201];

struct Edge{
    int from;
    int to;
    int dist;

    bool operator < (Edge other) const {
        if (dist <= other.dist)
            return true;
        return false;
    }
};

set <Edge> edges;

int find(int ver){
    if(parent[ver]!=ver){
        parent[ver]=find(parent[ver]);
    }
    return parent[ver];
}

void Qunion(int v1,int v2){
    int p1=find(v1);
    int p2=find(v2);
    parent[p1]=p2;
}

int Kruskal(){
    for(int i=1;i<=n;i++){
        parent[i] = i;
    }

    int distance = 0;

    set<Edge>::iterator biggestEdge = edges.end();
    //iterate over set of edges
    for (set<Edge>::iterator it=edges.begin(); it!=edges.end(); ++it){
        if(find(it->from) != find(it->to)){
            Qunion(it->from,it->to);
            distance += it->dist;
        }
        else {
            biggestEdge=it;
        }
    }
    if(biggestEdge!= edges.end()){
        edges.erase(biggestEdge);
    }

    return distance;
}

void inputData(){
    scanf("%d %d %d",&x,&y,&c);
    Edge edge;
    edge.dist=c;
    edge.from=x;
    edge.to=y;
    edges.insert(edge);
}

void outputData(int * distances,int i){
    int root = find(1);

    for(int j= 2;j<=n; j++){
        if(find(j)!=root){
            distances[i] = -1;
            break;
        }
    }
}

int main()
{
    scanf("%d %d",&n,&w);
    int distances[w];

    for(int i=0; i<w;i++){
        inputData();
        distances[i] = Kruskal();
        outputData(distances,i);

    }

   for(int i=0;i<w;i++){
        printf("%d\n", distances[i]);
    }

    return 0;
}
