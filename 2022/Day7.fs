module aoc.year2022.Day7

open System
open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("aoc-test")>]
do ()

type Kind =
    | Folder
    | File of size: int

type Node =
    { Name: string
      Kind: Kind
      Children: Node list }

    member this.Size: int =
        match this.Kind with
        | Folder -> this.Children |> List.map (fun child -> child.Size) |> List.sum
        | File size -> size

let internal parseListLine (line: string) : Node =
    let (name: string, kind: Kind) =
        match line with
        | dir when dir.StartsWith "dir " -> (dir.Substring 4, Folder)
        | file ->
            let tokens = file.Split(" ", StringSplitOptions.RemoveEmptyEntries)
            (tokens[1], File(tokens[0] |> int))

    { Name = name
      Kind = kind
      Children = [] }


let answer1 input = 0
let answer2 input = 0
