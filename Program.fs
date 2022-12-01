open aoc.year2022
open aoc.Input

[<EntryPoint>]
let main (args) =
    let year = args[0] |> int
    let day = args[1] |> int

    let input = readDay year day

    match input with
    | Some input -> printfn $"Day {day} / {year}: {Day1.answer1 input} and {Day1.answer2 input}"
    | None -> eprintfn "Sorry, but there is no input for the current day"

    0
