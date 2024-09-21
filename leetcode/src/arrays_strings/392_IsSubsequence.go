package main

import "fmt"

func main() {
	fmt.Println(
		"392. Is Subsequence",
	)

	check := isSubsequence("abc", "ahbgdc")
	fmt.Println(check)
}

func isSubsequence(s string, t string) bool {
	var (
		i = 0
		j = 0
	)

	for i < len(s) && j < len(t) {
		if s[i] == t[j] {
			i++
		}

		j++
	}

	return i == len(s)
}
