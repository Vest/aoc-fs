module aoc.year2022.Day8

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Field =
    { Tree: int[][] }

    member this.isVisible (row: int) (col: int) : bool =
        let width = this.Tree[0].Length
        let height = this.Tree.Length

        match (row, col) with
        | 0, _ -> true
        | _, 0 -> true
        | r, _ when r = height - 1 -> true
        | _, c when c = width - 1 -> true
        | _, _ ->
            // up
            let up =
                [ 0 .. row - 1 ]
                |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
                |> Option.isNone

            let down =
                [ row + 1 .. height - 1 ]
                |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
                |> Option.isNone

            let left =
                [ 0 .. col - 1 ]
                |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
                |> Option.isNone

            let right =
                [ col + 1 .. width - 1 ]
                |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
                |> Option.isNone

            up || down || left || right

let internal parseLine (line: string) : int[] =
    let inline charToInt c = int c - int '0'

    line |> Seq.map charToInt |> Seq.toArray

let internal parseForest (input: string) : int[][] =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.map parseLine

let internal createField input = { Tree = parseForest input }

let answer1 (input: string) : int =
    let field = createField input
    let width = field.Tree[0].Length
    let height = field.Tree.Length

    [0..height - 1]
    |> List.allPairs [0..width - 1]
    |> List.filter (fun (row, col) -> field.isVisible row col)
    |> List.length

let answer2 (input: string) : int = 0
