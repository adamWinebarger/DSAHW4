

class Edge : Comparable<Edge> {

    val node1 : Int
    val node2 : Int
    val weight : Int

    constructor(Node1 : Int = 0, Node2 : Int = 0, weight : Int = 0) {
        this.node1 = Node1
        this.node2 = Node2
        this.weight = weight
    }

    constructor(input : String) {
        val firstSpace = input.indexOf(" ")
        val secondSpace = input.indexOf(" ", firstSpace + 1)

        val node1 = input.substring(0, firstSpace).toInt()
        val node2 = input.substring(firstSpace + 1, secondSpace).toInt()
        val weight = input.substring(secondSpace+1).toInt()

        this.node1 = node1
        this.node2 = node2
        this.weight = weight
    }


    override fun compareTo(other: Edge): Int {

        return this.weight - other.weight
    }
}

