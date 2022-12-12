module aoc.year2022.Day12

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Coord = { row: int; col: int }

let internal parseLandToArray (input: string) : char[][] =
    let lines = input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    lines |> Array.map (fun line -> line.ToCharArray())

let answer1 input = 0
let answer2 input = 0
