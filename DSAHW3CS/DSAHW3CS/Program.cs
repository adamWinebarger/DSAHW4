// See https://aka.ms/new-console-template for more information

using DSAHW3CS;
using static System.Console;

void loadArray(string[] lines, Edge[] arr)
{
    for (int i = 0; i < lines.Length; i++)
    {
        arr[i] = new Edge(lines[i]);
    }
}

Console.WriteLine("Hello, World!");

//Testing the Edge class and 

string[] star5 = File.ReadAllLines("star5.txt"),
    k3 = File.ReadAllLines("k3k3.txt"),
    k5 = File.ReadAllLines("k5.txt");

Edge[] star5Edges = new Edge[star5.Length],
    k3Edges = new Edge[k3.Length],
    k5Edges = new Edge[k5.Length];
    
loadArray(star5, star5Edges);
loadArray(k3, k3Edges);
loadArray(k5, k5Edges);

Graph2 g = new Graph2();

g.mst(star5Edges);

WriteLine();

g.mst(k3Edges);

WriteLine();

g.mst(k5Edges);