module aoc.year2022.Day9

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Coord = { row: int; col: int }

let internal moveRight coord =
    { row = coord.row; col = coord.col + 1 }

let internal moveLeft coord =
    { row = coord.row; col = coord.col - 1 }

let internal moveUp coord =
    { row = coord.row - 1; col = coord.col }

let internal moveDown coord =
    { row = coord.row + 1; col = coord.col }

let internal updateKnot head knot =
    match (head, knot) with
    | (head, knot) when head = knot -> knot
    | (head, knot) when abs (head.row - knot.row) <= 1 && abs (head.col - knot.col) <= 1 -> knot
    | (head, knot) when abs (head.col - knot.col) = 1 ->
        { row = (head.row + knot.row) / 2
          col = head.col }
    | (head, knot) when abs (head.row - knot.row) = 1 ->
        { row = head.row
          col = (head.col + knot.col) / 2 }
    | (head, knot) ->
        { row = (head.row + knot.row) / 2
          col = (head.col + knot.col) / 2 }

type Movement =
    | Right of int
    | Left of int
    | Up of int
    | Down of int

let internal parseLine (input: string) : Movement =
    let steps = input.Substring 2 |> Int32.Parse

    match input with
    | i when i[0] = 'R' -> Right steps
    | i when i[0] = 'L' -> Left steps
    | i when i[0] = 'U' -> Up steps
    | i when i[0] = 'D' -> Down steps
    | _ -> failwith "Wrong input, unexpected string"

let updateRope (move: Coord -> Coord) (rope: Coord list) : Coord list =
    let newHead = move rope.Head

    rope
    |> List.skip 1
    |> List.fold
        (fun acc knot ->
            let head = acc |> List.last
            let newKnot = updateKnot head knot
            acc @ [ newKnot ])
        [ newHead ]

let findAnswer (input: string) (rope: Coord list) : int =
    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parseLine
    |> Seq.mapFold
        (fun rope movement ->
            let moves =
                match movement with
                | Right steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveRight rope) rope
                | Left steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveLeft rope) rope
                | Up steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveUp rope) rope
                | Down steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveDown rope) rope

            let newRope = moves |> List.last
            let lastMoves = moves |> List.map (fun move -> move |> List.last)
            lastMoves, newRope)
        rope
    |> fst
    |> Seq.collect id
    |> Seq.countBy (fun knot -> (knot.row, knot.col))
    |> Seq.length

let answer1 (input: string) : int =
    let rope: Coord list = [ { row = 0; col = 0 }; { row = 0; col = 0 } ]
    findAnswer input rope

let answer2 (input: string) : int =
    let rope: Coord list = Seq.init 10 (fun _ -> { row = 0; col = 0 }) |> Seq.toList
    findAnswer input rope
