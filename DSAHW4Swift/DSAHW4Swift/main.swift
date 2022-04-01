//
//  main.swift
//  DSAHW4Swift
//
//  Created by adam Winebarger on 3/30/22.
//

import Foundation
import Cocoa

//print("Hello, World!")

func loadArray(lines : [String]) -> [Edge] {
    
    var edges : [Edge] = []
    
    for line in lines {
        let edge = Edge(input: line)
        edges.append(edge)
    }
    
    return edges
}

let k3lines = FileContents.k3Contents.split(separator: "\n").map {String($0)}
let k5lines = FileContents.k5Contents.split(separator: "\n").map {String($0)}
let star5lines = FileContents.star5Contents.split(separator: "\n").map {String($0)}
//^this has to be done because spliting a string this way causes it to be of type Swift.subsequence
//and this is pretty much the simplest, most effective way to turn our subsequences into strings

let k3Edges = loadArray(lines: k3lines)
let k5Edges = loadArray(lines: k5lines)
let star5Edges = loadArray(lines: star5lines)

let g = Graph2()

g.mst(e: k3Edges)
print("")
g.mst(e: k5Edges)
print("")
g.mst(e: star5Edges)
print("")
print("done")
