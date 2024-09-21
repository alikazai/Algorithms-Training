package main

import (
	"fmt"
)

func main() {
	fmt.Println("Github Test 21/09/2024")
	U := 9
	weight1 := []int{5, 3, 8, 1, 8, 7, 7, 6}
	result1 := Solution(U, weight1)
	fmt.Println(result1) // Output: 4

	// Test case 2
	// U = 7
	// weight2 := []int{7, 6, 5, 2, 7, 4, 5, 4}
	// result2 := Solution(U, weight2)
	// fmt.Println(result2) // Output: 5
}

func Solution(U int, weight []int) int {
	n := len(weight)
	minTurns := n // max possible turns to the umber of cars

	for i := 0; i < (1 << n); i++ {
		totalWeight := 0
		turns := 0
		canCross := true

		for j := 0; j < n; j++ {
			if i&(1<<j) != 0 {
				turns++ //mark the car to turnback
			} else {
				totalWeight += weight[j]
				if j == 0 {
					fmt.Println(" ")
				}
				fmt.Printf("Weight at %v = %v \n", j, weight[j])
				fmt.Printf("TotalWeight %v \n", totalWeight)
				if totalWeight > U {
					canCross = false
					break
				}
			}
		}

		if canCross {
			minTurns = min(minTurns, turns)
		}
	}

	return minTurns
}
