module aoc.year2022.Day5

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Crate =
    | Crate of char
    | Empty

    static member Equal(c1: Crate, c2: Crate) =
        match (c1, c2) with
        | (Crate ch1, Crate ch2) when ch1 = ch2 -> true
        | (Empty, Empty) -> true
        | _ -> false

    static member (!=)(c1: Crate, c2: Crate) =
        match (c1, c2) with
        | (Crate ch1, Crate ch2) when ch1 = ch2 -> false
        | (Empty, Empty) -> false
        | _ -> true

let internal parseCrates (line: string) : Crate[] =
    line
    |> Seq.chunkBySize 4
    |> Seq.map (fun crate ->
        let crate = crate |> Seq.toList

        match crate with
        | '[' :: c :: ']' :: _ -> Crate c
        | _ -> Empty)
    |> Seq.toArray

let internal parseCargo (lines: seq<string>) =
    let tempCargo =
        lines
        |> Seq.filter (fun line -> line.Contains('[') || line.Contains(']'))
        |> Seq.map parseCrates
        |> Seq.toArray

    let getColumn (i: int) : Crate list =
        ([], [ 0 .. tempCargo.Length - 1 ])
        ||> Seq.fold (fun acc row -> acc @ [ tempCargo[row][i] ])
        |> List.filter (fun c -> c != Empty)

    ([], [ 0 .. tempCargo.Length - 1 ])
    ||> Seq.fold (fun acc column -> acc @ [getColumn column])

let answer1 (input: string) : string = "test"

let answer2 (input: string) : string = "test"
