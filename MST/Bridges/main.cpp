#include <cstdio>
#include <vector>
#include <algorithm>
#include <limits.h>
using namespace std;

int n,m;
typedef pair<int, int> edge;
vector <pair <edge, edge> > edges;

int parent[10001];

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


int main()
{
    scanf("%d %d",&n,&m);
    edges.resize(m);
    int x,y,z,p;
    for(int i=0;i<m;++i){
        scanf("%d %d %d %d",&x,&y,&z,&p);
        edges[i]=make_pair(make_pair(z,p),make_pair(x,y));
    }
    //From MST sort asc
    sort(edges.begin(),edges.end());

    for(int i=1;i<n;++i){
        parent[i]=i;
    }
    int amount=INT_MAX;
     for(int i=0;i<m;++i){
        edge e=edges[i].second;
        int p1=find(e.first);
        int p2=find(e.second);
        if(p1!=p2){
            Qunion(p1,p2);
            amount=min(amount,edges[i].first.second);
        }

    }
     int firstEl = find(1);

        for(int j= 2;j<=n; j++){
            if(find(j)!=firstEl){
                amount = 0;
                break;
            }
        }
    printf("%d\n",amount-1);
    return 0;
}
