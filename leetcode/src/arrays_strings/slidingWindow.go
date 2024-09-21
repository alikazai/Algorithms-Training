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
