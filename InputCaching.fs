module aoc.InputCaching

open System.IO
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let internal inputFile (year: int) (day: int) : string = $"input/{year}/{day, 2:D2}.txt"

let readInput (year: int) (day: int) : string option =
    let path = inputFile year day

    match File.Exists path with
    | true ->
        try
            File.ReadAllText path |> Some
        with e ->
            eprintfn $"An exception occured, while reading the file '{path}': {e.Message}\n{e.StackTrace}"
            None
    | false -> None

let writeInput (year: int) (day: int) (input: string) : unit  =
    let path = inputFile year day

    match File.Exists path with
    | true -> File.Delete path
    | false -> ()

    try
        Directory.CreateDirectory "input/2022" |> ignore
        File.WriteAllText(path, input)
    with e ->
        eprintfn $"An exception occured, while reading the file '{path}': {e.Message}\n{e.StackTrace}"
