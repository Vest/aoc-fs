open aoc.Input

printfn "Hello from aoc-fs"

let input = readDay 2021 6
match input with
| Some input -> printfn $"Read input: '{input}'"
| None -> printfn "Nothing was found :("
