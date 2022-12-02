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
