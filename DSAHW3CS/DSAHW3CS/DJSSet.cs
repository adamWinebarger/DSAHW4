namespace DSAHW3CS;

public class DJSSet
{
    private int[] s;
    /**
     * Construct the disjoint sets object.
     * @param numElements the initial number of disjoint sets.
     */
    public DJSSet(int numElements)
    {
        s = new int[numElements];

        foreach (int i in Enumerable.Range(0, numElements))
        {
            s[i] = -1;
        }
    }

    /**
     * Union two disjoint sets using the height heuristic.
     * For simplicity, we assume root1 and root2 are distinct
     * and represent set names.
     * @param root1 the root of set 1.
     * @param root2 the root of set 2.
     */

    public void union(int r1, int r2)
    {
        if( s[r2] < s[r1] )  // root2 is deeper
            s[r1] = r2;        // Make root2 new root
        else
        {
            if( s[r1] == s[r2] )
                s[r1]--;          // Update height if same
            s[r2] = r1;        // Make root1 new root
        }
    }

    /**
     * Perform a find with path compression.
     * Error checks omitted again for simplicity.
     * @param x the element being searched for.
     * @return the set containing x.
     */

    public int find(int x)
    {
        if (s[x] < 0)
            return x;
        else
            return s[x] = find(s[x]);
    }
    
}