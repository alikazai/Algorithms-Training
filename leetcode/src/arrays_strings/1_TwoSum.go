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

	fmt.Println("nums = [2,5,5,11], target = 10")
	ans4 := twoSum([]int{2, 5, 5, 11}, 10)
	fmt.Printf("output = %v\n", ans4)
}

// Given an array of integers nums and an integer target, return
// indices of the two numbers such that they add up to target.

// You may assume that each input would have exactly one solution,
// and you may not use the same element twice.

//You can return the answer in any order.

func twoSum(nums []int, target int) []int {
	l := 0

	for r := 1; r < len(nums); r++ {
		curr := nums[l] + nums[r]

		if curr == target {
			return []int{l, r}
		}

		if curr > target {
			l++
			r = 1
		}
	}

	return []int{}
}
