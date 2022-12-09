module aoc.year2022.Day9

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Coord = { row: int; col: int }

type Rope = { head: Coord; tail: Coord }

let internal moveRight coord =
    { row = coord.row; col = coord.col + 1 }

let internal moveLeft coord =
    { row = coord.row; col = coord.col - 1 }

let internal moveUp coord =
    { row = coord.row - 1; col = coord.col }

let internal moveDown coord =
    { row = coord.row + 1; col = coord.col }

let internal updateTail rope =
    match rope with
    | { head = head; tail = tail } when head = tail -> rope
    | { head = head; tail = tail } when abs (head.row - tail.row) <= 1 && abs (head.col - tail.col) <= 1 -> rope
    | { head = head; tail = tail } when head.row = tail.row || head.col = tail.col ->
        { head = head
          tail =
            { row = (head.row + tail.row) / 2
              col = (head.col + tail.col) / 2 } }
    | { head = head; tail = tail } when abs (head.col - tail.col) = 1 ->
        { head = head
          tail =
            { row = (head.row + tail.row) / 2
              col = head.col } }
    | { head = head; tail = tail } when abs (head.row - tail.row) = 1 ->
        { head = head
          tail =
            { row = head.row
              col = (head.col + tail.col) / 2 } }
    | _ -> failwith "couldn't happen?!"

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

let answer1 (input: string) : int =
    let rope: Rope =
        { head = { row = 0; col = 0 }
          tail = { row = 0; col = 0 } }

    input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    |> Array.toSeq
    |> Seq.map parseLine
    |> Seq.mapFold
        (fun rope movement ->
            // helper function
            let updateRope (move: Coord -> Coord) (rope: Rope) : Rope =
                let newHead = move rope.head
                let newRope = { head = newHead; tail = rope.tail }
                updateTail newRope

            let moves =
                match movement with
                | Right steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveRight rope) rope
                | Left steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveLeft rope) rope
                | Up steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveUp rope) rope
                | Down steps -> [ 1..steps ] |> List.scan (fun rope _ -> updateRope moveDown rope) rope

            moves, moves |> Seq.last)
        rope
    |> fst
    |> Seq.collect (fun res -> res |> List.toSeq)
    |> Seq.map (fun moves -> moves.tail)
    |> Seq.countBy (fun tail -> (tail.row, tail.col))
    |> Seq.length

let answer2 (input: string) : int = 0
