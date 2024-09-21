package main

import "fmt"

func main() {
	fmt.Println(
		"977. Squares of a sorted array",
	)

	var nums = []int{-4, -1, 0, 3, 10}
	fmt.Println(nums)
	arr := sortedSquaresRefactor(nums)
	fmt.Println(arr)
}

func sortedSquares(nums []int) []int {
	var ans []int
	left := 0

	for left < len(nums) {
		sq := nums[left] * nums[left]
		ans = append(ans, sq)
		left++
	}
	fmt.Println(ans)

	left = 0
	right := 1
	for right < len(ans) {
		if ans[left] > ans[right] {
			ans[left], ans[right] = ans[right], ans[left]
		}
	}

	return ans
}

func sortedSquaresRefactor(nums []int) []int {
	n := len(nums)
	res := make([]int, n)

	left := 0
	right := n - 1
	index := n - 1

	for left <= right {
		leftSquare := nums[left] * nums[left]
		rightSquare := nums[right] * nums[right]

		if leftSquare > rightSquare {
			res[index] = leftSquare
			left++
		} else {
			res[index] = rightSquare
			right--
		}

		index--
	}

	return res
}
