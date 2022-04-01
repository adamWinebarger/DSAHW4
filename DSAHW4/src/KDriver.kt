import java.io.File

class KDriver {

    fun loadArrays(lines : List<String>) : Array<Edge>{

        val edges = Array(lines.size) { Edge() }

        for ((i, line) in lines.withIndex()) {
            edges[i] = Edge(line)
        }

        return edges
    }

    init {

        val star5 = File("star5.txt").readLines()
        val k3 = File("k3k3.txt").readLines()
        val k5 = File("k5.txt").readLines()

//        for (line in star5)
//            println(line)

        val star5Edges = loadArrays(star5)
        val k3Edges = loadArrays(k3)
        val k5Edges = loadArrays(k5)

        val g = Graph2

        g.mst(star5Edges)
        println()
        g.mst(k3Edges)
        println()
        g.mst(k5Edges)
        println()
    }

}