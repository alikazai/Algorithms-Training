package main

import "fmt"

func main() {
	fmt.Println("1. TwoSum")
	fmt.Println("nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2")
	ans := longestOnes([]int{1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0}, 2)
	fmt.Printf("output = %v\n", ans)

	fmt.Println("nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3")
	ans2 := longestOnes([]int{0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1}, 3)
	fmt.Printf("output = %v\n", ans2)
}

// Given a binary array nums and an integer k, return the maximum
// number of consecutive 1's in the array if you can flip at most k 0's.

func longestOnes(nums []int, k int) int {
	return 0
}
