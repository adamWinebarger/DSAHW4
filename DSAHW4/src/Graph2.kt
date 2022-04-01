object Graph2 {

    private fun determineVertices(edges: Array<Edge>): Int {
        //This should determine the unique number of nodes in the graph
        val vertices = ArrayList<Int>()

        for (edge in edges) {

            if(!vertices.contains(edge.node1))
                vertices.add(edge.node1)
            if(!vertices.contains(edge.node2))
                vertices.add(edge.node2)
        }
        return vertices.size
    }


    private fun find(subsets: Array<subset>, i: Int): Int {
        //find root and make root as parent of i
        if (subsets[i].parent != i)
            subsets[i].parent = subsets[i].parent?.let { find(subsets, it) }


        return subsets[i].parent!! //I remember this from the java one
    }

    private fun union(subsets: Array<subset>, x : Int, y : Int) {
        val xr = find(subsets, x)
        val yr = find(subsets, y)

        //Attach smaller tree under root of high-ranking tree (union by rank)
        if (subsets[xr].rank!! < subsets[yr].rank!!)
            subsets[xr].parent = yr
        else if (subsets[yr].rank!! < subsets[xr].rank!!)
            subsets[yr].parent = xr

        else {
            subsets[yr].parent = xr
            subsets[xr].rank = subsets[xr].rank!!.plus(1)
        }
    }

    public fun mst(edges : Array<Edge>) {

        val vertices = determineVertices(edges)

        val result = Array(vertices - 1) { Edge() }


        var e = 0 //index for result
        var i = 0 //index for sorted edges

        //First we need to sort the edges by order of weight
        edges.sort()

        val subsets = Array(vertices) { subset(null, null) }

        for (k in 0 until vertices)
            subsets[k] = subset(k, 0)

        //number of edges will be equal to vertices - 1
        while (e < vertices - 1) {

            //Now we need to find the smallest edge and increment the index for the next iteration
            val nextEdge = edges[i++]

            val x = find(subsets, nextEdge.node1)
            val y = find(subsets, nextEdge.node2)

            //Now we need a catchment to ensure that we don't create a cycle by including this edge
            if (x != y) {
                result[e++] = nextEdge
                union(subsets, x, y)
            } //and we discard the edge if this condition isn't met
        }

        //now we can print the contents of result and the total weight
        var totalCost = 0

        for (edge in result) {
            println("[${edge.node1} ${edge.node2}] weight: ${edge.weight}")
            totalCost += edge.weight
        }
        println("The total cost is: $totalCost")

    }



    internal class subset(var parent : Int?, var rank : Int?)
}