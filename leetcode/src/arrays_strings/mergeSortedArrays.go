package main

import "fmt"

func main() {
	fmt.Println(
		"Given a sorted array of unique integers and a target integer, return true if there exists a pair of numbers that sum to target, false otherwise",
	)
	arr1 := []int{1, 4, 7, 20}
	arr2 := []int{3, 5, 6}

	check := MergeSortedArrays(arr1, arr2)
	fmt.Println(check)
}

func MergeSortedArrays(arr1 []int, arr2 []int) []int {
	var (
		i       = 0
		j       = 0
		arr1Len = len(arr1)
		arr2Len = len(arr2)
		ans     []int
	)

	for i < arr1Len && j < arr2Len {
		if arr1[i] < arr2[j] {
			ans = append(ans, arr1[i], arr2[j])
		} else {
			ans = append(ans, arr2[j], arr1[i])
		}
		i++
		j++
	}

	for i < arr1Len {
		ans = append(ans, arr1[i])
		i++
	}

	for j < arr2Len {
		ans = append(ans, arr2[j])
		j++
	}

	return ans
}
