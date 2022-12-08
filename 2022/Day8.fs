module aoc.year2022.Day8

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Field =
    { Tree: int[][] }

    member this.isVisible(row: int, col: int) : bool =
        match (row, col) with
        | 0, _ -> true
        | _, 0 -> true
        | r, _ when r = this.Tree.Length - 1 -> true
        | _, c when c = this.Tree[0].Length - 1 -> true
        | _, _ ->
            // up
            [ row - 1 .. 0 ]
            |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[r + 1][col])
            |> Option.isNone

let internal parseLine (line: string) : int[] =
    let inline charToInt c = int c - int '0'

    line |> Seq.map charToInt |> Seq.toArray

let internal parseForest (input: string) : int[][] =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.map parseLine

let internal createField input = { Tree = parseForest input }

let answer1 (input: string) : int = 0

let answer2 (input: string) : int = 0
