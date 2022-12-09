module aoc.year2022.Day8

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type VisibleTrees =
    { up: int
      down: int
      left: int
      right: int }

type Field =
    { Tree: int[][] }

    member this.Width: int = if this.Tree.Length > 0 then this.Tree[0].Length else 0

    member this.Height: int = this.Tree.Length

    member this.isVisible (row: int) (col: int) : bool =
        match (row, col) with
        | 0, _ -> true
        | _, 0 -> true
        | r, _ when r = this.Height - 1 -> true
        | _, c when c = this.Width - 1 -> true
        | _, _ ->
            // up
            let up =
                [ 0 .. row - 1 ]
                |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
                |> Option.isNone

            let down =
                [ row + 1 .. this.Height - 1 ]
                |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
                |> Option.isNone

            let left =
                [ 0 .. col - 1 ]
                |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
                |> Option.isNone

            let right =
                [ col + 1 .. this.Width - 1 ]
                |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
                |> Option.isNone

            up || down || left || right

    member this.countTrees (row: int) (col: int) : VisibleTrees =
        let up =
            [ 0 .. row - 1 ]
            |> List.rev
            |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
            |> Option.defaultValue 0

        let down =
            [ row + 1 .. this.Height - 1 ]
            |> List.tryFind (fun r -> this.Tree[r][col] >= this.Tree[row][col])
            |> Option.defaultValue (this.Height - 1)

        let left =
            [ 0 .. col - 1 ]
            |> List.rev
            |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
            |> Option.defaultValue 0

        let right =
            [ col + 1 .. this.Width - 1 ]
            |> List.tryFind (fun c -> this.Tree[row][c] >= this.Tree[row][col])
            |> Option.defaultValue (this.Width - 1)

        { up = row - up
          down = down - row
          left = col - left
          right = right - col }

let internal parseLine (line: string) : int[] =
    let inline charToInt c = int c - int '0'

    line |> Seq.map charToInt |> Seq.toArray

let internal parseForest (input: string) : int[][] =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.map parseLine

let internal createField input = { Tree = parseForest input }

let answer1 (input: string) : int =
    let field = createField input

    [ 0 .. field.Height - 1 ]
    |> List.allPairs [ 0 .. field.Width - 1 ]
    |> List.filter (fun (row, col) -> field.isVisible row col)
    |> List.length

let answer2 (input: string) : int =
    let field = createField input

    [ 0 .. field.Height - 1 ]
    |> List.allPairs [ 0 .. field.Width - 1 ]
    |> List.map (fun (row, col) ->
        let { up = up
              down = down
              left = left
              right = right } =
            field.countTrees row col

        up * down * left * right)
    |> List.max
