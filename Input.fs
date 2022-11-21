module aoc.Input

open aoc.Downloader
open aoc.InputCaching

let readDay (year: int) (day: int) : string option =
    match readInput year day with
    | Some input -> Some input
    | None ->
        match downloadInput year day with
        | Some input ->
            let input = input.Trim()
            writeInput year day input
            Some input
        | None ->
            eprintfn $"Couldn't download input for {year}/{day}. Skipping..."
            None
