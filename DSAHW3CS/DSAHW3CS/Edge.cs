namespace DSAHW3CS;

public class Edge : Comparer<Edge>
{
    public int weight { get; private set; }
    public int node1 { get; private set; }
    public  int node2 { get; private set; }

    public Edge(int node1 = 0, int node2 = 0, int weight = 0)
    {
        this.weight = weight;
        this.node1 = node1;
        this.node2 = node2;
    }
    

    public Edge(string inputParam)
    {
        int firstSpace = inputParam.IndexOf(" ");
        int secondSpace = inputParam.IndexOf(" ", firstSpace + 1);

        int node1 = Convert.ToInt32(inputParam[..firstSpace]);
        int node2 = Convert.ToInt32(inputParam[++firstSpace..secondSpace]);
        int weight = Convert.ToInt32(inputParam[++secondSpace..]);

        this.weight = weight;
        this.node1 = node1;
        this.node2 = node2;
    }
    
    public override int Compare(Edge? x, Edge? y)
    {
        return x.weight.CompareTo(y.weight); //Just remember to make x.weight as the Edge's own weight
    }

}