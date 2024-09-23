package main

import (
	"fmt"
)

func main() {
	fmt.Println("713. Subarray Product Less Than K")
	// Given an array of integers nums and an integer k, return the number of contiguous subarrays where the product of all the elements in the subarray is strictly less than k.
	nums := []int{10, 5, 2, 6}
	ans := numSubarrayProductLessThanK(nums, 100)
	fmt.Println(ans)
}

func numSubarrayProductLessThanK(nums []int, k int) int {
	if k <= 1 {
		return 0
	}

	var (
		left = 0
		ans  = 0
		prod = 1
	)

	for right := 0; right < len(nums); right++ {
		prod *= nums[right]

		for prod >= k {
			prod /= nums[left]
			left++
		}
		//update ans
		ans += right - left + 1
	}
	return ans
}
