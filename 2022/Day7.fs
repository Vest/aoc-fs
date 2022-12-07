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
      mutable Children: Node list }

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

(*let internal buildFileSystem (commands : string seq) : int * Node list =
    let mut nodes : Node list = []
    commands
        |> *)

let internal buildFolder (commands : string list) : Node list =
    commands
    |> List.map parseListLine

let rec internal getCurrentFolder (startingPosition : int) (commands : string list) : (int * Node list) =
    let mutable children : Node list = List.empty
    let mutable toBreak = false
    let mutable i = startingPosition

    while not toBreak && i < commands.Length do
        let command = commands[i]

        if (command= "$ ls" || command = "$ cd /") then
            // nothing
            ()
        elif (command = "$ cd ..") then
            toBreak <- true
            i <- i - 1
        elif (command.StartsWith("$ cd") = true) then
            let folderName = command.Substring 5
            let child = children
                        |> List.find (fun c -> c.Name = folderName)
            let newI, nestedChildren = getCurrentFolder (i + 1) commands
            child.Children <- nestedChildren
            i <- newI
        else
            let node = parseListLine command
            children <- List.append children [node]
            ()
        i <- i + 1
    i, children

let answer1 (input : string) : int =
    let _, tree =
        input.Split([| "\r\n"; "\r"; "\n" |], StringSplitOptions.None)
        |> Array.toList
        |> getCurrentFolder 0
    let rec loop (input : Node) acc =
        match input with
        | node when node.Kind = Folder -> node :: List.fold (fun acc child -> loop child acc) acc node.Children
        | node -> node :: acc
    let res =
        tree
        |> List.fold (fun acc t -> loop t acc) []
        |> List.filter (fun node ->
            match node with
            | node when node.Kind = Folder -> node.Size <= 100000
            | _ -> false)
        |> List.map (fun node -> node.Size)
        |> List.sum

    res
let answer2 input = 0
