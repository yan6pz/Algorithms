#include <cstdio>
#include <vector>
#include <algorithm>
#include <functional>   // std::greater

using namespace std;

int n,m;
typedef pair<int, int> edge;//predefining with type edge=pair<int,int>
vector <pair <int, edge> > edges;

int parent[1024];

//finds the parent of given ver and every node
//from the path is recursively pointed the parent of ver
int find(int ver){
    if(parent[ver]!=ver){
        parent[ver]=find(parent[ver]);
    }
    return parent[ver];
}

int Qunion(int v1,int v2){
    int p1=find(v1);
    int p2=find(v2);
    parent[v1]=v2;
}


int main()
{
    scanf("%d %d",&n,&m);
    edges.resize(m);
    int a,b,d;
    for(int i=0;i<m;++i){
        scanf("%d %d %d",&a,&b,&d);
        edges[i]=make_pair(d,make_pair(a,b));
    }
    //From Maximal spanning tree find minimum edge
    sort(edges.begin(),edges.end(), greater <pair<int, edge> >());

    for(int i=1;i<n;++i){
        parent[i]=i;
    }
    int last=-1;
     for(int i=0;i<m;++i){
        edge e=edges[i].second;
        int p1=find(e.first);
        int p2=find(e.second);
        if(p1!=p2){
            Qunion(p1,p2);
            //the last from the pq is with the smallest distance
            last=edges[i].first;
        }

    }

    printf("%d\n",last);
    return 0;
}
