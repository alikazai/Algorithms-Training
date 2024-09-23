package main

import (
	"fmt"
)

func main() {
	fmt.Println("Sliding Window")
	fmt.Println("Example 1")
	nums := []int{3, 1, 2, 7, 4, 2, 1, 1, 5}
	ans := exampleOne(nums, 8)
	fmt.Println(ans)
	fmt.Println("Example 2")
	ans2 := exampleTwo("1101100111")
	fmt.Println(ans2)

	fmt.Println("Example 3")
	nums3 := []int{10, 5, 2, 6}
	ans3 := exampleThree(nums3, 100)
	fmt.Println(ans3)

	fmt.Println("Example 4")
	ans4 := exampleFour([]int{3, -1, 4, 12, -8, 5, 6}, 4)
	fmt.Println(ans4)
}

// Given an array of positive integers nums and an integer k,
// find the length of the longest subarray whose sum is less than or equal to k.
func exampleOne(nums []int, k int) int {
	left := 0
	ans := 0
	curr := 0

	for right := 0; right < len(nums); right++ {
		curr += nums[right]

		for curr > k {
			curr -= nums[left]
			left++
		}

		ans = max(ans, right-left+1)
	}
	return ans
}

// You are given a binary string s (a string containing only "0" and "1").
// You may choose up to one "0" and flip it to a "1".
// What is the length of the longest substring achievable that contains only "1"?
func exampleTwo(s string) int {
	left := 0
	ans := 0
	curr := 0

	for right := 0; right < len(s); right++ {
		if s[right] == '0' {
			curr++
		}

		for curr > 1 {
			if s[left] == '0' {
				curr--
			}
			left++
		}
		ans = max(ans, right-left+1)
	}
	return ans
}

// Given an array of positive integers nums and an integer k,
// return the number of subarrays where the product of all the
// elements in the subarray is strictly less than k.
func exampleThree(nums []int, k int) int {
	if k <= 1 {
		return 0
	}

	left := 0
	ans := 0
	curr := 1 //dealing with multiplication so cant be 0

	for right := 0; right < len(nums); right++ {
		curr *= nums[right]

		for curr >= k {
			curr /= nums[left]
			left++
		}
		ans += right - left + 1
	}
	return ans
}

// Given an integer array nums and an integer k,
// find the sum of the subarray with the largest sum whose length is k.
func exampleFour(nums []int, k int) int {
	curr := 0

	for i := 0; i < k; i++ {
		curr += nums[i]
	}

	ans := curr

	for i := k; i < len(nums); i++ {
		curr += nums[i] - nums[i-k]
		ans = max(ans, curr)
	}

	return ans
}
