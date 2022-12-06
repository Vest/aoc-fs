module aoc.year2022.Day6

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

let internal isUnique (input: string) : bool =
    (Set.empty, input) ||> Seq.fold (fun acc c -> Set.add c acc) |> Set.count = input.Length

let internal findPosition (length: int) (input: string) : int =
    let startingIndex =
        [ 1 .. input.Length ]
        |> List.find (fun i ->
            let subInput = input.Substring(i, length)
            isUnique subInput)

    startingIndex + length

let answer1 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map (findPosition 4)
    |> Seq.sum

let answer2 (input: string) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map (findPosition 14)
    |> Seq.sum
