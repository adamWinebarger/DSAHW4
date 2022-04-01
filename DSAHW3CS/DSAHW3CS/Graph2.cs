using System.IO.Enumeration;

namespace DSAHW3CS;

public class Graph2
{

    int determineVertices(Edge[] edges)
    {
        //This should determine the number of unique nodes in our graph
        List<int> vertices = new List<int>();

        foreach (Edge edge in edges)
        {
            if (!vertices.Contains(edge.node1))
                vertices.Add(edge.node1);
            if (!vertices.Contains(edge.node2))
                vertices.Add(edge.node2);
        }

        return vertices.Count; 
    }

    int find(subset[] subsets, int i)
    {
        //find root and make root as parent of i
        if (subsets[i].parent != i)
            subsets[i].parent = find(subsets, subsets[i].parent);
        

        return subsets[i].parent; //I remember this from the java one
    }

    void union(subset[] subsets, int x, int y)
    {
        int xr = find(subsets, x);
        int yr = find(subsets, y);
        
        //attach smaller tree under root of high rank tree (union by rank)
        if (subsets[xr].rank < subsets[yr].rank)
            subsets[xr].parent = yr;
        else if (subsets[xr].rank > subsets[yr].rank)
            subsets[yr].parent = xr;

        //If ranks are the same, then we'll increment one and make it root
        else
        {
            subsets[yr].parent = xr;
            subsets[xr].rank++;
        }
    }
    
    public void mst(Edge[] e1)
    {
        Edge[] edges = e1;
        int vertices = determineVertices(edges);
        
        Edge[] result = new Edge[vertices - 1];

        int e = 0; //index var for result
        int i = 0; //index variable for sorted edges
        
        //First we need to sort edges by order of weight
        Array.Sort(edges, new Edge());

        subset[] subsets = new subset[vertices];

        for (int k = 0; k < subsets.Length; k++)
            subsets[k] = new subset();

        for (int j = 0; j < vertices; j++)
        {
            subsets[j].parent = j;
            subsets[j].rank = 0;
        }
        
        //number of edges will be equal to vertices - 1
        while (e < vertices - 1)
        {
            //now we need to find the smallest edge and increment the index for the next iteration
            Edge nextEdge = edges[i++];

            int x = find(subsets, nextEdge.node1);
            int y = find(subsets, nextEdge.node2);
            
            //Now we need a catchment to ensure that including this edge doesn't create a cycle
            if (x != y)
            {
                result[e++] = nextEdge;
                union(subsets, x, y);
            } //and if this isn't met then we discard that edge
        }
        
        //now we'll print the contents of result
        int totaclCost = 0;

        foreach (Edge _ in result)
        {
            Console.WriteLine("[{0} {1}] weight: {2}", _.node1, _.node2, _.weight);
            totaclCost += _.weight;
        }
            
        Console.WriteLine("The total cost is: {0}", totaclCost);
        
    }


    class subset
    {
        public int parent, rank;
    }
}