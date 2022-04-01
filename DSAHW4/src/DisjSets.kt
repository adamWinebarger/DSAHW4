// DisjSets class
//
// CONSTRUCTION: with int representing initial number of sets
//
// ******************PUBLIC OPERATIONS*********************
// void union( root1, root2 ) --> Merge two sets
// int find( x )              --> Return set containing x
// ******************ERRORS********************************
// No error checking is performed
/**
 * Disjoint set class, using union by rank and path compression.
 * Elements in the set are numbered starting at 0.
 * @author Mark Allen Weiss
 */
class DisjSets(numElements: Int) {

    private val s: IntArray

    /**
     * Union two disjoint sets using the height heuristic.
     * For simplicity, we assume root1 and root2 are distinct
     * and represent set names.
     * @param root1 the root of set 1.
     * @param root2 the root of set 2.
     */
    fun union(root1: Int, root2: Int) {
        if (s[root2] < s[root1]) // root2 is deeper
            s[root1] = root2 // Make root2 new root
        else {
            if (s[root1] == s[root2]) s[root1]-- // Update height if same
            s[root2] = root1 // Make root1 new root
        }
    }

    /**
     * Perform a find with path compression.
     * Error checks omitted again for simplicity.
     * @param x the element being searched for.
     * @return the set containing x.
     */
    fun find(x: Int): Int {
        return if (s[x] < 0) x else find(s[x]).also { s[x] = it }
    }

    /**
     * Construct the disjoint sets object.
     * @param numElements the initial number of disjoint sets.
     */
    init {
        s = IntArray(numElements)
        for (i in s.indices) s[i] = -1
    }
}