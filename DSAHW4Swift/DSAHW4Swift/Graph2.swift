//
//  Graph2.swift
//  DSAHW4Swift
//
//  Created by adam Winebarger on 3/30/22.
//

import Foundation

class Graph2 {
    
    private func determineVertices(edges : [Edge]) -> Int {
        var vertices : [Int] = []
        
        for edge in edges {
            if !vertices.contains(edge.node1) {
                vertices.append(edge.node1)
            }
            if !vertices.contains(edge.node2) {
                vertices.append(edge.node2)
            }
        }
        
        return vertices.count
    }
    
    private func find(subsets : [subset], i : Int) -> Int {
        
        //find root and make root as parent of i
        if subsets[i].parent != i {
            subsets[i].parent = find(subsets: subsets, i: subsets[i].parent)
        }
        
        return subsets[i].parent
    }
    
    func union(subsets : [subset], x : Int, y : Int) {
        
        let xr = find(subsets: subsets, i: x),
        yr = find(subsets: subsets, i: y)
        
        //attach smaller tree under root of high rank tree (union by rank)
        if subsets[xr].rank < subsets[yr].rank {
            subsets[xr].parent = yr
        } else if subsets[xr].rank > subsets[yr].rank {
            subsets[yr].parent = xr
        } else {
            //If ranks are the same, then we'll increment one and make it root
            subsets[yr].parent = xr
            subsets[xr].rank += 1
        }
        
    }
    
    public func mst(e : [Edge]) {
        
        //print("poop")
        var edges = e
        
        let vertices = determineVertices(edges: edges)
        //print(vertices)
        
        var result : [Edge] = []
        
        var e = 0 //index for result
        var i = 0 //index for sorted edges
        
        //First we need to sort edges
        edges.sort()
        
        var subsets : [subset] = []
        
        for k in 0...vertices {
            subsets.append(subset(parent: k, rank: 0))
        }
        
        //number of edges will be equal to vertices - 1
        while (e < vertices - 1) {
            
            //Now we need to find the smallest edge and increment the index for the next iteration
            let nextEdge = edges[i]; i+=1
            
            let x = find(subsets: subsets, i: nextEdge.node1)
            let y = find(subsets: subsets, i: nextEdge.node2)
            
            //Now we need a catchment to ensure that we don't create a cycle by including this edge
            if x != y {
                result.append(nextEdge); e += 1
                union(subsets: subsets, x: x, y: y)
            } //and we discard the edge if this condition isn't met
        }
        //now we can print contents
        var totalCost = 0
        
        for edge in result {
            print("[\(edge.node1) \(edge.node2)] weight: \(edge.weight)")
            totalCost += edge.weight
        }
        
        print("The total cost is: \(totalCost)")

    }
    
}

internal class subset {
    var parent : Int,
        rank : Int
    
    init (parent : Int = 0, rank : Int = 0) {
        self.parent = parent
        self.rank = rank
    }
    
}
