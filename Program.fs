open System
open aoc.year2022
open aoc.Input

let displayAnswer (answer: string) (isError: bool) : unit =
    match isError with
    | true -> printfn $"{answer}"
    | false -> eprintfn $"{answer}"

let display year day =
    let input = readDay year day

    let answer =
        match input, day with
        | Some input, 1 -> (false, $"Day {day} / {year}: {Day1.answer1 input} and {Day1.answer2 input}")
        | Some input, 2 -> (false, $"Day {day} / {year}: {Day2.answer1 input} and {Day2.answer2 input}")
        | Some input, 3 -> (false, $"Day {day} / {year}: {Day3.answer1 input} and {Day3.answer2 input}")
        | Some input, 4 -> (false, $"Day {day} / {year}: {Day4.answer1 input} and {Day4.answer2 input}")
        | Some input, 5 -> (false, $"Day {day} / {year}: {Day5.answer1 input} and {Day5.answer2 input}")
        | Some input, 6 -> (false, $"Day {day} / {year}: {Day6.answer1 input} and {Day6.answer2 input}")
        | Some input, 7 -> (false, $"Day {day} / {year}: {Day7.answer1 input} and {Day7.answer2 input}")
        | Some input, 8 -> (false, $"Day {day} / {year}: {Day8.answer1 input} and {Day8.answer2 input}")
        | Some input, 9 -> (false, $"Day {day} / {year}: {Day9.answer1 input} and {Day9.answer2 input}")
        | Some input, 10 ->
            (false, $"Day {day} / {year}: {Day10.answer1 input} and:{Environment.NewLine}{Day10.answer2 input}")
        | Some input, 11 -> (false, $"Day {day} / {year}: {Day11.answer1 input} and {Day11.answer2 input}")
        | Some input, 12 -> (false, $"Day {day} / {year}: {Day12.answer1 input} and {Day12.answer2 input}")
        | _ -> (true, $"Day {day} / {year}: Sorry, but there is no input for the current day")

    displayAnswer (snd answer) (fst answer)

[<EntryPoint>]
let main args =
    if args.Length = 2 then
        let year = args[0] |> int
        let day = args[1] |> int

        display year day
    else
        seq { 1..25 }
        |> Seq.iter (fun day ->
            let year = 2022
            display year day)

    0
