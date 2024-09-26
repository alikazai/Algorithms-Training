package main

import "fmt"

func main() {
	fmt.Println("1. TwoSum")
	fmt.Println("nums = [2,7,11,15], target = 9")
	ans := twoSum([]int{2, 7, 11, 15}, 9)
	fmt.Printf("output = %v\n", ans)

	fmt.Println("nums = [3,2,4], target = 6")
	ans2 := twoSum([]int{3, 2, 4}, 6)
	fmt.Printf("output = %v\n", ans2)

	fmt.Println("nums = [3,3], target = 6")
	ans3 := twoSum([]int{3, 3}, 6)
	fmt.Printf("output = %v\n", ans3)
}

// Given an array of integers nums and an integer target, return
// indices of the two numbers such that they add up to target.

// You may assume that each input would have exactly one solution,
// and you may not use the same element twice.

//You can return the answer in any order.

func twoSum(nums []int, target int) []int {
	return []int{}
}
