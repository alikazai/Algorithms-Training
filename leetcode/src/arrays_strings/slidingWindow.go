package main

import (
	"fmt"
)

func main() {
	fmt.Println("Sliding Window")
	nums := []int{3, 1, 2, 7, 4, 2, 1, 1, 5}
	ans := exampleOne(nums, 8)
	fmt.Println(ans)
	ans2 := exampleTwo("1101100111")
	fmt.Println(ans2)
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

func exampleThree(s string) int {
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
