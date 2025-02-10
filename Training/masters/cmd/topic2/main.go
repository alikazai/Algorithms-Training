package main

import (
	"fmt"
	"strings"
)

func main() {
	phrase := "Iguanas create electricity"
	f := strings.Split(phrase, " ")
	var letters string
	for _, r := range f {
		fl := r[0]
		letters = letters + string(fl)
	}

	fmt.Println(strings.ToUpper(letters))
}
