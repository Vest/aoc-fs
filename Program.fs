open aoc.year2022
open aoc.Input
open System

printfn "Hello from aoc-fs"



// let input = readDay 2022 1
// match input with
// | Some input -> printfn $"Read input: '{input}'"
// | None -> printfn "Nothing was found :("

[<EntryPoint>]
let main(args) =
    let year = args[0] |> int
    let day = args[1]  |> int
    printfn $"Current Day: {day, 2:D2}/{year}"

    let input = readDay year day
    match input with
    | Some input ->
        printfn $"The first answer is {Day1.answer1 input}"
        printfn $"The second answer is {Day1.answer2 input}"
    | None -> eprintfn "Sorry, but there is no input for the current day"
    0
