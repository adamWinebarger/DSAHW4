//
//  Edge.swift
//  DSAHW4Swift
//
//  Created by adam Winebarger on 3/30/22.
//

import Foundation

class Edge : Comparable {
    
    
    
    let node1 : Int, node2 : Int, weight : Int
    
    init(node1 : Int, node2 : Int, weight : Int) {
        self.node1 = node1
        self.node2 = node2
        self.weight = weight
    }
    
    init(input : String) {
        let elements = input.components(separatedBy: " ")
        node1 = Int (elements[0]) ?? 0
        node2 = Int (elements[1]) ?? 0
        weight = Int (elements[2]) ?? 0
        
    }
    
    init() {
        node1 = 0
        node2 = 0
        weight = 0
    }
    
    static func < (lhs: Edge, rhs: Edge) -> Bool {
        return lhs.weight < rhs.weight
    }
    
    static func == (lhs: Edge, rhs: Edge) -> Bool {
        return lhs.weight == rhs.weight
    }
    
}

