open aoc.year2022
open aoc.Input

[<EntryPoint>]
let main args =
    if args.Length = 2 then
        let year = args[0] |> int
        let day = args[1] |> int

        let input = readDay year day

        match input with
        | Some input -> printfn $"Day {day} / {year}: {Day1.answer1 input} and {Day1.answer2 input}"
        | None -> eprintfn $"Day {day} / {year}: Sorry, but there is no input for the current day"
    else
        seq { 1..25 }
        |> Seq.iter (fun day ->
            let year = 2022
            let input = readDay year day

            let answer =
                match input, day with
                | Some input, 1 -> $"{Day1.answer1 input} and {Day1.answer2 input}"
                | _ -> "Sorry, but there is no input for the current day"

            match input with
            | Some input -> printfn $"Day {day} / {year}: {answer}"
            | None -> eprintfn $"Day {day} / {year}: {answer}")

    0
