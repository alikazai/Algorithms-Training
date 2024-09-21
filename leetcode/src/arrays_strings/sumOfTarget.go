package main

import "fmt"

func main() {
	fmt.Println(
		"Given a sorted array of unique integers and a target integer, return true if there exists a pair of numbers that sum to target, false otherwise",
	)
	arr := []int{1, 2, 4, 6, 8, 9, 14, 15}

	check := CheckIfSumOfTargetAvailable(arr, 13)
	fmt.Println(check)
}

func CheckIfSumOfTargetAvailable(arr []int, target int) bool {
	left := 0
	right := len(arr) - 1

	for left < right {
		sum := arr[left] + arr[right]

		if sum == target {
			return true
		}

		if sum > target {
			right--
		} else {
			left++
		}
	}

	return false
}
