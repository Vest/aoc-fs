module aoc.year2022.Day12

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Coord = { row: int; col: int }

let internal parseLandToArray (input: string) : char[][] =
    let lines = input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    lines |> Array.map (fun line -> line.ToCharArray())

(*let internal createMapOfLand (map: char[][]) : Map<Coord, Coord list> =
    let height = map |> Array.length
    let width = map[0] |> Array.length

    ([ 0..height ], [ 0..width ])
    ||> List.allPairs
    |> List.map (fun row col -> { row = row; col = col })
    |> List.map (fun coord ->
        match coord with
        | coord when row = 0 && col = 0 -> [ () ])
    |> ignore

    [| [||] |]*)


let internal canMove (fromC: char) (toC: char) : bool =
    (Convert.ToInt32 toC - Convert.ToInt32 fromC = 1)
    || (Char.IsLower toC && fromC >= toC)
    || (toC = 'S')
    || (fromC = 'z' && toC = 'E')
    || (fromC = 'S' && toC = 'a')

let internal gatherNeighbours (map: char[][]) (coord: Coord) : (Set<Coord>) =
    let fromChar: char = map[coord.row][coord.col]
    let height = map |> Array.length
    let width = map[0] |> Array.length

    let up = (coord.row - 1, coord.col)
    let down = (coord.row + 1, coord.col)
    let left = (coord.row, coord.col - 1)
    let right = (coord.row, coord.col + 1)

    [ up; down; left; right ]
    |> List.filter (fun (r, c) -> r >= 0 && r < height && c >= 0 && c < width)
    |> List.map (fun c -> (c, map[fst c][snd c]))
    |> List.filter (fun (_, toChar) -> canMove fromChar toChar)
    |> List.map (fun ((row, col), _) -> { row = row; col = col })
    |> Set.ofList

let answer1 input = 0
let answer2 input = 0
