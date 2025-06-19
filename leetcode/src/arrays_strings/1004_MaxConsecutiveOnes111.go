package main

import "fmt"

func main() {
	fmt.Println("1. TwoSum")
	fmt.Println("nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2")
	ans := longestOnes([]int{1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0}, 2)
	fmt.Printf("output = %v\n", ans)
	fmt.Println("")

	//	fmt.Println("nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3")
	//
	// ans2 := longestOnes([]int{0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1}, 3)
	// fmt.Printf("output = %v\n", ans2)
}

// Given a binary array nums and an integer k, return the maximum
// number of consecutive 1's in the array if you can flip at most k 0's.

func longestOnes(nums []int, k int) int {
	left := 0
	zeroCount := 0
	maxLength := 0

	for right := 0; right < len(nums); right++ {
		fmt.Printf("When right is %v, value at nums[right] is %v \n", right, nums[right])
		if nums[right] == 0 {
			zeroCount++
			fmt.Printf("Value of nums[right] is 0 zeroCount++ so new value of zeroCount is %v \n", zeroCount)
		}

		for zeroCount > k {
			fmt.Printf("zeroCount greater than k value \n")
			if nums[left] == 0 {
				zeroCount--
				fmt.Printf("Value of nums[left] is 0 zeroCount-- so new value of zeroCount is %v \n", zeroCount)
			}
			fmt.Printf("Value of nums[left] is not 0 left++ so new value of left is %v \n", left)
			left++
			fmt.Println("")
		}

		fmt.Printf("zeroCount is %v \n", zeroCount)
		fmt.Printf("left is %v \n", left)
		fmt.Println("")

		if currentLength := right - left + 1; currentLength > maxLength {
			maxLength = currentLength
		}
	}

	return maxLength
}
