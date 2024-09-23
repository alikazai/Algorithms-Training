package main

import "fmt"

func main() {
	fmt.Println("643. Maximum Average Subarray I")
	ans := findMaxAverage([]int{1, 12, -5, -6, 50, 3}, 4)
	fmt.Println(ans)
}

// You are given an integer array nums consisting of n elements, and an integer k.

// Find a contiguous subarray whose length is equal to k that has the maximum
// average value and return this value. Any answer with a calculation error
// less than 10-5 will be accepted.

func findMaxAverage(nums []int, k int) float64 {
	count := 0.0
	var ans float64

	for i := 0; i < k; i++ {
		count += float64(nums[i])
	}

	ans = float64(count / float64(k))

	for i := k; i < len(nums); i++ {
		count += float64(nums[i] - nums[i-k])
		ans = max(ans, float64(count/float64(k)))
	}

	return ans
}
