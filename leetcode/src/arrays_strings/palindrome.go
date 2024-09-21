package main

import "fmt"

func main() {
	fmt.Println("Palindrome")
	check := CheckIfPalindrome("racecar")
	fmt.Println(check)
}

func CheckIfPalindrome(s string) bool {
	left := 0
	right := len(s) - 1

	for left < right {
		if s[left] != s[right] {
			return false
		}

		left++
		right--
	}

	return true
}
