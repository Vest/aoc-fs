module aoc.year2022.Day5

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Crate =
    | Crate of char
    | Empty

    static member Equal (c1: Crate) (c2: Crate) =
        match (c1, c2) with
        | (Crate ch1, Crate ch2) when ch1 = ch2 -> true
        | (Empty, Empty) -> true
        | _ -> false

let internal parseCrates (line: string) : Crate[] =
    line
    |> Seq.chunkBySize 4
    |> Seq.map (fun crate ->
        let crate = crate |> Seq.toList

        match crate with
        | '[' :: c :: ']' :: _ -> Crate c
        | _ -> Empty)
    |> Seq.toArray


let answer1 (input: string) : string = "test"

let answer2 (input: string) : string = "test"
