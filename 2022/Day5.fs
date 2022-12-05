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
        | Crate ch1, Crate ch2 when ch1 = ch2 -> true
        | Empty, Empty -> true
        | _ -> false

    static member (!=)(c1: Crate, c2: Crate) =
        match (c1, c2) with
        | Crate ch1, Crate ch2 when ch1 = ch2 -> false
        | Empty, Empty -> false
        | _ -> true

type Move =
    { countCrates: int
      fromPile: int
      toPile: int }

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
        ||> Seq.fold (fun acc row ->
            acc
            @ [ if i >= tempCargo[row].Length then
                    Empty
                else
                    tempCargo[row][i] ])
        |> List.filter (fun c -> c != Empty)

    ([], [ 0 .. tempCargo[0].Length - 1 ])
    ||> Seq.fold (fun acc column -> acc @ [ getColumn column ])

let internal parseMovements (lines: seq<string>) =
    lines
    |> Seq.filter (fun line -> line.StartsWith("move"))
    |> Seq.map (fun line ->
        let tokens =
            line.Split([| "move "; " from "; " to " |], StringSplitOptions.RemoveEmptyEntries)

        { countCrates = tokens[0] |> int
          fromPile = tokens[1] |> int
          toPile = tokens[2] |> int })

let internal convertCargoToMap (cargo: Crate list list) : Map<int, Crate list> =
    (Map.empty, [ 1 .. cargo.Length ])
    ||> Seq.fold (fun acc pile -> acc.Add(pile, cargo |> Seq.skip (pile - 1) |> Seq.head))

let internal popFromPile (cargo: Map<int, Crate list>) (fromPile: int) : Crate * Map<int, Crate list> =
    let crate = cargo[fromPile].Head
    let rest = cargo[fromPile].Tail
    let cargoWithoutCrate = cargo.Add(fromPile, rest)
    (crate, cargoWithoutCrate)

let pushToPile (cargo: Map<int, Crate list>) (toPile: int) (crate: Crate) : Map<int, Crate list> =
    let pile = [ crate ] @ cargo[toPile]
    cargo.Add(toPile, pile)

let answer1 (input: string) : string =
    let input = input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    let cargo = parseCargo input |> convertCargoToMap
    let movements = parseMovements input

    let res: Map<int, Crate list> =
        (cargo, movements)
        ||> Seq.fold (fun acc move ->
            (acc, [ 1 .. move.countCrates ])
            ||> Seq.fold (fun res _ ->
                let crate, newCargo = popFromPile res move.fromPile
                pushToPile newCargo move.toPile crate))

    ([], [ 1 .. res.Count ])
    ||> Seq.fold (fun acc pile -> res[pile].Head :: acc)
    |> Seq.map (fun (crate: Crate) ->
        match crate with
        | Crate c -> c
        | _ -> ' ')
    |> Seq.rev
    |> String.Concat


let answer2 (input: string) : string =
    let input = input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
    let cargo = parseCargo input |> convertCargoToMap
    let movements = parseMovements input

    let res: Map<int, Crate list> =
        (cargo, movements)
        ||> Seq.fold (fun acc move ->
            let take = acc[move.fromPile] |> List.take move.countCrates
            let left = acc[move.fromPile] |> List.skip move.countCrates
            let newPile = take @ acc[move.toPile]
            let newCargo = acc.Add(move.fromPile, left)
            newCargo.Add(move.toPile, newPile))

    ([], [ 1 .. res.Count ])
    ||> Seq.fold (fun acc pile -> res[pile].Head :: acc)
    |> Seq.map (fun (crate: Crate) ->
        match crate with
        | Crate c -> c
        | _ -> ' ')
    |> Seq.rev
    |> String.Concat
