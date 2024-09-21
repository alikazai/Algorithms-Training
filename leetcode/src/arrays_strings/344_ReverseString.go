package main

import "fmt"

func main() {
	fmt.Println(
		"344. Reverse String",
	)

	var s = []byte{'h', 'e', 'e', 'l', 'l', 'o'}
	fmt.Println(s)
	reverseString(s)
	fmt.Println(s)
}

func reverseString(s []byte) {
	left := 0
	right := len(s) - 1

	for left < right {
		temp := s[left]
		s[left] = s[right]
		s[right] = temp
		left++
		right--
	}
}

func reverseStringAlternative(s []byte) {
	n := len(s)

	for i := 0; i < n/2; i++ {
		s[i], s[n-i-1] = s[n-1-i], s[i]
	}
}

func reverseStringFaster(s []byte) {
	left := 0
	right := len(s) - 1

	for left < right {
		s[left], s[right] = s[right], s[left]
		left++
		right--
	}
}
